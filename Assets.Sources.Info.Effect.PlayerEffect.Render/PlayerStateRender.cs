using System.Collections.Generic;
using System.Linq;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerStateRender : AbstractPlayerEffectRender
{
	private SpriteList _spriteList;

	private GameObject[] _sprites;

	private Transform[] _transforms;

	private SpriteAnimation[] _animas;

	private SpriteRenderer[] _renders;

	private Dictionary<int, Sprite[]> _cache;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_sprites = new GameObject[6]
		{
			null,
			effectGameObject.transform.Find("GameObject/1/sprite1").gameObject,
			effectGameObject.transform.Find("GameObject/1/sprite2").gameObject,
			effectGameObject.transform.Find("GameObject/1/sprite3").gameObject,
			effectGameObject.transform.Find("GameObject/1/sprite4").gameObject,
			effectGameObject.transform.Find("GameObject/1/sprite5").gameObject
		};
		_transforms = new Transform[6]
		{
			null,
			_sprites[1].transform,
			_sprites[2].transform,
			_sprites[3].transform,
			_sprites[4].transform,
			_sprites[5].transform
		};
		_animas = new SpriteAnimation[6]
		{
			null,
			_sprites[1].GetComponent<SpriteAnimation>(),
			_sprites[2].GetComponent<SpriteAnimation>(),
			_sprites[3].GetComponent<SpriteAnimation>(),
			_sprites[4].GetComponent<SpriteAnimation>(),
			_sprites[5].GetComponent<SpriteAnimation>()
		};
		_renders = new SpriteRenderer[6]
		{
			null,
			_sprites[1].GetComponent<SpriteRenderer>(),
			_sprites[2].GetComponent<SpriteRenderer>(),
			_sprites[3].GetComponent<SpriteRenderer>(),
			_sprites[4].GetComponent<SpriteRenderer>(),
			_sprites[5].GetComponent<SpriteRenderer>()
		};
		_spriteList = _sprites[1].GetComponent<SpriteList>();
		if (_cache == null)
		{
			_cache = new Dictionary<int, Sprite[]>();
			_cache[0] = _spriteList.Sprites.Skip(0).Take(1).ToArray();
			_cache[1] = _spriteList.Sprites.Skip(1).Take(1).ToArray();
			_cache[2] = _spriteList.Sprites.Skip(2).Take(1).ToArray();
			_cache[3] = _spriteList.Sprites.Skip(3).Take(1).ToArray();
			_cache[4] = _spriteList.Sprites.Skip(4).Take(11).ToArray();
			_cache[15] = _spriteList.Sprites.Skip(15).Take(1).ToArray();
		}
		PlayerInfoData playerInfo = player.GetPlayerInfo();
		_ = Contexts.sharedInstance.battleRoom.playerInfo;
		int i = 1;
		int num = 0;
		if (playerInfo.InMark)
		{
			num += 64;
			SetSprites(i++, 0, 1, num - 32);
		}
		if (playerInfo.InFear)
		{
			num += 64;
			SetSprites(i++, 1, 1, num - 32);
		}
		if (playerInfo.InChaos)
		{
			num += 64;
			SetSprites(i++, 2, 1, num - 32);
		}
		if (playerInfo.InHuoYanXianJi)
		{
			num += 64;
			SetSprites(i++, 3, 1, num - 32);
		}
		if (player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_BOSS10_SHANDIANHUAN.ID))
		{
			num += 64;
			SetSprites(i++, 2, 1, num - 32);
		}
		if (player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_INCHAOS.ID))
		{
			num += 128;
			SetSprites(i++, 4, 11, num - 64);
		}
		if (player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_INRAGE.ID))
		{
			num += 128;
			SetSprites(i++, 15, 1, num - 64);
		}
		if (player.skill.Status.ContainsKey(1261))
		{
			num += 128;
			SetSprites(i++, 16, 1, num - 64);
		}
		Transform transform = effectGameObject.transform.Find("GameObject/1");
		transform.localPosition = new Vector3((float)(-num) / 2f * transform.localScale.x, 0f);
		for (; i <= 5; i++)
		{
			_sprites[i].SetObjectActive(isactive: false);
		}
	}

	private void SetSprites(int index, int start, int len, int pos)
	{
		Sprite[] value = null;
		if (_cache.TryGetValue(start, out value))
		{
			_sprites[index].SetObjectActive(isactive: true);
			SpriteAnimation spriteAnimation = _animas[index];
			spriteAnimation.FrameRate = len;
			spriteAnimation.Sprites = value;
			_transforms[index].localPosition = new Vector3(pos, 0f);
			_renders[index].sprite = spriteAnimation.Sprites.First();
		}
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer));
	}
}
