using System;
using System.Xml;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using Sources.Utils.Ui;

namespace Assets.Sources.Particle.Config;

public class PlayerInfoEffectData : BaseEffectData, IEquatable<PlayerInfoEffectData>
{
	public float Around;

	public string Career = "";

	public float EffectScaleX = 1f;

	public float Forward;

	public string JointName = "";

	public int PitchTrim;

	public int RestartTime;

	public float Up;

	public int YawTrim;

	public int ViewHeight;

	public int ViewHeightTop;

	public bool AutoSize;

	public bool HasViewEffect;

	public bool ThirdEffectHide;

	public string Matrix = "";

	public string animClass;

	public string animParameter;

	public int viewShow;

	public int showX;

	public int showY;

	public int showZ;

	public int changeScale;

	public bool scaleOnlyXY;

	public bool isSmallMirror;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("playerStatus");
		string text = xn.Read("obtainSupplieUrl");
		if (!string.IsNullOrEmpty(text))
		{
			SingletonInstance<ObtainSupplieParser>.Instance.AddObtainSuppliesConfig(int.Parse(Key), text);
			return null;
		}
		if (string.IsNullOrEmpty(Key))
		{
			Key = xn.Read("playerState");
		}
		EffectScale = xn.Read("effectScale", 1f);
		YawTrim = xn.Read("yawTrim", 0);
		PitchTrim = xn.Read("pitchTrim", 0);
		Up = xn.Read("up", 0f);
		Forward = xn.Read("forward", 0f);
		Around = xn.Read("around", 0f);
		JointName = xn.Read("jointName");
		Career = xn.Read("career");
		RestartTime = xn.Read("restartTime", 0);
		EffectScaleX = xn.Read("effectScaleX", 1f);
		ViewHeight = xn.Read("viewHeight", 0);
		ViewHeightTop = xn.Read("viewHeightTop", 0);
		AutoSize = xn.Read("autoSize", 0) == 1;
		ThirdEffectHide = xn.Read("thirdEffectHide", defaultval: false);
		HasViewEffect = xn.Read("hasViewEffect", defaultval: false);
		Matrix = xn.Read("matrix");
		animClass = xn.Read("animClass");
		animParameter = xn.Read("animParameter");
		viewShow = xn.Read("viewShow", 0);
		showX = xn.Read("showX", 0);
		showY = xn.Read("showY", 0);
		showZ = xn.Read("showZ", 0);
		changeScale = xn.Read("changeScale", 0);
		scaleOnlyXY = xn.Read("scaleOnlyXY", defaultval: false);
		isSmallMirror = xn.Read("isSmallMirror", defaultval: false);
		return this;
	}

	public override string GetName()
	{
		return "playerinfo_" + Key;
	}

	public bool Equals(PlayerInfoEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && Around.Equals(other.Around) && string.Equals(Career, other.Career) && EffectScaleX.Equals(other.EffectScaleX) && Forward.Equals(other.Forward) && string.Equals(JointName, other.JointName) && PitchTrim == other.PitchTrim && RestartTime == other.RestartTime && Up.Equals(other.Up) && YawTrim == other.YawTrim && ViewHeight == other.ViewHeight && ViewHeightTop == other.ViewHeightTop && AutoSize == other.AutoSize && HasViewEffect == other.HasViewEffect)
		{
			return ThirdEffectHide == other.ThirdEffectHide;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((PlayerInfoEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((((((((((((((((((((((((base.GetHashCode() * 397) ^ Around.GetHashCode()) * 397) ^ ((Career != null) ? Career.GetHashCode() : 0)) * 397) ^ EffectScaleX.GetHashCode()) * 397) ^ Forward.GetHashCode()) * 397) ^ ((JointName != null) ? JointName.GetHashCode() : 0)) * 397) ^ PitchTrim) * 397) ^ RestartTime) * 397) ^ Up.GetHashCode()) * 397) ^ YawTrim) * 397) ^ ViewHeight) * 397) ^ ViewHeightTop) * 397) ^ AutoSize.GetHashCode()) * 397) ^ HasViewEffect.GetHashCode()) * 397) ^ ThirdEffectHide.GetHashCode()) * 397) ^ ((Matrix != null) ? Matrix.GetHashCode() : 0);
	}
}
