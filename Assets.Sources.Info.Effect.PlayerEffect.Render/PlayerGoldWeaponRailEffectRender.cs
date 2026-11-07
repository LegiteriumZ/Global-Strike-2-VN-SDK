using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerGoldWeaponRailEffectRender : AbstractPlayerEffectRender
{
	private List<GameObject> _imageList = new List<GameObject>();

	private List<int> _timeList = new List<int>();

	private Vector3 _lastPos;

	private int _createTime;

	private const int LifeTime = 750;

	private const int MaxNum = 8;

	private const int CreateTime = 100;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		for (int i = 0; i < 8; i++)
		{
			_imageList.Add(effectGameObject.transform.Find("GameObject/Image" + (1 + i)).gameObject);
			_imageList[i].SetObjectActive(isactive: false);
			_timeList.Add(750);
		}
		_lastPos = VectorCoordConverter.SsjjToUnity(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		for (int i = 0; i < _imageList.Count; i++)
		{
			if (_imageList[i].IsActiveSelf())
			{
				_timeList[i] += frameTime;
				if (_timeList[i] > 750 && _imageList[i].IsActiveSelf())
				{
					_imageList[i].SetObjectActive(isactive: false);
				}
			}
		}
		_createTime += frameTime;
		Vector3 vector = VectorCoordConverter.SsjjToUnity(targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex()));
		if (_lastPos == vector)
		{
			return;
		}
		_lastPos = vector;
		if (_createTime < 100)
		{
			return;
		}
		_createTime = 0;
		for (int j = 0; j < _imageList.Count; j++)
		{
			if (!_imageList[j].IsActiveSelf())
			{
				_timeList[j] = 0;
				_imageList[j].SetObjectActive(isactive: true);
				_imageList[j].transform.position = _lastPos;
				break;
			}
		}
	}

	public override void Update(int frameTime, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room)
	{
	}
}
