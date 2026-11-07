using Assets.Sources.Components.SceneObject;
using Assets.Sources.Free.Data;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class C4RenderInfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void InitSound(SceneObjectEntity entity)
	{
		InitDummySound(entity);
	}

	protected override void UpdateSound(SceneObjectEntity entity)
	{
		GameRuleContext gameRule = Contexts.sharedInstance.gameRule;
		ISoundPlayer source = entity.sound.Source;
		if (gameRule.hasC4State && gameRule.c4State.Active)
		{
			int num = 35000;
			if (GameModelLocator.GetInstance().GameModel.RoomData.RaceType == 8)
			{
				num = 45000;
			}
			int num2 = 1;
			int time = gameRule.c4State.Time;
			int num3 = num - time;
			if (num3 < 7000)
			{
				num2 = 5;
			}
			else if (num3 < 14000)
			{
				num2 = 4;
			}
			else if (num3 < 21000)
			{
				num2 = 3;
			}
			else if (num3 < 28000)
			{
				num2 = 2;
			}
			_ = entity.unityObjects.LoadResults[0].GameObject;
			AssetInfo assetInfo = new AssetInfo("sound/c4", $"Assets/Res/Assets/sound/c4/c4_beep{num2}.mp3");
			if (source.AssetInfo != assetInfo)
			{
				source.PlaySound(assetInfo, 1f, 5500, loop: true);
			}
		}
		else
		{
			_ = entity.unityObjects.LoadResults[0].GameObject;
			source.StopSound();
		}
	}
}
