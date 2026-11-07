using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model;

public interface ICellModel
{
	GameObject Container { get; set; }

	int Index { get; set; }

	IListNotify Listener { get; set; }

	void SetContainerAndListener(GameObject container, IListNotify listener, int index);
}
