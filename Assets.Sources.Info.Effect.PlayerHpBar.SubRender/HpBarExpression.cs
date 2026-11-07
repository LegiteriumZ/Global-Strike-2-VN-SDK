using Assets.Sources.Components.GameRule.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarExpression : BaseHpBar
{
	private GameObject _expressionObj;

	private Image _expressionImage;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private GameRuleContext _gameRule;

	private string _codeName;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_expressionImage = Tran.Find("WorldSpace/ExpressionImage").GetComponent<Image>();
		_expressionObj = _expressionImage.gameObject;
		SetActive(_expressionObj, ref _lastActive, newActive: false);
		_gameRule = contexts.gameRule;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (_gameRule.personalized.ShowExpressions == null)
		{
			return;
		}
		int value = playerEntity.entityId.Value;
		ShowExpression showExpression = null;
		for (int i = 0; i < _gameRule.personalized.ShowExpressions.Count; i++)
		{
			if (_gameRule.personalized.ShowExpressions[i].Id == value)
			{
				showExpression = _gameRule.personalized.ShowExpressions[i];
				break;
			}
		}
		if (showExpression == null || showExpression.RemainTime <= 0)
		{
			SetActive(_expressionObj, ref _lastActive, newActive: false);
			return;
		}
		if (string.IsNullOrEmpty(_codeName) || !_codeName.Equals(showExpression.CodeName))
		{
			Loader.RetriveSprite("ui/halfLoadedres/expression", showExpression.CodeName + ".png", delegate(Sprite sprite)
			{
				_expressionImage.sprite = sprite;
				SetActive(_expressionObj, ref _lastActive, newActive: true);
			});
			_codeName = showExpression.CodeName;
		}
		HpBar.PosY += 30;
		SetPosition(_expressionObj.transform, ref _lastPos, new Vector3(0f, HpBar.PosY));
		HpBar.PosY += 30;
	}
}
