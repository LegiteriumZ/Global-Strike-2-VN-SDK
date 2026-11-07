using System.Collections;
using Assets.Sources.Components.SceneObject;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Sound;
using SSJJAsset.AssetManager;
using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public class SoundPlayer : MonoBehaviour, ISoundPlayer
{
	private bool _stop;

	public AssetInfo AssetInfo { get; private set; }

	private void Awake()
	{
	}

	public void PlaySound(AssetInfo info, float volumeScale, int maxDist, bool loop)
	{
		AssetInfo = info;
		_stop = false;
		StopCoroutine("PlaySoundAsync");
		StartCoroutine(PlaySoundAsync(info, volumeScale, maxDist, loop));
	}

	public void StopSound()
	{
		_stop = true;
		Stop();
	}

	private IEnumerator PlaySoundAsync(AssetInfo info, float volumeScale, int maxDist, bool loop)
	{
		while (SoundAssetCache.LoadingList.Contains(info))
		{
			yield return null;
		}
		AudioClip value = null;
		SoundAssetCache.ClipCache.TryGetValue(info, out value);
		if (value == null)
		{
			SoundAssetCache.LoadingList.Add(info);
			AssetAsyncLoader<AudioClip> loader = new AssetAsyncLoader<AudioClip>();
			yield return loader.LoadAsync(info);
			SoundAssetCache.LoadingList.Remove(info);
			value = loader.Instantiate();
			if (value == null)
			{
				yield break;
			}
			SoundAssetCache.ClipCache.Add(info, value);
		}
		PlayClipAtPoint(value, volumeScale, maxDist, loop);
	}

	private void Stop()
	{
		AudioSource component = base.gameObject.GetComponent<AudioSource>();
		if (component != null)
		{
			Object.DestroyImmediate(component);
		}
	}

	private void PlayClipAtPoint(AudioClip clip, float volumeScale, int maxDist, bool loop)
	{
		Stop();
		if (!_stop)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.volume = volumeScale;
			audioSource.dopplerLevel = 0.01f;
			audioSource.maxDistance = maxDist;
			audioSource.minDistance = 1f;
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.spatialBlend = 1f;
			audioSource.loop = loop;
			audioSource.Play();
		}
	}
}
