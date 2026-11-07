using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Constant;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils;

public class CaptureCameraManager : MonoBehaviourSingleton<CaptureCameraManager>
{
	public RenderTexture Rt;

	private bool _isEffect;

	private GameObject _cube;

	private Material _cubeMat;

	private Vector3 _originCameraPos;

	private Quaternion _originCameraQua;

	private float _originFov;

	private int _cubeCameraDistance = 80;

	private int _playerCubeDistance = 2200;

	private float _fov = 12.5f;

	private readonly Dictionary<GameObject, Vector3> _thirds = new Dictionary<GameObject, Vector3>();

	private Color _randomColor;

	private Texture2D _captureTexture;

	private bool _hasSend;

	private bool _isDead;

	private float _deadStartTime;

	private int _width;

	private int _height;

	private int _captureCount;

	public void SetEffect()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (RuleUtilty.IsGroupModel(raceType) || RuleUtilty.IsExplode(raceType) || SpecailDebug.Instance.KillScreenSave)
		{
			_isEffect = true;
		}
	}

	private void Start()
	{
		_cube = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("CubeCapture"));
		_cube.transform.SetParent(base.transform);
		_cube.gameObject.SetObjectActive(isactive: false);
		_cubeMat = _cube.GetComponent<MeshRenderer>().material;
		Rt = UnityEngine.Object.Instantiate(Resources.Load<RenderTexture>("Capture"));
		_width = Rt.width;
		_height = Rt.height;
	}

	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.F8) && SpecailDebug.Instance.KillScreenSave)
		{
			StartCoroutine(CaptureCamera());
		}
		if (CheckCaputure())
		{
			StartCoroutine(CaptureCamera());
		}
	}

	private bool CheckCaputure()
	{
		if (!_isEffect)
		{
			return false;
		}
		if (_hasSend)
		{
			return false;
		}
		if (_captureCount > 10)
		{
			return false;
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null && myPlayerEntity.hasBasicInfo && myPlayerEntity.basicInfo.IsDead != _isDead)
		{
			_isDead = myPlayerEntity.basicInfo.IsDead;
			if (_isDead && Time.time - _deadStartTime > 10f)
			{
				_deadStartTime = Time.time;
				return true;
			}
		}
		return false;
	}

	private IEnumerator CaptureCamera()
	{
		Camera main = Camera.main;
		if (main == null)
		{
			yield break;
		}
		SetEnviorment(main);
		main.targetTexture = Rt;
		main.Render();
		_captureCount++;
		main.targetTexture = null;
		ResetEnviorment(main);
		yield return Yielders.GetWaitForSeconds(0.2f);
		try
		{
			RenderTexture.active = Rt;
			_captureTexture = new Texture2D(_width, _height, TextureFormat.RGB24, mipChain: false);
			_captureTexture.ReadPixels(new Rect(0f, 0f, _width, _height), 0, 0);
			_captureTexture.Apply();
			RenderTexture.active = null;
			if (CheckIsPerspective())
			{
				MonoBehaviourSingleton<NetEaseCloudManager>.Instance.Send(_captureTexture.EncodeToPNG(), 14);
				_hasSend = true;
				this.Info("IsPerspective");
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("CaptureError > {0}", ex.ToString());
		}
	}

	private void SetEnviorment(Camera cam)
	{
		_originCameraPos = cam.transform.position;
		_originCameraQua = cam.transform.rotation;
		_originFov = cam.fieldOfView;
		cam.transform.position = new Vector3(-30000f, -50000f, -30000f);
		cam.transform.rotation = Quaternion.identity;
		cam.fieldOfView = _fov;
		_cube.gameObject.SetObjectActive(isactive: true);
		_cube.transform.rotation = Quaternion.identity;
		_cube.transform.position = cam.transform.position + cam.transform.forward * _cubeCameraDistance + cam.transform.up * 300f;
		_randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), 1f);
		_cubeMat.color = _randomColor;
		_thirds.Clear();
		GameObject gameObject = GameObject.Find("thirdPersonResources");
		if (gameObject == null)
		{
			return;
		}
		for (int i = 0; i < gameObject.transform.childCount && i < 5; i++)
		{
			_thirds.Add(gameObject.transform.GetChild(i).gameObject, gameObject.transform.GetChild(i).position);
		}
		foreach (KeyValuePair<GameObject, Vector3> third in _thirds)
		{
			third.Key.transform.position = cam.transform.position + cam.transform.forward * (_cubeCameraDistance + _playerCubeDistance) - cam.transform.up * 65f;
		}
	}

	private void ResetEnviorment(Camera cam)
	{
		_cube.gameObject.SetObjectActive(isactive: false);
		foreach (KeyValuePair<GameObject, Vector3> third in _thirds)
		{
			third.Key.transform.position = third.Value;
		}
		cam.transform.position = _originCameraPos;
		cam.transform.rotation = _originCameraQua;
		cam.fieldOfView = _originFov;
	}

	private bool CheckIsPerspective()
	{
		if (_hasSend)
		{
			return false;
		}
		if (_captureTexture == null)
		{
			return false;
		}
		bool result = false;
		int num = 0;
		List<Color> list = new List<Color>
		{
			_captureTexture.GetPixel(1, 1),
			_captureTexture.GetPixel(_captureTexture.width - 2, 1),
			_captureTexture.GetPixel(_captureTexture.width - 2, _captureTexture.height - 2),
			_captureTexture.GetPixel(1, _captureTexture.height - 2)
		};
		_randomColor = list[0];
		for (int i = 1; i < list.Count; i++)
		{
			if (!ColorEqual(list[i], _randomColor))
			{
				result = true;
				break;
			}
		}
		for (int j = (int)((float)_captureTexture.width * 0.25f); j < (int)((float)_captureTexture.width * 0.75f); j++)
		{
			for (int k = (int)((float)_captureTexture.height * 0.25f); k < (int)((float)_captureTexture.height * 0.75f); k++)
			{
				Color pixel = _captureTexture.GetPixel(j, k);
				if (!ColorEqual(pixel, _randomColor))
				{
					num++;
					if (num > 20)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	private bool ColorEqual(Color color1, Color color2)
	{
		if (Mathf.Abs(color1.b - color2.b) < 0.1f && Mathf.Abs(color1.g - color2.g) < 0.1f && Mathf.Abs(color1.r - color2.r) < 0.1f)
		{
			return true;
		}
		return false;
	}
}
