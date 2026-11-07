public interface IknifeFightModelRandomEffectProvider : IModuleProvider
{
	bool CanSet(int index);

	string SetImage(int index);

	bool IsShow();
}
