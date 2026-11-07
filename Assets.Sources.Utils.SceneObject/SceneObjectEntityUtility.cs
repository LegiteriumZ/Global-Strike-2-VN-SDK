using System;
using Assets.Sources.Components.Interface;
using UnityEngine;
using config;
using share;

namespace Assets.Sources.Utils.SceneObject;

public class SceneObjectEntityUtility
{
	public static void CleanSkyboxUnityObjects(SceneObjectEntity entity)
	{
		if (entity.hasSkyboxUnityObjects)
		{
			UnityEngine.Object.Destroy(entity.skyboxUnityObjects.Skybox);
			entity.RemoveSkyboxUnityObjects();
		}
	}

	public static bool InSceneBuffRadius(PlayerEntity player, ISceneObjectEntity entity)
	{
		if (player == null)
		{
			return false;
		}
		if (!entity.HasSceneBuff)
		{
			return false;
		}
		Vector3 compenstatePos = player.GetCompenstatePos(player.fpos.Change.GetPosIndex());
		float num = compenstatePos.x - entity.SceneBuff.Data.X;
		float num2 = compenstatePos.y - entity.SceneBuff.Data.Y;
		float value = compenstatePos.z - entity.SceneBuff.Data.Z;
		float radius = entity.SceneBuff.Data.Radius;
		if (num * num + num2 * num2 <= radius * radius && Math.Abs(value) <= radius)
		{
			return true;
		}
		return false;
	}

	public static Vector3 GetPlayerSize(PlayerEntity player)
	{
		Vector3 zero = Vector3.zero;
		int num = player.DuckState();
		string career = player.GetCareer();
		Vector3D boundsMinForDuckPlayer = BoundBoxConfig.GetBoundsMinForDuckPlayer(career);
		zero.x = (float)boundsMinForDuckPlayer.x;
		zero.y = (float)boundsMinForDuckPlayer.y;
		if (num == 0 || num == 2)
		{
			zero.z = (float)BoundBoxConfig.GetBoundsMaxForDuckPlayer(career).z;
		}
		else
		{
			zero.z = (float)BoundBoxConfig.GetBoundsMaxForNormalPlayer(career).z;
		}
		return zero;
	}

	public static bool CanPickWeapon(PlayerEntity player, ISceneObjectEntity entity)
	{
		if (player == null)
		{
			return false;
		}
		if (!entity.HasSceneBuff)
		{
			return false;
		}
		Vector3 compenstatePos = player.GetCompenstatePos(player.fpos.Change.GetPosIndex());
		float value = compenstatePos.x - entity.SceneBuff.Data.X;
		float value2 = compenstatePos.y - entity.SceneBuff.Data.Y;
		float value3 = compenstatePos.z - entity.SceneBuff.Data.Z;
		Vector3 playerSize = GetPlayerSize(player);
		float value4 = playerSize.x - entity.SceneBuff.Data.Radius;
		float value5 = playerSize.y - entity.SceneBuff.Data.Radius;
		float value6 = playerSize.z - entity.SceneBuff.Data.Radius;
		if (Math.Abs(value) < Math.Abs(value4) && Math.Abs(value2) < Math.Abs(value5) && Math.Abs(value3) < Math.Abs(value6))
		{
			return true;
		}
		return false;
	}
}
