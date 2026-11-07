using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarFavor : BaseHpBar
{
	private Text _favorText;

	private Image _favorImage;

	private GameObject _favorImageObj;

	private RectTransform _favorImageTran;

	private Vector3 _lastFavorPos;

	private bool _lastFavorActive = true;

	private bool _favorLoaded;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_favorImage = Tran.Find("ScreenSpace/FavorImage").GetComponent<Image>();
		_favorImageObj = _favorImage.gameObject;
		_favorImageTran = _favorImage.rectTransform;
		SetActive(_favorImageObj, ref _lastFavorActive, newActive: false);
		_favorText = Tran.Find("ScreenSpace/FavorImage/FavorText").GetComponent<Text>();
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (!SameCameraTeam)
		{
			SetActive(_favorImageObj, ref _lastFavorActive, newActive: false);
		}
		else if (PlayerEntity.GetFavor() > 0)
		{
			_favorText.text = StringCache.IntToString(PlayerEntity.GetFavor());
			if (!_favorLoaded)
			{
				_favorLoaded = true;
				Loader.RetriveSprite("effect/deathmatchmode", "Assets/Res/Assets/effect/deathMatchMode/favor/favor.png", delegate(Sprite sprite)
				{
					_favorImage.sprite = sprite;
				});
			}
			SetActive(_favorImageObj, ref _lastFavorActive, newActive: true);
			SetPosition(_favorImageTran, ref _lastFavorPos, new Vector3(HpBar.NameWidth / 2f + 12f, 0f) + HpBar.NameTextPos);
		}
		else
		{
			SetActive(_favorImageObj, ref _lastFavorActive, newActive: false);
		}
	}
}
