public interface IrpgLootModelMessageProvider : IModuleProvider
{
	bool isShowNoOccupy();

	bool isShowGetMoreFlag();

	bool isShowGetFlagWin();

	float getFlagWinCount();
}
