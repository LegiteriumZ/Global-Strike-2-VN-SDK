using Assets.Sources.Components.Rader;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class RadarMapItemModel : MapItemModel
{
	protected override Vector3 GetPosition()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			Vector3 result = item.Position - UiIEventCondition.Get_cameraOwnerData_Position();
			result.x *= MapData.ScaleX;
			result.y *= MapData.ScaleY;
			result.z = 0f;
			if (!item.RadarFixPos && result.magnitude > MapData.Radius)
			{
				result = result.normalized * MapData.Radius;
			}
			result.z = 0f;
			return result;
		}
		return Vector3.zero;
	}

	protected override AssetInfo GetSmallMapImage()
	{
		ISmallMapImageItem item = GetItem();
		if (item == null || (item.Mask > 0 && item.Mask != 7))
		{
			return new AssetInfo("null", "null");
		}
		return item.RadarImage;
	}

	protected override Vector3 GetImageScale()
	{
		ISmallMapImageItem item = GetItem();
		if (item != null)
		{
			if (item.Mask == 7)
			{
				_ = MapData.WorldMax - MapData.WorldMin;
				return new Vector3(item.ScaleX * MapData.ScaleX / 30f, item.ScaleY * MapData.ScaleX / 30f);
			}
			if (!item.FreeRadar)
			{
				return new Vector3(item.ScaleX, item.ScaleY);
			}
			if (item.Mask <= 0)
			{
				return new Vector3(item.ScaleX, item.ScaleY) * item.RadarScale;
			}
		}
		return Vector3.one;
	}

	protected override long GetHp()
	{
		return 0L;
	}

	protected override string GetName()
	{
		return "";
	}
}
