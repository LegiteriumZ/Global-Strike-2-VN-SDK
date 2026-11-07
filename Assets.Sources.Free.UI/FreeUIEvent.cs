using Assets.Sources.Free.Utility;
using NetData;

namespace Assets.Sources.Free.UI;

public class FreeUIEvent
{
	public const int EVENT_LEFT_CLICK = 1;

	public const int EVENT_MOVE = 3;

	public const int EVENT_MOUSE_ENTER = 4;

	public const int EVENT_MOUSE_OUT = 5;

	public const int EVENT_KEYBOARD = 2;

	public const int SPLIT_ACTION = 7;

	public const int EVENT_RIGHT_CLICK = 8;

	public const int CTRL_RIGHT_CLICK = 9;

	public const int EVENT_BUTTON_STATUS = 6;

	public int Event;

	public SimpleProto Key;

	public SimpleProto KeyCopy;

	public FreeUIEvent()
	{
		Key = new SimpleProto();
		KeyCopy = new SimpleProto();
	}

	public void ResetEvent()
	{
		Event = 0;
		Key.Reset();
	}

	public SimpleProto ToData()
	{
		Key.CopyTo(KeyCopy);
		return KeyCopy;
	}

	public bool HasEvent()
	{
		return Event > 0;
	}
}
