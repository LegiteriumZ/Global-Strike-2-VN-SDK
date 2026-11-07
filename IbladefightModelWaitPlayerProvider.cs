public interface IbladefightModelWaitPlayerProvider : IModuleProvider
{
	float getCurrentPlayerCount();

	bool isShowTime();

	float getCurrentTime();

	float getMaxPlayerCount();

	float getMaxTime();

	bool isWaitGameStart();
}
