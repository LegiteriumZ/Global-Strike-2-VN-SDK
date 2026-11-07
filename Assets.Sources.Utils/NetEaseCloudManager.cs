using System;
using System.IO;
using System.Text;
using Assets.Sources.Config;
using Assets.Sources.Utils.EventLogger;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Utility;
using zlib;

namespace Assets.Sources.Utils;

public class NetEaseCloudManager : MonoBehaviourSingleton<NetEaseCloudManager>
{
	public void Init()
	{
	}

	public void Send(byte[] bytes, int methodId)
	{
		try
		{
			RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
			GameBootConfig gameBootConfig = TplManager.Instance.GameBootConfig;
			BinaryDataWriter binaryDataWriter = new BinaryDataWriter();
			WriteString(binaryDataWriter, gameBootConfig.ExternalUrl);
			string text = "&platform=" + gameBootConfig.Platform + "&serverId=" + gameBootConfig.ServerId + "&uid=" + gameBootConfig.UserId + "&charId=" + gameBootConfig.CharId + "&ruleType=" + 1 + "&gamePlugFlag=" + 1 + "&raceType=" + data.RaceType + "&sceneId=" + data.SceneId;
			string mD5HashFromFile = Md5Utility.GetMD5HashFromFile(Encoding.Default.GetBytes(text + "adf35b91c956e63f7de79c5513f5823e"));
			WriteString(binaryDataWriter, text);
			WriteString(binaryDataWriter, mD5HashFromFile);
			binaryDataWriter.WriteByteArray(bytes, 0, bytes.Length);
			byte[] bytes2 = binaryDataWriter.GetBytes();
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zOutputStream = new ZOutputStream(memoryStream, -1);
			zOutputStream.Write(bytes2, 0, bytes2.Length);
			zOutputStream.finish();
			zOutputStream.Close();
			ImgData message = new ImgData
			{
				Content = memoryStream.GetBuffer(),
				Type = MonoBehaviourSingleton<ScreenShotManager>.Instance.ScreenImageReason
			};
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(methodId, message);
			if (methodId == 14)
			{
				Assets.Sources.Utils.EventLogger.EventLogger.Instance.StageLogger("SendMethodId ", StartStageEnum.NetEasePerspective);
			}
			else
			{
				Assets.Sources.Utils.EventLogger.EventLogger.Instance.StageLogger("Send:" + Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid, StartStageEnum.NetEase);
			}
		}
		catch (Exception args)
		{
			this.LogErrorFormat("NetEaseError{0}", args);
		}
	}

	public void WriteString(BinaryDataWriter binaryDataWriter, string data)
	{
		binaryDataWriter.WriteShort((short)data.Length);
		binaryDataWriter.WriteUtf(data, 0);
	}
}
