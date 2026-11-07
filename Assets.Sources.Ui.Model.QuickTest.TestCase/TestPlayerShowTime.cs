using Assets.Sources.Systems.PacketHandle.Handlers;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using NetData;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestPlayerShowTime : QuickTestCase
{
	public TestPlayerShowTime(Contexts contexts)
		: base(contexts)
	{
		TestPlayerShowTime testPlayerShowTime = this;
		KillPlayerInfoDataHandler killHandler = new KillPlayerInfoDataHandler(contexts);
		AddAction(1000, delegate
		{
			PlayerEntity enemyEntity2 = testPlayerShowTime.GetEnemyEntity();
			killHandler.Handle(new KillPlayerInfoData
			{
				CurKillNum = 1,
				KillPlayerId = contexts.player.cameraOwnerEntity.GetId(),
				BeKillPlayerId = (enemyEntity2?.GetId() ?? 0)
			});
		}, () => !NetRecordManager.Playing);
		AddAction(3000, delegate
		{
			PlayerEntity enemyEntity = testPlayerShowTime.GetEnemyEntity();
			killHandler.Handle(new KillPlayerInfoData
			{
				CurKillNum = 2,
				KillPlayerId = contexts.player.cameraOwnerEntity.GetId(),
				BeKillPlayerId = (enemyEntity?.GetId() ?? 0)
			});
		});
		AssistsnumDataHandler assistHandler = new AssistsnumDataHandler(contexts);
		AddAction(3000, delegate
		{
			assistHandler.Handle(new object());
		});
		AddAction(1000, delegate
		{
			PlayerShowTimeViewModel property = testPlayerShowTime.GetProperty<PlayerShowTimeModel, PlayerShowTimeViewModel>("ViewModel");
			QuickTestCase.Assert(!property.ContinusKillShow, "viewModel.ContinusKillShow == false");
			QuickTestCase.Assert(!property.RevengeShow, "viewModel.RevengeShow == false");
			QuickTestCase.Assert(!property.GradeShow, "viewModel.GradeShow == false");
			QuickTestCase.Assert(property.ShowAlpha >= 1f, "viewModel.ShowAlpha >= 1");
		});
	}
}
