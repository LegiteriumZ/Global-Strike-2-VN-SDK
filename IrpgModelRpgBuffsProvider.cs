public interface IrpgModelRpgBuffsProvider : IModuleProvider
{
	bool IsShow(int index);

	string SetImage(int index);

	bool IsTextShow(int index);

	string SetText(int index);
}
