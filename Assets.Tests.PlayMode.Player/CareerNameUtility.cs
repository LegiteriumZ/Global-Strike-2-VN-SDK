using System.Linq;
using System.Reflection;
using share.constant;

namespace Assets.Tests.PlayMode.Player;

public static class CareerNameUtility
{
	public static string[] GetAllCareerNames()
	{
		return (from x in typeof(PlayerCareerConstant).GetFields(BindingFlags.Static | BindingFlags.Public)
			where !x.Name.StartsWith("HAND_") && x.GetValue(null) is string
			select x.GetValue(null) as string).ToArray();
	}
}
