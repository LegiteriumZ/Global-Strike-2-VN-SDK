using System;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Free.Auto;

public class AutoPlayerValue : AbstractAutoValue
{
	private int _currentValue;

	private string _field;

	private int _id;

	private bool _idChange;

	public override string ValueToString()
	{
		return GetType().Name + " _field : " + _field + " _id : " + _id;
	}

	public override AutoValueData Frame(int frameTime)
	{
		PlayerEntity playerEntity = Contexts.sharedInstance.player.GetEntityWithEntityId(_id);
		if (playerEntity == null)
		{
			playerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		}
		if (playerEntity == null)
		{
			return AutoValueData.F(0.0);
		}
		if ("speed" == _field)
		{
			Vector3 velocity = playerEntity.move.Velocity;
			velocity.z = 0f;
			return AutoValueData.F(velocity.magnitude);
		}
		if ("ping" == _field)
		{
			int value = 0;
			Contexts.sharedInstance.battleRoom.playerInfo.PingMap.TryGetValue(playerEntity.entityId.Value, out value);
			return AutoValueData.F(value);
		}
		if (_field == "hp")
		{
			return AutoValueData.F(playerEntity.basicInfo.Current.Hp);
		}
		if (_field == "maxHp")
		{
			return AutoValueData.F(playerEntity.basicInfo.Current.MaxHp);
		}
		if (_field == "maxSpeed")
		{
			return AutoValueData.F(0.0);
		}
		if (_field == "x")
		{
			return AutoValueData.F(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).x);
		}
		if (_field == "y")
		{
			return AutoValueData.F(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).y);
		}
		if (_field == "z")
		{
			return AutoValueData.F(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).z);
		}
		if (_field == "pitch")
		{
			return AutoValueData.F(playerEntity.orientation.Pitch);
		}
		if (_field == "yaw")
		{
			return AutoValueData.F(playerEntity.orientation.Yaw);
		}
		return AutoValueData;
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 4 && array[0] == "player")
		{
			return new AutoPlayerValue
			{
				_id = int.Parse(array[1]),
				_field = array[2],
				_idChange = ("true" == array[3])
			};
		}
		return null;
	}

	public override void SetValue(params string[] value)
	{
		if (value.Length >= 1)
		{
			if (_idChange && (int)Convert.ToSingle(value[0]) > 0)
			{
				_id = (int)Convert.ToSingle(value[0]);
			}
			else
			{
				_currentValue = (int)Convert.ToSingle(value[0]);
			}
		}
	}
}
