public interface IrpgModelBossDescribeProvider : IModuleProvider
{
	float getBossBaseY();

	string getBossName();

	string getBossTitleUrl();

	bool isShowBossType(int index);

	string getBossType(int index);

	string getCritdefUrl();

	string getCritrateUrl();

	float getExtraordinaryCount(int index);

	bool showExtraordinaryIcon(int index);

	float getHpLeft();

	bool showHpRight();

	float getHpRight();

	bool isShowHpType(int index);

	string getHpTypeUrl(int index);

	string getHpTypeLockUrl(int index);

	string getHpWordUrl();

	string getHujiaUrl();

	string getLichangUrl();

	bool isShow();

	bool showSkillBack1(int index);

	bool showSkillBack2(int index);

	string getSkillName(int index);

	bool showSkillPage(int index);

	float getSkillPageY(int index);

	string getSkillTitle1(int index);

	bool showSkillTitle2(int index);

	string getSkillTitle2(int index);

	string getYangDunType();

	bool showYangDun();

	string getYinDunType();

	bool showYinDun();

	float getExtraordinaryValue();
}
