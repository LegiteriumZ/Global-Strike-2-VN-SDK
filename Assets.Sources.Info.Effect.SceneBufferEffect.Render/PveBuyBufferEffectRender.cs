using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class PveBuyBufferEffectRender : AbstractSceneBuffEffectRender
{
	private PlayerEntity _player;

	private SpriteRenderer _spriteRender;

	private bool _isTitanLaboratory;

	private int _maxDis;

	private bool _zTestFlag;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (entity.HasSceneBuff)
		{
			Transform transform = effectGameObject.transform.Find("GameObject/0/model");
			Transform transform2 = effectGameObject.transform.Find("GameObject/0/Suggest");
			if (entity.SceneBuff.Data.BufName == "buy_skill")
			{
				transform.GetComponent<MeshFilter>().mesh = transform.GetComponent<MeshList>().Meshes[0];
				transform.GetComponent<ModelTextureSheetAnimation>().Textures = new Texture2D[1] { transform.GetComponent<TextureList>().Textures[0] };
				_spriteRender = transform2.GetComponent<SpriteRenderer>();
				_spriteRender.sprite = transform2.GetComponent<SpriteList>().Sprites[0];
			}
			else
			{
				transform.GetComponent<MeshFilter>().mesh = transform.GetComponent<MeshList>().Meshes[1];
				transform.GetComponent<ModelTextureSheetAnimation>().Textures = new Texture2D[1] { transform.GetComponent<TextureList>().Textures[1] };
				_spriteRender = transform2.GetComponent<SpriteRenderer>();
				_spriteRender.sprite = transform2.GetComponent<SpriteList>().Sprites[1];
			}
		}
		_isTitanLaboratory = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 1002;
		_maxDis = (_isTitanLaboratory ? 1000000 : 15625000);
		_spriteRender.material.SetInt("_ZTest", _zTestFlag ? 2 : 0);
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (_player == null && Contexts.sharedInstance.player.isMyPlayer)
		{
			_player = Contexts.sharedInstance.player.myPlayerEntity;
		}
		if (_player != null)
		{
			SceneBufEntityData data = Entity.SceneBuff.Data;
			Vector3 compenstatePos = _player.GetCompenstatePos(_player.fpos.Change.GetPosIndex());
			bool flag = (compenstatePos.x - data.X) * (compenstatePos.x - data.X) + (compenstatePos.y - data.Y) * (compenstatePos.y - data.Y) + (compenstatePos.z - data.Z) * (compenstatePos.z - data.Z) >= (float)_maxDis;
			if (_zTestFlag != flag)
			{
				_zTestFlag = flag;
				_spriteRender.material.SetInt("_ZTest", _zTestFlag ? 2 : 0);
			}
		}
	}
}
