using System;
using CommonUtils;
using UnityEngine;

namespace Assets.Tests;

public class FloatTest : MonoBehaviour
{
	private static readonly char[] hexArray = "0123456789ABCDEF".ToCharArray();

	private void Start()
	{
		float num = 4579.62f;
		byte[] bytes = BitConverter.GetBytes(num);
		float b = BitConverter.ToSingle(bytes, 0);
		DebugLogger.LogErrorFormat("precision {0} {1}", Mathf.Approximately(num, b), BytesToHex(bytes));
	}

	private string ToHex(float i)
	{
		return BytesToHex(BitConverter.GetBytes(i));
	}

	public static string BytesToHex(byte[] bytes)
	{
		char[] array = new char[bytes.Length * 2];
		for (int i = 0; i < bytes.Length; i++)
		{
			int num = bytes[i] & 0xFF;
			array[i * 2] = hexArray[num >>> 4];
			array[i * 2 + 1] = hexArray[num & 0xF];
		}
		return new string(array);
	}

	private void Update()
	{
	}
}
