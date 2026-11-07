using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;
using UnityEngine.UI;

namespace VisualProfiler;

public class VisualProfiler : MonoBehaviour
{
	public static class PerformanceInfo
	{
		public struct PerformanceInformation
		{
			public int Size;

			public IntPtr CommitTotal;

			public IntPtr CommitLimit;

			public IntPtr CommitPeak;

			public IntPtr PhysicalTotal;

			public IntPtr PhysicalAvailable;

			public IntPtr SystemCache;

			public IntPtr KernelTotal;

			public IntPtr KernelPaged;

			public IntPtr KernelNonPaged;

			public IntPtr PageSize;

			public int HandlesCount;

			public int ProcessCount;

			public int ThreadCount;
		}

		[DllImport("psapi.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPerformanceInfo(out PerformanceInformation PerformanceInformation, [In] int Size);

		public static long GetPhysicalAvailableMemoryInMiB()
		{
			PerformanceInformation PerformanceInformation = default(PerformanceInformation);
			if (GetPerformanceInfo(out PerformanceInformation, Marshal.SizeOf(PerformanceInformation)))
			{
				return PerformanceInformation.PhysicalAvailable.ToInt64() * PerformanceInformation.PageSize.ToInt64() / 1048576;
			}
			return -1L;
		}

		public static long GetTotalMemoryInMiB()
		{
			PerformanceInformation PerformanceInformation = default(PerformanceInformation);
			if (GetPerformanceInfo(out PerformanceInformation, Marshal.SizeOf(PerformanceInformation)))
			{
				return PerformanceInformation.PhysicalTotal.ToInt64() * PerformanceInformation.PageSize.ToInt64() / 1048576;
			}
			return -1L;
		}
	}

	private static readonly int maxStringLength = 32;

	private static readonly int frameRange = 30;

	private static readonly string usedMemoryString = "Used: ";

	private static readonly string peakMemoryString = "Peak: ";

	private static readonly string limitMemoryString = "Limit: ";

	[Header("UI Settings")]
	public GameObject UiPrefab;

	[SerializeField]
	private Vector2 DetailSize = new Vector2(300f, 300f);

	[Header("Profiler Settings")]
	[SerializeField]
	[Tooltip("Is the profiler currently visible.")]
	private bool isVisible = true;

	[SerializeField]
	private int TargetFrameRate = 120;

	[Header("Window Settings")]
	[SerializeField]
	[Range(0.5f, 5f)]
	[Tooltip("Use to scale the window size up or down, can simulate a zooming effect.")]
	private float windowScale = 1f;

	[SerializeField]
	[Range(0f, 3f)]
	[Tooltip("How many decimal places to display on numeric strings.")]
	private int displayedDecimalDigits = 1;

	[SerializeField]
	[Tooltip("The color to display on frames which meet or exceed the target frame rate.")]
	private Color targetFrameRateColor = new Color(0.49609375f, 93f / 128f, 0f, 1f);

	[SerializeField]
	[Tooltip("The color to display on frames which fall below the target frame rate.")]
	private Color missedFrameRateColor = new Color(121f / 128f, 0.3125f, 17f / 128f, 1f);

	[SerializeField]
	[Tooltip("The color to display for current memory usage values.")]
	private Color memoryUsedColor = new Color(0f, 41f / 64f, 0.93359375f, 1f);

	[SerializeField]
	[Tooltip("The color to display for peak (aka max) memory usage values.")]
	private Color memoryPeakColor = new Color(0.99609375f, 0.72265625f, 0f, 1f);

	[SerializeField]
	[Tooltip("The color to display for the platforms memory usage limit.")]
	private Color memoryLimitColor = new Color(75f / 128f, 75f / 128f, 75f / 128f, 1f);

	private char[] stringBuffer = new char[maxStringLength];

	private VisualProfilerRender _uiRender = new VisualProfilerRender();

	private int _lastRecordFrame;

	private long _totalComputerMb;

	private long _canusedComputerMb;

	private bool _showDetail;

	private ulong _memoryUsage;

	private ulong _peakMemoryUsage;

	private StringBuilder _detalBuilder = new StringBuilder();

	public bool IsVisible
	{
		get
		{
			return isVisible;
		}
		set
		{
			isVisible = value;
		}
	}

	public float WindowScale
	{
		get
		{
			return windowScale;
		}
		set
		{
			windowScale = Mathf.Clamp(value, 0.5f, 5f);
		}
	}

	private float AppFrameRate
	{
		get
		{
			float num = 0f;
			if ((int)num != 0)
			{
				return num;
			}
			return TargetFrameRate;
		}
	}

	private static ulong AppMemoryUsage => (ulong)Profiler.GetTotalAllocatedMemoryLong();

	private ulong AppMemoryUsageLimit
	{
		get
		{
			long num = 0L;
			num = SystemInfo.systemMemorySize;
			num = Math.Min(num, _canusedComputerMb);
			return Math.Max(0uL, ConvertMegabytesToBytes(num) + AppMemoryUsage);
		}
	}

	private void BuildlUi()
	{
		GameObject gameObject = new GameObject("Canvas");
		gameObject.layer = LayerMask.NameToLayer("UI");
		Canvas canvas = gameObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.sortingOrder = 9999;
		gameObject.AddComponent<CanvasScaler>();
		gameObject.AddComponent<GraphicRaycaster>();
		gameObject.transform.parent = base.transform;
		if ((bool)UiPrefab)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(UiPrefab);
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localRotation = Quaternion.identity;
			gameObject2.transform.localScale = Vector3.one;
			RectTransform rectTransform = gameObject2.transform as RectTransform;
			if ((bool)rectTransform)
			{
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
				rectTransform.anchorMax = Vector2.one;
				rectTransform.anchorMin = Vector2.zero;
				rectTransform.sizeDelta = Vector2.zero;
			}
			_uiRender.BuildReference(gameObject2);
			_uiRender.SetProgressUiCount(Mathf.Max(0, frameRange - 1), targetFrameRateColor);
			_uiRender.UpdateDetailSize(DetailSize);
		}
		else
		{
			Debug.LogError("Missing Ui Prefab");
		}
		CreateEventSystem(null);
	}

