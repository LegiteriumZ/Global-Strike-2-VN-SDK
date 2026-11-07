using Assets.Sources.Ui.Model.Biochemical;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

public class Bio_ZchemicalMessageModel : BiochemicalMessageModel
{
	protected new static AssetInfo _successfulinfectionAsset = new AssetInfo("ui/biochemical_z", "Assets/Res/Assets/ui/GameGUIRes/biochemical_z/Other/successfulinfection.png");

	protected override void UpdateImage(BioMessageType messageType)
	{
		if (messageType == BioMessageType.SUCCESSFULINFECTION)
		{
			_selfMessageImageActiveChip.Time = 3000;
			SetSelfMessageImage(ref _successfulinfectionAsset);
		}
		else
		{
			base.UpdateImage(messageType);
		}
	}
}
