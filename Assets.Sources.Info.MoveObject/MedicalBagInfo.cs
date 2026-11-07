using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

internal class MedicalBagInfo : AbstractMoveObjectInfo
{
	private float yMaxOffset = 20f;

	private float yOffset;

	private bool floatUp = true;

	private GameObject gameObj;

	public override void InitEntity(SceneObjectEntity entity)
	{
		base.InitEntity(entity);
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (!(gameObject == null))
		{
			gameObj = gameObject;
			VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
			gameObj.transform.position = dest;
			gameObj.transform.Rotate(new Vector3(0f, 300f * Time.deltaTime, 0f));
			UpdateModelPos();
		}
	}

	private void UpdateModelPos()
	{
		if (floatUp)
		{
			yOffset += 10f * Time.deltaTime;
		}
		else
		{
			yOffset -= 10f * Time.deltaTime;
		}
		if (yOffset > yMaxOffset)
		{
			floatUp = false;
		}
		else if (yOffset < 0f - yMaxOffset)
		{
			floatUp = true;
		}
		gameObj.transform.position += new Vector3(0f, yOffset, 0f);
	}
}
