using System.Collections.Generic;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class PlayerWaterEffectRender : AbstractSceneEffectRender
{
	public static List<Vector3> WaterFaces = new List<Vector3>();

	private List<GameObject> _imageList = new List<GameObject>();

	private List<int> _timeList = new List<int>();

	private Dictionary<int, Vector3> _lastPos = new Dictionary<int, Vector3>();

	private Dictionary<int, int> _createTime = new Dictionary<int, int>();

	private const int LifeTime = 750;

	private const int MaxNum = 10;

	private const int CreateTime = 150;

	private PlayerContext _playerContext;

	private int _index;

	public override void Init(SceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		for (int i = 0; i < 10; i++)
		{
			_imageList.Add(effectGameObject.transform.Find("GameObject/Image" + (1 + i)).gameObject);
			_imageList[i].SetObjectActive(isactive: false);
			_timeList.Add(750);
		}
		_playerContext = Contexts.sharedInstance.player;
	}

	private bool IsInWater(Vector3 pos)
	{
		for (int i = 0; i < WaterFaces.Count; i += 2)
		{
			Vector3 vector = WaterFaces[i];
			Vector3 vector2 = WaterFaces[i + 1];
			if (pos.x > vector.x && pos.x < vector2.x && pos.y < vector2.y && pos.z > vector.z && pos.z < vector2.z)
			{
				return true;
			}
		}
		return false;
	}

	public override void Render(int frameTime, SceneObjectEntity entity)
	{
		if (EffectObject == null && entity.hasUnityObjects)
		{
			Init(entity, entity.unityObjects.LoadResults[0].GameObject);
		}
		if (EffectObject == null)
		{
			return;
		}
		for (int i = 0; i < _imageList.Count; i++)
		{
			if (_imageList[i].IsActiveSelf())
			{
				_timeList[i] += frameTime;
				if (_timeList[i] > 750)
				{
					_imageList[i].SetObjectActive(isactive: false);
				}
			}
		}
		foreach (PlayerEntity item in _playerContext)
		{
			int id = item.GetId();
			if (!_createTime.ContainsKey(id))
			{
				_createTime.Add(id, 0);
			}
			if (!_lastPos.ContainsKey(id))
			{
				_lastPos.Add(id, Vector3.zero);
			}
			_createTime[id] += frameTime;
			if (_lastPos[id] == item.GetCompenstatePos(item.fpos.Change.GetPosIndex()) || !IsInWater(VectorCoordConverter.SsjjToUnity(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()))) || _createTime[id] < 150)
			{
				continue;
			}
			_lastPos[id] = item.GetCompenstatePos(item.fpos.Change.GetPosIndex());
			_createTime[id] = 0;
			for (int j = 1; j < _imageList.Count; j++)
			{
				_index = (_index + j) % _imageList.Count;
				if (!_imageList[_index].IsActiveSelf())
				{
					_timeList[_index] = 0;
					_imageList[_index].SetObjectActive(isactive: true);
					_imageList[_index].transform.position = VectorCoordConverter.SsjjToUnity(_lastPos[id]);
					break;
				}
			}
		}
	}
}
