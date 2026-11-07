public interface IContextDataProvider : IDataProvider
{
	bool GetConstTrue();

	bool GetConstNo();

	float GetConstData(float a);

	string GetConstStr(string a);

	string GetFrameImageStr(string a);

	int GetClientTime();

	int GetServerTime();

	float GetUiProgress(string a);

	float GetUiPositionX(string a);

	float GetUiPositionY(string a);

	float GetUiPositionZ(string a);

	int GetMpData();

	int GetMaxMpData();

	bool IsPve();

	bool IsGeneralPve();

	bool IsOldPve();

	bool IsRpg();

	bool IsBio();

	bool IsBigHead();

	bool IsCompetitive();

	bool IsBlade();

	bool IsKnife();

	bool IsNotExplodeOrTeam();

	bool IsExplode();

	bool IsGroup();

	bool IsRule(string a);

	bool IsNotRule(string a);
}
