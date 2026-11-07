using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;

namespace Assets.Sources.Free.UI;

public interface IFreeComponent
{
	int Type { get; }

	int ValueType { get; }

	string Key { get; }

	bool IsIKeyboardResponder { get; set; }

	FreeUIEvent FreeUIEvent { get; }

	string EventKey { get; set; }

	bool CanDrag { get; set; }

	bool IsNoMouse { get; }

	SimpleFreeUI FreeUi { get; set; }

	void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true);

	void RefreshPosition();

	void SetParentKey(string parentKey);

	void SetValue(SetValueAdapter.SetValueData a, SetValueAdapter.SetValueData b);

	void Initial(params object[] init);

	void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup group);

	IUiObject ToUI();

	IFreeComponent Clone();

	void Destroy();

	void AddKeyBoardResponder();

	bool ShowMouse();

	string ToStr();

	void initToBeBindAutos(string simpleProtoS);

	void SetRelation(SimpleFreeUI freeUi);
}
