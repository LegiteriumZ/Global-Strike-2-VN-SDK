using System.Collections.Generic;
using Assets.Sources.Components.GameRule.BioUnionBase;
using NetData;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BioHumChosePlayerPanelHandler : ApcPacketHandler<NBioUnionInitData>
{
	private GameRuleContext _context;

	public BioHumChosePlayerPanelHandler(Contexts contexts)
	{
		_context = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 614;
	}

	public override void Handle(NBioUnionInitData data)
	{
		_context.bioUnionBaseData.SelectPlayerPanelShow = true;
		_context.bioUnionBaseData.nowPage = 0;
		_context.bioUnionBaseData.totalPage = 0;
		if (data != null && data.CareerList != null)
		{
			_context.bioUnionBaseData.changeToGhostCountDown = 20000;
			if (_context.bioUnionBaseData.careerList == null)
			{
				_context.bioUnionBaseData.careerList = new List<BioUnionCareerInfo>();
			}
			_context.bioUnionBaseData.careerList.Clear();
			foreach (NBioUnionCareerData career in data.CareerList)
			{
				BioUnionCareerInfo item = new BioUnionCareerInfo
				{
					career = career.Career,
					isLock = career.Lock
				};
				_context.bioUnionBaseData.careerList.Add(item);
			}
			_context.bioUnionBaseData.totalPage = Mathf.CeilToInt((float)data.CareerList.Count / 9f);
		}
		else
		{
			_context.bioUnionBaseData.careerList.Clear();
			_context.bioUnionBaseData.SelectPlayerPanelShow = false;
		}
	}
}
