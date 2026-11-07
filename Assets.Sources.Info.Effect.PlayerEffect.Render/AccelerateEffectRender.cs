using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class AccelerateEffectRender : AbstractPlayerEffectRender
{
	private Texture2D[] _textures;

	private TrailRenderer _trail;

	private Transform _jointBone;

	private bool _isLongyinSpecial;

	private int _startFrame;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		GameObject gameObject = effectGameObject.transform.Find("Accelerate").gameObject;
		_textures = gameObject.GetComponent<TextureList>().Textures;
		_trail = gameObject.GetComponent<TrailRenderer>();
		int height = PlayerCareerConstantUtility.GetHeight(player.GetCareer());
		gameObject.transform.localPosition = new Vector3(0f, (float)height * 0.5f, 0f);
		TrailRenderer trail = _trail;
		float startWidth = (_trail.endWidth = ((height > 100) ? 100 : height));
		trail.startWidth = startWidth;
		_trail.time = 1f;
		if (player.GetPlayerInfo().Mp5mrSkillFlag > 0)
		{
			_trail.material.mainTexture = _textures[1];
		}
		else if (AccelerateEffectInfo.HasPlayerEntityTailEffect(player.GetSkin()))
		{
			if (player.GetSkin() == "longyin_yh1_v5")
			{
				_trail.material.mainTexture = _textures[3];
			}
			else
			{
				_trail.material.mainTexture = _textures[2];
			}
			TrailRenderer trail2 = _trail;
			startWidth = (_trail.endWidth = 15f);
			trail2.startWidth = startWidth;
			_trail.time = 0.7f;
			_isLongyinSpecial = true;
			_jointBone = player.GetBone("player_particle_effect1");
			if (_jointBone != null)
			{
				Vector3 position = _jointBone.transform.TransformPoint(Vector3.zero);
				_trail.transform.localPosition = EffectObject.transform.InverseTransformPoint(position);
				EffectObject.SetActive(value: false);
			}
		}
		else if (AccelerateEffectInfo.HasPlayerEntityTailEffect(player.basicInfo.Current.Career))
		{
			if (player.basicInfo.Current.Career == "longyin_yh1_v5")
			{
				_trail.material.mainTexture = _textures[3];
			}
			else
			{
				_trail.material.mainTexture = _textures[2];
			}
			TrailRenderer trail3 = _trail;
			startWidth = (_trail.endWidth = 15f);
			trail3.startWidth = startWidth;
			_trail.time = 0.7f;
			_isLongyinSpecial = true;
			_jointBone = player.GetBone("player_particle_effect1");
			if (_jointBone != null)
			{
				Vector3 position2 = _jointBone.transform.TransformPoint(Vector3.zero);
				_trail.transform.localPosition = EffectObject.transform.InverseTransformPoint(position2);
				EffectObject.SetActive(value: false);
			}
		}
		else if (player.HasStatus(PlayerInfoStatusConstant.RPG_using_role1002.ID))
		{
			_trail.material.mainTexture = _textures[1];
		}
		else
		{
			switch (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType)
			{
			case 6:
			case 14:
			case 117:
			case 118:
				if (player.GetCareer().Equals("doun_master"))
				{
					_trail.material.mainTexture = _textures[4];
				}
				else
				{
					_trail.material.mainTexture = _textures[1];
				}
				break;
			case 11:
				_trail.material.mainTexture = _textures[1];
				break;
			case -2:
				_trail.material.mainTexture = _textures[0];
				break;
			case -3:
				_trail.material.mainTexture = _textures[0];
				break;
			case 24:
				_trail.material.mainTexture = _textures[1];
				break;
			case 25:
				_trail.material.mainTexture = _textures[1];
				break;
			case 33:
				_trail.material.mainTexture = _textures[1];
				break;
			default:
				_trail.material.mainTexture = _textures[0];
				break;
			}
		}
		_startFrame = Time.frameCount;
		_trail.Clear();
	}

	public override void Render(int frameTime, PlayerEntity player, IBattleRoom battleRoom)
	{
		if (Time.frameCount - _startFrame == 1)
		{
			_trail.Clear();
		}
		if (player != null && _isLongyinSpecial)
		{
			_jointBone = player.GetBone("player_particle_effect1");
		}
		if (!(_jointBone != null))
		{
			return;
		}
		Vector3 position = _jointBone.transform.TransformPoint(Vector3.zero);
		_trail.transform.localPosition = EffectObject.transform.InverseTransformPoint(position);
		if (player != null)
		{
			bool flag = true;
			if (Contexts.sharedInstance.player.cameraOwnerEntity == player)
			{
				flag = player.GetPlayerInfo().ThirdMode || player.GetPlayerInfo().InChaos || player.GetPlayerInfo().InFear || player.HasState(131072) || player.HasStatus(PlayerInfoStatusConstant.RPG_using_role1002.ID);
			}
			bool flag2 = (player.GetVelocity() > 310f || (player.HasStatus(PlayerInfoStatusConstant.RPG_using_role1002.ID) && !player.IsDead())) && player.hasSkill && !Mathf.Approximately(player.skill.getStealthAlpha(), 0f) && !player.HasStatus(PlayerInfoStatusConstant.ONLY_SEEN_BY_TEAMMATE.ID);
			if (!flag)
			{
				flag2 = false;
			}
			if (_trail != null && _trail.enabled != flag2)
			{
				_trail.enabled = flag2;
			}
		}
	}
}
