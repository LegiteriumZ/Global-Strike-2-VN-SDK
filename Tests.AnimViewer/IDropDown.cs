using System.Collections.Generic;

namespace Tests.AnimViewer;

public interface IDropDown
{
	bool InitDropDown(List<string> animList);

	string GetStateName();
}
