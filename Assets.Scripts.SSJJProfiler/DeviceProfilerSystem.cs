using System.Text;
using Assets.Sources.Framework;
using Assets.Sources.Utils.EventLogger;
using UnityEngine;

namespace Assets.Scripts.SSJJProfiler;

internal class DeviceProfilerSystem : IPlaybackSystem
{
	private StringBuilder _detalBuilder;

	private string _result;

	private int times;

	public void OnPlayback()
	{
		if (times < 1)
		{
			string deviceInfo = GetDeviceInfo();
			if (!string.IsNullOrEmpty(deviceInfo))
			{
				EventLogger.Instance.StartLogger("DeviceInfo", deviceInfo);
				EventLogger.Instance.EndLogger("SsjjDevice");
				times++;
			}
		}
	}

	private string GetDeviceInfo()
	{
		if (_detalBuilder == null)
		{
			_detalBuilder = new StringBuilder();
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
			_result = _detalBuilder.ToString();
		}
		return _result;
	}
}
