using System.Collections.Generic;
using Assets.Sources.Free.UI;
using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Effect;

public class EffectShowHandler : ISimpleMesssageHandler
{
	private const string DEBUG_ID = "debug_effect";

	private BattleRoomContext _battleRoomContext;

	public EffectShowHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public bool CanHandle(int key)
	{
		return key == 61;
	}

	public void Handle(SimpleProto sp)
	{
		ShowSimpleStyle show = new ShowSimpleStyle();
		int num = sp.Ks[0];
		string text = sp.Ss[0];
		if (text.StartsWith("honorHead"))
		{
			int value = int.Parse(text.Split("honorHead")[1]);
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(value);
			if (entityWithEntityId != null && num < 0)
			{
				if (!_battleRoomContext.playerInfo.AllHonorDic.ContainsKey(entityWithEntityId.GetId()))
				{
					_battleRoomContext.playerInfo.AllHonorDic[entityWithEntityId.GetId()] = new List<string>();
				}
				_battleRoomContext.playerInfo.AllHonorDic[entityWithEntityId.GetId()].Clear();
				if (!_battleRoomContext.playerInfo.AllCareerDic.ContainsKey(entityWithEntityId.GetId()))
				{
					_battleRoomContext.playerInfo.AllCareerDic[entityWithEntityId.GetId()] = new List<string>();
				}
				_battleRoomContext.playerInfo.AllCareerDic[entityWithEntityId.GetId()].Clear();
			}
			return;
		}
		FreeRenderObject effect = FreeEffectManager.GetInstance().GetEffect(text);
		if (effect != null)
		{
			if (sp.Fs.Count == 9)
			{
				effect.Move(sp.Fs[0], sp.Fs[1], sp.Fs[2], sp.Fs[6], sp.Fs[7], sp.Fs[8]);
			}
			if (num < 0)
			{
				effect.Visible = false;
				return;
			}
			effect.Visible = true;
			effect.Show(show, num);
		}
	}
}
