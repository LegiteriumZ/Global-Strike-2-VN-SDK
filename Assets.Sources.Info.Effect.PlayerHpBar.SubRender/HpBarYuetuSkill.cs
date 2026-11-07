using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.GameRule;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarYuetuSkill : BaseHpBar
{
	private RectTransform _bioLevelBackTran;

	private Image _bioShieldBackImage;

	private RectTransform _parentRectTransform;

	private Image _bioShieldUpImage;

	private Vector3 _lastPos;

	private bool _lastActive;

	private IGameRule _gameRule;

	private PlayerEntity owerEntity;

	private BattleRoomContext _battleRoomContext;

	private float maxPoint = 10f;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_bioShieldBackImage = Tran.Find("WorldSpace/BioYuetuSkill").GetComponent<Image>();
		_bioLevelBackTran = _bioShieldBackImage.rectTransform;
		_parentRectTransform = Tran.Find("WorldSpace").GetComponent<RectTransform>();
		_bioShieldUpImage = Tran.Find("WorldSpace/BioYuetuSkill/Up").GetComponent<Image>();
		SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
		_bioShieldUpImage.fillAmount = 0f;
		_gameRule = contexts.gameRule.currentRule.Rule;
		owerEntity = contexts.player.cameraOwnerEntity;
		_battleRoomContext = contexts.battleRoom;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (!playerEntity.basicInfo.IsDead)
		{
			bool flag = false;
			float fillAmount = 0f;
			if (_battleRoomContext.playerInfo.StatusDatas.ContainsKey(playerEntity.GetCharacterId()))
			{
				IMyDictionary<int, PlayerInfoComponent.StatusDes> myDictionary = _battleRoomContext.playerInfo.StatusDatas[playerEntity.GetCharacterId()];
				if (myDictionary.ContainsKey(PlayerInfoStatusConstant.YUETU_CARROT_JIAOXIE.ID))
				{
					if (PlayerCareerUtil.IsZombieHero(owerEntity.GetCareer()) || PlayerCareerUtil.IsNormalZombie(owerEntity.GetCareer()))
					{
						fillAmount = 1f;
						flag = true;
					}
				}
				else if (myDictionary.ContainsKey(PlayerInfoStatusConstant.YUETU_CARROT_CNT.ID) && owerEntity.GetCareer() == "yuetu")
				{
					fillAmount = (float)myDictionary[PlayerInfoStatusConstant.YUETU_CARROT_CNT.ID].Number / maxPoint;
					flag = true;
				}
			}
			if (flag)
			{
				_bioShieldUpImage.fillAmount = fillAmount;
				SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: true);
			}
			else
			{
				SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
			}
		}
		else
		{
			SetActive(_bioShieldBackImage.gameObject, ref _lastActive, newActive: false);
		}
	}

	public void SetPos(Transform tran, ref Vector3 lastPos, Vector3 newPos)
	{
		if (lastPos != newPos)
		{
			tran.localPosition = newPos;
			lastPos = newPos;
		}
	}
}
