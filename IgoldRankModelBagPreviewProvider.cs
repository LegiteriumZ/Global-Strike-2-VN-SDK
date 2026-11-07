public interface IgoldRankModelBagPreviewProvider : IModuleProvider
{
	bool IsShowView(int index);

	string SetWeaponView(int index);

	string SetWeaponName(int index);

	bool IsShow();
}
