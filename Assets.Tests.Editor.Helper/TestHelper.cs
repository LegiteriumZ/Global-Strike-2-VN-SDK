using System;
using CommonUtils;

namespace Assets.Tests.Editor.Helper;

public static class TestHelper
{
	public static void FastJumpOut(string loginfo)
	{
		DebugLogger.LogError(loginfo);
		throw new Exception(loginfo);
	}
}
