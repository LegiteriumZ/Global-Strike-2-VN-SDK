using Assets.Libs.UiEditor.RunTime;
using Assets.Sources.Components.Time;
using SSJJUIEditor.UI;

public class UiDataProvider : IUiDataProvider, IDataProvider
{
	public void Init(Contexts contexts)
	{
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool KeyCodeInput(int a, int b)
	{
		return RunTimeBindingManager.Instance.KeyCodeInput(b);
	}

	public bool KeyCodeStayInput(int a, int b, int c)
	{
		return RunTimeBindingManager.Instance.KeyCodeStayInput(b, c);
	}

	public bool KeyCodeExit(int a, int b)
	{
		return RunTimeBindingManager.Instance.KeyCodeExit(b);
	}

	public bool UiLeftClickListener(int index)
	{
		IElementEvent currentRunTimeButtonEvent = RunTimeBindingManager.Instance.GetCurrentRunTimeButtonEvent(index);
		if (currentRunTimeButtonEvent.IsLeftClick)
		{
			currentRunTimeButtonEvent.IsLeftClick = false;
			return true;
		}
		return false;
	}

	public bool UiRightClickListener(int index)
	{
		IElementEvent currentRunTimeButtonEvent = RunTimeBindingManager.Instance.GetCurrentRunTimeButtonEvent(index);
		if (currentRunTimeButtonEvent.IsRightClick)
		{
			currentRunTimeButtonEvent.IsRightClick = false;
			return true;
		}
		return false;
	}

	public bool UiMoveInListener()
	{
		IElementEvent currentRunTimeButtonEvent = RunTimeBindingManager.Instance.GetCurrentRunTimeButtonEvent(0);
		if (currentRunTimeButtonEvent.MoveIn)
		{
			currentRunTimeButtonEvent.MoveIn = false;
			return true;
		}
		return false;
	}

	public bool UiMoveOutListener()
	{
		IElementEvent currentRunTimeButtonEvent = RunTimeBindingManager.Instance.GetCurrentRunTimeButtonEvent(0);
		if (currentRunTimeButtonEvent.MoveOut)
		{
			currentRunTimeButtonEvent.MoveOut = false;
			return true;
		}
		return false;
	}
}
