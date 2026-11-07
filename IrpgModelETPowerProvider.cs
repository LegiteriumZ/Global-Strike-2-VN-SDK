public interface IrpgModelETPowerProvider : IModuleProvider
{
	bool SetShow(int index);

	string SetImage(int index);

	string SetValue(int index);

	bool GetFrameShow(int index);

	bool GetNumShow(int index);

	float GetCDTimer(int index);

	string GetCDTimerDes(int index);
}
