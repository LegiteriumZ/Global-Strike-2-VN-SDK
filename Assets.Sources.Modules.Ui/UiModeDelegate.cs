using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Modules.Ui.NewMode;
using Assets.UiFramework.Libs;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Ui;

public class UiModeDelegate : IPlaybackSystem, IResourceInitSystem, IResourceLoadSystem, IPreRenderSystem
{
	private readonly Contexts _contexts;

	private readonly BattleRoomContext _battleRoomContext;

	private bool _raceTypeUnknown = true;

	private BaseUiMode _uiMode;

	private readonly UiResourcesLoader _resourcesLoader;

	public BaseUiMode UiMode => _uiMode;

	public static UiModeDelegate Instance { get; set; }

	public void Clear()
	{
		Instance.UiMode.Clear();
		Instance._uiMode = null;
		Instance = null;
		_uiMode = null;
	}

	public UiModeDelegate(Contexts contexts)
	{
		Instance = this;
		_contexts = contexts;
		_battleRoomContext = contexts.battleRoom;
		_resourcesLoader = new UiResourcesLoader(contexts);
		AbstractModel.SetUiResourceLoader(_resourcesLoader);
	}

	public void OnInitResources()
	{
		if (_raceTypeUnknown && _battleRoomContext.hasRoomData)
		{
			_raceTypeUnknown = false;
			CreateUi(_battleRoomContext.roomData.Data.RaceType);
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		_resourcesLoader.OnLoadResources(coRoutineManager);
	}

	public void OnPlayback()
	{
		AbstractModel.InvokeInstantiate();
		AbstractModel.InvokePreSubscribe();
		if (_battleRoomContext.gameState.LoadingFinish)
		{
			AbstractModel.InvokeSubscribe();
			if (_uiMode != null)
			{
				_uiMode.OnPlayback();
			}
		}
	}

	public void OnPreRender()
	{
		if (_battleRoomContext.gameState.LoadingFinish)
		{
			AbstractModel.InvokeUpdateHandler();
		}
	}

	private void CreateUi(int raceType)
	{
		GameUiModeFactory gameUiModeFactory = new GameUiModeFactory();
		_uiMode = gameUiModeFactory.CreateUiMode(raceType, _contexts);
		if (_uiMode != null)
		{
			_uiMode.Initialize();
		}
	}
}
