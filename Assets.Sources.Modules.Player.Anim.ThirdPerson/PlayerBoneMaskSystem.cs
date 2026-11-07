using System;
using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerBoneMaskSystem : FrameExecuteSystem, IPreRenderSystem
{
	private struct BoneKey : IEquatable<BoneKey>
	{
		public int EntityId;

		public string JointName;

		private int _hashCode;

		public BoneKey(int id, string name)
		{
			EntityId = id;
			JointName = name;
			_hashCode = id;
			if (JointName != null)
			{
				_hashCode = (_hashCode * 397) ^ JointName.GetHashCode();
			}
		}

		public bool Equals(BoneKey other)
		{
			if (EntityId == other.EntityId)
			{
				return JointName == other.JointName;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is BoneKey))
			{
				return false;
			}
			return Equals((BoneKey)obj);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public static bool operator ==(BoneKey left, BoneKey right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(BoneKey left, BoneKey right)
		{
			return !object.Equals(left, right);
		}
	}

	private IGroup<PlayerEntity> _group;

	private PlayerContext _playerContext;

	private readonly List<BoneKey> _deleteList = new List<BoneKey>(16);

	private readonly Dictionary<BoneKey, ContorlJointsData> _boneDic = new Dictionary<BoneKey, ContorlJointsData>(16);

	public PlayerBoneMaskSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_playerContext = contexts.player;
	}

	public void OnPreRender()
	{
		if (!Frame())
		{
			return;
		}
		foreach (PlayerEntity item in _group)
		{
			List<ContorlJointsData> contorlJoints = item.basicInfo.Current.ContorlJoints;
			if (contorlJoints != null && contorlJoints.Count > 0)
			{
				foreach (ContorlJointsData item2 in contorlJoints)
				{
					item.thirdPersonUnityObjects.Animator.AddMask(item2.JointName, recursively: true);
					if (item.GetBone(item2.JointName) != null && item2.ScaleSpecified)
					{
						BoneKey key = new BoneKey(item.entityId.Value, item2.JointName);
						_boneDic[key] = item2;
					}
				}
			}
			if (!item.basicInfo.CareerInfo.Name.Equals("boss06"))
			{
				continue;
			}
			Transform bone = item.GetBone("xioangzhao");
			if (bone != null)
			{
				if (item.HasState(1))
				{
					bone.localScale = Vector3.one;
				}
				else
				{
					bone.localScale = Vector3.zero;
				}
			}
		}
		_deleteList.Clear();
		foreach (KeyValuePair<BoneKey, ContorlJointsData> item3 in _boneDic)
		{
			PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(item3.Key.EntityId);
			if (entityWithEntityId != null)
			{
				Transform bone2 = entityWithEntityId.GetBone(item3.Value.JointName);
				if (bone2 != null)
				{
					bone2.localScale = Vector3.one * item3.Value.Scale;
				}
				else
				{
					_deleteList.Add(item3.Key);
				}
			}
			else
			{
				_deleteList.Add(item3.Key);
			}
		}
		for (int i = 0; i < _deleteList.Count; i++)
		{
			_boneDic.Remove(_deleteList[i]);
		}
	}
}
