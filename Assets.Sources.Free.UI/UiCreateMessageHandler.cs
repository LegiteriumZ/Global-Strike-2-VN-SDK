using Assets.Sources.Free.Utility;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class UiCreateMessageHandler : ISimpleMesssageHandler
{
	private GameObject _freecanvas;

	private Transform _freeUi;

	public bool CanHandle(int key)
	{
		return key == 50;
	}

	public void Handle(SimpleProto data)
	{
		string text = data.Ss[0];
		MonoBehaviourSingleton<FreeUiManager>.Instance.RemoveOldUi(text);
		SimpleFreeUI simpleFreeUI = BuildNew(data);
		if (simpleFreeUI == null)
		{
			this.LogErrorFormat("Build Free UI Error > Ui == null , key {0}", text);
			return;
		}
		MonoBehaviourSingleton<FreeUiManager>.Instance.AddUi(simpleFreeUI);
		Transform orCreateLayerTran = MonoBehaviourSingleton<FreeUiManager>.Instance.GetOrCreateLayerTran(simpleFreeUI.Layer);
		simpleFreeUI.gameObject.transform.SetParent(orCreateLayerTran);
		if (simpleFreeUI.AtBottom)
		{
			simpleFreeUI.gameObject.transform.SetSiblingIndex(0);
		}
		if (!string.IsNullOrEmpty(simpleFreeUI.ScrollViewKey))
		{
			FreeUiScrollViewAdapter.Instance.AddSimpleFreeUi(simpleFreeUI);
		}
		FreeUIUtil.GetInstance().DestoryTemplate();
	}

	private void Init()
	{
		if (_freecanvas == null)
		{
			_freecanvas = MonoBehaviourSingleton<FreeUiManager>.Instance.GetFreeCanvas();
			_freeUi = MonoBehaviourSingleton<FreeUiManager>.Instance.GetFreeUiTran();
		}
	}

	private SimpleFreeUI BuildNew(SimpleProto simpleProto)
	{
		Init();
		SimpleFreeUI simpleFreeUI = null;
		if (_freeUi != null)
		{
			string key = simpleProto.Ss[0];
			GameObject gameObject = null;
			RectTransform rectTransform = null;
			bool flag = true;
			if (MonoBehaviourSingleton<FreePool>.Instance.CheckIsRecyclable(key))
			{
				SimpleFreeUI freeUi = MonoBehaviourSingleton<FreePool>.Instance.GetFreeUi();
				if (freeUi != null)
				{
					flag = false;
					gameObject = freeUi.gameObject;
					rectTransform = gameObject.GetComponent<RectTransform>();
					simpleFreeUI = gameObject.GetComponent<SimpleFreeUI>();
				}
			}
			if (flag)
			{
				gameObject = new GameObject();
				rectTransform = gameObject.AddComponent<RectTransform>();
				gameObject.AddComponent<CanvasRenderer>();
				simpleFreeUI = gameObject.AddComponent<SimpleFreeUI>();
			}
			gameObject.transform.SetParent(_freeUi);
			gameObject.transform.localPosition = Vector3.zero;
			rectTransform.anchorMin = new Vector2(0f, 1f);
			rectTransform.anchorMax = new Vector2(0f, 1f);
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			rectTransform.pivot = new Vector2(0f, 1f);
			simpleFreeUI.Key = simpleProto.Ss[0];
			simpleFreeUI.Visible = simpleProto.Bs[0];
			simpleFreeUI.AtBottom = simpleProto.Bs[1];
			simpleFreeUI.AddUpdater();
			int num = (simpleProto.Ks.Count - 1) * 4 + 2;
			string text = simpleProto.Ss[num + 1];
			string text2 = simpleProto.Ss[num + 2];
			string width = simpleProto.Ss[num + 3];
			string height = simpleProto.Ss[num + 4];
			if (!text.Equals("") && !text2.Equals(""))
			{
				simpleFreeUI.CheckSetScrollView(text, int.Parse(text2));
				simpleFreeUI.SetParentKey(width, height);
			}
			for (int i = 0; i < simpleProto.Ks.Count - 1; i++)
			{
				IFreeComponent freeComponent = null;
				freeComponent = ((!flag) ? simpleFreeUI.FreeComponents[i] : FreeUIUtil.GetInstance().GetComponent(simpleProto.Ks[i + 1]));
				if (freeComponent != null)
				{
					simpleFreeUI.SetChild(freeComponent, text);
					freeComponent.InitialFreeComponent(i, simpleProto, simpleFreeUI);
					freeComponent.initToBeBindAutos(simpleProto.Ss[i * 4 + 4]);
					if (freeComponent is FreeListComponent || freeComponent is FreeCheckBoxComponent)
					{
						freeComponent.Initial(simpleProto.Ps[i]);
					}
					simpleFreeUI.AddComponent(freeComponent);
					freeComponent.AddKeyBoardResponder();
				}
			}
			string config = simpleProto.Ss[(simpleProto.Ks.Count - 1) * 4 + 1];
			string config2 = simpleProto.Ss[(simpleProto.Ks.Count - 1) * 4 + 2];
			simpleFreeUI.initAutos(config);
			simpleFreeUI.initToBeBindAutos(config2);
			simpleFreeUI.Layer = simpleProto.Ins[(simpleProto.Ks.Count - 1) * 4];
		}
		return simpleFreeUI;
	}
}