	private static void CreateEventSystem(GameObject parent)
	{
		if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
		{
			GameObject obj = new GameObject("EventSystem");
			SetParentAndAlign(obj, parent);
			obj.AddComponent<EventSystem>();
			obj.AddComponent<StandaloneInputModule>();
		}
	}

	public static void SetParentAndAlign(GameObject child, GameObject parent)
	{
		if (!(parent == null))
		{
			child.transform.SetParent(parent.transform, worldPositionStays: false);
			RectTransform rectTransform = child.transform as RectTransform;
			if ((bool)rectTransform)
			{
				rectTransform.anchoredPosition = Vector2.zero;
				Vector3 localPosition = rectTransform.localPosition;
				localPosition.z = 0f;
				rectTransform.localPosition = localPosition;
			}
			else
			{
				child.transform.localPosition = Vector3.zero;
			}
			child.transform.localRotation = Quaternion.identity;
			child.transform.localScale = Vector3.one;
			SetLayerRecursively(child, parent.layer);
		}
	}

	private static void SetLayerRecursively(GameObject go, int layer)
	{
		go.layer = layer;
		Transform transform = go.transform;
		for (int i = 0; i < transform.childCount; i++)
		{
			SetLayerRecursively(transform.GetChild(i).gameObject, layer);
		}
	}

	private void UpdateDetail()
	{
		_uiRender.ShowDetailInfo(_showDetail);
		if (_showDetail)
		{
			UpdateDetailInfo();
			_uiRender.GetDetailText().text = _detalBuilder.ToString();
			_detalBuilder.Length = 0;
		}
	}

