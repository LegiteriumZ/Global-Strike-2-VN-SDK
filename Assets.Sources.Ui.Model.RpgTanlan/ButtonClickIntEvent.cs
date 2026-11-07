using System;

namespace Assets.Sources.Ui.Model.RpgTanlan;

public class ButtonClickIntEvent : EventArgs
{
	public int data;

	public int index;

	public ButtonClickIntEvent(int parameter, int tmpIndex)
	{
		data = parameter;
		index = tmpIndex;
	}
}
