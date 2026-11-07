using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Common;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Player;
using Entitas;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.SceneObject.MapMark;

public class MapMarkUpdateSystem : IPlaybackSystem
{
	private BattleRoomContext _battleRoomContext;

	private SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _group;

	public MapMarkUpdateSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_sceneObjectContext = contexts.sceneObject;
		_group = _sceneObjectContext.GetGroup(SceneObjectMatcher.MapMark);
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			item.isDestroy = true;
		}
		foreach (KeyValuePair<long, MapInfoComponent.PointInfo> markedPosition in _battleRoomContext.mapInfo.MarkedPositions)
		{
			EntityEffectId entityEffectId = new EntityEffectId(markedPosition.Key, "MapMark");
			SceneObjectEntity entityWithPlayerEffectId = _sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId);
			if (entityWithPlayerEffectId == null)
			{
				entityWithPlayerEffectId = _sceneObjectContext.CreateEntity();
				entityWithPlayerEffectId.AddPlayerEffectId(entityEffectId);
				entityWithPlayerEffectId.AddMapMark(markedPosition.Value.Position, markedPosition.Value.Color);
				entityWithPlayerEffectId.AddComponent(13, new SmallMapImageComponent());
				entityWithPlayerEffectId.smallMapImage.Position = markedPosition.Value.Position;
				entityWithPlayerEffectId.smallMapImage.Alpha = 1f;
				SmallMapImageComponent smallMapImage = entityWithPlayerEffectId.smallMapImage;
				float scaleX = (entityWithPlayerEffectId.smallMapImage.ScaleY = 1f);
				smallMapImage.ScaleX = scaleX;
				switch (markedPosition.Value.Color)
				{
				case 0:
					entityWithPlayerEffectId.smallMapImage.SmallMapImage = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/map/yellow.png");
					break;
				case 1:
					entityWithPlayerEffectId.smallMapImage.SmallMapImage = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/map/blue.png");
					break;
				case 2:
					entityWithPlayerEffectId.smallMapImage.SmallMapImage = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/map/orange.png");
					break;
				case 3:
					entityWithPlayerEffectId.smallMapImage.SmallMapImage = new AssetInfo("ui/commonfree", "Assets/Res/Assets/ui/GameGUIRes/commonfree/map/green.png");
					break;
				}
				entityWithPlayerEffectId.smallMapImage.RadarImage = new AssetInfo("null", "null");
			}
			else
			{
				entityWithPlayerEffectId.smallMapImage.Position = markedPosition.Value.Position;
				entityWithPlayerEffectId.isDestroy = false;
			}
			PlayerEntity playerByCid = PlayerUtility.GetPlayerByCid(markedPosition.Key);
			if (playerByCid != null)
			{
				if (playerByCid.hasMark)
				{
					playerByCid.mark.Color = markedPosition.Value.Color;
					playerByCid.mark.Position = markedPosition.Value.Position;
				}
				else
				{
					playerByCid.AddMark(markedPosition.Value.Color, markedPosition.Value.Position);
				}
			}
		}
	}
}