	private void UpdateDetailInfo()
	{
		_detalBuilder.AppendLine("--------------Device");
		_detalBuilder.AppendLine($"Dev Name:{SystemInfo.deviceName}");
		_detalBuilder.AppendLine($"Dev Model:{SystemInfo.deviceModel}");
		_detalBuilder.AppendLine($"Dev Type:{SystemInfo.deviceType}");
		_detalBuilder.AppendLine("--------------Grphics");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceID:{SystemInfo.graphicsDeviceID}");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceName:{SystemInfo.graphicsDeviceName}");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceType:{SystemInfo.graphicsDeviceType}");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceVendor:{SystemInfo.graphicsDeviceVendor}");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceVendorID:{SystemInfo.graphicsDeviceVendorID}");
		_detalBuilder.AppendLine($"Dev GraphicsDeviceVersion:{SystemInfo.graphicsDeviceVersion}");
		_detalBuilder.AppendLine($"Dev GraphicsMemorySize:{SystemInfo.graphicsMemorySize:N2}MB");
		_detalBuilder.AppendLine($"Dev GraphicsMultiThreaded:{SystemInfo.graphicsMultiThreaded}");
		_detalBuilder.AppendLine($"Dev GraphicsShaderLevel:{SystemInfo.graphicsShaderLevel}");
		_detalBuilder.AppendLine($"Dev SupportInstaning:{SystemInfo.supportsInstancing}");
		_detalBuilder.AppendLine("--------------System");
		_detalBuilder.AppendLine($"Dev OperatingSystem:{SystemInfo.operatingSystem}");
		_detalBuilder.AppendLine($"Dev OperatingSystemFamily:{SystemInfo.operatingSystemFamily}");
		_detalBuilder.AppendLine($"Dev SystemMemorySize:{SystemInfo.systemMemorySize:N2}MB");
		_detalBuilder.AppendLine($"Dev ComputerAvailableMemorySize:{_canusedComputerMb:N2}MB");
	}

	private static string MemoryUsageToString(char[] stringBuffer, int displayedDecimalDigits, string prefixString, ulong memoryUsage, Color col)
	{
		float num = ConvertBytesToMegabytes(memoryUsage);
		int num2 = (int)num;
		int num3 = (int)((num - (float)num2) * Mathf.Pow(10f, displayedDecimalDigits));
		int bufferIndex = 0;
		for (int i = 0; i < prefixString.Length; i++)
		{
			stringBuffer[bufferIndex++] = prefixString[i];
		}
		bufferIndex = MemoryItoA(num2, stringBuffer, bufferIndex);
		stringBuffer[bufferIndex++] = '.';
		if (num3 != 0)
		{
			bufferIndex = MemoryItoA(num3, stringBuffer, bufferIndex);
		}
		else
		{
			for (int j = 0; j < displayedDecimalDigits; j++)
			{
				stringBuffer[bufferIndex++] = '0';
			}
		}
		stringBuffer[bufferIndex++] = 'M';
		stringBuffer[bufferIndex++] = 'B';
		return string.Format("  <color={1}>{0}</color>", new string(stringBuffer, 0, bufferIndex), ColorUtility.ToHtmlStringRGBA(col));
	}

	private static int MemoryItoA(int value, char[] stringBuffer, int bufferIndex)
	{
		int num = bufferIndex;
		while (value != 0)
		{
			stringBuffer[bufferIndex++] = (char)((ushort)(value % 10) + 48);
			value /= 10;
		}
		int num2 = bufferIndex - 1;
		while (num < num2)
		{
			char c = stringBuffer[num];
			stringBuffer[num] = stringBuffer[num2];
			stringBuffer[num2] = c;
			num++;
			num2--;
		}
		return bufferIndex;
	}

	private static bool WillDisplayedMemoryUsageDiffer(ulong oldUsage, ulong newUsage, int displayedDecimalDigits)
	{
		float num = ConvertBytesToMegabytes(oldUsage);
		float num2 = ConvertBytesToMegabytes(newUsage);
		float num3 = Mathf.Pow(10f, displayedDecimalDigits);
		return (int)(num * num3) != (int)(num2 * num3);
	}

	private static ulong ConvertMegabytesToBytes(long megabytes)
	{
		return (ulong)(megabytes * 1024 * 1024);
	}

	private static float ConvertBytesToMegabytes(ulong bytes)
	{
		return (float)bytes / 1024f / 1024f;
	}
}
