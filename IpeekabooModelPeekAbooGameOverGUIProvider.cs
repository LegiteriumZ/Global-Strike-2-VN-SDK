public interface IpeekabooModelPeekAbooGameOverGUIProvider : IModuleProvider
{
	bool updateSurviveVisible();

	bool updateItemContainerVisible();

	bool updateWinItemVisible(int index);

	float updateConWinX(int index);

	string updateImgWinSrc();

	bool updateImgItemVisible(int index);

	string updateImgItemSrcByIndex(int index);

	bool updateRootVisible();

	bool updateTxtNameVisible(int index);

	string updateTxtNameByIndex(int index);

	float updateSurviveCount();
}
