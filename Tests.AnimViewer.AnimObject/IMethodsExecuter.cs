using System.Collections.Generic;

namespace Tests.AnimViewer.AnimObject;

public interface IMethodsExecuter
{
	int index { get; }

	List<string> stateNames { get; }

	string GetName();

	void PauseAnim();

	void ResumeAnim();

	void RestartAnim();

	void StopAnim();
}
