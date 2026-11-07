using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using NetData;
using share.constant;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestPlayerBuffer : QuickTestCase
{
	public TestPlayerBuffer(Contexts contexts)
		: base(contexts)
	{
		TestPlayerBuffer testPlayerBuffer = this;
		if (GetProperty<PlayerBufferModel, PlayerBufferViewModel>("ViewModel") != null)
		{
			AddAction(1, delegate
			{
				PlayerInfoData playerInfo2 = contexts.player.myPlayerEntity.GetPlayerInfo();
				playerInfo2.SubHp = true;
				playerInfo2.InFear = true;
				playerInfo2.InChaos = true;
				playerInfo2.InHuoYanXianJi = true;
			}, () => !NetRecordManager.Playing);
			AddAction(1, delegate
			{
				PlayerEntity myPlayerEntity = contexts.player.myPlayerEntity;
				PlayerInfoData playerInfo = myPlayerEntity.GetPlayerInfo();
				_ = myPlayerEntity.skill.Status;
				PlayerBufferViewModel property3 = testPlayerBuffer.GetProperty<PlayerBufferModel, PlayerBufferViewModel>("ViewModel");
				QuickTestCase.Assert(property3.BuffShow11, "playerInfo.SubHp");
				QuickTestCase.Assert(property3.BuffShow12, "playerInfo.InFear");
				QuickTestCase.Assert(property3.BuffShow13, "playerInfo.InChaos");
				QuickTestCase.Assert(property3.BuffShow14, "playerInfo.InHuoYanXianJi");
				playerInfo.SubHp = false;
				playerInfo.InFear = false;
				playerInfo.InChaos = false;
				playerInfo.InHuoYanXianJi = false;
			});
			AddAction(1, delegate
			{
				IMyDictionary<int, PlayerInfoComponent.StatusDes> status2 = contexts.player.myPlayerEntity.skill.Status;
				PlayerBufferViewModel property2 = testPlayerBuffer.GetProperty<PlayerBufferModel, PlayerBufferViewModel>("ViewModel");
				QuickTestCase.Assert(!property2.BuffShow11, "!playerInfo.SubHp");
				QuickTestCase.Assert(!property2.BuffShow12, "!playerInfo.InFear");
				QuickTestCase.Assert(!property2.BuffShow13, "!playerInfo.InChaos");
				QuickTestCase.Assert(!property2.BuffShow14, "!playerInfo.InHuoYanXianJi");
				status2.Remove(PlayerInfoStatusConstant.RED.ID);
				status2.Remove(PlayerInfoStatusConstant.YELLOW.ID);
				status2.Remove(PlayerInfoStatusConstant.BLUE.ID);
				status2.Remove(PlayerInfoStatusConstant.BLACK.ID);
				status2.Remove(PlayerInfoStatusConstant.GREEN.ID);
				status2.Remove(PlayerInfoStatusConstant.WHITE.ID);
			});
			AddAction(1, delegate
			{
				PlayerBufferViewModel property = testPlayerBuffer.GetProperty<PlayerBufferModel, PlayerBufferViewModel>("ViewModel");
				QuickTestCase.Assert(property.BuffShow1, "viewModel.BuffShow1");
				QuickTestCase.Assert(property.BuffShow2, "viewModel.BuffShow2");
				QuickTestCase.Assert(!property.BuffShow3, "!viewModel.BuffShow3");
				QuickTestCase.Assert(!property.BuffShow4, "!viewModel.BuffShow4");
			});
			AddAction(1000, delegate
			{
				IMyDictionary<int, PlayerInfoComponent.StatusDes> status = contexts.player.myPlayerEntity.skill.Status;
				status.Remove(PlayerInfoStatusConstant.RPG_GROUP_HP_ADD.ID);
				status.Remove(PlayerInfoStatusConstant.RPG_GROUP_SHILED_ADD.ID);
			});
		}
	}
}
