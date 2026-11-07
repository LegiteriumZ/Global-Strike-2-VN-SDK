using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Utility;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeSmallMapComponent : FreeBaseComponent
{
	private SmallMapMarkInfo _markInfo;

	private Dictionary<long, MapInfoComponent.PointInfo> MapPointInfos => Contexts.sharedInstance.battleRoom.mapInfo.MarkedPositions;

	public SmallMapMarkInfo GetMarkInfo()
	{
		return _markInfo;
	}

	public FreeSmallMapComponent()
	{
		base.Type = 7;
		_markInfo = new SmallMapMarkInfo();
		base.ValueType = 2;
		UnityObject = UnityUiUtility.CreateEmptyDisplayObject("SmallMap");
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		FrameAutos(uiDataManager, frameTime, gGroup);
		FrameInput(uiDataManager, frameTime, gGroup);
	}

	private void FrameInput(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		if (_markInfo.PlayerSpecifiedMarkPositionChanged)
		{
			FreeEvent.Event = 6;
			FreeEvent.Key.Key = 6;
			FreeEvent.Key.Ss.Add("smallMap");
			long cid = Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid;
			if (MapPointInfos.TryGetValue(cid, out var value))
			{
				string item = cid + "***" + value.Position.x + "***" + value.Position.y + "***" + value.Position.z;
				FreeEvent.Key.ComponentName.Add(item);
			}
			else
			{
				string item2 = cid + "***invalid***invalid***invalid";
				FreeEvent.Key.ComponentName.Add(item2);
			}
			_markInfo.PlayerSpecifiedMarkPositionChanged = false;
		}
	}

	private void FrameAutos(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		foreach (AutoField auto in Autos)
		{
			if (auto.field == "mark")
			{
				string @string = auto.auto.Frame(frameTime).String;
				if (FreeBaseComponent.IsNullString(@string))
				{
					continue;
				}
				string[] array = @string.Split("***");
				for (int i = 0; i < array.Length; i += 4)
				{
					if (!long.TryParse(array[i], out var result) || Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid == result)
					{
						continue;
					}
					if (array[i + 1] == "invalid" || array[i + 2] == "invalid" || array[i + 3] == "invalid")
					{
						MapPointInfos.Remove(result);
						continue;
					}
					int imageIndexForPlayer = _markInfo.GetImageIndexForPlayer(result);
					if (imageIndexForPlayer != -1)
					{
						float.TryParse(array[i + 1], out var result2);
						float.TryParse(array[i + 2], out var result3);
						float.TryParse(array[i + 3], out var result4);
						Vector3 position = new Vector3(result2, result3, result4);
						if (!MapPointInfos.TryGetValue(result, out var value))
						{
							value = new MapInfoComponent.PointInfo();
							MapPointInfos[result] = value;
						}
						value.Color = imageIndexForPlayer;
						value.Position = position;
					}
				}
			}
			else
			{
				if (!(auto.field == "teamInfo"))
				{
					continue;
				}
				string[] array2 = auto.auto.Frame(frameTime).String.Split("&&&");
				for (int j = 0; j < array2.Length; j++)
				{
					string[] array3 = array2[j].Split("=");
					if (array3.Length == 2 && long.TryParse(array3[0], out var result5))
					{
						int.TryParse(array3[1], out var result6);
						_markInfo.SetImageIndexForPlayer(result5, result6);
					}
				}
			}
		}
	}

	public void ClickSmallMap(Vector3 pos, float distance)
	{
		_markInfo.PlayerSpecifiedMarkPositionChanged = true;
		long cid = Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid;
		if (!MapPointInfos.TryGetValue(cid, out var value))
		{
			value = new MapInfoComponent.PointInfo();
			MapPointInfos[cid] = value;
		}
		else if (distance <= 10f)
		{
			MapPointInfos.Remove(cid);
			return;
		}
		value.Color = _markInfo.GetImageIndexForPlayer(cid);
		value.Position = pos;
	}

	public override IFreeComponent Clone()
	{
		return new FreeSmallMapComponent();
	}

	public override void Initial(params object[] ini)
	{
		if (ini.Length != 0)
		{
			InitialAuto(ini[1] as string);
		}
	}
}
