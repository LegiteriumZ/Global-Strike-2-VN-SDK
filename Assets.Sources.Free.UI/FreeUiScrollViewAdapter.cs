using System.Collections.Generic;
using SSJJBase.Singleton;

namespace Assets.Sources.Free.UI;

public class FreeUiScrollViewAdapter
{
	private static FreeUiScrollViewAdapter _instance;

	private readonly List<string> _freeUiKeys = new List<string>();

	private readonly List<FreeScrollViewComponent> _scrollViews = new List<FreeScrollViewComponent>();

	private List<SimpleFreeUI> _matchFreeUis = new List<SimpleFreeUI>(32);

	public static FreeUiScrollViewAdapter Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new FreeUiScrollViewAdapter();
			}
			return _instance;
		}
	}

	public void RemoveFreeUiKey(string freeUiKey, SimpleFreeUI freeUi, bool isReplace)
	{
		if (!isReplace)
		{
			_freeUiKeys.Remove(freeUiKey);
		}
		if (!(freeUi != null) || freeUi.FreeComponents == null)
		{
			return;
		}
		for (int i = 0; i < freeUi.FreeComponents.Count; i++)
		{
			IFreeComponent freeComponent = freeUi.FreeComponents[i];
			if (freeComponent is FreeScrollViewComponent)
			{
				FreeScrollViewComponent freeScrollViewComponent = freeComponent as FreeScrollViewComponent;
				freeScrollViewComponent.Reset();
				_scrollViews.Remove(freeScrollViewComponent);
			}
		}
	}

	public void AddSimpleFreeUi(SimpleFreeUI freeUi)
	{
		if (string.IsNullOrEmpty(freeUi.ScrollViewKey))
		{
			return;
		}
		if (!_freeUiKeys.Contains(freeUi.Key))
		{
			_freeUiKeys.Add(freeUi.Key);
		}
		foreach (FreeScrollViewComponent scrollView in _scrollViews)
		{
			if (scrollView != null && scrollView.FreeUi.Key.Equals(freeUi.ScrollViewKey))
			{
				scrollView.AddSimpleFreeUi(freeUi.Key);
			}
		}
	}

	public void AddScrollView(FreeScrollViewComponent scrollViewComponent)
	{
		if (_scrollViews.Contains(scrollViewComponent))
		{
			return;
		}
		_matchFreeUis.Clear();
		_scrollViews.Add(scrollViewComponent);
		foreach (string freeUiKey in _freeUiKeys)
		{
			SimpleFreeUI value = null;
			if (MonoBehaviourSingleton<FreeUiManager>.Instance.Uis.TryGetValue(freeUiKey, out value) && value != null && scrollViewComponent.FreeUi.Key.Equals(value.ScrollViewKey))
			{
				_matchFreeUis.Add(value);
			}
		}
		scrollViewComponent.AddSimpleFreeUi(_matchFreeUis);
	}

	public SimpleFreeUI GetScrollViewSimpleFreeUi(SimpleFreeUI freeUi)
	{
		if (!string.IsNullOrEmpty(freeUi.ScrollViewKey))
		{
			foreach (FreeScrollViewComponent scrollView in _scrollViews)
			{
				if (scrollView != null && scrollView.FreeUi.Key.Equals(freeUi.ScrollViewKey))
				{
					return scrollView.FreeUi;
				}
			}
		}
		return null;
	}
}
