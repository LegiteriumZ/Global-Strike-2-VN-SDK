using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerRobChickenRender : AbstractPlayerEffectRender
{
	private List<GameObject> _list = new List<GameObject>();

	private List<Vector3> _pos = new List<Vector3>();

	private GameObject _effectGameObject;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		for (int i = 1; i <= 9; i++)
		{
			_list.Add(effectGameObject.transform.Find("PlayerRobChicken/" + i).gameObject);
		}
		_effectGameObject = effectGameObject;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		int num = 10;
		int num2 = targetPlayer.GetPlayerInfo().ChickenNum + 5;
		int i = 1;
		int num3 = _pos.Count - num;
		for (; i <= num2; i++)
		{
			_list[i - 1].SetObjectActive(isactive: true);
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (_pos.Count > num)
			{
				_list[i - 1].transform.position = _pos[num3];
			}
			num3 -= num;
		}
		for (; i <= 9; i++)
		{
			_list[i - 1].SetObjectActive(isactive: false);
		}
		if (_pos.Count < num || Vector3.Distance(_effectGameObject.transform.position, _pos[_pos.Count - 1]) >= 1f)
		{
			_pos.Add(_effectGameObject.transform.position);
		}
		while (_pos.Count > 15 * num)
		{
			_pos.RemoveAt(0);
		}
	}
}
