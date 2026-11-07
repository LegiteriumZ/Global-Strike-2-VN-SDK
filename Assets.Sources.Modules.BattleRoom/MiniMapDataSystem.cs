using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Components.Rader;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.GameRule;
using NetData;
using share.constant;

namespace Assets.Sources.Modules.BattleRoom;

public class MiniMapDataSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private SceneObjectContext _sceneObjectContext;

	private IGameRule _gameRule;

	public MiniMapDataSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
		_sceneObjectContext = contexts.sceneObject;
		_gameRule = contexts.gameRule.currentRule.Rule;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner)
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (!cameraOwnerEntity.hasBasicInfo)
		{
			return;
		}
		PlayerEntityData current = cameraOwnerEntity.basicInfo.Current;
		List<ISmallMapImageItem> imageList = _battleRoomContext.mapInfo.ImageList;
		List<ISmallMapImageItem> list = new List<ISmallMapImageItem>();
		foreach (PlayerEntity item in _playerContext)
		{
			if ((!item.isCameraOwner || item.HasState(524288)) && item.hasSmallMapImage && item.hasBasicInfo)
			{
				bool flag = item.GetTeam() == current.Team;
				if ((flag || item.HasStatus(PlayerInfoStatusConstant.SMALLMAP_SEE_TARGETPLAYER.ID) || _gameRule.IsShowRadarEnemy()) && (!string.IsNullOrEmpty(item.smallMapImage.RadarImage.AssetName) || !string.IsNullOrEmpty(item.smallMapImage.SmallMapImage.AssetName)))
				{
					item.smallMapImage.MyTeam = flag;
					item.smallMapImage.TacticsSoundTime = item.GetTacticsSoundTime() > 0;
					item.smallMapImage.SceneObj = false;
					item.smallMapImage.IsBot = item.IsBot();
					list.Add(item.smallMapImage);
				}
			}
		}
		foreach (SceneObjectEntity item2 in _sceneObjectContext)
		{
			if (item2.hasSmallMapImage && (!RuleUtilty.IsSurvivalPvp(_battleRoomContext.roomData.Data.RaceType) || !item2.hasMoveObject || ((item2.moveObject.Current.Team != 100 || current.Team == 100) && (item2.moveObject.Current.Team == 100 || current.Team != 100))) && (!string.IsNullOrEmpty(item2.smallMapImage.RadarImage.AssetName) || !string.IsNullOrEmpty(item2.smallMapImage.SmallMapImage.AssetName)))
			{
				if (!item2.smallMapImage.FreeRadar)
				{
					item2.smallMapImage.Rotation = cameraOwnerEntity.orientation.Yaw - 90f;
				}
				item2.smallMapImage.MyTeam = true;
				item2.smallMapImage.TacticsSoundTime = false;
				item2.smallMapImage.SceneObj = true;
				item2.smallMapImage.IsBot = false;
				list.Add(item2.smallMapImage);
			}
		}
		for (int i = 0; i < imageList.Count; i++)
		{
			if (list.IndexOf(imageList[i]) == -1)
			{
				imageList.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (imageList.IndexOf(list[j]) == -1)
			{
				imageList.Add(list[j]);
			}
		}
		list = null;
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
