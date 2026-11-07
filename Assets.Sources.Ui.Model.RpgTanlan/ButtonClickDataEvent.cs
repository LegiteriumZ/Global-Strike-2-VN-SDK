using System;
using NetData;

namespace Assets.Sources.Ui.Model.RpgTanlan;

public class ButtonClickDataEvent : EventArgs
{
	public TanLanReadyItemCellData data;

	public ButtonClickDataEvent(TanLanReadyItemCellData parameter)
	{
		data = parameter;
	}
}
