using System;
using Assets.Generated.Table;
using Assets.Sources.Free.Effect;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using SSJJUserCmd;
using physics.trace;
using share;
using share.constant;

namespace Assets.Sources.Modules.Player.Move;

public class UltimateChallengeClientHandler
{
	public static bool startLand;

	public static bool landed;

	public static long startTime;

	public static long lastCheckTime;

	public static long lastSetTime;

	public static void handle(PlayerEntity player, IUserCmd cmd, Contexts contexts)
	{
		if (player.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID))
		{
			if (lastSetTime != contexts.weapon.currentWeaponEntity.power.Power2)
			{
				lastCheckTime = contexts.weapon.currentWeaponEntity.power.Power2;
				lastSetTime = lastCheckTime;
			}
			if (player.clientTime.ClientTime <= lastCheckTime + 100)
			{
				return;
			}
			lastCheckTime = player.clientTime.ClientTime;
			float[] dir = new float[3] { 0f, 0f, -1f };
			float[] dir2 = new float[3]
			{
				player.move.Velocity.x,
				player.move.Velocity.y,
				player.move.Velocity.z
			};
			float[] startPos = new float[3]
			{
				player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x,
				player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y,
				player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z
			};
			if (!startLand && (checkHitWorld(dir, 2400f, startPos, contexts.battleRoom, player) || checkHitWorld(dir2, 1000f, startPos, contexts.battleRoom, player)))
			{
				startLand = true;
				PlayerAnimationUtility.SetLegsAnimation(player, 209);
				PlayerAnimationUtility.SetTorseAnimation(player, 208);
				AssetInfo info = new AssetInfo("sound/free", "AudioLanding");
				MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref info);
				landed = false;
				startTime = player.clientTime.ClientTime;
			}
			_ = startLand;
		}
		if (startLand && !landed && player.clientTime.ClientTime > startTime + 1080)
		{
			AssetInfo info2 = new AssetInfo("sound/free", "AudioLanded");
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Other, player.isMyPlayer, info2, VectorCoordConverter.SsjjToUnity(player.GetCompenstatePos(player.fpos.Change.GetPosIndex())), 1f, 1000);
			CreateEffectAndShow(player, contexts);
			landed = true;
		}
	}

	private static void CreateEffectAndShow(PlayerEntity player, Contexts contexts)
	{
		SimpleProto simpleProto = new SimpleProto();
		simpleProto.Key = 60;
		simpleProto.Bs.Add(item: true);
		simpleProto.Bs.Add(item: false);
		simpleProto.Fs.Add(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x);
		simpleProto.Fs.Add(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y);
		simpleProto.Fs.Add(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Ks.Add(1);
		simpleProto.Ss.Add("landEffect" + player.basicInfo.Cid);
		simpleProto.Ss.Add("");
		simpleProto.Ss.Add("");
		simpleProto.Ss.Add("");
		simpleProto.Ks.Add(3);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(1f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Fs.Add(0f);
		simpleProto.Ss.Add("luodi");
		simpleProto.Ss.Add("");
		new EffectCreateHandler(contexts).Handle(simpleProto);
		SimpleProto simpleProto2 = new SimpleProto();
		simpleProto2.Key = 61;
		simpleProto2.Ss.Add("landEffect" + player.basicInfo.Cid);
		simpleProto2.Ks.Add(100000);
		new EffectShowHandler(contexts).Handle(simpleProto2);
	}

	private static bool checkHitWorld(float[] dir, float dis, float[] startPos, BattleRoomContext battleRoomContext, PlayerEntity player)
	{
		VectorUtils.VectorNormalize(dir);
		Trace trace = TraceObjectPool.AllocateTrace();
		float[] array = TraceObjectPool.AllocateFloat3();
		float[] array2 = TraceObjectPool.AllocateFloat3();
		float[] array3 = TraceObjectPool.AllocateFloat3();
		float[] array4 = TraceObjectPool.AllocateFloat3();
		if (trace != null && array != null && array2 != null && array3 != null && array4 != null)
		{
			try
			{
				VectorUtils.VectorSet(array3, -1.0, -1.0, -1.0);
				VectorUtils.VectorSet(array4, 1.0, 1.0, 1.0);
				array[0] = startPos[0];
				array[1] = startPos[1];
				array[2] = startPos[2];
				VectorUtils.VectorMA(array, dis, dir, array2);
				battleRoomContext.pyEngine.PyEngine.GetWorld().WorldTrace(trace, array, array2, array3, array4, 1, null, 1);
				if ((double)Math.Abs(trace.fraction - 1f) < 0.0001)
				{
					return false;
				}
				return true;
			}
			finally
			{
				TraceObjectPool.ReturnTrace(trace);
				TraceObjectPool.ReturnFloat3(array);
				TraceObjectPool.ReturnFloat3(array2);
				TraceObjectPool.ReturnFloat3(array3);
				TraceObjectPool.ReturnFloat3(array4);
			}
		}
		return false;
	}
}
