using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public interface IGameSound
{
	float LastUsetime { get; }

	bool IsPlaying { get; }

	string PlayedRes { get; }

	AudioSource _soundGameObject { get; set; }

	Vector3 Position { get; }

	int Priority { get; set; }

	float VolumeOffset { get; set; }

	int Subtype { get; set; }

	void CreateNew(Transform parent);

	void Stop();

	void Pause();

	void Resume();

	void ChangePos(Vector3 newPos);
}
