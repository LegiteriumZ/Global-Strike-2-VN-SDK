public interface IcommonVideoHelpProvider : IModuleProvider
{
	bool isCrimialSuspectDead();

	bool isCrimialSuspectOut();

	float getCurrentSnapshotLength();

	float selectSnapshotIndex();

	float getProgress();

	bool isVideo();

	bool isSelectVideoSpeed(int index);

	string getStopOrContinue();

	float getTotalSnapshotLength();
}
