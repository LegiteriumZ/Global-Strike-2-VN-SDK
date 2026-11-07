namespace Assets.Sources.Free.Data;

public class GameModelLocator
{
	public BattleModel GameModel;

	private static GameModelLocator _instance;

	private GameModelLocator()
	{
		GameModel = new BattleModel();
	}

	public static GameModelLocator GetInstance()
	{
		if (_instance == null)
		{
			_instance = new GameModelLocator();
		}
		return _instance;
	}

	public static void Dispose()
	{
		_instance = null;
	}
}
