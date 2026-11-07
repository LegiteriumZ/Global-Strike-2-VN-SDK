using Assets.Sources.Components.Interface;
using Assets.Sources.Utils;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class ParasiticSniperRender : AbstractPlayerEffectRender
{
	private Vector3 _offset;

	private SpriteRenderer _sprite;

	private TextMesh _textMesh;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_sprite = effectGameObject.transform.Find("Suggest").GetComponent<SpriteRenderer>();
		_textMesh = effectGameObject.transform.Find("Number").GetComponent<TextMesh>();
		_textMesh.GetComponent<Renderer>().material.renderQueue++;
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return _offset;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		_offset = new Vector3(0f, 0f, ViewHeightUtility.GetViewHeight(targetPlayer) * 0.7f);
		long cid = targetPlayer.basicInfo.Cid;
		if (Contexts.sharedInstance.battleRoom.playerInfo.PlayerInfoExtraDatas.TryGetValue(cid, out var value))
		{
			_textMesh.text = StringCache.IntToString(value.Numb);
		}
	}
}
