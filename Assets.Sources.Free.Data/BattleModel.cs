using NetData;
using UnityEngine;

namespace Assets.Sources.Free.Data;

public class BattleModel
{
	public ProfitModelWrapper ProfitModel;

	public RoomData RoomData;

	public bool IsMatch;

	public bool IsMatchWaitPlayer;

	public bool IsObserver;

	public Vector3 ShakeAngleOffect;

	public BattleModel()
	{
		ProfitModel = new ProfitModelWrapper();
	}
}
