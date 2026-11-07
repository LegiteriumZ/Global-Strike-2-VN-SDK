using System.Collections;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Sound;
using SSJJAsset.AssetManager;
using SSJJBase.Logger;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public class Game2DSound : IGameSound
{
	private string _res;

	private IEnumerator _asyncEnumerator;

	private int _priority;

	private int _subtype;

	private float _volumeOffset;

	public AudioSource _soundGameObject { get; set; }

	public string PlayedRes => _res;

	public float LastUsetime { get; private set; }

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

	public Vector3 Position => Vector3.zero;

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
		GameObject gameObject = new GameObject("One shot audio 2D");
		gameObject.transform.parent = parent.transform;
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.spatialBlend = 0f;
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
	}

	public void PlayClip(AssetInfo info, float volum, AudioSource source, int delay = 0, bool loop = false, int playCount = 1)
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
		_asyncEnumerator = PlayeClip(source, info, volum, (float)delay / 1000f, loop, playCount);
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
		_asyncEnumerator = PlayeClip(source, info, source.volume, (float)delay / 1000f, source.loop, playCount);
		BaseAsyncManager.Instance.StartCoroutine(_asyncEnumerator);
	}

	private IEnumerator PlayeClip(AudioSource source, AssetInfo info, float volum, float delay, bool loop, int playCount)
	{
		_res = info.AssetName;
		if (SoundAssetCache.ClipCache.TryGetValue(info, out var clip2))
		{
			yield return Yielders.GetWaitForSeconds(delay);
			PlayLoadClip(source, clip2, info, volum, loop, playCount);
			yield return Yielders.GetWaitForSeconds(clip2.length * (float)playCount);
			_res = null;
			_asyncEnumerator = null;
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
		PlayLoadClip(source, clip2, info, volum, loop, playCount);
		yield return Yielders.GetWaitForSeconds(clip2.length * (float)playCount);
		_asyncEnumerator = null;
		_res = null;
	}

	private void PlayLoadClip(AudioSource source, AudioClip clip, AssetInfo info, float volum, bool loop, int playCount)
	{
		if (clip != null)
		{
			source.loop = false;
			source.volume = volum;
			if (!loop && playCount == 1)
			{
				source.PlayOneShot(clip);
			}
			else
			{
				source.clip = clip;
				_soundGameObject.Play();
			}
			source.loop = playCount > 1;
			if (source == _soundGameObject)
			{
				LastUsetime = Time.realtimeSinceStartup;
				_res = info.AssetName;
			}
		}
		else
		{
			this.LogErrorFormat("clip not found :{0}", info);
		}
	}
}
