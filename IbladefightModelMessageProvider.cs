public interface IbladefightModelMessageProvider : IModuleProvider
{
	bool isFogAreaRefresh();

	bool isWaitRealStart();

	float getWaitRealStartTime();

	bool isSafeAreaRefresh();

	bool isObserve();

	bool isGetEnergyPack();

	bool isTargetGetEnergyPack();
}
