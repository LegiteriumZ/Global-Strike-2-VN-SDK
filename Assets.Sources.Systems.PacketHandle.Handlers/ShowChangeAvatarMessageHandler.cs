using Assets.Sources.Components.GameRule.Biochemical;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class ShowChangeAvatarMessageHandler : ApcPacketHandler<ChangeAvatarData>
{
	private GameRuleContext _gameRuleContext;

	public ShowChangeAvatarMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 103;
	}

	public override void Handle(ChangeAvatarData data)
	{
		BioSelectAvatarDataComponent bioSelectAvatarData = _gameRuleContext.bioSelectAvatarData;
		bioSelectAvatarData.SelectType = data.Type;
		if (data.Type == 1)
		{
			bioSelectAvatarData.HasModel1 = (data.HasCode & 2) > 0;
			bioSelectAvatarData.HasModel2 = (data.HasCode & 0x10) > 0;
			bioSelectAvatarData.HasModel3 = (data.HasCode & 4) > 0;
			bioSelectAvatarData.HasModel4 = (data.HasCode & 8) > 0;
			bioSelectAvatarData.HasModel5 = (data.HasCode & 0x20) > 0;
			bioSelectAvatarData.HasModel6 = (data.HasCode & 0x10000) > 0;
			bioSelectAvatarData.HasModel7 = (data.HasCode & 0x80000) > 0;
			bioSelectAvatarData.HasModel8 = (data.HasCode & 0x100000) > 0;
			bioSelectAvatarData.HasModel9 = (data.HasCode & 0x1000000) > 0;
			if (data.Selected == 2)
			{
				bioSelectAvatarData.CheckedModel = 0;
			}
			if (data.Selected == 16)
			{
				bioSelectAvatarData.CheckedModel = 1;
			}
			if (data.Selected == 4)
			{
				bioSelectAvatarData.CheckedModel = 2;
			}
			if (data.Selected == 8)
			{
				bioSelectAvatarData.CheckedModel = 3;
			}
			if (data.Selected == 32)
			{
				bioSelectAvatarData.CheckedModel = 4;
			}
			if (data.Selected == 65536)
			{
				bioSelectAvatarData.CheckedModel = 5;
			}
			if (data.Selected == 524288)
			{
				bioSelectAvatarData.CheckedModel = 6;
			}
			if (data.Selected == 1048576)
			{
				bioSelectAvatarData.CheckedModel = 7;
			}
			if (data.Selected == 16777216)
			{
				bioSelectAvatarData.CheckedModel = 8;
			}
		}
		else if (data.Type == 4)
		{
			bioSelectAvatarData.HasModel3 = (data.HasCode & 0x8000) > 0;
			if (data.Selected == 16384)
			{
				bioSelectAvatarData.CheckedModel = 0;
			}
			if (data.Selected == 8192)
			{
				bioSelectAvatarData.CheckedModel = 1;
			}
			if (data.Selected == 32768)
			{
				bioSelectAvatarData.CheckedModel = 2;
			}
		}
		else if (data.Type == 6)
		{
			bioSelectAvatarData.HasModel2 = (data.HasCode & 0x40000) > 0;
			if (data.Selected == 131072)
			{
				bioSelectAvatarData.CheckedModel = 0;
			}
			if (data.Selected == 262144)
			{
				bioSelectAvatarData.CheckedModel = 1;
			}
		}
		bioSelectAvatarData.SelectTime = data.Time;
	}
}
