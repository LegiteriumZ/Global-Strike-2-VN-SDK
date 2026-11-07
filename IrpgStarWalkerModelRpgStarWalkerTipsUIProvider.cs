public interface IrpgStarWalkerModelRpgStarWalkerTipsUIProvider : IModuleProvider
{
	bool infectionIsShow();

	float getNumInfection();

	bool checkShow();

	bool playerNameIsShow();

	string getPlayerName();

	bool tipShowByIndex(int index);
}
