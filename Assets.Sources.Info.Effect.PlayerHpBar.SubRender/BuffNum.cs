using Assets.Sources.Components.Interface.Info.GameRule;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class BuffNum : BaseHpBar
{
	private Transform _buffNumTran;

	private GameObject _buffNumObj;

	private Text _buffNumText;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private IGameRule _gameRule;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_buffNumTran = Tran.Find("WorldSpace/buffNum");
		_buffNumObj = _buffNumTran.gameObject;
		_buffNumText = Tran.Find("WorldSpace/buffNum/buffNum_text").GetComponent<Text>();
		_gameRule = contexts.gameRule.currentRule.Rule;
		_lastActive = false;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (playerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.HERO_GUANZITOU_BUFF_COUNT.ID))
		{
			SetActive(_buffNumObj, ref _lastActive, newActive: true);
			_buffNumText.text = playerEntity.skill.Status[PlayerInfoStatusConstant.HERO_GUANZITOU_BUFF_COUNT.ID].Number.ToString();
		}
		else
		{
			SetActive(_buffNumObj, ref _lastActive, newActive: false);
		}
	}
}
