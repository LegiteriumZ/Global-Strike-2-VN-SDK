using System.Collections.Generic;

namespace Assets.Scripts.Utility.Sound;

public class AutoSoundEventConfig
{
	public string EventType;

	public int Probability;

	public int EventPriority;

	public bool CanClose;

	public List<AutoSoundItemConfig> SoundItems;
}
