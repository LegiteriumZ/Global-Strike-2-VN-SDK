using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils.Sound;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Sound;

[RequireComponent(typeof(AudioSource))]
internal class FootstepControl : MonoBehaviour
{
	private AudioSource _audioSource;

	private bool _isPlay;

	private float _nextPlayTime;

	private float _endTime;

	public AudioClip Clip;

	public int Intval;

	public int MaxDist;

	public float Vol;

	private static AnimationCurve _curve;

	public bool IsPlaying => _isPlay;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		_audioSource.dopplerLevel = 0.01f;
		_audioSource.rolloffMode = AudioRolloffMode.Logarithmic;
		_audioSource.spatialBlend = 1f;
		_audioSource.playOnAwake = false;
		_audioSource.loop = false;
		_endTime = 0f;
		if (_curve == null)
		{
			AudioRolloffTable.Row row = AudioRolloffLoader.Instance.Table.Find_Id(1);
			_curve = SoundUtility.GetCurve(row.Min, row.Max, row.A, row.B);
		}
	}

	private void Update()
	{
		if (_isPlay && _nextPlayTime < Time.time)
		{
			if (_audioSource.isPlaying)
			{
				Stop();
			}
			_audioSource.clip = Clip;
			_audioSource.volume = Vol * GameSoundManager.Config.StepVolume;
			_audioSource.maxDistance = _curve[_curve.length - 1].time;
			_audioSource.minDistance = _curve[0].time;
			_audioSource.rolloffMode = AudioRolloffMode.Custom;
			_audioSource.SetCustomCurve(AudioSourceCurveType.CustomRolloff, _curve);
			_audioSource.loop = false;
			_audioSource.Play();
			_nextPlayTime = Time.time + Clip.length + 1f * (float)Intval / 1000f;
			_endTime = Time.time + Clip.length;
			_isPlay = false;
		}
	}

	public void Stop()
	{
		_audioSource.Stop();
		_isPlay = false;
	}

	public bool canChangeClip()
	{
		return _endTime < Time.time;
	}

	public void Play(AudioClip clip, float vol, int maxDist, int intval)
	{
		intval -= 40;
		if (_endTime < Time.time)
		{
			_isPlay = true;
			Vol = vol;
			MaxDist = maxDist;
			Clip = clip;
			Intval = intval;
		}
	}
}
