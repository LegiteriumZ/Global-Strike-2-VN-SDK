using System.Collections;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Free.Sound;

internal class PlaySoundHandler : ISimpleMesssageHandler
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(PlaySoundHandler));

	private Dictionary<AssetInfo, IEnumerator> _soundEnumerators = new Dictionary<AssetInfo, IEnumerator>();

	public bool CanHandle(int key)
	{
		return key == 41;
	}

	private IEnumerator StopSound(AssetInfo info, float delay)
	{
		yield return Yielders.GetWaitForSeconds(delay);
		MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref info);
	}

	private void SetSoundStopDelay(AssetInfo info, float playTime)
	{
		IEnumerator value = null;
		if (!_soundEnumerators.TryGetValue(info, out value))
		{
			value = StopSound(info, playTime);
			_soundEnumerators.Add(info, value);
		}
		else
		{
			if (value != null)
			{
				BaseAsyncManager.Instance.StopCoRoutine(value);
			}
			value = StopSound(info, playTime);
		}
		BaseAsyncManager.Instance.StartCoRoutine(value);
	}

	public void Handle(SimpleProto data)
	{
		string text = "";
		string text2 = "";
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num2 = 1;
		float num3 = 0f;
		if (data.Ss.Count > 0)
		{
			text = data.Ss[0];
		}
		if (data.Ss.Count > 1)
		{
			text2 = data.Ss[1];
		}
		if (data.Ks.Count > 0)
		{
			num = data.Ks[0];
		}
		if (data.Bs.Count > 0)
		{
			flag = data.Bs[0];
		}
		if (data.Bs.Count > 1)
		{
			flag2 = data.Bs[1];
		}
		if (data.Bs.Count > 2)
		{
			flag3 = data.Bs[2];
		}
		if (data.Ins.Count > 0)
		{
			num2 = data.Ins[0];
		}
		if (data.Ins.Count > 1)
		{
			num3 = (float)data.Ins[1] / 1000f;
		}
		string[] array = text.Split('/');
		if (array.Length < 3)
		{
			Logger.ErrorFormat("Sound Info Error, Sound:{0},vol:{1},stop:{2},pos:{3},hasPos:{4}", text);
			return;
		}
		AssetInfo info = new AssetInfo(array[0] + "/" + array[1], array[2].Split('.')[0]);
		if (flag)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref info);
			IEnumerator value = null;
			if (_soundEnumerators.TryGetValue(info, out value))
			{
				if (value != null)
				{
					BaseAsyncManager.Instance.StopCoRoutine(value);
				}
				_soundEnumerators.Remove(info);
			}
		}
		else if (flag2)
		{
			string[] array2 = text2.Split(',');
			if (array2.Length != 3)
			{
				return;
			}
			Vector3 inv = new Vector3(float.Parse(array2[0]), float.Parse(array2[1]), float.Parse(array2[2]));
			inv = VectorCoordConverter.SsjjToUnity(inv);
			if (flag3)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.ChangeSound(ref info, inv);
				return;
			}
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: true, info, inv, GameSoundManager.Config.AsideVolume, 3000, 0, loop: false, num2);
			if (num3 > 0.01f)
			{
				SetSoundStopDelay(info, num3);
			}
		}
		else
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, info, num, 0, loop: false, num2);
			if (num3 > 0.01f)
			{
				SetSoundStopDelay(info, num3);
			}
		}
	}
}
