using Assets.Res.Assets.Scripts;
using SSJJMath;
using UnityEngine;
using math;

namespace Assets.Sources.Info.LinkObject;

public class TrackLinkObjectInfo : AbstractLinkObjectInfo
{
	public int Width;

	public int Height;

	public TrackLinkObjectInfo()
	{
		Width = 100;
		Height = 64;
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		gameObject.name = "trackLink_" + entity.linkObject.Now.LinkType;
		PlayerContext player = Contexts.sharedInstance.player;
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpStart, out var dest);
		gameObject.transform.position = dest;
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpEnd, out var dest2);
		gameObject.transform.position = Vector3.zero;
		TrackLink component = gameObject.GetComponent<TrackLink>();
		component.start = dest;
		component.end = dest2;
		_ = component.playerForward;
		PlayerEntity entityWithEntityId = player.GetEntityWithEntityId(entity.linkObject.UseId);
		if (entityWithEntityId != null)
		{
			Vector3 vector = VectorCoordConverter.SsjjToUnity(getPlayerForward(entityWithEntityId));
			component.playerForward.Set(vector.x, vector.y, vector.z);
		}
	}

	private Vector3 getPlayerForward(PlayerEntity entity)
	{
		double angle = entity.GetViewYaw() + entity.GetPunchYaw();
		double angle2 = entity.GetViewPitch() + entity.GetPunchPitch();
		double num = AngleUtils.MakeAngleInRange(angle);
		angle2 = AngleUtils.MakeAngleInRange(angle2);
		return AngleUtility.AnglesToVector((float)num, (float)angle2);
	}
}
