public interface IrpgTreasureBossModelTreasureBossTipsUIProvider : IModuleProvider
{
	bool tipShowByIndex(int index);

	bool tipBtnBIsShow();

	bool tipEnterRoomIsShow();

	float updateCbtLvl();

	string updatePlayerName();
}
