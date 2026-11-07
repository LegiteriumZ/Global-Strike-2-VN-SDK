using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarTitle : BaseHpBar
{
	private Image _TitleImage;

	private GameObject _TitleImageObj;

	private RectTransform _TitleImageTran;

	private Vector3 _lastTitlePos;

	private bool _lastTitleActive = true;

	private bool _TitleLoaded;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_TitleImage = Tran.Find("WorldSpace/TitleImage").GetComponent<Image>();
		_TitleImageObj = _TitleImage.gameObject;
		_TitleImageTran = _TitleImage.rectTransform;
		SetActive(_TitleImageObj, ref _lastTitleActive, newActive: false);
	}

	public bool IsSuggestTitle(PlayerEntity playerEntity)
	{
		if (playerEntity.GetStealthAlpha() <= 0.8f)
		{
			return false;
		}
		if (playerEntity.IsDead())
		{
			return false;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.PLAYER_USING_CHEATING_FLAG.ID))
		{
			HpBar.PosY += 30;
			SetPosition(_TitleImageTran, ref _lastTitlePos, new Vector3(0f, HpBar.PosY));
			Vector3 vector = (Vector3)RectTransformUtility.WorldToScreenPoint(MainCamera, _TitleImageTran.position) - new Vector3(Screen.width, Screen.height) / 2f;
			HpBar.TitlePos = new Vector3((int)vector.x, (int)vector.y, (int)vector.z);
			HpBar.PosY += 30;
			return false;
		}
		if (playerEntity.basicInfo.Current.TitleId <= 0 && playerEntity.hasHonorary)
		{
			playerEntity.honorary.ForceShowTitle = false;
			return false;
		}
		if (!GameRule.IsGeneralPve() && playerEntity.hasHonorary)
		{
			if (playerEntity.honorary.NumHonorary > 0)
			{
				if (!RuleUtilty.IsTurnBasedModel(battleContext.roomData.Data.RaceType) || battleContext.roomData.Data.SectionTime - battleContext.sectionTime.SectionTime > 5000)
				{
					playerEntity.honorary.ForceShowTitle = false;
					return false;
				}
				playerEntity.honorary.ForceShowTitle = true;
			}
			else
			{
				playerEntity.honorary.ForceShowTitle = true;
			}
		}
		Vector3 uiMyPlayer_Position = UiIEventCondition.Get_uiMyPlayer_Position();
		float num = uiMyPlayer_Position.x - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).x;
		float num2 = uiMyPlayer_Position.y - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).y;
		float num3 = uiMyPlayer_Position.z - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).z;
		if (num * num + num2 * num2 + num3 * num3 > 100000000f)
		{
			return false;
		}
		playerEntity.IsBot();
		if (2 == GameSetting.Config.SuggestFlag)
		{
			return false;
		}
		return UiIEventCondition.Get_uiMyPlayer_Team() == playerEntity.GetTeam();
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		PlayerTitleEffectData titleEffectData = ParticleManager.Instance().GetTitleEffectData(playerEntity.basicInfo.Current.TitleId);
		if (titleEffectData != null && titleEffectData.viewHeightTop)
		{
			SetActive(_TitleImageObj, ref _lastTitleActive, newActive: false);
		}
		else if (IsSuggestTitle(playerEntity))
		{
			int titleId = playerEntity.basicInfo.Current.TitleId;
			if (!_TitleLoaded)
			{
				_TitleLoaded = true;
				Loader.RetriveSprite("ui/halfLoadedRes/playerHononary", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerHononary/{titleId}.png", delegate(Sprite sprite)
				{
					_TitleImage.sprite = sprite;
				});
			}
			HpBar.PosY += 30;
			SetPosition(_TitleImageTran, ref _lastTitlePos, new Vector3(0f, HpBar.PosY));
			HpBar.PosY += 30;
			SetActive(_TitleImageObj, ref _lastTitleActive, newActive: true);
		}
		else
		{
			SetActive(_TitleImageObj, ref _lastTitleActive, newActive: false);
		}
	}
}
