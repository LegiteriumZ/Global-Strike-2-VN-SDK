namespace Assets.Sources.Utils;

public interface ICaptureSnapshot
{
	void InitScreenThread();

	void WaitScreen();

	void ScreenNow();

	void ScreenOver();

	void UpdateScreen();

	void DestoryThread();

	bool IsPrepareScreen();

	void SetDir(string dir);
}
