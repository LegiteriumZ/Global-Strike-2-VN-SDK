using System;
using UnityEngine;

public class ExecuteGG : MonoBehaviour
{
	public const int S2C_CHECK = 1;

	public const int S2C_VERSION_ERROR = 2;

	public const int S2C_AUTH_ERROR = 3;

	public const int C2S_HEART_BEAT = 4;

	public const int C2S_CHECK = 5;

	public static void CloseNPGameMon()
	{
	}

	public static void SendCSAuth3ToGameMon(IntPtr pbPacket, uint dwPacketSize, uint dwServerNumber)
	{
	}
}
