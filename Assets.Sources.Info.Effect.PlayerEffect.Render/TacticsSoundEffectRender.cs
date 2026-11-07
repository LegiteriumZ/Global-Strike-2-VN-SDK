using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class TacticsSoundEffectRender : AbstractPlayerEffectRender
{
	private SpriteList _backList;

	private Image _backAnima;

	private SpriteList _msgList;

	private Image _msgAnima;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		GameObject gameObject = effectGameObject.transform.Find("GameObject/1/sprite").gameObject;
		_backList = gameObject.GetComponent<SpriteList>();
		_backAnima = gameObject.GetComponent<Image>();
		GameObject gameObject2 = effectGameObject.transform.Find("GameObject/2/sprite").gameObject;
		_msgList = gameObject2.GetComponent<SpriteList>();
		_msgAnima = gameObject2.GetComponent<Image>();
		_backAnima.sprite = _backList.Sprites[0];
		_msgAnima.sprite = _msgList.Sprites[0];
		if (Contexts.sharedInstance.gameRule.currentRule.Rule.IsPve())
		{
			switch (player.GetTacticsSoundId())
			{
			case 2:
				_backAnima.sprite = _backList.Sprites[0];
				_msgAnima.sprite = _msgList.Sprites[2];
				break;
			case 3:
				_backAnima.sprite = _backList.Sprites[0];
				_msgAnima.sprite = _msgList.Sprites[1];
				break;
			case 4:
				_backAnima.sprite = _backList.Sprites[0];
				_msgAnima.sprite = _msgList.Sprites[6];
				break;
			case 5:
				_backAnima.sprite = _backList.Sprites[0];
				_msgAnima.sprite = _msgList.Sprites[5];
				break;
			case 6:
				_backAnima.sprite = _backList.Sprites[1];
				_msgAnima.sprite = _msgList.Sprites[3];
				break;
			case 7:
				_backAnima.sprite = _backList.Sprites[1];
				_msgAnima.sprite = _msgList.Sprites[4];
				break;
			}
		}
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer()));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}
}
