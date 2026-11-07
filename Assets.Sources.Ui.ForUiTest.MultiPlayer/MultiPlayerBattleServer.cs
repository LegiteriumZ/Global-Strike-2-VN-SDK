using System;
using System.Collections.Generic;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Networking.Server;
using Assets.Sources.Snapshots;
using NetData;
using SSJJBase.Utility;
using SSJJNetworking.BattleServer;
using SSJJUserCmd;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public class MultiPlayerBattleServer : BattleServer
{
	public BattleGameState GameState;

	public DateTime LastSendP2PTime = DateTime.MinValue;

	public List<Snapshot> PartialSnapshots = new List<Snapshot>();

	public PlayerEntityData PlayerData;

	public int CmdSeq = 1;

	private bool _loadSuccess;

	public DateTime ReceiveSnapshotTime;

	public int ReceiveSnapshotLatency
	{
		get
		{
			if (ReceiveSnapshotTime == DateTime.MinValue)
			{
				return 0;
			}
			return (int)(DateTime.Now - ReceiveSnapshotTime).TotalMilliseconds;
		}
	}

	public MultiPlayerBattleServer(ISnapShotCompress snapShotCompress, List<int> ignoreTcpList, bool debugUdpBytes, bool auto = true)
		: base(snapShotCompress, ignoreTcpList, debugUdpBytes, auto)
	{
		MultiPlayerServerManager.MultiPlayerInstances.Add(this);
		MultiPlayerServerManager.MultiPlayerInstances.Add(_tcpPacketFactory);
		MultiPlayerServerManager.MultiPlayerInstances.Add(_udpPacketFactory);
		MultiPlayerServerManager.MultiPlayerInstances.Add(_tcpPacketQueue);
		MultiPlayerServerManager.MultiPlayerInstances.Add(_udpPacketQueue);
	}

	public override void Update()
	{
		base.Update();
		if (base.State == BattleServerState.Connected && GameState == BattleGameState.WaitingSnapshot && !_loadSuccess && base.ConnectionId != 0)
		{
			UdpConnectionIDData message = new UdpConnectionIDData
			{
				Id = base.ConnectionId
			};
			SendTcpMessage(3, message);
			_loadSuccess = true;
		}
		else if (base.State == BattleServerState.Connected && (GameState == BattleGameState.WaitingP2P || GameState == BattleGameState.WaitingSnapshot) && (DateTime.Now - LastSendP2PTime).TotalMilliseconds > 500.0)
		{
			SendUdpP2PData(0, splice: true, compress: false);
			LastSendP2PTime = DateTime.Now;
		}
		else if (PartialSnapshots.Count > 0)
		{
			GameState = BattleGameState.Gaming;
			SendUdpData(2, GetUserCmdBytes(Contexts.sharedInstance.userCommand.commands.CommandToSendList, out var _));
		}
	}

	public byte[] GetUserCmdBytes(LinkedList<UserCmd> sendCmdList, out int datalen)
	{
		datalen = 0;
		if (sendCmdList.Count == 0)
		{
			return null;
		}
		bool flag = !MultiPlayerServerManager.ConnectSelected.Contains(base.ConnectionId);
		bool flag2 = MultiPlayerServerManager.SimpleCopy || flag;
		LinkedListNode<UserCmd> first = sendCmdList.First;
		UserCmd value = first.Value;
		BinaryDataWriter binaryDataWriter = new BinaryDataWriter();
		int num = ReceiveSnapshotLatency;
		if (num > 255)
		{
			num = 255;
		}
		binaryDataWriter.WriteByte((byte)num);
		binaryDataWriter.WriteInt(CmdSeq++);
		binaryDataWriter.WriteInt(value.RenderTime);
		int seqId = PartialSnapshots[PartialSnapshots.Count - 1].SeqId;
		binaryDataWriter.WriteInt(seqId);
		int num2 = 0;
		num2 = num2 | 8 | 4 | 1 | 2 | 0x20 | 0x10 | 0x80;
		binaryDataWriter.WriteByte((byte)num2);
		binaryDataWriter.WriteByte((byte)value.FrameInterval);
		int num3 = ((!flag2) ? ((int)value.MoveForward) : 0);
		int num4 = ((!flag2) ? ((int)value.MoveRight) : 0);
		binaryDataWriter.WriteByte((byte)num3);
		binaryDataWriter.WriteByte((byte)num4);
		int v = ((!flag) ? value.Buttons : 0);
		binaryDataWriter.WriteInt(v);
		int num5 = 0;
		if (!flag)
		{
			num5 |= value.BagId;
			num5 <<= 4;
			num5 |= value.Weapon;
		}
		binaryDataWriter.WriteByte((byte)num5);
		binaryDataWriter.WriteShort(flag2 ? ((short)(PlayerData.ViewYaw * 100f)) : value.CameraYaw);
		binaryDataWriter.WriteShort(flag2 ? ((short)(PlayerData.ViewPitch * 100f)) : value.CameraPitch);
		UserCmd userCmd = value;
		for (first = first.Next; first != null; first = first.Next)
		{
			num2 = 0;
			UserCmd value2 = first.Value;
			int position = binaryDataWriter.Position;
			binaryDataWriter.WriteByte((byte)num2);
			if (value2.FrameInterval != userCmd.FrameInterval)
			{
				num2 |= 1;
				binaryDataWriter.WriteByte((byte)value2.FrameInterval);
			}
			if (!flag2 && (value2.MoveForward != userCmd.MoveForward || value2.MoveRight != userCmd.MoveRight))
			{
				num2 |= 2;
				num3 = (int)value2.MoveForward;
				num4 = (int)value2.MoveRight;
				binaryDataWriter.WriteByte((byte)num3);
				binaryDataWriter.WriteByte((byte)num4);
			}
			if (!flag)
			{
				if (value2.Buttons != userCmd.Buttons)
				{
					num2 |= 4;
					binaryDataWriter.WriteInt(value2.Buttons);
				}
				if (value2.Weapon != userCmd.Weapon || value2.BagId != userCmd.BagId)
				{
					num2 |= 8;
					num5 = 0;
					num5 |= value2.BagId;
					num5 <<= 4;
					num5 |= value2.Weapon;
					binaryDataWriter.WriteByte((byte)num5);
				}
			}
			if (!flag2)
			{
				if (value2.CameraYaw != userCmd.CameraYaw)
				{
					num2 |= 0x10;
					binaryDataWriter.WriteShort(value2.CameraYaw);
				}
				if (value2.CameraPitch != userCmd.CameraPitch)
				{
					num2 |= 0x20;
					binaryDataWriter.WriteShort(value2.CameraPitch);
				}
			}
			if (value2.RenderTime != userCmd.RenderTime + value2.FrameInterval)
			{
				if (Math.Abs(value2.RenderTime - userCmd.RenderTime) <= 127)
				{
					num2 |= 0x40;
					binaryDataWriter.WriteByte((byte)(value2.RenderTime - userCmd.RenderTime));
				}
				else
				{
					num2 |= 0x80;
					binaryDataWriter.WriteInt(value2.RenderTime);
				}
			}
			userCmd = value2;
			int position2 = binaryDataWriter.Position;
			binaryDataWriter.Position = position;
			binaryDataWriter.WriteByte((byte)num2);
			binaryDataWriter.Position = position2;
		}
		byte[] orCreateNormalByte = NetByteFactory.Instance.GetOrCreateNormalByte(binaryDataWriter.Length);
		binaryDataWriter.SetBytes(orCreateNormalByte);
		datalen = orCreateNormalByte.Length;
		return orCreateNormalByte;
	}
}
