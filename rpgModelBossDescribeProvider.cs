using Assets.Sources.Components.Time;
using Assets.Sources.Utils.Ui;
using SSJJBase.Singleton;

public class rpgModelBossDescribeProvider : IrpgModelBossDescribeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private BossDescribeData bossDescribeData;

	public rpgModelBossDescribeProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		bossDescribeData = SingletonInstance<BossDescribeData>.Instance;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float getBossBaseY()
	{
		return (float)(bossDescribeData.getBossSkillHeight(-1) + BossDescribeData.BASE_HEIGHT) * 0.5f * -1f;
	}

	public string getBossName()
	{
		return bossDescribeData.Name;
	}

	public string getBossTitleUrl()
	{
		return "/ui/GameGUIRes/halfLoadedRes/bossTitle/" + bossDescribeData.Codename;
	}

	public string getCritdefUrl()
	{
		return "/ui/GameGUIRes/rpgModel/botHp/critDef" + bossDescribeData.getResistance(2);
	}

	public string getCritrateUrl()
	{
		return "/ui/GameGUIRes/rpgModel/botHp/critRateDef" + bossDescribeData.getResistance(3);
	}

	public float getHpLeft()
	{
		long hp = bossDescribeData.Hp;
		int num = 0;
		num = (int)((hp > 10000000000000000L) ? (hp / 10000000000000000L) : ((hp > 1000000000000L) ? (hp / 1000000000000L) : (((int)(hp / 100000000) > 0) ? (hp / 100000000) : (((int)(hp / 10000) <= 0) ? hp : (hp / 10000)))));
		return num;
	}

	public bool showHpRight()
	{
		long hp = bossDescribeData.Hp;
		if (hp > 10000000000000000L)
		{
			return true;
		}
		if (hp > 1000000000000L)
		{
			return true;
		}
		if ((int)(hp / 100000000) > 0)
		{
			return true;
		}
		if ((int)(hp / 10000) > 0)
		{
			return true;
		}
		return false;
	}

	public float getHpRight()
	{
		long hp = bossDescribeData.Hp;
		int num = 0;
		if (hp > 10000000000000000L)
		{
			num = (int)(hp % 10000000000000000L / 1000000000000000L);
		}
		else if (hp > 1000000000000L)
		{
			num = (int)(hp % 1000000000000L / 100000000000L);
		}
		else if ((int)(hp / 100000000) > 0)
		{
			num = (int)(hp % 100000000 / 10000000);
		}
		else if ((int)(hp / 10000) > 0)
		{
			num = (int)(hp % 10000 / 1000);
		}
		return num;
	}

	public bool isShowHpType1()
	{
		return bossDescribeData.isShowHpType(0);
	}

	public string getHpWordUrl()
	{
		long hp = bossDescribeData.Hp;
		if (hp > 10000000000000000L)
		{
			return "/ui/GameGUIRes/common/numpoint/whitejin";
		}
		if (hp > 1000000000000L)
		{
			return "/ui/GameGUIRes/common/numpoint/whitezhao";
		}
		if ((int)(hp / 100000000) > 0)
		{
			return "/ui/GameGUIRes/common/numpoint/whiteyi";
		}
		if ((int)(hp / 10000) > 0)
		{
			return "/ui/GameGUIRes/common/numpoint/whitewan";
		}
		return "/ui/GameGUIRes/common/numpoint/whitejin";
	}

	public string getHujiaUrl()
	{
		return "/ui/GameGUIRes/rpgModel/botHp/hujia" + bossDescribeData.getResistance(1);
	}

	public string getLichangUrl()
	{
		return "/ui/GameGUIRes/rpgModel/botHp/lichang" + bossDescribeData.getResistance(0);
	}

	public bool isShow()
	{
		return bossDescribeData.hasBossDescribe();
	}

	public bool showSkillBack1(int index)
	{
		return bossDescribeData.hasBossSkillTitle2(index);
	}

	public bool showSkillBack2(int index)
	{
		return !bossDescribeData.hasBossSkillTitle2(index);
	}

	public string getSkillName(int index)
	{
		return bossDescribeData.getSkillName(index);
	}

	public bool showSkillPage(int index)
	{
		return bossDescribeData.hasBossSkill(index);
	}

	public float getSkillPageY(int index)
	{
		return ((float)(bossDescribeData.getBossSkillHeight(-1) + BossDescribeData.BASE_HEIGHT) * 0.5f - (float)BossDescribeData.BASE_HEIGHT - (float)bossDescribeData.getBossSkillHeight(index)) * -1f;
	}

	public string getSkillTitle1(int index)
	{
		return bossDescribeData.getSkillTitle1(index);
	}

	public bool showSkillTitle2(int index)
	{
		return bossDescribeData.hasBossSkillTitle2(index);
	}

	public string getSkillTitle2(int index)
	{
		return bossDescribeData.getSkillTitle2(index);
	}

	public bool isShowBossType(int index)
	{
		return bossDescribeData.hasBossType(index);
	}

	public string getBossType(int index)
	{
		return bossDescribeData.getBossType(index);
	}

	public bool isShowHpType(int index)
	{
		return bossDescribeData.isShowHpType(index);
	}

	public string getHpTypeUrl(int index)
	{
		return "/ui/GameGUIRes/rpgModel/bossDescribe/hpType" + bossDescribeData.getHpType(index);
	}

	public string getHpTypeLockUrl(int index)
	{
		return "/ui/GameGUIRes/rpgModel/bossDescribe/hpType" + bossDescribeData.getHpType(index) + "Back";
	}

	public string getYangDunType()
	{
		return "/ui/GameGUIRes/rpgModel/bossDescribe/yangDunType" + bossDescribeData.getYinyangDunType(0);
	}

	public bool showYinDun()
	{
		return bossDescribeData.getYinyangDunType(1) > 0;
	}

	public bool showYangDun()
	{
		return bossDescribeData.getYinyangDunType(0) > 0;
	}

	public string getYinDunType()
	{
		return "/ui/GameGUIRes/rpgModel/bossDescribe/yinDunType" + bossDescribeData.getYinyangDunType(1);
	}

	public float getExtraordinaryCount(int index)
	{
		return bossDescribeData.getExtraordinaryCount(index);
	}

	public bool showExtraordinaryIcon(int index)
	{
		return bossDescribeData.getExtraordinaryCount(index) > 0;
	}

	public float getExtraordinaryValue()
	{
		return bossDescribeData.ExtraordinaryValue;
	}
}
