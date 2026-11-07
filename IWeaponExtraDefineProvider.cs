using Assets.Sources.Components.Time;

public interface IWeaponExtraDefineProvider : IDataProvider
{
	string KeyInfo { get; set; }

	void OnFrame(TimeComponent time);
}
