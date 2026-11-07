using System;
using SSJJBase.Extensions;
using SSJJBase.Logger;

namespace Assets.Sources.Free.Auto;

public class AutoRotateValue : AbstractAutoValue
{
	private int id;

	private int angle;

	public override string ValueToString()
	{
		return GetType().Name + " id : " + id + " player " + Contexts.sharedInstance.player.GetEntityWithEntityId(id);
	}

	public override AutoValueData Frame(int frameTime)
	{
		PlayerEntity playerEntity = Contexts.sharedInstance.player.GetEntityWithEntityId(id);
		if (playerEntity == null)
		{
			playerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		}
		if (playerEntity == null)
		{
			return AutoValueData.F(angle);
		}
		return AutoValueData.F((float)angle + playerEntity.orientation.Yaw);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length == 3 && array[0] == "rotate")
		{
			AutoRotateValue autoRotateValue = new AutoRotateValue();
			if (!int.TryParse(array[1], out autoRotateValue.id))
			{
				this.LogErrorFormat("id error : {0}", array[1]);
			}
			autoRotateValue.angle = (int)Convert.ToSingle(array[2]);
			return autoRotateValue;
		}
		return null;
	}
}
