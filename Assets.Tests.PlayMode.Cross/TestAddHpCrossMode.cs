using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.BigHead;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Weapon;

namespace Assets.Tests.PlayMode.Cross;

public class TestAddHpCrossMode : AbstractMode
{
	private SpecialCrossModel _specialCross = new SpecialCrossModel();

	private DangongCrossModel _dangongCross = new DangongCrossModel();

	private G36CCrossModel _g36CCross = new G36CCrossModel();

	private Mp5sd6DevilCrossModel _mp5sd6DevilCross = new Mp5sd6DevilCrossModel();

	private RedpointModel _redPointCross = new RedpointModel();

	public static TestAddHpCrossMode Instance;

	public TestAddHpCrossMode(Contexts contexts)
		: base(contexts, flag: false)
	{
		Instance = this;
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
		AddPlaybackSystem(new AddHpCrossModel());
		AddPlaybackSystem(_specialCross);
		AddPlaybackSystem(_dangongCross);
		AddPlaybackSystem(_g36CCross);
		AddPlaybackSystem(_mp5sd6DevilCross);
		AddPlaybackSystem(_redPointCross);
	}

	public void SetCross(int type)
	{
		_specialCross.Visible(type == 1);
		_dangongCross.Visible(type == 2);
		_g36CCross.Visible(type == 3);
		_mp5sd6DevilCross.Visible(type == 4);
		_redPointCross.Visible(type == 5);
	}
}
