using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJIK;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.TPS;

public class PlayerIkSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	private List<int> _loseIkEffectAni = new List<int> { 17 };

	public PlayerIkSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.TorseAnim));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _group)
		{
			InverseKinematics ikinematics = item.thirdPersonUnityObjects.Ikinematics;
			int stateId = item.torseAnim.TorsoAnimInfo.StateId;
			bool flag = _loseIkEffectAni.Contains(stateId);
			bool flag2 = !item.hasVisiable || item.visiable.IsVisiable;
			if (ikinematics != null && flag2 && !flag)
			{
				ikinematics.PlayBack();
			}
		}
	}
}
