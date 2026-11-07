using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class StealExpertMaterialHandler : ApcPacketHandler<MaterialsData>
{
	private readonly GameRuleContext _gameRuleContext;

	public StealExpertMaterialHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 277;
	}

	public override void Handle(MaterialsData data)
	{
		MaterialsData materialData = _gameRuleContext.rpgCommon.MaterialData;
		if (materialData == null)
		{
			_gameRuleContext.rpgCommon.MaterialData = new MaterialsData
			{
				HoldNum = 0,
				MaxHoldNum = 0,
				SubmitNum = 0,
				MaxSubmitNum = 0
			};
			materialData = _gameRuleContext.rpgCommon.MaterialData;
		}
		if (data.HoldNumSpecified)
		{
			materialData.HoldNum = data.HoldNum;
		}
		if (data.MaxHoldNumSpecified)
		{
			materialData.MaxHoldNum = data.MaxHoldNum;
		}
		if (data.SubmitNumSpecified)
		{
			materialData.SubmitNum = data.SubmitNum;
		}
		if (data.MaxSubmitNumSpecified)
		{
			materialData.MaxSubmitNum = data.MaxSubmitNum;
		}
	}
}
