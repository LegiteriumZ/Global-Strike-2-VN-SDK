using System;
using System.Collections.Generic;
using SSJJ.Utility;
using SSJJAsset.AssetBundle;
using SSJJBase.Singleton;
using SSJJUniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SSJJ.BattleLoading;

public class BattleLoadingViewModel : MonoBehaviour
{
	public GameObject BackNormal;

	public Image ProgressBarBack;

	public Image ProgressBar;

	public Image ProgressBarEffect;

	public Text ProgressLabel;

	public Text TipLabel;

	public Text GameRuleInfo;

	public Text TipsInfo;

	public Text DownloadText;

	public Image Back;

	public GameObject BackRpg;

	public Text RpgProgressLabel;

	public Text RpgTipLabel;

	public Text RpgGameRuleInfo;

	public Text RpgTipsInfo;

	public Text RpgDownloadText;

	public Image RpgBack;

	private List<IDisposable> _list = new List<IDisposable>();

	private void SetBackSprite(Sprite sprite)
	{
		BattleLoadingModel progressModel = MonoBehaviourSingleton<BattleLoadingManager>.Instance.ProgressModel;
		if (sprite != null)
		{
			if (progressModel.IsRpg.Value)
			{
				RpgBack.sprite = sprite;
			}
			else
			{
				Back.sprite = sprite;
			}
		}
	}

	private void SetProgressBackSprite(Sprite sprite)
	{
		_ = MonoBehaviourSingleton<BattleLoadingManager>.Instance.ProgressModel;
		if (sprite != null)
		{
			ProgressBarBack.sprite = sprite;
			ProgressBarBack.SetNativeSize();
		}
	}

	private void SetProgressSprite(Sprite sprite)
	{
		_ = MonoBehaviourSingleton<BattleLoadingManager>.Instance.ProgressModel;
		if (sprite != null)
		{
			ProgressBar.sprite = sprite;
			ProgressBar.SetNativeSize();
		}
	}

	private void SetIsRpg(bool isRpg)
	{
		BackRpg.SetObjectActive(isRpg);
		BackNormal.SetObjectActive(!isRpg);
	}

	private void Start()
	{
		BattleLoadingModel progressModel = MonoBehaviourSingleton<BattleLoadingManager>.Instance.ProgressModel;
		_list.Add(progressModel.BackSprite.Subscribe(SetBackSprite));
		_list.Add(progressModel.ProgressBackSprite.Subscribe(SetProgressBackSprite));
		_list.Add(progressModel.ProgressSprite.Subscribe(SetProgressSprite));
		_list.Add(progressModel.IsRpg.Subscribe(SetIsRpg));
		_list.Add(progressModel.Progress.SubscribeToFillAmount(ProgressBar));
		_list.Add(progressModel.Progress.SubscribeToText(ProgressLabel, (float x) => (int)((x + 0.001f) * 100f) + "%"));
		_list.Add(progressModel.Progress.SubscribeToText(RpgProgressLabel, (float x) => (int)((x + 0.001f) * 100f) + "%"));
		_list.Add(progressModel.Tip.SubscribeToText(TipLabel));
		_list.Add(progressModel.Tip.SubscribeToText(RpgTipLabel));
		_list.Add(progressModel.TipsInfo.SubscribeToText(TipsInfo));
		_list.Add(progressModel.TipsInfo.SubscribeToText(RpgTipsInfo));
		_list.Add(progressModel.GameRuleInfo.SubscribeToText(GameRuleInfo));
		_list.Add(progressModel.GameRuleInfo.SubscribeToText(RpgGameRuleInfo));
		float num = (float)Display.main.systemWidth / (float)Display.main.systemHeight;
		CanvasScaler component = base.transform.parent.gameObject.GetComponent<CanvasScaler>();
		if (num >= component.referenceResolution.x / component.referenceResolution.y)
		{
			component.matchWidthOrHeight = 1f;
		}
		else
		{
			component.matchWidthOrHeight = 0f;
		}
	}

	private void Update()
	{
		DownloadText.text = AssetBundleManager.GetDownloadInfo();
		RpgDownloadText.text = AssetBundleManager.GetDownloadInfo();
		float fillAmount = ProgressBar.fillAmount;
		Vector3 localPosition = ProgressBarEffect.transform.localPosition;
		int num = -890;
		int num2 = 630;
		localPosition.x = (float)num + (float)(num2 - num) * fillAmount;
		ProgressBarEffect.transform.localPosition = localPosition;
	}

	private void OnDestroy()
	{
		foreach (IDisposable item in _list)
		{
			item.Dispose();
		}
		ProgressBarBack.sprite = null;
		ProgressBar.sprite = null;
		ProgressBarEffect.sprite = null;
		Back.sprite = null;
		RpgBack.sprite = null;
		Resources.UnloadUnusedAssets();
	}
}
