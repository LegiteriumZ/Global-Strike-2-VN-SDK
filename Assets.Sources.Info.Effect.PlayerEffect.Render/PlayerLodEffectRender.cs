using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerLodEffectRender : AbstractPlayerEffectRender
{
	private Text _lodText;

	private Text _screenPortionText;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_lodText = EffectObject.transform.Find("Pivot/Lod").GetComponent<Text>();
		_screenPortionText = EffectObject.transform.Find("Pivot/Portion").GetComponent<Text>();
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		string text = "";
		string text2 = "";
		for (int i = 0; i < targetPlayer.lod.Switcher.Count; i++)
		{
			ILODSwitcher iLODSwitcher = targetPlayer.lod.Switcher[i];
			text = text + StringCache.IntToString(iLODSwitcher.getLodLevel()) + ":";
		}
		_lodText.text = text;
		_screenPortionText.text = text2;
	}
}
