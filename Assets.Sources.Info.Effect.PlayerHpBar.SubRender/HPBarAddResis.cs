using NetData;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HPBarAddResis : BaseHpBar
{
	private GameObject bgYan;

	private GameObject bgYin;

	private Image yanHpImage;

	private Image yinHpImahe;

	private bool _bgYanActive = true;

	private bool _bgYinActive = true;

	private bool _addResisHpActive = true;

	private GameObject _addResisHpBack;

	private PlayerContext _playerContext;

	public new PlayerEntityData PlayerData;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_addResisHpBack = Tran.Find("WorldSpace/AddResis").gameObject;
		yanHpImage = Tran.Find("WorldSpace/AddResis/bgYan/YanHpImage").GetComponent<Image>();
		yinHpImahe = Tran.Find("WorldSpace/AddResis/bgYin/YinHpImage").GetComponent<Image>();
		_playerContext = contexts.player;
		PlayerData = playerEntity.basicInfo.Current;
		bgYan = Tran.Find("WorldSpace/AddResis/bgYan").gameObject;
		bgYin = Tran.Find("WorldSpace/AddResis/bgYin").gameObject;
		bgYan.gameObject.SetActive(value: false);
		bgYin.gameObject.SetActive(value: false);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (PlayerData.BotQuality >= 3 || _playerContext.cameraOwnerEntity.normalTrace.EntityId != playerEntity.entityId.Value)
		{
			SetActive(_addResisHpBack, ref _addResisHpActive, newActive: false);
			return;
		}
		SetActive(bgYin, ref _bgYinActive, PlayerData.CritDefMaxHp > 0);
		SetActive(bgYan, ref _bgYanActive, PlayerData.CritRateDefMaxHp > 0);
		if (_bgYinActive)
		{
			yinHpImahe.fillAmount = (float)PlayerData.CritDefHp / (float)PlayerData.CritDefMaxHp;
		}
		if (_bgYanActive)
		{
			yanHpImage.fillAmount = (float)PlayerData.CritRateDefHp / (float)PlayerData.CritRateDefMaxHp;
		}
	}
}
