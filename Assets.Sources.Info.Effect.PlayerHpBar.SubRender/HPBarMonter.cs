using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HPBarMonter : BaseHpBar
{
	private Image _hpBackImage;

	private RectTransform _hpBackTran;

	private GameObject _hpBackObj;

	private Image _hpProgress;

	private Image _hdProgress;

	private Image _zjProgress;

	private Image _locklProgress;

	private Image _lockrProgress;

	private GameObject _lockTran;

	private bool _lastlocakActive = true;

	private bool _lasthpActive = true;

	private long _currHp;

	private long _currMaxHp;

	private long _currHd;

	private long _currMaxHd;

	private long _currZj;

	private long _currMaxZj;

	private string _name;

	private Text _text;

	private Text _lockName;

	private bool _lasthpThosActive = true;

	private GameObject _monsterHpBack;

	private PlayerContext _playerContext;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_hpBackImage = Tran.Find("WorldSpace/HpBack").GetComponent<Image>();
		_hpBackTran = _hpBackImage.rectTransform;
		_monsterHpBack = Tran.Find("WorldSpace/MonsterHpBack").gameObject;
		_lockTran = Tran.Find("WorldSpace/MonsterHpBack/lockHp").gameObject;
		_locklProgress = Tran.Find("WorldSpace/MonsterHpBack/lockHp/lockl").GetComponent<Image>();
		_lockrProgress = Tran.Find("WorldSpace/MonsterHpBack/lockHp/lockr").GetComponent<Image>();
		_hpBackObj = _hpBackTran.gameObject;
		SetActive(_hpBackObj, ref _lasthpActive, newActive: false);
		_hpProgress = Tran.Find("WorldSpace/MonsterHpBack/HpProgress").GetComponent<Image>();
		_hdProgress = Tran.Find("WorldSpace/MonsterHpBack/HdProgress").GetComponent<Image>();
		_zjProgress = Tran.Find("WorldSpace/MonsterHpBack/ZjProgress").GetComponent<Image>();
		_text = Tran.Find("WorldSpace/MonsterHpBack/Name").GetComponent<Text>();
		_lockName = Tran.Find("WorldSpace/MonsterHpBack/lockHp/LockName").GetComponent<Text>();
		_playerContext = contexts.player;
		int num = 4;
		for (int i = 0; i < PlayerData.LifeBarSeq.Count; i++)
		{
			if (PlayerData.LifeBarSeq[i] == 3)
			{
				_zjProgress.transform.localPosition = new Vector3(0f, num, 0f);
			}
			if (PlayerData.LifeBarSeq[i] == 2)
			{
				_hdProgress.transform.localPosition = new Vector3(0f, num, 0f);
			}
			if (PlayerData.LifeBarSeq[i] == 1)
			{
				_hpProgress.transform.localPosition = new Vector3(0f, num, 0f);
			}
			num -= 4;
		}
		_hpProgress.gameObject.SetActive(value: false);
		_zjProgress.gameObject.SetActive(value: false);
		_hdProgress.gameObject.SetActive(value: false);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (PlayerData.BotQuality >= 3 || _playerContext.cameraOwnerEntity.normalTrace.EntityId != playerEntity.entityId.Value)
		{
			SetActive(_monsterHpBack, ref _lasthpThosActive, newActive: false);
			return;
		}
		if (PlayerData.MaxHudun > 0 || PlayerData.MaxZhuangjia > 0)
		{
			SetActive(_hpBackObj, ref _lasthpActive, newActive: false);
			SetActive(_monsterHpBack, ref _lasthpThosActive, newActive: true);
		}
		if (PlayerData.IsLockBlood)
		{
			SetActive(_lockTran, ref _lastlocakActive, newActive: true);
			_locklProgress.fillAmount = (float)PlayerData.LockBloodPercent / 100f;
			_lockrProgress.fillAmount = (float)PlayerData.LockBloodPercent / 100f;
			return;
		}
		SetActive(_lockTran, ref _lastlocakActive, newActive: false);
		if (!playerEntity.basicInfo.PlayerName.Equals(_name))
		{
			_name = playerEntity.basicInfo.PlayerName;
			_text.text = _name;
		}
		bool[] array = new bool[3];
		for (int i = 0; i < PlayerData.LifeBarSeq.Count; i++)
		{
			array[PlayerData.LifeBarSeq[i] - 1] = true;
		}
		if ((PlayerData.Hp != _currHp || PlayerData.MaxHp != _currMaxHp) && array[0])
		{
			_currHp = PlayerData.Hp;
			_currMaxHp = PlayerData.MaxHp;
			float num = ((PlayerData.MaxHp > 0) ? ((float)PlayerData.Hp / (float)PlayerData.MaxHp) : 0f);
			_hpProgress.fillAmount = num;
			_hpProgress.gameObject.SetObjectActive(!Mathf.Approximately(num, 0f));
		}
		if ((PlayerData.Hudun != _currHd || PlayerData.MaxHudun != _currMaxHd) && array[1])
		{
			_currHd = PlayerData.Hudun;
			_currMaxHd = PlayerData.MaxHudun;
			float num2 = ((PlayerData.MaxHudun > 0) ? ((float)PlayerData.Hudun / (float)PlayerData.MaxHudun) : 0f);
			_hdProgress.fillAmount = num2;
			_hdProgress.gameObject.SetObjectActive(!Mathf.Approximately(num2, 0f));
		}
		if ((PlayerData.Zhuangjia != _currZj || PlayerData.MaxZhuangjia != _currMaxZj) && array[2])
		{
			_currZj = PlayerData.Zhuangjia;
			_currMaxZj = PlayerData.MaxZhuangjia;
			float num3 = ((PlayerData.MaxZhuangjia > 0) ? ((float)PlayerData.Zhuangjia / (float)PlayerData.MaxZhuangjia) : 0f);
			_zjProgress.fillAmount = num3;
			_zjProgress.gameObject.SetObjectActive(!Mathf.Approximately(num3, 0f));
		}
		if (PlayerData.LifeBarSeq.Count > PlayerData.CurrentLifeBarSeq)
		{
			_lockName.text = ScriptLocalization.Get($"LOCKHP{PlayerData.LifeBarSeq[PlayerData.CurrentLifeBarSeq]}");
		}
	}
}
