public interface IrpgBaseRunModelRpgBaseRunTaskUIProvider : IModuleProvider
{
	bool IsItemShowByIndex(int index);

	bool checkTaskUIShow();

	bool IsItemAddDiByIndex(int index);

	string updateTaskNameByIndex(int index);

	float updateAddNum();

	float updateMulNum();

	float updatePercentNum();

	float updateTaskProgressByIndex(int index);

	float updateTaskScoreByIndex(int index);

	float updateTotalNum();

	float updateLvl();
}
