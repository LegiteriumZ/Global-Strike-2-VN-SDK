using UnityEngine.Events;

namespace Tests.AnimViewer;

public interface IControlButton
{
	void InitButton(UnityAction pauseAction, UnityAction resumeAction, UnityAction restartAction, UnityAction stopAction);
}
