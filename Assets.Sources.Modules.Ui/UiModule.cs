using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Free;
using Assets.Sources.Modules.Ui.Cross;
using Assets.Sources.Modules.Ui.Message;
using Assets.Sources.Modules.Ui.UiEditorRunTime;
using Assets.Sources.Modules.Ui.Utils;
using Assets.Sources.Modules.Ui.Weapon;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;

namespace Assets.Sources.Modules.Ui;

public class UiModule : CompositeGameModule
{
	private class UiModeModule : GameModule
	{
		private readonly UiModeDelegate _delegate;

		private UiEditorLoadSystem _uiEditorLoadSystem;

		private RuleUiLoadSystem _ruleUiLoadSystem;

		public UiModeModule(Contexts contexts)
			: base(contexts)
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
			_delegate = new UiModeDelegate(contexts);
			_uiEditorLoadSystem = new UiEditorLoadSystem(contexts);
			_ruleUiLoadSystem = new RuleUiLoadSystem(contexts);
		}

		protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
		{
			systems.Add(_delegate);
			systems.Add(_uiEditorLoadSystem);
			systems.Add(_ruleUiLoadSystem);
		}

		protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
		{
			systems.Add(new NotifyInitSystem(contexts));
			systems.Add(_delegate);
			systems.Add(new FreeFrameSystem());
			systems.Add(new RuleUiPlaybackSystem(contexts));
			systems.Add(new UiEditorPlaybackSystem(contexts));
		}

		protected override void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
		{
			systems.Add(_delegate);
		}

		protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
		{
			systems.Add(_delegate);
			systems.Add(_uiEditorLoadSystem);
			systems.Add(_ruleUiLoadSystem);
		}

		protected override void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
		{
			systems.Add(new UiEditorDestorySystem(contexts));
		}
	}

	public UiModule(Contexts contexts)
	{
		AddModule(new UiModeModule(contexts));
		AddModule(new CrossModule(contexts));
		AddModule(new WeaponModule(contexts));
		AddModule(new UiCommonChatModule(contexts));
		AddModule(new UiUtilsModule(contexts));
	}
}
