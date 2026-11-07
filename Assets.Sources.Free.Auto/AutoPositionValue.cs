using System;
using Assets.Sources.Free.Data;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJMath;
using UnityEngine;
using share;

namespace Assets.Sources.Free.Auto;

public class AutoPositionValue : AbstractAutoValue
{
	private int id;

	private float distance;

	private float height;

	private float pitch;

	private float _angle;

	private bool hasEntity;

	public override string ValueToString()
	{
		return string.Concat(GetType().Name, " id : ", id, " player ", Contexts.sharedInstance.player.GetEntityWithEntityId(id), "  hasEntity : ", hasEntity.ToString());
	}

	public override AutoValueData Frame(int frameTime)
	{
		Matrix3D matrix3D = new Matrix3D();
		BattleModel gameModel = GameModelLocator.GetInstance().GameModel;
		PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(id);
		hasEntity = false;
		Vector3 data = Vector3.zero;
		float num = 0f;
		if (entityWithEntityId != null)
		{
			num = entityWithEntityId.orientation.Yaw + gameModel.ShakeAngleOffect.x;
			data = entityWithEntityId.GetCompenstatePos(entityWithEntityId.fpos.Change.GetPosIndex());
			hasEntity = true;
		}
		else
		{
			SceneObjectEntity entityWithEntityId2 = Contexts.sharedInstance.sceneObject.GetEntityWithEntityId(id);
			if (entityWithEntityId2 != null)
			{
				if (entityWithEntityId2.hasMoveObject)
				{
					num = entityWithEntityId2.moveObject.PitchYawRoll.x + gameModel.ShakeAngleOffect.x;
					matrix3D.SetM(5, entityWithEntityId2.moveObject.PitchYawRoll.z);
					matrix3D.SetM(4, entityWithEntityId2.moveObject.PitchYawRoll.y);
					matrix3D.SetM(3, entityWithEntityId2.moveObject.PitchYawRoll.x);
					matrix3D.SetM(11, 1.0);
				}
				if (entityWithEntityId2.hasPosition)
				{
					data = entityWithEntityId2.position.Origin;
				}
				matrix3D.SetM(9, id);
				hasEntity = true;
			}
		}
		if (!hasEntity)
		{
			return AutoValueData.M(null);
		}
		num += _angle;
		Vector3D vector3D = new Vector3D();
		Vector3D vector3D2 = new Vector3D();
		Vector3D vector3D3 = new Vector3D();
		Vector3D vector3D4 = new Vector3D();
		vector3D3.SetTo(-10.0, -10.0, -10.0);
		vector3D4.SetTo(10.0, 10.0, 10.0);
		AngleUtility.AnglesToVector(num, pitch, vector3D);
		vector3D.ScaleBy(-1f);
		MathExtension.Vector3DMA(VectorTypeConverter.Unity2Ssjj(data), distance, vector3D, vector3D2);
		matrix3D.SetM(0, vector3D2.x);
		matrix3D.SetM(1, vector3D2.y);
		matrix3D.SetM(2, vector3D2.z + (double)height);
		return AutoValueData.M(matrix3D);
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length >= 6 && array[0] == "position")
		{
			AutoPositionValue autoPositionValue = new AutoPositionValue();
			if (!int.TryParse(array[1], out autoPositionValue.id))
			{
				this.LogErrorFormat("id error : {0}", array[1]);
			}
			autoPositionValue.distance = Convert.ToSingle(array[2]);
			autoPositionValue.height = Convert.ToSingle(array[3]);
			autoPositionValue.pitch = Convert.ToSingle(array[4]);
			autoPositionValue._angle = Convert.ToSingle(array[5]);
			return autoPositionValue;
		}
		return null;
	}
}
