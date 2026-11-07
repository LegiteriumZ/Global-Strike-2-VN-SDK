public interface IbladefightModelGameOverProvider : IModuleProvider
{
	float getDamage();

	float getKillNum();

	bool isWin();

	float getRanking();

	float getReturnLobbyTime();

	bool isShow();

	bool isReturnLobby();
}
