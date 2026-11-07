using System;
using System.Collections.Generic;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Snapshots;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Pool;
using Entitas;
using SSJJBase.Utility;
using SSJJNetworking.BattleServer;
using SSJJUserCmd;

namespace Assets.Sources.Systems.UserCommand;

public class SendUserCommandSystem : IExecuteSystem, ISystem
{
	public static IRecord Record;

	private readonly BattleServerContext _battleServerContext;

	private readonly UserCommandContext _userCommandContext;

	private readonly SnapshotContext _snapshotContext;

	private BinaryDataWriter _binaryDataWriter;

	public SendUserCommandSystem(Contexts contexts)
	{
		_battleServerContext = contexts.battleServer;
		_userCommandContext = contexts.userCommand;
		_snapshotContext = contexts.snapshot;
		_binaryDataWriter = new BinaryDataWriter();
	}

	public void Execute()
	{
		UserCmd currentCmd = _userCommandContext.commands.getCurrentCmd();
		if (currentCmd != null)
		{
			SaveUserCmd(_userCommandContext.commands, currentCmd);
			SendUserCommands(_userCommandContext.commands, _snapshotContext.snapshots);
			_userCommandContext.commands.setCurrentCmd(null);
		}
	}

	private void SendUserCommands(CommandsComponent commands, SnapshotsComponent snapshots)
	{
		if (commands.CommandToSendList.Count > 0 && _battleServerContext.battleServer.Server.State == BattleServerState.Connected)
		{
			int datalen = 0;
			bool isDefaultUseTcp = _battleServerContext.battleServer.Server.IsDefaultUseTcp;
			byte[] userCmdBytes = GetUserCmdBytes(commands.CommandToSendList, snapshots, out datalen, isDefaultUseTcp);
			if (isDefaultUseTcp)
			{
				_battleServerContext.battleServer.Server.SendTcpData(31, userCmdBytes);
			}
			else
			{
				_battleServerContext.battleServer.Server.SendUdpData(2, userCmdBytes);
			}
			NetByteFactory.Instance.AddNormal(userCmdBytes);
		}
	}

	public byte[] GetUserCmdBytes(LinkedList<UserCmd> sendCmdList, SnapshotsComponent snapshots, out int datalen, bool isTcp)
	{
		datalen = 0;
		if (sendCmdList.Count == 0)
		{
			return null;
		}
		bool flag = Record == null || Record.IsSelfMove();
		LinkedListNode<UserCmd> first = sendCmdList.First;
		UserCmd value = first.Value;
		_binaryDataWriter.Reset();
		if (isTcp)
		{
			_binaryDataWriter.WriteByte(31);
		}
		int num = snapshots.ReceiveSnapshotLatency;
		if (num > 255)
		{
			num = 255;
		}
		_binaryDataWriter.WriteByte((byte)num);
		_binaryDataWriter.WriteInt(value.Seq);
		_binaryDataWriter.WriteInt(value.RenderTime);
		_binaryDataWriter.WriteInt(snapshots.LatestSnapshotSeqId);
		int num2 = 0;
		num2 = num2 | 8 | 4 | 1 | 2 | 0x20 | 0x10 | 0x80;
		_binaryDataWriter.WriteByte((byte)num2);
		_binaryDataWriter.WriteByte((byte)value.FrameInterval);
		int num3 = (flag ? ((int)value.MoveForward) : 0);
		int num4 = (flag ? ((int)value.MoveRight) : 0);
		_binaryDataWriter.WriteByte((byte)num3);
		_binaryDataWriter.WriteByte((byte)num4);
		_binaryDataWriter.WriteInt(value.Buttons);
		int num5 = 0;
		num5 |= value.BagId;
		num5 <<= 4;
		num5 |= value.Weapon;
		_binaryDataWriter.WriteByte((byte)num5);
		_binaryDataWriter.WriteShort(value.CameraYaw);
		_binaryDataWriter.WriteShort(value.CameraPitch);
		UserCmd userCmd = value;
		for (first = first.Next; first != null; first = first.Next)
		{
			num2 = 0;
			UserCmd value2 = first.Value;
			int position = _binaryDataWriter.Position;
			_binaryDataWriter.WriteByte((byte)num2);
			if (value2.FrameInterval != userCmd.FrameInterval)
			{
				num2 |= 1;
				_binaryDataWriter.WriteByte((byte)value2.FrameInterval);
			}
			if (flag && (value2.MoveForward != userCmd.MoveForward || value2.MoveRight != userCmd.MoveRight))
			{
				num2 |= 2;
				num3 = (int)value2.MoveForward;
				num4 = (int)value2.MoveRight;
				_binaryDataWriter.WriteByte((byte)num3);
				_binaryDataWriter.WriteByte((byte)num4);
			}
			if (value2.Buttons != userCmd.Buttons)
			{
				num2 |= 4;
				_binaryDataWriter.WriteInt(value2.Buttons);
			}
			if (value2.Weapon != userCmd.Weapon || value2.BagId != userCmd.BagId)
			{
				num2 |= 8;
				num5 = 0;
				num5 |= value2.BagId;
				num5 <<= 4;
				num5 |= value2.Weapon;
				_binaryDataWriter.WriteByte((byte)num5);
			}
			if (value2.CameraYaw != userCmd.CameraYaw)
			{
				num2 |= 0x10;
				_binaryDataWriter.WriteShort(value2.CameraYaw);
			}
			if (value2.CameraPitch != userCmd.CameraPitch)
			{
				num2 |= 0x20;
				_binaryDataWriter.WriteShort(value2.CameraPitch);
			}
			if (value2.RenderTime != userCmd.RenderTime + value2.FrameInterval)
			{
				if (Math.Abs(value2.RenderTime - userCmd.RenderTime) <= 127)
				{
					num2 |= 0x40;
					_binaryDataWriter.WriteByte((byte)(value2.RenderTime - userCmd.RenderTime));
				}
				else
				{
					num2 |= 0x80;
					_binaryDataWriter.WriteInt(value2.RenderTime);
				}
			}
			userCmd = value2;
			int position2 = _binaryDataWriter.Position;
			_binaryDataWriter.Position = position;
			_binaryDataWriter.WriteByte((byte)num2);
			_binaryDataWriter.Position = position2;
		}
		byte[] orCreateNormalByte = NetByteFactory.Instance.GetOrCreateNormalByte(_binaryDataWriter.Length);
		_binaryDataWriter.SetBytes(orCreateNormalByte);
		datalen = orCreateNormalByte.Length;
		return orCreateNormalByte;
	}

	private void SaveUserCmd(CommandsComponent comp, UserCmd cmd)
	{
		cmd.Seq = comp.Counter++;
		if (comp.CommandList.Count >= 200)
		{
			UserCmd value = comp.CommandList.First.Value;
			comp.CommandList.RemoveFirst();
			if (!comp.CommandToSendList.Contains(value))
			{
				UserCmdFactory.Instance().Add(value);
			}
		}
		comp.CommandList.AddLast(cmd);
		if (comp.CommandToSendList.Count >= 5)
		{
			comp.CommandToSendList.RemoveFirst();
		}
		comp.CommandToSendList.AddLast(cmd);
	}
}
