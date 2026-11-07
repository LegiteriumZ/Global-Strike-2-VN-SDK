using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Free.Data;

public class AllObserverNameData : UIBaseData
{
	private List<string> _nameList;

	public List<string> NameList => _nameList;

	public void ObserverNameChanged(ObserverNameData data)
	{
		Changed = true;
		_nameList = data.PlayerName;
	}
}
