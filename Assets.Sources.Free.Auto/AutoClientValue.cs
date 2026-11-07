using System;
using System.Collections.Generic;
using I2.Loc;
using SSJJBase.Extensions;
using SSJJBase.String;

namespace Assets.Sources.Free.Auto;

public class AutoClientValue : AbstractAutoValue
{
	private string _field;

	private string _key;

	public static Dictionary<string, object> roomInfo = new Dictionary<string, object>();

	private const int IndividualMatch = 1;

	private const int FreedomAthletics = 0;

	private const string IndividualMatchName = "个人联赛";

	private int _roomId = -999;

	private string _roomName = "";

	private int _battleType = -999;

	private string _limitNumber = "";

	private bool _initRoom;

	public override string ValueToString()
	{
		return GetType().Name + " field : " + _field + " _key : " + _key;
	}

	private void Init()
	{
		if (!_initRoom || _battleType < 0)
		{
			_initRoom = true;
			_battleType = Convert.ToInt32(roomInfo.GetOrDefault("battleType"));
			_limitNumber = StringCache.IntToString(Contexts.sharedInstance.battleRoom.roomData.LimitNum);
			if (_battleType != 1)
			{
				_roomId = Convert.ToInt32(roomInfo.GetOrDefault("roomId"));
				_roomName = string.Concat(roomInfo.GetOrDefault("channelName"), "({1})".Replace("{1}", StringCache.IntToString(_roomId)));
			}
		}
	}

	public override AutoValueData Frame(int frameTime)
	{
		if (_field.Equals("roomName") && roomInfo != null)
		{
			Init();
			if (_battleType == 1)
			{
				AutoValueData.S("个人联赛");
			}
			else
			{
				AutoValueData.S(_roomName);
			}
		}
		if (_field.Equals("weaponName"))
		{
			AutoValueData.S(ScriptLocalization.Get(_key));
		}
		if (_field.Equals("roomMax") && roomInfo != null)
		{
			Init();
			AutoValueData.S(_limitNumber);
		}
		return AutoValueData;
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 2 && array[0] == "client")
		{
			AutoClientValue autoClientValue = new AutoClientValue();
			autoClientValue._field = array[1];
			if (array.Length > 2)
			{
				autoClientValue._key = array[2];
			}
			return autoClientValue;
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			_key = value[0];
		}
	}
}
