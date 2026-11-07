public interface IbioUnionBaseSelectPlayerUIProvider : IModuleProvider
{
	bool checkHeadCanShowByIndex(int index);

	bool checKeyInputByIndex(int index);

	string updateHeadIconByIndex(int index);

	float inputHandleByIndex(int index);

	bool checkLockShowByIndex(int index);

	bool checkLeftArrowIsShow();

	float leftArrowHandle();

	bool checkRightArrowIsShow();

	float rightArrowHandle();

	bool checkRootShow();
}
