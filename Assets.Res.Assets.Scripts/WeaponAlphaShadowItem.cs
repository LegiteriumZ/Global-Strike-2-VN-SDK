using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class WeaponAlphaShadowItem : MonoBehaviour
{
	[NonSerialized]
	[HideInInspector]
	public Color StartColor;

	public MeshRenderer MeshRenderer;

	public bool IsStart;

	private WeaponAlphaShadowFactory.WeaponAlphaShadowAssembly _playerAlphaShadowItem;

	public float Interval;

	private WeaponAlphaShadow _alphaShadow;

	private PlayerEntity _playerEntity;

	public void InitData(WeaponAlphaShadow alphaShadow, float interval, Color startColor, MeshRenderer meshRenderer, WeaponAlphaShadowFactory.WeaponAlphaShadowAssembly playerAlphaShadowItem, PlayerEntity entity)
	{
		_alphaShadow = alphaShadow;
		Interval = interval;
		MeshRenderer = meshRenderer;
		IsStart = true;
		StartColor = startColor;
		_playerAlphaShadowItem = playerAlphaShadowItem;
		_playerEntity = entity;
	}

	public void Stop()
	{
		IsStart = false;
	}

	private void Update()
	{
		if (!IsStart)
		{
			return;
		}
		Interval -= Time.deltaTime;
		if (Interval <= 0f)
		{
			if (_alphaShadow.list.Contains(this))
			{
				_alphaShadow.list.Remove(this);
			}
			_alphaShadow.Release(_playerAlphaShadowItem);
		}
	}
}
