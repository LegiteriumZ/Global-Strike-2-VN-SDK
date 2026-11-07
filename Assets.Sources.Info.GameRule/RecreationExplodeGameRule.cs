using SSJJAsset.Asset;

namespace Assets.Sources.Info.GameRule;

public class RecreationExplodeGameRule : DefaultGameRule
{
	protected static AssetInfo TGameStartSound = new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/gamestartt.mp3");

	protected static AssetInfo CtGameStartSound = new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/gamestartt.mp3");

	public override bool IsHasC4()
	{
		return true;
	}

	public override int GetNotMoveTime()
	{
		return 3000;
	}

	public override AssetInfo GetStartGameSound(int team)
	{
		if (team == 1)
		{
			return TGameStartSound;
		}
		return CtGameStartSound;
	}

	public override int GetC4TotalTime()
	{
		return 45000;
	}

	public override int GetTipsIndex()
	{
		return 1;
	}
}
