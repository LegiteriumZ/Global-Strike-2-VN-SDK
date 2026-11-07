using System.Collections.Generic;
using Assets.Sources.Free.UI;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Free.Effect;

public class EffectCreateHandler : ISimpleMesssageHandler
{
	private const string DEBUG_ID = "debug_effect";

	private static FreeRenderObject debug;

	private BattleRoomContext _battleRoomContext;

	public EffectCreateHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public bool CanHandle(int key)
	{
		return key == 60;
	}

	public void Handle(SimpleProto simpleUI)
	{
		FreeRenderObject freeRenderObject = build(simpleUI);
		if (freeRenderObject == null)
		{
			return;
		}
		if (freeRenderObject.Key == "debug_effect")
		{
			if (debug != null)
			{
				FreeEffectManager.GetInstance().RemoveEffect(debug);
			}
			debug = freeRenderObject;
		}
		FreeEffectManager.GetInstance().AddEffect(freeRenderObject);
	}

	private FreeRenderObject build(SimpleProto sp)
	{
		if (sp.Ss[0].StartsWith("honorHead"))
		{
			int key = int.Parse(sp.Ss[0].Split("honorHead")[1]);
			if (!_battleRoomContext.playerInfo.AllHonorDic.ContainsKey(key))
			{
				_battleRoomContext.playerInfo.AllHonorDic[key] = new List<string>();
			}
			_battleRoomContext.playerInfo.AllHonorDic[key].Clear();
			if (!_battleRoomContext.playerInfo.AllCareerDic.ContainsKey(key))
			{
				_battleRoomContext.playerInfo.AllCareerDic[key] = new List<string>();
			}
			_battleRoomContext.playerInfo.AllCareerDic[key].Clear();
			for (int i = 4; i < sp.Ss.Count; i += 2)
			{
				if (sp.Ss[i] == "")
				{
					continue;
				}
				string[] array = sp.Ss[i].Split("_$$$_");
				string item = array[3].Replace(".atf", ".png");
				if (array[0] == "1")
				{
					if (!_battleRoomContext.playerInfo.AllHonorDic[key].Contains(item))
					{
						_battleRoomContext.playerInfo.AllHonorDic[key].Add(item);
					}
				}
				else if (!_battleRoomContext.playerInfo.AllCareerDic[key].Contains(item))
				{
					_battleRoomContext.playerInfo.AllCareerDic[key].Add(item);
				}
			}
			return null;
		}
		GameObject gameObject = new GameObject(sp.Ss[0]);
		gameObject.transform.SetParent(FreeEffectManager.GetInstance().GetEffectParent());
		FreeRenderObject freeRenderObject = gameObject.AddComponent<FreeRenderObject>();
		string text = sp.Ss[3];
		if (text != null && text != "" && text.Split(",").Length == 3)
		{
			freeRenderObject.Fixed = true;
		}
		freeRenderObject.Key = sp.Ss[0];
		freeRenderObject.Name = sp.Ss[0];
		freeRenderObject.SetGameObjectName("FreeRender_" + freeRenderObject.Name);
		freeRenderObject.RaderImage = new RaderImage();
		freeRenderObject.RaderImage.RadarImage = sp.Ss[1];
		freeRenderObject.Visible = sp.Bs[0];
		freeRenderObject.NeedPvs = sp.Bs[1];
		freeRenderObject.HideHpNumber = sp.Bs.Count > 2 && sp.Bs[2];
		freeRenderObject.SetPos(sp.Fs[0], sp.Fs[1], sp.Fs[2], sp.Fs[3], sp.Fs[4], sp.Fs[5], sp.Fs[6], sp.Fs[7], sp.Fs[8]);
		for (int j = 1; j < sp.Ks.Count; j++)
		{
			IFreeEffect effect = FreeUIUtil.GetInstance().GetEffect(sp.Ks[j]);
			if (effect == null)
			{
				this.LogErrorFormat("Effect Component is not exist {0}", sp.Ks[j]);
				continue;
			}
			effect.Initial(sp.Ss[j * 2 + 2], sp.Ss[j * 2 + 3]);
			effect.SetPos(sp.Fs[9 * j], sp.Fs[9 * j + 1], sp.Fs[9 * j + 2], sp.Fs[9 * j + 3], sp.Fs[9 * j + 4], sp.Fs[9 * j + 5], sp.Fs[9 * j + 6], sp.Fs[9 * j + 7], sp.Fs[9 * j + 8]);
			freeRenderObject.AddEffect(effect);
		}
		freeRenderObject.InitialAuto(sp.Ss[2]);
		return freeRenderObject;
	}
}
