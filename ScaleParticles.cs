using System;
using System.Collections.Generic;
using UnityEngine;

public class ScaleParticles : MonoBehaviour
{
	private class ParticleScaleParam
	{
		public readonly float LengthScale;

		public readonly ParticleSystem.MinMaxCurve StartSizeX;

		public readonly ParticleSystem.MinMaxCurve StartSizeY;

		public readonly ParticleSystem.MinMaxCurve StartSizeZ;

		public readonly ParticleSystem.MinMaxCurve StartSpeed;

		public readonly float VelocityScale;

		public ParticleScaleParam(ParticleSystem.MinMaxCurve startSizeX, ParticleSystem.MinMaxCurve startSizeY, ParticleSystem.MinMaxCurve startSizeZ, ParticleSystem.MinMaxCurve startSpeed, float lengthScale, float velocityScale)
		{
			StartSizeX = startSizeX;
			StartSizeY = startSizeY;
			StartSizeZ = startSizeZ;
			StartSpeed = startSpeed;
			LengthScale = lengthScale;
			VelocityScale = velocityScale;
		}
	}

	private readonly List<ParticleScaleParam> initialSizes = new List<ParticleScaleParam>();

	private Vector3 lossyScale;

	private void Awake()
	{
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem obj in componentsInChildren)
		{
			ParticleSystem.MinMaxCurve startSizeInit = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSizeInit2 = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSizeInit3 = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSizeInit4 = default(ParticleSystem.MinMaxCurve);
			float lengthScale = 0f;
			float velocityScale = 0f;
			ParticleSystemRenderer component = obj.GetComponent<ParticleSystemRenderer>();
			if ((bool)component)
			{
				lengthScale = component.lengthScale;
				velocityScale = component.velocityScale;
			}
			ParticleSystem.MainModule main = obj.main;
			if (!main.startSize3D)
			{
				main.startSize3D = true;
			}
			CopyStartSize(main.startSizeX, ref startSizeInit);
			CopyStartSize(main.startSizeY, ref startSizeInit2);
			CopyStartSize(main.startSizeZ, ref startSizeInit3);
			CopyStartSize(main.startSpeed, ref startSizeInit4);
			initialSizes.Add(new ParticleScaleParam(startSizeInit, startSizeInit2, startSizeInit3, startSizeInit4, lengthScale, velocityScale));
		}
		lossyScale = new Vector3(1f, 1f, 1f);
	}

	public void Update()
	{
		if ((double)Math.Abs(lossyScale.x - base.transform.lossyScale.x) < 0.001 && (double)Math.Abs(lossyScale.y - base.transform.lossyScale.y) < 0.001 && (double)Math.Abs(lossyScale.z - base.transform.lossyScale.z) < 0.001)
		{
			return;
		}
		lossyScale.x = base.transform.lossyScale.x;
		lossyScale.y = base.transform.lossyScale.y;
		lossyScale.z = base.transform.lossyScale.z;
		int num = 0;
		ParticleSystem[] componentsInChildren = base.gameObject.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem obj in componentsInChildren)
		{
			Vector3 vector = obj.gameObject.transform.lossyScale;
			ParticleScaleParam particleScaleParam = initialSizes[num++];
			ParticleSystem.MainModule main = obj.main;
			ParticleSystem.MinMaxCurve startSize = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSize2 = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSize3 = default(ParticleSystem.MinMaxCurve);
			ParticleSystem.MinMaxCurve startSize4 = default(ParticleSystem.MinMaxCurve);
			ScalaStartSize(ref startSize, particleScaleParam.StartSizeX, vector.x);
			ScalaStartSize(ref startSize2, particleScaleParam.StartSizeY, vector.y);
			ScalaStartSize(ref startSize3, particleScaleParam.StartSizeZ, vector.z);
			ScalaStartSize(ref startSize4, particleScaleParam.StartSpeed, vector.magnitude);
			main.startSizeX = startSize;
			main.startSizeY = startSize2;
			main.startSizeZ = startSize3;
			main.startSpeed = startSize4;
			ParticleSystemRenderer component = obj.GetComponent<ParticleSystemRenderer>();
			if ((bool)component)
			{
				component.lengthScale = particleScaleParam.LengthScale * base.gameObject.transform.lossyScale.magnitude;
				component.velocityScale = particleScaleParam.VelocityScale * base.gameObject.transform.lossyScale.magnitude;
			}
		}
	}

	private void ScalaStartSize(ref ParticleSystem.MinMaxCurve startSize, ParticleSystem.MinMaxCurve startSizeInit, float x)
	{
		startSize.constant = startSizeInit.constant * x;
		startSize.constantMax = startSizeInit.constantMax * x;
		startSize.constantMin = startSizeInit.constantMin * x;
		startSize.curveMultiplier = startSizeInit.curveMultiplier * x;
		startSize.mode = startSizeInit.mode;
	}

	private void CopyStartSize(ParticleSystem.MinMaxCurve startSize, ref ParticleSystem.MinMaxCurve startSizeInit)
	{
		startSizeInit.constant = startSize.constant;
		startSizeInit.constantMax = startSize.constantMax;
		startSizeInit.constantMin = startSize.constantMin;
		startSizeInit.mode = startSize.mode;
	}
}
