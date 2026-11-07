using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Assets.Sources.Components.GameRule.BioUnionBase;
using Assets.Sources.Components.Time;
using SSJJBase.Manager;

public class bioUnionBaseSelectPlayerUIProvider : IbioUnionBaseSelectPlayerUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private BioUnionBaseDataComponent data;

	private BattleServerContext _battleServer;

	public bioUnionBaseSelectPlayerUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		data = _gameRuleContext.bioUnionBaseData;
		_battleServer = contexts.battleServer;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checKeyInputByIndex(int index)
	{
		int num = 49 + index;
		return BattleSingletonInstance<DataProviderManager>.Instance.uiDataProvider.KeyCodeInput(num, num);
	}

	public string updateHeadIconByIndex(int index)
	{
		if (data.careerList == null)
		{
			return "";
		}
		int num = data.nowPage * 9 + index;
		if (num < data.careerList.Count)
		{
			return ("/ui/GameGUIRes/bioUnionBase/head/" + data.careerList[num].career) ?? "";
		}
		return "";
	}

	public float inputHandleByIndex(int index)
	{
		if (data.careerList == null)
		{
			return 0f;
		}
		int num = data.nowPage * 9 + index;
		if (num < data.careerList.Count)
		{
			_battleServer.battleServer.Server.SendTcpMessage(162, data.careerList[num].career);
		}
		data.SelectPlayerPanelShow = false;
		return 0f;
	}

	public bool checkHeadCanShowByIndex(int index)
	{
		if (data.careerList == null)
		{
			return false;
		}
		if (data.nowPage * 9 + index >= data.careerList.Count)
		{
			return false;
		}
		return true;
	}

	public bool checkRootShow()
	{
		return data.SelectPlayerPanelShow;
	}

	public bool checkLockShowByIndex(int index)
	{
		if (data.careerList == null)
		{
			return false;
		}
		int num = data.nowPage * 9 + index;
		if (num >= data.careerList.Count)
		{
			return false;
		}
		return data.careerList[num].isLock;
	}

	public float leftArrowHandle()
	{
		data.nowPage--;
		if (data.nowPage < 0)
		{
			data.nowPage = 0;
		}
		return 0f;
	}

	public float rightArrowHandle()
	{
		data.nowPage++;
		if (data.nowPage >= data.totalPage)
		{
			data.nowPage = data.totalPage - 1;
		}
		return 0f;
	}

	public bool checkLeftArrowIsShow()
	{
		return data.nowPage > 0;
	}

	public bool checkRightArrowIsShow()
	{
		return data.nowPage < data.totalPage - 1;
	}
}
