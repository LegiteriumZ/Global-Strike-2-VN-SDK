using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ResScripts.Refrenceless.DyVersion;

public class UiRefrenceAssetInfoResUnit : MonoBehaviour
{
	private UiResourcesLoader _loader;

	public string BundleName;

	public string AssetPath;

	public Image Image;

	private int _notifyEnabled;

	private bool _setSprite;

	private bool _retriveSpriteOver;

	public void NotifyEnable(bool isShow)
	{
		_notifyEnabled = (isShow ? 1 : (-1));
		if (_retriveSpriteOver)
		{
			Image.enabled = isShow;
		}
	}

	private void Start()
	{
		_loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
	}

	private void Update()
	{
		if (!Contexts.sharedInstance.battleRoom.gameState.LoadingFinish || _setSprite)
		{
			return;
		}
		_setSprite = true;
		_loader.RetriveSprite(BundleName, AssetPath, delegate(Sprite sp)
		{
			_retriveSpriteOver = true;
			if (Image.sprite == null)
			{
				Image.sprite = sp;
			}
			if (_notifyEnabled == 0 || _notifyEnabled == 1)
			{
				Image.enabled = true;
			}
		});
	}
}
