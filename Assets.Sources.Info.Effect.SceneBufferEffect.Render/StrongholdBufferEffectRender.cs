using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class StrongholdBufferEffectRender : AbstractSceneBuffEffectRender
{
	private TextMesh _textMesh;

	private MaterialPropertyBlock _block;

	private SpriteRenderer _spriteRender;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_textMesh = effectGameObject.transform.Find("GameObject/0/Point/DistanceText").GetComponent<TextMesh>();
		if (entity.HasSceneBuff)
		{
			effectGameObject.transform.Find("GameObject").localScale = Vector3.one * entity.SceneBuff.Data.Radius / 64f * 2f;
			if (entity.SceneBuff.Data.Lv == 1)
			{
				Transform transform = effectGameObject.transform.Find("GameObject/0/Point");
				transform.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteList>().Sprites[0];
			}
			_spriteRender = EffectObject.transform.Find("0/sprite").GetComponent<SpriteRenderer>();
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (Entity.HasSceneBuff)
		{
			if (_block == null)
			{
				_block = new MaterialPropertyBlock();
			}
			_spriteRender.GetPropertyBlock(_block);
			_block.SetColor("_AddactiveColor", Color.white);
			if (Entity.SceneBuff.Data.Team == 1)
			{
				_block.SetColor("_AddactiveColor", new Color(0.972f, 0f, 0f));
			}
			else if (Entity.SceneBuff.Data.Team == 2)
			{
				_block.SetColor("_AddactiveColor", new Color(0f, 0.687f, 0f));
			}
			if (GameSetting.Config.SuggestFlag == 1)
			{
				_textMesh.text = StringCache.IntToString(GetDistance(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)));
			}
			else
			{
				_textMesh.text = "";
			}
		}
	}

	protected int GetDistance(Vector3 position)
	{
		return (int)(Vector3.Distance(Contexts.sharedInstance.player.myPlayerEntity.GetCompenstatePos(Contexts.sharedInstance.player.myPlayerEntity.fpos.Change.GetPosIndex()), position) * 0.01f);
	}
}
