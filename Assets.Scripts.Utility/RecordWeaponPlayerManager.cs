using System;
using System.Collections.Generic;
using System.IO;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class RecordWeaponPlayerManager : MonoBehaviourSingleton<RecordWeaponPlayerManager>
{
	private class RecordUnit
	{
		public long Cid;

		public bool IsUseing;

		public string Name;

		public int SeeTime;
	}

	private List<RecordUnit> _units = new List<RecordUnit>();

	public void Init()
	{
		MonoBehaviourSingleton<GameExitManager>.Instance.RegisterAction(RecordOver);
	}

	public void Record(long playerCid, string weaponName)
	{
		for (int i = 0; i < _units.Count; i++)
		{
			if (_units[i].Cid == playerCid)
			{
				if (_units[i].Name.Equals(weaponName))
				{
					_units[i].IsUseing = true;
					_units[i].SeeTime = (int)Time.time;
				}
				else
				{
					_units[i].IsUseing = false;
				}
			}
		}
		bool flag = false;
		for (int j = 0; j < _units.Count; j++)
		{
			if (_units[j].Cid == playerCid && _units[j].Name.Equals(weaponName))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			RecordUnit recordUnit = new RecordUnit();
			recordUnit.Cid = playerCid;
			recordUnit.IsUseing = true;
			recordUnit.Name = weaponName;
			recordUnit.SeeTime = (int)Time.time;
			_units.Add(recordUnit);
		}
	}

	private void RecordOver()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (File.Exists("RecordWeaponPlayer.txt"))
		{
			File.Delete("RecordWeaponPlayer.txt");
		}
		StreamWriter streamWriter = File.AppendText("RecordWeaponPlayer.txt");
		streamWriter.WriteLine(DateTime.Now.ToString("yy-MM-dd-hh-mm-ss") + "  raceType : " + raceType);
		List<RecordUnit> list = new List<RecordUnit>();
		for (int i = 0; i < _units.Count; i++)
		{
			if (_units[i].IsUseing)
			{
				_units[i].SeeTime = (int)Time.time;
			}
		}
		for (int j = 0; j < _units.Count; j++)
		{
			bool flag = false;
			for (int k = 0; k < list.Count; k++)
			{
				if (_units[j].Name == list[k].Name)
				{
					flag = true;
					if (Time.time - (float)_units[j].SeeTime <= (float)list[k].SeeTime)
					{
						list[k].SeeTime = _units[j].SeeTime;
					}
				}
			}
			if (!flag)
			{
				RecordUnit recordUnit = new RecordUnit();
				recordUnit.SeeTime = (int)Time.time - _units[j].SeeTime;
				recordUnit.Name = _units[j].Name;
				list.Add(recordUnit);
			}
		}
		list.Sort((RecordUnit x, RecordUnit y) => x.SeeTime - y.SeeTime);
		for (int l = 0; l < list.Count; l++)
		{
			streamWriter.WriteLine(l + " time : " + list[l].SeeTime + "s   WeaponName : " + list[l].Name);
		}
		streamWriter.Flush();
		streamWriter.Close();
	}
}
