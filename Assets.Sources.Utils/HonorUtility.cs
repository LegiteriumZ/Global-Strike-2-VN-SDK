using I2.Loc;

namespace Assets.Sources.Utils;

public class HonorUtility
{
	public static string GetRankLvName(int sect, int level)
	{
		return ScriptLocalization.Get(GetRankLvNameKey(sect, level));
	}

	private static string GetRankLvNameKey(int sect, int level)
	{
		return sect switch
		{
			0 => "Notrated", 
			1 => "Bronzelevel" + level, 
			2 => "Silverlevel" + level, 
			3 => "Goldlevel" + level, 
			4 => "Platinumlevel" + level, 
			5 => "Diamondlevel" + level, 
			6 => "King", 
			_ => "Notrated", 
		};
	}
}
