using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public interface IPlayerScoreCell
{
	GameObject Container { get; set; }

	int Index { get; set; }

	IListNotify Listener { get; set; }

	void Initialize();

	void SetPlayerContext(PlayerContext context);

	void OnPlayback();

	bool HasSubscribed();
}
