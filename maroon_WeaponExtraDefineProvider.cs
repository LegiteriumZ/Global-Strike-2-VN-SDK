using Assets.Sources.Components.Time;
using SSJJMath;
using UnityEngine;

public class maroon_WeaponExtraDefineProvider : Abstractmaroon_WeaponExtraDefineProvider
{
	private PlayerContext playerContext;

	protected int textureIndex;

	private int textureStartIndex;

	protected int textureTotalNum = 9;

	private int flashUseTime = 300;

	private int startFrameTime;

	public override void OnFrame(TimeComponent time)
	{
		playerContext = Contexts.sharedInstance.player;
		if (playerContext != null && playerContext.myPlayerEntity != null)
		{
			if ((playerContext.myPlayerEntity.GetCurrentWeaponEffectLevel() & 2) <= 0)
			{
				textureIndex = 0;
				startFrameTime = 0;
			}
			else
			{
				float speed = (float)flashUseTime / (float)textureTotalNum;
				textureIndex = FlashMaths.GetTextureIndex(textureStartIndex, textureTotalNum, speed, startFrameTime, repeat: false);
				startFrameTime += time.FrameInterval;
			}
		}
	}

	public override bool updateImgVisible()
	{
		return textureIndex < textureTotalNum - 1;
	}

	public override string updateFlashImg()
	{
		return "/weapon/maroon/ui/flash_" + Mathf.Min(textureIndex, textureTotalNum - 2);
	}
}
