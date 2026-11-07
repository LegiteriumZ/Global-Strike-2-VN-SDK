using System.Collections.Generic;
using Assets.Sources.Components.Time;
using NetData;

public class freeRpg_107000ModelSelectPlayerProvider : IfreeRpg_107000ModelSelectPlayerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public freeRpg_107000ModelSelectPlayerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float ClosePanel()
	{
		_gameRuleContext.mystery.SelectPlayerShow = false;
		return 0f;
	}

	public bool IsShowChoosePlayer(int index)
	{
		int num = 0;
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isMyPlayer && !item.basicInfo.Current.IsBot && item.basicInfo.Current.CharacterId >= 0)
			{
				num++;
			}
		}
		return index < num;
	}

	public string GetPlayerName(int index)
	{
		List<string> list = new List<string>();
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isMyPlayer && !item.basicInfo.Current.IsBot && item.basicInfo.Current.CharacterId >= 0)
			{
				list.Add(item.basicInfo.PlayerName);
			}
		}
		if (index < list.Count)
		{
			return list[index];
		}
		return "";
	}

	public bool IsSelect(int index)
	{
		List<long> list = new List<long>();
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isMyPlayer && !item.basicInfo.Current.IsBot && item.basicInfo.Current.CharacterId >= 0)
			{
				list.Add(item.basicInfo.Cid);
			}
		}
		if (_gameRuleContext.mystery.SelectPlayers != null && index < list.Count)
		{
			return _gameRuleContext.mystery.SelectPlayers.Contains(list[index]);
		}
		return false;
	}

	public float SelectPlayer(int index)
	{
		List<long> list = new List<long>();
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isMyPlayer && !item.basicInfo.Current.IsBot && item.basicInfo.Current.CharacterId >= 0)
			{
				list.Add(item.basicInfo.Cid);
			}
		}
		bool flag = false;
		if (_gameRuleContext.mystery.SelectPlayers != null && index < list.Count)
		{
			flag = _gameRuleContext.mystery.SelectPlayers.Contains(list[index]);
		}
		if (_gameRuleContext.mystery.SelectPlayers == null)
		{
			_gameRuleContext.mystery.SelectPlayers = new List<long>();
		}
		if (flag)
		{
			_gameRuleContext.mystery.SelectPlayers.Remove(list[index]);
		}
		else
		{
			_gameRuleContext.mystery.SelectPlayers.Add(list[index]);
		}
		StringData message = new StringData
		{
			Data = CollectList()
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(117, message);
		return 0f;
	}

	private string CollectList()
	{
		string text = "";
		foreach (long selectPlayer in _gameRuleContext.mystery.SelectPlayers)
		{
			text = text + selectPlayer + "|";
		}
		if (text.Length > 1)
		{
			text = text.Substring(0, text.Length - 1);
		}
		return text;
	}

	public bool IsShowSelectPlayer()
	{
		return _gameRuleContext.mystery.SelectPlayerShow;
	}

	public bool IsSelect1()
	{
		return IsSelect(0);
	}

	public float SelectPlayer1()
	{
		return SelectPlayer(0);
	}

	public bool IsSelect2()
	{
		return IsSelect(1);
	}

	public float SelectPlayer2()
	{
		return SelectPlayer(1);
	}

	public bool IsSelect3()
	{
		return IsSelect(2);
	}

	public float SelectPlayer3()
	{
		return SelectPlayer(2);
	}

	public bool IsSelect4()
	{
		return IsSelect(3);
	}

	public float SelectPlayer4()
	{
		return SelectPlayer(3);
	}

	public bool IsSelect5()
	{
		return IsSelect(4);
	}

	public float SelectPlayer5()
	{
		return SelectPlayer(4);
	}

	public bool IsSelect6()
	{
		return IsSelect(5);
	}

	public float SelectPlayer6()
	{
		return SelectPlayer(5);
	}

	public bool IsSelect7()
	{
		return IsSelect(6);
	}

	public float SelectPlayer7()
	{
		return SelectPlayer(6);
	}

	public bool IsSelect8()
	{
		return IsSelect(7);
	}

	public float SelectPlayer8()
	{
		return SelectPlayer(7);
	}

	public bool IsSelect9()
	{
		return IsSelect(8);
	}

	public float SelectPlayer9()
	{
		return SelectPlayer(8);
	}

	public bool IsSelect10()
	{
		return IsSelect(9);
	}

	public float SelectPlayer10()
	{
		return SelectPlayer(9);
	}

	public bool IsSelect11()
	{
		return IsSelect(10);
	}

	public float SelectPlayer11()
	{
		return SelectPlayer(10);
	}

	public bool IsSelect12()
	{
		return IsSelect(11);
	}

	public float SelectPlayer12()
	{
		return SelectPlayer(11);
	}

	public bool IsSelect13()
	{
		return IsSelect(12);
	}

	public float SelectPlayer13()
	{
		return SelectPlayer(12);
	}

	public bool IsSelect14()
	{
		return IsSelect(13);
	}

	public float SelectPlayer14()
	{
		return SelectPlayer(13);
	}

	public bool IsSelect15()
	{
		return IsSelect(14);
	}

	public float SelectPlayer15()
	{
		return SelectPlayer(14);
	}
}
