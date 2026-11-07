using Assets.Sources.Components.Common;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Modules.Player.SmallMap;

public class PlayerDrawMapImageSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private SnapshotContext _snapContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private IGameRule _gameRule;

	private TimeComponent _time;

	private static AssetInfo _botLowAssetInfo = new AssetInfo("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/rader/botlow.png");

	private static AssetInfo _botHeightAssetInfo = new AssetInfo("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/rader/botheight.png");

	private static AssetInfo _botAssetInfo = new AssetInfo("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/rader/bot.png");

	private static AssetInfo _playerctsosAsset = new AssetInfo("ui/deathmatchmodel", "Assets/Res/Assets/ui/GameGUIRes/deathMatchModel/rader/playerctsos.png");

	private static AssetInfo _playertsosAsset = new AssetInfo("ui/deathmatchmodel", "Assets/Res/Assets/ui/GameGUIRes/deathMatchModel/rader/playertsos.png");

	private static AssetInfo _playersosAsset = new AssetInfo("ui/deathmatchmodel", "Assets/Res/Assets/ui/GameGUIRes/deathMatchModel/rader/playersos.png");

	private static AssetInfo _ctplayerdeadAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/ctplayerdead.png");

	private static AssetInfo _tplayerdeadAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/tplayerdead.png");

	private static AssetInfo _ctplayerlowAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/ctplayerlow.png");

	private static AssetInfo _tplayerlowAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/tplayerlow.png");

	private static AssetInfo _ctplayerheightAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/ctplayerheight.png");

	private static AssetInfo _tplayerheightAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/tplayerheight.png");

	private static AssetInfo _ctplayerAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/ctplayer.png");

	private static AssetInfo _tplayerAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/tplayer.png");

	private static AssetInfo _deadAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/dead.png");

	private static AssetInfo _playerAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/player.png");

	private static AssetInfo _playerlowAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/playerlow.png");

	private static AssetInfo _playerheightAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/map/playerheight.png");

	private static AssetInfo _c4playerlowAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/c4playerlow.png");

	private static AssetInfo _c4playerheightAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/c4playerheight.png");

	private static AssetInfo _c4playerAsset = new AssetInfo("ui/blastmodel", "Assets/Res/Assets/ui/GameGUIRes/blastModel/map/c4player.png");

	public PlayerDrawMapImageSystem(Contexts contexts)
	{
		_snapContext = contexts.snapshot;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_gameRule = _gameRuleContext.currentRule.Rule;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner)
		{
			return;
		}
		int num = _playerContext.cameraOwnerEntity.basicInfo.Current.Team;
		bool flag = _battleRoomContext.roomData.Data.RaceType == 25;
		if (flag)
		{
			ISnapshot nowSnapshot = _snapContext.snapshots.NowSnapshot;
			bool flag2 = false;
			if (nowSnapshot.ControlId != 0 && (nowSnapshot.CameraEntityDataDict.ContainsKey(nowSnapshot.ControlId) || nowSnapshot.SceneItemEntityDataDict.ContainsKey(nowSnapshot.ControlId)))
			{
				flag2 = true;
			}
			num = ((!flag2) ? 1 : 2);
		}
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasBasicInfo)
			{
				continue;
			}
			if (_gameRule.IsPve() && !_gameRule.IsRpgPvp() && item.basicInfo.Current.Team != num)
			{
				if (item.basicInfo.Current.IsBot && item.GetCareer() != PlayerCareerConstantUtility.Rpg10500002)
				{
					DrawBotMapImage(item);
				}
			}
			else if (item.basicInfo.Current.Team != num && item.HasStatus(PlayerInfoStatusConstant.SMALLMAP_SEE_TARGETPLAYER.ID))
			{
				DrawBotMapImage(item);
			}
			else if (flag)
			{
				DrawPeekabooMapImage(item, num);
			}
			else
			{
				DrawMapImage(item, num);
			}
		}
	}

	private long GetHP(PlayerEntity entity)
	{
		for (int i = 0; i < entity.basicInfo.Current.LifeBarSeq.Count; i++)
		{
			if (entity.basicInfo.Current.LifeBarSeq[i] == 3 && entity.basicInfo.Current.Zhuangjia > 0)
			{
				return entity.basicInfo.Current.Zhuangjia;
			}
			if (entity.basicInfo.Current.LifeBarSeq[i] == 2 && entity.basicInfo.Current.Hudun > 0)
			{
				return entity.basicInfo.Current.Hudun;
			}
			if (entity.basicInfo.Current.LifeBarSeq[i] == 1 && entity.basicInfo.Current.Hp > 0)
			{
				return entity.basicInfo.Current.Hp;
			}
		}
		return entity.basicInfo.Current.Hp;
	}

	private void DrawBotMapImage(PlayerEntity entity)
	{
		if (entity.basicInfo.IsDead)
		{
			if (entity.hasSmallMapImage)
			{
				SmallMapImageComponent smallMapImage = entity.smallMapImage;
				smallMapImage.SmallMapImage = default(AssetInfo);
				smallMapImage.RadarImage = default(AssetInfo);
				smallMapImage.Position = entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex());
				smallMapImage.Rotation = 0f;
				smallMapImage.ScaleX = 1f;
				smallMapImage.ScaleY = 1f;
				smallMapImage.Alpha = 1f;
				smallMapImage.Mask = 0;
				smallMapImage.Name = entity.basicInfo.PlayerName;
				smallMapImage.Hp = GetHP(entity);
				smallMapImage.IsHideNameAndHp = entity.HasStatus(PlayerInfoStatusConstant.SMALLMAP_SEE_TARGETPLAYER.ID);
			}
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		AssetInfo radarImage;
		AssetInfo smallMapImage2 = ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z > 180f) ? (radarImage = _botLowAssetInfo) : ((!(entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z < -180f)) ? (radarImage = _botAssetInfo) : (radarImage = _botHeightAssetInfo)));
		if (!entity.hasSmallMapImage)
		{
			entity.AddComponent(9, new SmallMapImageComponent());
		}
		SmallMapImageComponent smallMapImage3 = entity.smallMapImage;
		smallMapImage3.SmallMapImage = smallMapImage2;
		smallMapImage3.RadarImage = radarImage;
		smallMapImage3.Position = entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex());
		smallMapImage3.Rotation = 0f;
		smallMapImage3.ScaleX = 1f;
		smallMapImage3.ScaleY = 1f;
		smallMapImage3.Alpha = 1f;
		smallMapImage3.Mask = 0;
		smallMapImage3.Name = entity.basicInfo.PlayerName;
		smallMapImage3.Hp = GetHP(entity);
		smallMapImage3.IsHideNameAndHp = entity.HasStatus(PlayerInfoStatusConstant.SMALLMAP_SEE_TARGETPLAYER.ID);
	}

	private void DrawMapImage(PlayerEntity entity, int myTeam)
	{
		float rotation = entity.orientation.Yaw - 90f;
		float num = 1f;
		AssetInfo radarImage = default(AssetInfo);
		AssetInfo smallMapImage = default(AssetInfo);
		bool isSos = false;
		if (entity.hasSmallMapImage)
		{
			entity.smallMapImage.SmallMapImage = smallMapImage;
			entity.smallMapImage.RadarImage = radarImage;
			num = entity.smallMapImage.Alpha;
		}
		if (_battleRoomContext.roomData.IsObserver)
		{
			if (entity == _playerContext.myPlayerEntity)
			{
				return;
			}
			if (entity.basicInfo.IsDead)
			{
				if (_gameRule.IsNoShowRadarDead())
				{
					return;
				}
				if (entity.HasState(524288))
				{
					if (entity.GetTeam() == 2)
					{
						smallMapImage = (radarImage = _playerctsosAsset);
						isSos = true;
					}
					else
					{
						smallMapImage = (radarImage = _playertsosAsset);
						isSos = true;
					}
					rotation = _playerContext.cameraOwnerEntity.orientation.Yaw - 90f;
					num -= (float)_time.FrameInterval / 1000f;
				}
				else
				{
					if (entity.isCameraOwner)
					{
						return;
					}
					smallMapImage = ((entity.GetTeam() != 2) ? (radarImage = _tplayerdeadAsset) : (radarImage = _ctplayerdeadAsset));
					rotation = 90f;
				}
			}
			else
			{
				if (entity.isCameraOwner)
				{
					return;
				}
				PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
				smallMapImage = ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z > 180f) ? ((entity.GetTeam() != 2) ? (radarImage = _tplayerlowAsset) : (radarImage = _ctplayerlowAsset)) : ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z < -180f) ? ((entity.GetTeam() != 2) ? (radarImage = _tplayerheightAsset) : (radarImage = _ctplayerheightAsset)) : ((entity.GetTeam() != 2) ? (radarImage = _tplayerAsset) : (radarImage = _ctplayerAsset))));
			}
		}
		else
		{
			if (entity.GetTeam() != myTeam)
			{
				return;
			}
			if (entity.basicInfo.IsDead)
			{
				if (_gameRule.IsNoShowRadarDead())
				{
					return;
				}
				if (entity.HasState(524288))
				{
					smallMapImage = (radarImage = _playersosAsset);
					isSos = true;
					rotation = _playerContext.cameraOwnerEntity.orientation.Yaw - 90f;
					num -= (float)_time.FrameInterval / 1000f;
				}
				else
				{
					if (entity.isCameraOwner)
					{
						return;
					}
					smallMapImage = (radarImage = _deadAsset);
					rotation = 90f;
				}
			}
			else
			{
				if (entity.isCameraOwner)
				{
					return;
				}
				PlayerEntity cameraOwnerEntity2 = _playerContext.cameraOwnerEntity;
				smallMapImage = ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity2.GetCompenstatePos(cameraOwnerEntity2.fpos.Change.GetPosIndex()).z > 180f) ? ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerlowAsset) : (radarImage = _c4playerlowAsset)) : ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity2.GetCompenstatePos(cameraOwnerEntity2.fpos.Change.GetPosIndex()).z < -180f) ? ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerheightAsset) : (radarImage = _c4playerheightAsset)) : ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerAsset) : (radarImage = _c4playerAsset))));
			}
		}
		if (!entity.hasSmallMapImage)
		{
			entity.AddComponent(9, new SmallMapImageComponent());
		}
		SmallMapImageComponent smallMapImage2 = entity.smallMapImage;
		smallMapImage2.SmallMapImage = smallMapImage;
		smallMapImage2.RadarImage = radarImage;
		smallMapImage2.Position = entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex());
		smallMapImage2.Rotation = rotation;
		smallMapImage2.ScaleX = 1f;
		smallMapImage2.ScaleY = 1f;
		smallMapImage2.Alpha = 1f;
		smallMapImage2.Mask = 0;
		smallMapImage2.Name = entity.basicInfo.PlayerName;
		smallMapImage2.Hp = GetHP(entity);
		smallMapImage2.IsSos = isSos;
		if (entity.IsDead())
		{
			if (entity.HasState(524288))
			{
				smallMapImage2.DeadTime = 8000;
				if (num <= 0f)
				{
					num = 1f;
				}
				float scaleX = (smallMapImage2.ScaleY = 2f - num);
				smallMapImage2.ScaleX = scaleX;
				smallMapImage2.Alpha = num;
			}
			else
			{
				smallMapImage2.DeadTime += _time.FrameInterval;
			}
		}
		else
		{
			smallMapImage2.DeadTime = 0;
		}
	}

	public void DrawPeekabooMapImage(PlayerEntity entity, int myTeam)
	{
		float rotation = entity.orientation.Yaw - 90f;
		float num = 1f;
		AssetInfo radarImage = default(AssetInfo);
		AssetInfo smallMapImage = default(AssetInfo);
		bool isSos = false;
		if (entity.hasSmallMapImage)
		{
			entity.smallMapImage.SmallMapImage = smallMapImage;
			entity.smallMapImage.RadarImage = radarImage;
			num = entity.smallMapImage.Alpha;
		}
		if (_battleRoomContext.roomData.IsObserver)
		{
			if (entity == _playerContext.myPlayerEntity)
			{
				return;
			}
			if (entity.basicInfo.IsDead)
			{
				if (_gameRule.IsNoShowRadarDead())
				{
					return;
				}
				smallMapImage = ((entity.GetTeam() != 2) ? (radarImage = _tplayerdeadAsset) : (radarImage = _ctplayerdeadAsset));
				rotation = 90f;
			}
			else
			{
				PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
				smallMapImage = ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z > 180f) ? ((entity.GetTeam() != 2) ? (radarImage = _tplayerlowAsset) : (radarImage = _ctplayerlowAsset)) : ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex()).z < -180f) ? ((entity.GetTeam() != 2) ? (radarImage = _tplayerheightAsset) : (radarImage = _ctplayerheightAsset)) : ((entity.GetTeam() != 2) ? (radarImage = _tplayerAsset) : (radarImage = _ctplayerAsset))));
			}
		}
		else
		{
			if (entity.GetTeam() != myTeam)
			{
				return;
			}
			if (entity.basicInfo.IsDead)
			{
				if (_gameRule.IsNoShowRadarDead())
				{
					return;
				}
				if (entity.HasState(524288))
				{
					smallMapImage = (radarImage = _playersosAsset);
					isSos = true;
					rotation = _playerContext.cameraOwnerEntity.orientation.Yaw - 90f;
					num -= (float)_time.FrameInterval / 1000f;
				}
				else
				{
					smallMapImage = (radarImage = _deadAsset);
					rotation = 90f;
				}
			}
			else
			{
				PlayerEntity cameraOwnerEntity2 = _playerContext.cameraOwnerEntity;
				smallMapImage = ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity2.GetCompenstatePos(cameraOwnerEntity2.fpos.Change.GetPosIndex()).z > 180f) ? ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerlowAsset) : (radarImage = _c4playerlowAsset)) : ((entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex()).z - cameraOwnerEntity2.GetCompenstatePos(cameraOwnerEntity2.fpos.Change.GetPosIndex()).z < -180f) ? ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerheightAsset) : (radarImage = _c4playerheightAsset)) : ((!_gameRule.IsExplode() || !entity.basicInfo.Current.HasC4) ? (radarImage = _playerAsset) : (radarImage = _c4playerAsset))));
			}
		}
		if (!entity.hasSmallMapImage)
		{
			entity.AddComponent(9, new SmallMapImageComponent());
		}
		SmallMapImageComponent smallMapImage2 = entity.smallMapImage;
		smallMapImage2.SmallMapImage = smallMapImage;
		smallMapImage2.RadarImage = radarImage;
		smallMapImage2.Position = entity.GetCompenstatePos(entity.fpos.Change.GetPosIndex());
		smallMapImage2.Rotation = rotation;
		smallMapImage2.ScaleX = 1f;
		smallMapImage2.ScaleY = 1f;
		smallMapImage2.Alpha = 1f;
		smallMapImage2.Mask = 0;
		smallMapImage2.Name = entity.basicInfo.PlayerName;
		smallMapImage2.Hp = GetHP(entity);
		smallMapImage2.IsSos = isSos;
		if (entity.IsDead())
		{
			if (entity.HasState(524288))
			{
				smallMapImage2.DeadTime = 8000;
				if (num <= 0f)
				{
					num = 1f;
				}
				float scaleX = (smallMapImage2.ScaleY = 2f - num);
				smallMapImage2.ScaleX = scaleX;
				smallMapImage2.Alpha = num;
			}
			else
			{
				smallMapImage2.DeadTime += _time.FrameInterval;
			}
		}
		else
		{
			smallMapImage2.DeadTime = 0;
		}
	}
}
