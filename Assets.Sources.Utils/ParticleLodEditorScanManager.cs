using System;
using System.Collections.Generic;
using Assets.Scripts.Utility.ParticleSize;
using Assets.Sources.Utils.Ui;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Utils;

public class ParticleLodEditorScanManager : MonoBehaviourSingleton<ParticleLodEditorScanManager>
{
	[Serializable]
	public class ParticleScanMsg
	{
		public GameObject ParticleObject;

		public bool IsSee;

		public List<ParticleScanUnitMsg> Units = new List<ParticleScanUnitMsg>();
	}

	[Serializable]
	public class ParticleScanUnitMsg
	{
		public GameObject ChildObject;

		public bool IsSee;
	}

	public bool IsSeeAll;

	public List<ParticleScanMsg> Scans = new List<ParticleScanMsg>();

	public int SizeCount;

	public int AllParticleCount;

	public int SetUnRenderParticleCount;

	public int GlusDc;

	public int AllParticleDc;

	public List<GameObject> NowAllSeePs = new List<GameObject>();

	public List<GameObject> NowAllUnSeePs = new List<GameObject>();

	private void Update()
	{
		if (!IsSeeAll)
		{
			return;
		}
		IsSeeAll = false;
		for (int i = 0; i < Scans.Count; i++)
		{
			ParticleSizeUnit component = Scans[i].ParticleObject.GetComponent<ParticleSizeUnit>();
			if (!(component.FireEffect == null))
			{
				continue;
			}
			foreach (ParticleScanUnitMsg unit in Scans[i].Units)
			{
				unit.ChildObject.GetComponent<Renderer>().enabled = true;
			}
			component.ResetSee();
		}
	}

	public void Remove(ParticleSizeUnit particleSize)
	{
		for (int i = 0; i < Scans.Count; i++)
		{
			if (Scans[i].ParticleObject == particleSize.gameObject)
			{
				Scans.RemoveAt(i);
				break;
			}
		}
		SizeCount--;
	}

	public void Add(ParticleSizeUnit particleSize)
	{
		ParticleScanMsg particleScanMsg = new ParticleScanMsg();
		particleScanMsg.ParticleObject = particleSize.gameObject;
		particleScanMsg.IsSee = true;
		for (int i = 0; i < particleSize.Sizes.Count; i++)
		{
			ParticleScanUnitMsg particleScanUnitMsg = new ParticleScanUnitMsg();
			particleScanUnitMsg.ChildObject = particleSize.Sizes[i].Ren.gameObject;
			particleScanUnitMsg.IsSee = true;
			particleScanMsg.Units.Add(particleScanUnitMsg);
		}
		Scans.Add(particleScanMsg);
		SizeCount++;
	}

	public void Refresh(ParticleSizeUnit particleSize)
	{
		ParticleScanMsg particleScanMsg = null;
		for (int i = 0; i < Scans.Count; i++)
		{
			if (Scans[i].ParticleObject == particleSize.gameObject)
			{
				particleScanMsg = Scans[i];
				break;
			}
		}
		if (particleScanMsg != null)
		{
			particleScanMsg.IsSee = particleSize.IsAllSee;
			for (int j = 0; j < particleScanMsg.Units.Count; j++)
			{
				particleScanMsg.Units[j].IsSee = particleSize.Sizes[j].IsSee;
			}
		}
	}

	public void Sum()
	{
		AllParticleDc = (AllParticleCount = (SetUnRenderParticleCount = (GlusDc = 0)));
		NowAllSeePs.Clear();
		NowAllUnSeePs.Clear();
		for (int i = 0; i < Scans.Count; i++)
		{
			for (int j = 0; j < Scans[i].Units.Count; j++)
			{
				bool num = InScreenUtils.CheckInScreenAccury(Scans[i].Units[j].ChildObject.transform.position, Camera.main) > 0f;
				if (num && !Scans[i].Units[j].IsSee && Scans[i].Units[j].ChildObject.activeInHierarchy)
				{
					NowAllUnSeePs.Add(Scans[i].Units[j].ChildObject);
					GlusDc++;
				}
				if (num && Scans[i].Units[j].IsSee && Scans[i].Units[j].ChildObject.activeInHierarchy)
				{
					NowAllSeePs.Add(Scans[i].Units[j].ChildObject);
					AllParticleDc++;
				}
				if (!Scans[i].Units[j].IsSee)
				{
					SetUnRenderParticleCount++;
				}
				AllParticleCount++;
			}
		}
	}
}
