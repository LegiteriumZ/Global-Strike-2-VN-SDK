using System.Diagnostics;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class Jump2GameRuleSendedReportHandler : ApcPacketHandler<object>
{
	public Jump2GameRuleSendedReportHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 224;
	}

	public override void Handle(object data)
	{
		MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
		ExecuteGG.CloseNPGameMon();
		if (!Application.isEditor)
		{
			Process.GetCurrentProcess().Kill();
		}
	}
}
