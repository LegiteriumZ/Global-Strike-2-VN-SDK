using UnityEngine;

namespace Assets.Sources.Info.CyberStyle;

public class CyberMonster : MonoBehaviour
{
	public CyberMonsterConfigItem arise;

	public CyberMonsterConfigItem show;

	public CyberMonsterConfigItem dispos;

	private MaterialPropertyBlock _materialPropertyBlock;

	public SkinnedMeshRenderer meshRenderer;

	public float time;

	public int state;

	public CyberMonsterConfigItem currentState;

	public PlayerEntity playerEntity;

	public void OnEnable()
	{
		_materialPropertyBlock = new MaterialPropertyBlock();
		UpdateState(0);
	}

	public void Update()
	{
		if (playerEntity != null && playerEntity.basicInfo.IsDead)
		{
			Disable();
			playerEntity = null;
		}
		if (state == 2)
		{
			time += Time.deltaTime;
			_materialPropertyBlock.SetFloat("_DissolveAmount", time / currentState.time);
			meshRenderer.SetPropertyBlock(_materialPropertyBlock);
		}
		else
		{
			if (state != 0)
			{
				return;
			}
			if (time > currentState.time)
			{
				if (state != 1)
				{
					UpdateState(1);
					meshRenderer.SetPropertyBlock(_materialPropertyBlock);
				}
			}
			else
			{
				time += Time.deltaTime;
				_materialPropertyBlock.SetFloat("_DissolveAmount", 1f - time / currentState.time);
				meshRenderer.SetPropertyBlock(_materialPropertyBlock);
			}
		}
	}

	public void Disable()
	{
		UpdateState(2);
	}

	public void UpdateState(int id)
	{
		state = id;
		switch (state)
		{
		case 0:
			currentState = arise;
			_materialPropertyBlock.SetFloat("_Model", 1f);
			break;
		case 1:
			currentState = show;
			_materialPropertyBlock.SetFloat("_Model", 2f);
			_materialPropertyBlock.SetFloat("_DissolveAmount", currentState.rimAmount);
			_materialPropertyBlock.SetFloat("_RimAlpha", currentState.rimAlpha);
			_materialPropertyBlock.SetFloat("_ScanAmount", currentState.scanAmount);
			break;
		case 2:
			currentState = dispos;
			_materialPropertyBlock.SetFloat("_Model", 0f);
			break;
		}
		time = 0f;
		_materialPropertyBlock.SetColor("_EdgeColor", currentState.color);
		_materialPropertyBlock.SetFloat("_EdgeWidth", currentState.edgeWidth);
	}
}
