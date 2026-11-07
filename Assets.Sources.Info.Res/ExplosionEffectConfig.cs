using Assets.Generated.Table;
using Assets.Sources.Utils;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Res;

internal class ExplosionEffectConfig
{
	public static ExplosionEffectConfig DefaultConfig = new ExplosionEffectConfig
	{
		EventId = 0,
		HasBulletHole = true,
		SoundType = "weapon",
		SoungSubType = "grenade"
	};

	protected const string NoneSoundType = "none";

	protected const string WeaponSoundType = "weapon";

	protected const string Weapon2SoundType = "weapon2";

	protected const string WeaponSkillSoundType = "weaponskill";

	protected const string WeaponSkill2SoundType = "weaponskill2";

	protected const string PveSoundType = "pve";

	protected const string ModelSoundType = "model";

	protected const string NpcSoundType = "npcsound";

	protected const string Weapon4SoundType = "weapon4sound";

	public int EventId { get; set; }

	public bool HasBulletHole { get; set; }

	public string SoungSubType { get; set; }

	public string SoundType { get; set; }

	public ExplosionEffectConfig(ExplosionEffectTable.Row row)
	{
		EventId = row.EventId;
		HasBulletHole = row.HasBulletHole;
		SoundType = row.SoundType;
		SoungSubType = row.SoundSubType;
	}

	public ExplosionEffectConfig()
	{
	}

	public bool HasSound()
	{
		return !"none".Equals(SoundType);
	}

	public AssetInfo GetSoundAssetInfo(int ruleType)
	{
		return SoundType switch
		{
			"weapon" => SoundResourceUtility.GetWeaponSoundFireAssetInfo(SoungSubType), 
			"weapon2" => SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(SoungSubType), 
			"model" => SoundResourceUtility.GetSoundUrl(ruleType, SoungSubType), 
			"pve" => SoundResourceUtility.GetPveCommonSoundUrl(SoungSubType), 
			"weaponskill" => SoundResourceUtility.GetWeaponSoundSkillAssetInfo(SoungSubType), 
			"weaponskill2" => SoundResourceUtility.GetWeaponSoundSkill2AssetInfo(SoungSubType), 
			"npcsound" => SoundResourceUtility.GetNpcSound(SoungSubType), 
			"weapon4sound" => SoundResourceUtility.GetWeaponSoundFire4AssetInfo(SoungSubType), 
			_ => new AssetInfo(null, null), 
		};
	}
}
