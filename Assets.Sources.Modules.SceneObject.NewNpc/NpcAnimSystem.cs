using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using SSJJAnim.AnimState;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NpcAnimSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly TimeComponent _time;

	private int _playBackFrameCount;

	public NpcAnimSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.NpcUnityObjects, SceneObjectMatcher.NpcAnim));
		_time = contexts.time.time;
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			ILegAnimStateInfo legAnimInfo = AnimStateInfoFactory.Instance.GetLegAnimInfo(item.npcBasicInfo.Current.Anim);
			if (legAnimInfo != item.npcAnim.CurrentAnim)
			{
				item.npcAnim.CurrentAnim = legAnimInfo;
				item.npcAnim.Elapsed = 0;
			}
			item.npcAnim.Elapsed += _time.FrameInterval;
			ISjAnimatior animator = item.npcUnityObjects.Animator;
			animator.PlayAtFixedTime(stateName: AnimationConstantUtility.GetLegAnimName(animator.GetAnimations(), item.npcAnim.CurrentAnim.StateId, null), visiable: !item.hasVisiable || item.visiable.IsVisiable || item.visiable.IsNear, layerIndex: 0, time: (float)item.npcAnim.Elapsed / 1000f, speed: 1f, isLoop: item.npcAnim.CurrentAnim.IsLoop);
		}
	}
}
