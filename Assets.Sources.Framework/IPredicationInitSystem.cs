namespace Assets.Sources.Framework;

public interface IPredicationInitSystem
{
	string LastErrorMsg { get; }

	void OnPredicatoinInit();

	void SavePredicationState(int cmdSeq);

	bool HasPredicatonError(int cmdSeq);

	void OnPredicatoinError(int cmdSeq);

	void OnPredicatoinSucc(int cmdSeq);

	bool ShouldResetAll();
}
