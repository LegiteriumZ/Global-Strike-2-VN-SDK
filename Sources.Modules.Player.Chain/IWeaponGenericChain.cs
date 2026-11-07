namespace Sources.Modules.Player.Chain;

public interface IWeaponGenericChain<T> where T : struct
{
	int Action(ref T args);
}
