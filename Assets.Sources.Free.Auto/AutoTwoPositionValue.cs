using System;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJMath;
using share;

namespace Assets.Sources.Free.Auto;

public class AutoTwoPositionValue : AbstractAutoValue
{
	private int source;

	private int target;

	private float distance;

	private float height;

	private bool toSource;

	public override AutoValueData Frame(int frameTime)
	{
		Vector3D vector3D = new Vector3D();
		PlayerEntity playerEntity = Contexts.sharedInstance.player.GetEntityWithEntityId(source);
		if (playerEntity == null)
		{
			playerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		}
		PlayerEntity playerEntity2 = Contexts.sharedInstance.player.GetEntityWithEntityId(target);
		if (playerEntity2 == null)
		{
			playerEntity2 = Contexts.sharedInstance.player.myPlayerEntity;
		}
		Vector3D v = VectorTypeConverter.Unity2Ssjj(playerEntity2.GetCompenstatePos(playerEntity2.fpos.Change.GetPosIndex())).Subtract(VectorTypeConverter.Unity2Ssjj(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())));
		if (toSource)
		{
			v = VectorTypeConverter.Unity2Ssjj(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())).Subtract(VectorTypeConverter.Unity2Ssjj(playerEntity2.GetCompenstatePos(playerEntity2.fpos.Change.GetPosIndex())));
		}
		Vector3D vector3D2 = new Vector3D();
		AngleUtility.VectorToAngles(v, vector3D2);
		double x = vector3D2.x;
		Vector3D vector3D3 = new Vector3D();
		Vector3D vector3D4 = new Vector3D();
		Vector3D vector3D5 = new Vector3D();
		Vector3D vector3D6 = new Vector3D();
		vector3D5.SetTo(-10.0, -10.0, -10.0);
		vector3D6.SetTo(10.0, 10.0, 10.0);
		AngleUtility.AnglesToVector(x, 0.0, vector3D3);
		vector3D3.ScaleBy(-1f);
		if (toSource)
		{
			MathExtension.Vector3DMA(VectorTypeConverter.Unity2Ssjj(playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())), distance, vector3D3, vector3D4);
		}
		else
		{
			MathExtension.Vector3DMA(VectorTypeConverter.Unity2Ssjj(playerEntity2.GetCompenstatePos(playerEntity2.fpos.Change.GetPosIndex())), distance, vector3D3, vector3D4);
		}
		vector3D.x = vector3D4.x;
		vector3D.y = vector3D4.y;
		vector3D.z = vector3D4.z + (double)height;
		return AutoValueData.V(vector3D);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 6 && array[0] == "tposition")
		{
			AutoTwoPositionValue autoTwoPositionValue = new AutoTwoPositionValue();
			if (!int.TryParse(array[1], out autoTwoPositionValue.source))
			{
				this.LogErrorFormat("sourceId error : {0}", array[1]);
			}
			if (!int.TryParse(array[2], out autoTwoPositionValue.target))
			{
				this.LogErrorFormat("targetId error : {0}", array[2]);
			}
			autoTwoPositionValue.distance = Convert.ToSingle(array[3]);
			autoTwoPositionValue.height = Convert.ToSingle(array[4]);
			autoTwoPositionValue.toSource = array[5] == "true";
			return autoTwoPositionValue;
		}
		return null;
	}
}
