using System;
using System.Runtime.InteropServices;
using NetData;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GameguardDataHandler : ApcPacketHandler<GameguardData>
{
	private static LoggerAdapter Logger = new LoggerAdapter(typeof(ExecuteGG));

	public GameguardDataHandler(Contexts contexts)
	{
	}

	public override int MethodId()
	{
		return 234;
	}

	public override void Handle(GameguardData data)
	{
		int num = data.Data.Length;
		byte[] array = new byte[num - 4];
		int num2 = bytesToInt(data.Data);
		if (data.Data.Length > 4)
		{
			Array.Copy(data.Data, 4, array, 0, num - 4);
		}
		if (1 == num2)
		{
			int num3 = array.Length;
			IntPtr intPtr = Marshal.AllocHGlobal(num3);
			Marshal.Copy(array, 0, intPtr, num3);
			ExecuteGG.SendCSAuth3ToGameMon(intPtr, (uint)num3, 0u);
			Marshal.FreeHGlobal(intPtr);
		}
		else if (2 == num2 || 3 == num2)
		{
			Logger.ErrorFormat("NP: {0}", "认证失败 :" + num2);
			Application.Quit();
		}
	}

	public int bytesToInt(byte[] src, int offset = 0)
	{
		return (src[offset] & -16777216) | ((src[offset + 1] & 0xFF) << 16) | ((src[offset + 2] & 0xFF) << 8) | (src[offset + 3] & 0xFF);
	}
}
