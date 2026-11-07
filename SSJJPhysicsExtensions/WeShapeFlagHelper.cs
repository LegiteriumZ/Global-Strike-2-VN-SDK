using SSJJPhysics;
using physics.engine.data;
using physics.engine.entity.indicator;

namespace SSJJPhysicsExtensions;

public class WeShapeFlagHelper : BaseWeShapeFlagHelper
{
	private int raceType;

	public WeShapeFlagHelper(int raceType)
	{
		this.raceType = raceType;
	}

	public override void GetNormalBrushFlag(CollisionBox box)
	{
		if (raceType == 25)
		{
			if (box is SceneItemCollisionBox)
			{
				box.SetProperties(ShapeFlagSet.Of(ShapeFlag.POSITION, ShapeFlag.UPDATABLE_BOUNDS, ShapeFlag.ABSOLUTE_POSITION, ShapeFlag.ROTATE_TRANSITION, ShapeFlag.CTR_LOCK));
			}
			else
			{
				box.SetProperties(ShapeFlagSet.Of(ShapeFlag.POSITION, ShapeFlag.UPDATABLE_BOUNDS, ShapeFlag.CTR_UNLOCK));
			}
		}
		else
		{
			base.GetNormalBrushFlag(box);
		}
	}

	public override void GetHitBrushSetFlag(IEntityIndicator entity, HitBox box)
	{
		if ((raceType == 19 || raceType == 90) && "Bip01_Head".Equals(box.GetBoneName()))
		{
			box.SetProperties(ShapeFlagSet.Of(ShapeFlag.POSITION, ShapeFlag.ABSOLUTE_POSITION, ShapeFlag.ROTATE_TRANSITION, ShapeFlag.UPDATABLE_BOUNDS, ShapeFlag.SCALE));
		}
		else
		{
			base.GetHitBrushSetFlag(entity, box);
		}
	}
}
