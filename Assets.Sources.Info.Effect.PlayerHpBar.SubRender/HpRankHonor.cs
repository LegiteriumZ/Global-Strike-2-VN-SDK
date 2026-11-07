using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils;
using NetData;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpRankHonor : BaseHpBar
{
	private Image _titleImage;

	private GameObject _titleImageObj;

	private RectTransform _titleImageTran;

	private Text _titleDes;

	private int _maxhonorDesIndex = 26;

	private Vector3 _lastTitlePos;

	private bool _lastTitleActive = true;

	private bool _titleLoaded;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_titleImage = Tran.Find("WorldSpace/RankHonorImage").GetComponent<Image>();
		_titleImageObj = _titleImage.gameObject;
		_titleImageTran = _titleImage.rectTransform;
		_titleDes = Tran.Find("WorldSpace/RankHonorImage/HonorDes").GetComponent<Text>();
		SetActive(_titleImageObj, ref _lastTitleActive, newActive: false, force: true);
	}

	public bool IsSuggestTitle(PlayerEntity playerEntity)
	{
		if (playerEntity.IsDead())
		{
			return false;
		}
		if (playerEntity.IsBot())
		{
			return false;
		}
		if (UiIEventCondition.Get_uiRoomData_IsMatch())
		{
			if (UiIEventCondition.Get_uiRoomData_IsMatchWaitPlayer())
			{
				return true;
			}
			if (UiIEventCondition.Get_uiSectionTime_NotMoveTime() > 0)
			{
				return true;
			}
		}
		return false;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (IsSuggestTitle(playerEntity) && playerEntity.hasObserverInfo)
		{
			ObserverInfoData data = playerEntity.observerInfo.Data;
			if (data == null)
			{
				return;
			}
			if (!_titleLoaded)
			{
				_titleLoaded = true;
				Loader.RetriveSprite("ui/halfLoadedRes/playerRaceRankSect", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerRaceRankSect/raceranksect{data.RaceRankSect}.png", delegate(Sprite sprite)
				{
					_titleImage.sprite = sprite;
				});
				_titleDes.text = HonorUtility.GetRankLvName(data.RaceRankSect, data.RaceRankLv);
			}
			HpBar.PosY += 30;
			SetPosition(_titleImageTran, ref _lastTitlePos, new Vector3(0f, HpBar.PosY));
			HpBar.PosY += 30;
			SetActive(_titleImageObj, ref _lastTitleActive, newActive: true);
		}
		else
		{
			SetActive(_titleImageObj, ref _lastTitleActive, newActive: false);
		}
	}
}
