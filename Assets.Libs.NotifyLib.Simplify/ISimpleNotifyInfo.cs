namespace Assets.Libs.NotifyLib.Simplify;

internal interface ISimpleNotifyInfo
{
	bool Suspend { get; set; }

	void Update();

	void Clear();

	void Dispose();
}
