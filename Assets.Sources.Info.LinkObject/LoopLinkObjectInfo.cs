using System.Collections.Generic;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.LinkObject;

public class LoopLinkObjectInfo : AbstractLinkObjectInfo
{
	private GameObject _go;

	private List<GameObject> _gos = new List<GameObject>();

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (_go == null)
		{
			if (gameObject.transform.GetChild(0) == null)
			{
				return;
			}
			_go = gameObject.transform.GetChild(0).gameObject;
			_go.transform.localPosition = Vector3.zero;
			_gos.Add(_go);
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>(includeInactive: true);
			int num = 1;
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				if (transform.name.EndsWith("(Clone)(Clone)"))
				{
					transform.localPosition = new Vector3(0f, 0f, (float)num++ * UnitLength);
					_gos.Add(transform.gameObject);
				}
			}
		}
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpEnd, out var dest2);
		float num2 = Vector3.Distance(dest, dest2);
		int num3 = (int)(num2 / UnitLength);
		Debug.Log(num2 + " ==========> " + num3 + " ==========> " + UnitLength);
		if (_gos.Count < num3)
		{
			for (int j = _gos.Count; j < num3; j++)
			{
				_gos.Add(Object.Instantiate(_go, gameObject.transform));
				_gos[j].transform.localPosition = new Vector3(0f, 0f, (float)j * UnitLength);
			}
		}
		else
		{
			for (int k = 0; k < num3; k++)
			{
				_gos[k].SetActive(value: true);
			}
			for (int l = num3; l < _gos.Count; l++)
			{
				_gos[l].SetActive(value: false);
			}
		}
		gameObject.transform.position = dest;
		gameObject.transform.localScale = new Vector3(1f, 1f, num2 / (UnitLength * (float)num3));
		gameObject.transform.LookAt(dest2);
	}
}
