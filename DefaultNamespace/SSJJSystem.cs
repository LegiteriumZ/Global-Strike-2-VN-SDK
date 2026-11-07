using Entitas;

namespace DefaultNamespace;

public class SSJJSystem : Systems
{
	public void Clear()
	{
		_initializeSystems.Clear();
		_executeSystems.Clear();
		_cleanupSystems.Clear();
		_tearDownSystems.Clear();
	}
}
