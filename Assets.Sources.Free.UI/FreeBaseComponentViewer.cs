using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeBaseComponentViewer : MonoBehaviour
{
	private FreeBaseComponent _free;

	public FreeBaseDataElement DataElement;

	public void SetFreeBaseComponent(FreeBaseComponent free)
	{
		_free = free;
	}

	private void Update()
	{
		if (_free != null)
		{
			DataElement = _free.DataElement;
			DataElement.Update(_free);
		}
	}
}
