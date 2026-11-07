namespace Assets.Sources.Systems.Snapshot;

public sealed class SnapshotFeature : Feature
{
	public SnapshotFeature(Contexts contexts)
	{
		if (OfflineGameController.setting != null && OfflineGameController.setting.TurnOn)
		{
			Add(new OfflineSnapshotSystem(contexts));
		}
		Add(new AssembleSystem(contexts));
		Add(new SelectSystem(contexts));
		Add(new TimeInterpolationSystem(contexts));
	}
}
