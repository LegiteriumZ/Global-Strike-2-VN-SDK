using Assets.Sources.Components.Time;

public interface IModeExtraDataProvider : IDataProvider
{
	string KeyInfo { get; set; }

	void OnFrame(TimeComponent time);
}
