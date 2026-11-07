using System;
using Assets.Scripts.Fog;
using Assets.Sources.Free.Auto;
using SSJJBase.Logger;

namespace Assets.Sources.Free.Scene;

public class FreeFog : BaseAutoFields
{
	private int fogId;

	private SSJJFog.FogConfig fog;

	public FreeFog(int id, SSJJFog.FogConfig fog)
	{
		fogId = id;
		this.fog = fog;
	}

	public int getFogId()
	{
		return fogId;
	}

	public SSJJFog.FogConfig getFog()
	{
		return fog;
	}

	public void frame(int frameTime)
	{
		AutoValue(frameTime);
	}

	protected override void InitialAutoValue(string field, IAutoValue auto)
	{
	}

	protected override void SetAutoValueTo(AutoField auto, int frammeTime)
	{
		if (auto.field == "near")
		{
			fog.Near = (float)auto.auto.Frame(frammeTime).Float;
		}
		if (auto.field == "far")
		{
			fog.Far = (float)auto.auto.Frame(frammeTime).Float;
		}
		if (auto.field == "density")
		{
			double num = auto.auto.Frame(frammeTime).Float / 1000.0;
			fog.Density = (float)num;
		}
		if (auto.field == "color")
		{
			uint args = Convert.ToUInt32(auto.auto.Frame(frammeTime).Float);
			this.LogErrorFormat("Fog Auto Value Color not implemented {0} ", args);
		}
	}
}
