using System;
using UnityEngine;

namespace I2.Loc;

[Serializable]
public class EventCallback
{
	public MonoBehaviour Target;

	public string MethodName = string.Empty;

	public void Execute(UnityEngine.Object Sender = null)
	{
		if ((bool)Target && Application.isPlaying)
		{
			Target.gameObject.SendMessage(MethodName, Sender, SendMessageOptions.DontRequireReceiver);
		}
	}
}
