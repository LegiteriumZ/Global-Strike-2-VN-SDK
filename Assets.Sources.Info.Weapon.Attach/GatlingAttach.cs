using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Attach;

internal class GatlingAttach : AbstractAttach
{
	public GatlingState State;

	public int StateEndTime;

	public int UnReadyTime;

	public override void Init()
	{
		State = GatlingState.Idle;
		UnReadyTime = 0;
	}

	public void EnterState(GatlingState state)
	{
		State = state;
		StateEndTime = 0;
	}
}
