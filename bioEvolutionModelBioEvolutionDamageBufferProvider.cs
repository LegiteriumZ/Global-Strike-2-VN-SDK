using System.Collections.Generic;
using Assets.Sources.Components.Time;

public class bioEvolutionModelBioEvolutionDamageBufferProvider : IbioEvolutionModelBioEvolutionDamageBufferProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private readonly Dictionary<int, string> _lvDirDictionary = new Dictionary<int, string>();

	public bioEvolutionModelBioEvolutionDamageBufferProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.bioEvolutionDamage.VisiableTime > 0)
		{
			_gameRuleContext.bioEvolutionDamage.VisiableTime -= time.FrameInterval;
		}
	}

	private string GetBufferUrl(int lv)
	{
		string value = null;
		if (!_lvDirDictionary.TryGetValue(lv, out value))
		{
			value = "/ui/GameGUIRes/bioEvolutionModel/danageBuffer/" + lv;
			_lvDirDictionary.Add(lv, value);
		}
		return value;
	}

	public string getBufferUrl()
	{
		return GetBufferUrl(_gameRuleContext.bioEvolutionDamage.Lv);
	}

	public bool isShow()
	{
		return _gameRuleContext.bioEvolutionDamage.VisiableTime > 0;
	}
}
