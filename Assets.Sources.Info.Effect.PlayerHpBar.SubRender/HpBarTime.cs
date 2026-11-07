using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Constant;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarTime : BaseHpBar
{
	private Image _timeBackImage;

	private RectTransform _timeBackTran;

	private GameObject _timeBackObj;

	private Image _timeProgressImage;

	private bool _showTime;

	private Vector3 _lastTimeBackPos;

	private bool _lastTimeBackActive = true;

	private bool _timeLoaded;

	private AssetInfo _currTimeBackSprite;

	private int _lastMp;

	private static AssetInfo[] _timeBackAssets = new AssetInfo[4]
	{
		new AssetInfo("ui/ultimatechallengemodel", "Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeModel/hpbar/time_yellow.png"),
		new AssetInfo("ui/ultimatechallengemodel", "Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeModel/hpbar/time_blue.png"),
		new AssetInfo("ui/ultimatechallengemodel", "Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeModel/hpbar/time_orange.png"),
		new AssetInfo("ui/ultimatechallengemodel", "Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeModel/hpbar/time_green.png")
	};

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_timeBackImage = Tran.Find("WorldSpace/TimeBack").GetComponent<Image>();
		_timeBackTran = _timeBackImage.rectTransform;
		_timeBackObj = _timeBackImage.gameObject;
		_timeProgressImage = Tran.Find("WorldSpace/TimeBack/TimeProgress").GetComponent<Image>();
		SetActive(_timeBackObj, ref _lastTimeBackActive, newActive: false);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		HpBar.TimeActive = false;
		if (!RuleUtilty.IsUltimateChallenge())
		{
			return;
		}
		base.Update(playerEntity, pos);
		_showTime = PlayerEntity.HasStatus(PlayerInfoStatusConstant.FAKE_DEAD.ID);
		if (!_showTime || !PlayerEntity.hasMp)
		{
			SetActive(_timeBackObj, ref _lastTimeBackActive, newActive: false);
			return;
		}
		SceneObjectEntity sceneObjectEntity = ContextsExtensions.GetEntityWithPlayerEffectId(Id: new EntityEffectId(PlayerData.CharacterId, "MapMark"), context: Contexts.sharedInstance.sceneObject);
		int num = 0;
		if (sceneObjectEntity != null)
		{
			num = sceneObjectEntity.mapMark.Color;
		}
		SetActive(_timeBackObj, ref _lastTimeBackActive, newActive: true);
		if (!_timeLoaded)
		{
			Loader.RetriveSprite("ui/ultimatechallengemodel", "Assets/Res/Assets/ui/GameGUIRes/UltimateChallengeModel/hpbar/time_progress.png", delegate(Sprite sprite)
			{
				_timeProgressImage.sprite = sprite;
			});
		}
		SetTimeBackSprite(ref _timeBackAssets[num]);
		if (_lastMp != PlayerEntity.mp.Mp)
		{
			_lastMp = PlayerEntity.mp.Mp;
			_timeProgressImage.fillAmount = (float)_lastMp / 100f;
		}
		HpBar.PosY += 33;
		SetPosition(_timeBackTran, ref _lastTimeBackPos, new Vector3(0f, HpBar.PosY));
		HpBar.PosY += 33;
		HpBar.TimeActive = _lastTimeBackActive;
	}

	private void SetTimeBackSprite(ref AssetInfo asset)
	{
		if (!(_currTimeBackSprite != asset))
		{
			return;
		}
		_currTimeBackSprite = asset;
		if (BaseHpBar.SpriteDic.ContainsKey(asset))
		{
			_timeBackImage.sprite = BaseHpBar.SpriteDic[asset];
			return;
		}
		AssetInfo info = asset;
		Loader.RetriveSpriteByRef(ref info, delegate(Sprite sprite)
		{
			_timeBackImage.sprite = SaveSprite(info, sprite);
		});
	}
}
