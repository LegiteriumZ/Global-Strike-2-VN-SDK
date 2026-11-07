using Assets.Sources.Config;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarDistance : BaseHpBar
{
	private Text _distanceText;

	private GameObject _distanceTextObj;

	private RectTransform _distanceTextTran;

	private Vector3 _lastDistancePos;

	private bool _lastDistanceActive = true;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_distanceText = Tran.Find("ScreenSpace/DistanceText").GetComponent<Text>();
		_distanceTextObj = _distanceText.gameObject;
		_distanceTextTran = _distanceText.rectTransform;
		SetActive(_distanceTextObj, ref _lastDistanceActive, newActive: false);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (!SameCameraTeam)
		{
			SetActive(_distanceTextObj, ref _lastDistanceActive, newActive: false);
		}
		else if (GameSetting.Config.SuggestFlag == 1 && !PlayerData.IsBot)
		{
			SetActive(_distanceTextObj, ref _lastDistanceActive, newActive: true);
			_distanceText.text = StringCache.IntToString(GetDistance(PlayerEntity));
			HpBar.PosY += 14;
			SetPosition(_distanceTextTran, ref _lastDistancePos, HpBar.NameTextPos + new Vector3(0f, (float)(HpBar.PosY - HpBar.NamePosY) * ScreenScale));
			HpBar.PosY += 10;
		}
		else
		{
			SetActive(_distanceTextObj, ref _lastDistanceActive, newActive: false);
		}
	}
}
