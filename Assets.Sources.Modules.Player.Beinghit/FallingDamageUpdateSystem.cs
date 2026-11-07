using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using data;
using physics;

namespace Assets.Sources.Modules.Player.Beinghit;

public class FallingDamageUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private const float PlayerMaxSafeFallSpeed = 1473.2f;

	private static AssetInfo _fallingDamageSound = new AssetInfo("sound/player", "Assets/Res/Assets/sound/player/pl_falldamage.mp3");

	private bool _playSound;

	public FallingDamageUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		IPyEngine pyEngine = _battleRoomContext.pyEngine.PyEngine;
		if (pyEngine == null)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (!((SceneMoveData)pyEngine.GetWorld().GetSceneMoveData()).jumpDamage)
		{
			return;
		}
		if (!myPlayerEntity.IsDead() && 0f - myPlayerEntity.move.Velocity.z > 1473.2f)
		{
			float z = myPlayerEntity.move.Velocity.z;
			if (myPlayerEntity.move.PyPlayerMove.GetJumpHeight(myPlayerEntity.move.Velocity.z) <= z)
			{
				float num = 0f - myPlayerEntity.move.Velocity.z - 1473.2f;
				switch (myPlayerEntity.move.getPml().waterlevel)
				{
				case 1:
					num *= 0.5f;
					break;
				case 2:
					num *= 0.25f;
					break;
				case 3:
					num *= 0f;
					break;
				}
				if ((int)num > 0)
				{
					_playSound = true;
					return;
				}
			}
		}
		if (_playSound)
		{
			_playSound = false;
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Other, myPlayerEntity.isMyPlayer, _fallingDamageSound, GameSoundManager.Config.StepVolume);
		}
	}
}
