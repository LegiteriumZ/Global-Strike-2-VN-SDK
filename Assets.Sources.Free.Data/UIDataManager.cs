namespace Assets.Sources.Free.Data;

public class UIDataManager : IUIDataManager
{
	private static UIDataManager _instance;

	public SimpleUIData SimpleUIData { get; private set; }

	public SimpleFreeUIData SFreeUIata { get; private set; }

	public AllObserverNameData AllObserverNameData { get; private set; }

	public string FreeType { get; set; }

	public static UIDataManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new UIDataManager();
				_instance.Init();
			}
			return _instance;
		}
	}

	private void Init()
	{
		SFreeUIata = new SimpleFreeUIData();
		AllObserverNameData = new AllObserverNameData();
	}
}
