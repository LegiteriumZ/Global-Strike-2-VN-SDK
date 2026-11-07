using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant;
using SSJJUserCmd;

namespace Assets.Sources.Info.Weapon.Logic.SpreadLogic;

public class GhostTwinsSpreadLogic : ISpreadLogic, IParamParse
{
	private ISpreadLogic _normaPvpLogic;

	private ISpreadLogic _normaPveLogic;

	private ISpreadLogic _specialLogic;

	public void Parse(string param)
	{
		SniperSpreadLogic sniperSpreadLogic = new SniperSpreadLogic();
		sniperSpreadLogic.DefaultParam = 0.001f;
		sniperSpreadLogic.AirParam = 0.85f;
		sniperSpreadLogic.LengthParam1 = 0.2f;
		sniperSpreadLogic.LengthParam2 = 0.1f;
		sniperSpreadLogic.DuckParam = 0f;
		sniperSpreadLogic.FovAddParam = 0.08f;
		_normaPvpLogic = sniperSpreadLogic;
		FixedSpreadLogic fixedSpreadLogic = new FixedSpreadLogic();
		fixedSpreadLogic.DefaultParam = 0.001f;
		_normaPveLogic = fixedSpreadLogic;
		RifleSpreadLogic rifleSpreadLogic = new RifleSpreadLogic();
		rifleSpreadLogic.AirParam = 0.435f;
		rifleSpreadLogic.DefaultParam = 0.025f;
		_specialLogic = rifleSpreadLogic;
	}

	public void BeforeFire(out float spread, PlayerEntity player, WeaponEntity currentWeapon, IUserCmd cmd, bool isWeightlessness)
	{
		float spread2 = 0f;
		if (!currentWeapon.special.SpecialMode && _normaPvpLogic != null && _normaPveLogic != null)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType))
			{
				_normaPveLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
			}
			else
			{
				_normaPvpLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
			}
		}
		else if (currentWeapon.special.SpecialMode && _specialLogic != null)
		{
			_specialLogic.BeforeFire(out spread2, player, currentWeapon, cmd, isWeightlessness);
		}
		spread = spread2;
	}
}
