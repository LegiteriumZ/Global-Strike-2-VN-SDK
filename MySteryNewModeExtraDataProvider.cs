public class MySteryNewModeExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/freerpg_107000model";
		Providers.Add(new freeRpg_107000ModelCanSelectModeProvider(contexts));
		Providers.Add(new freeRpg_107000ModelChooseModeProvider(contexts));
		Providers.Add(new freeRpg_107000ModelNotLeaveRoomProvider(contexts));
		Providers.Add(new freeRpg_107000ModelTaskInfoProvider(contexts));
		Providers.Add(new freeRpg_107000ModelTimerProvider(contexts));
		Providers.Add(new freeRpg_107000ModelCanLightFireProvider(contexts));
		Providers.Add(new freeRpg_107000ModelExpProgressProvider(contexts));
		Providers.Add(new freeRpg_107000ModelSelectPlayerProvider(contexts));
		Providers.Add(new freeRpg_107000ModelFireStartProvider(contexts));
		Providers.Add(new freeRpg_107000ModelSpecailExpSetProvider(contexts));
		Providers.Add(new freeRpg_107000ModelCanSelectSpecailPlayerProvider(contexts));
		Providers.Add(new freeRpg_107000ModelRankProvider(contexts));
	}
}
