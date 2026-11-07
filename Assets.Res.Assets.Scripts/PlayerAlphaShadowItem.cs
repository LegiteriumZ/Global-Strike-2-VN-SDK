using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class PlayerAlphaShadowItem : MonoBehaviour
{
	[NonSerialized]
	[HideInInspector]
	public Color StartColor;

	public MeshRenderer MeshRenderer;

	public bool IsStart;

	private PlayerAlphaShadowFactory.PlayerAlphaShadowAssembly _playerAlphaShadowItem;

	public float Interval;

	private PlayerAlphaShadow _alphaShadow;

	private PlayerEntity _playerEntity;

	public void InitData(PlayerAlphaShadow alphaShadow, float interval, Color startColor, MeshRenderer meshRenderer, PlayerAlphaShadowFactory.PlayerAlphaShadowAssembly playerAlphaShadowItem, PlayerEntity entity)
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
		if ((bool)MeshRenderer.material)
		{
			for (int i = 0; i < MeshRenderer.materials.Length; i++)
			{
				_playerAlphaShadowItem.Block.SetColor("_Color", StartColor);
				_playerAlphaShadowItem.MeshRenderer.SetPropertyBlock(_playerAlphaShadowItem.Block);
			}
		}
		Interval -= Time.deltaTime;
		if (Interval <= 0f || (_playerEntity.hasBasicInfo && ((_playerEntity.basicInfo.Current.Id == Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.Id) & !Contexts.sharedInstance.player.cameraOwnerEntity.isThirdPersonView)))
		{
			if (_alphaShadow.list.Contains(this))
			{
				_alphaShadow.list.Remove(this);
			}
			_alphaShadow.Release(_playerAlphaShadowItem);
		}
	}
}
