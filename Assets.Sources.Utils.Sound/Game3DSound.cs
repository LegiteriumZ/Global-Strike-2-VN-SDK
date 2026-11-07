using System.Collections;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Sound;
using SSJJAsset.AssetManager;
using SSJJBase.Logger;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public class Game3DSound : IGameSound
{
	private string _res;

	private IEnumerator _asyncEnumerator;

	private int _priority;

	private int _subtype;

	private float _volumeOffset;

	public AudioSource _soundGameObject { get; set; }

	public float LastUsetime { get; private set; }

	public string PlayedRes => _res;

	public bool IsPlaying
	{
		get
		{
			if (_soundGameObject == null)
			{
				return false;
			}
			if (_asyncEnumerator != null)
			{
				return true;
			}
			return _soundGameObject.isPlaying;
		}
	}

	public Vector3 Position => _soundGameObject.transform.position;

	public int Priority
	{
		get
		{
			return _priority;
		}
		set
		{
			_priority = value;
		}
	}

	public float VolumeOffset
	{
		get
		{
			return _volumeOffset;
		}
		set
		{
			_volumeOffset = value;
		}
	}

	public int Subtype
	{
		get
		{
			return _subtype;
		}
		set
		{
			_subtype = value;
		}
	}

	public void CreateNew(Transform parent)
	{
		GameObject gameObject = new GameObject("One shot audio Ponit");
		gameObject.transform.parent = parent.transform;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.dopplerLevel = 0f;
		audioSource.minDistance = 1f;
		audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
		audioSource.spatialBlend = 1f;
		audioSource.loop = false;
		_soundGameObject = audioSource;
	}

	public void Stop()
	{
		if (_soundGameObject != null)
		{
			_soundGameObject.Stop();
			if (_asyncEnumerator != null)
			{
				BaseAsyncManager.Instance.StopCoRoutine(_asyncEnumerator);
				_asyncEnumerator = null;
			}
			_res = null;
		}
	}

	public void Pause()
	{
		if (_soundGameObject != null)
		{
			_soundGameObject.Pause();
		}
	}

	public void Resume()
	{
		if (_soundGameObject != null)
		{
			_soundGameObject.UnPause();
		}
	}

	public void ChangePos(Vector3 newPos)
	{
		_soundGameObject.transform.position = newPos;
	}

	public void PlayClip(AssetInfo info, Vector3 position, float volumeScale, int maxDist, AudioSource source, int delay, bool loop, int playCount, float moveTime)
	{
		if (_asyncEnumerator != null)
		{
			BaseAsyncManager.Instance.StopCoroutine(_asyncEnumerator);
			_asyncEnumerator = null;
		}
		if (source == null)
		{
			source = _soundGameObject;
		}
		_asyncEnumerator = PlayeClip(info, (float)delay / 1000f, Play(source, info, position, volumeScale, maxDist, loop, playCount, moveTime));
		BaseAsyncManager.Instance.StartCoroutine(_asyncEnumerator);
	}

	public void PlayClip(AssetInfo info, Vector3 position, float volumeScale, AnimationCurve curve, AudioSource source, int delay, bool loop, int playCount)
	{
		if (_asyncEnumerator != null)
		{
			BaseAsyncManager.Instance.StopCoroutine(_asyncEnumerator);
			_asyncEnumerator = null;
		}
		if (source == null)
		{
			source = _soundGameObject;
		}
		_asyncEnumerator = PlayeClip(info, (float)delay / 1000f, Play(source, info, position, volumeScale, curve, loop, playCount));
		BaseAsyncManager.Instance.StartCoroutine(_asyncEnumerator);
	}

	public void PlaySound(AssetInfo info, AudioSource source, int delay = 0, int playCount = 1)
	{
		if (_asyncEnumerator != null)
		{
			BaseAsyncManager.Instance.StopCoroutine(_asyncEnumerator);
			_asyncEnumerator = null;
		}
		if (source == null)
		{
			source = _soundGameObject;
		}
		_asyncEnumerator = PlayeClip(info, (float)delay / 1000f, Play(source, info, source.transform.position, source.volume, source.maxDistance, source.loop, playCount));
		BaseAsyncManager.Instance.StartCoroutine(_asyncEnumerator);
	}

	private IEnumerator PlayeClip(AssetInfo info, float delay, IEnumerator nexttask)
	{
		_res = info.AssetName;
		if (SoundAssetCache.ClipCache.TryGetValue(info, out var clip2))
		{
			if (delay != 0f)
			{
				yield return Yielders.GetWaitForSeconds(delay);
			}
			yield return nexttask;
			yield break;
		}
		float currenttime = Time.realtimeSinceStartup;
		while (SoundAssetCache.LoadingList.Contains(info))
		{
			yield return null;
		}
		SoundAssetCache.LoadingList.Add(info);
		AssetAsyncLoader<AudioClip> loader = new AssetAsyncLoader<AudioClip>();
		yield return loader.LoadAsync(info);
		SoundAssetCache.LoadingList.Remove(info);
		clip2 = loader.Instantiate();
		if (clip2 == null)
		{
			_asyncEnumerator = null;
			yield break;
		}
		float num = delay - (Time.realtimeSinceStartup - currenttime);
		if (num > 0f)
		{
			yield return Yielders.GetWaitForSeconds(num);
		}
		SoundAssetCache.ClipCache[info] = clip2;
		yield return nexttask;
	}

	private IEnumerator Play(AudioSource source, AssetInfo info, Vector3 position, float volumeScale, float maxDist, bool loop, int playCount, float moveTime = 0f)
	{
		if (SoundAssetCache.ClipCache.TryGetValue(info, out var value))
		{
			_soundGameObject.gameObject.transform.position = position;
			_soundGameObject.volume = volumeScale * (1f + _volumeOffset);
			_soundGameObject.maxDistance = maxDist;
			_soundGameObject.minDistance = maxDist / 10f;
			if (!loop && playCount == 1)
			{
				source.PlayOneShot(value);
			}
			else
			{
				source.clip = value;
				_soundGameObject.Play();
			}
			source.loop = playCount > 1;
			if (source == _soundGameObject)
			{
				LastUsetime = Time.realtimeSinceStartup;
			}
			yield return Yielders.GetWaitForSeconds(value.length * (float)playCount - moveTime);
			_res = null;
		}
		else
		{
			this.LogErrorFormat("clip not found :{0}", info);
		}
		_asyncEnumerator = null;
	}

	private IEnumerator Play(AudioSource source, AssetInfo info, Vector3 position, float volumeScale, AnimationCurve curve, bool loop, int playCount)
	{
		if (SoundAssetCache.ClipCache.TryGetValue(info, out var value))
		{
			source.gameObject.transform.position = position;
			source.volume = volumeScale * (1f + _volumeOffset);
			source.minDistance = curve[0].time;
			source.maxDistance = curve[curve.length - 1].time;
			source.rolloffMode = AudioRolloffMode.Custom;
			source.SetCustomCurve(AudioSourceCurveType.CustomRolloff, curve);
			if (!loop && playCount == 1)
			{
				source.PlayOneShot(value);
			}
			else
			{
				source.clip = value;
				_soundGameObject.Play();
			}
			source.loop = playCount > 1;
			if (source == _soundGameObject)
			{
				LastUsetime = Time.realtimeSinceStartup;
			}
			yield return Yielders.GetWaitForSeconds(value.length * (float)playCount);
			_res = null;
		}
		else
		{
			this.LogErrorFormat("clip not found :{0}", info);
		}
		_asyncEnumerator = null;
	}
}
