namespace Assets.UiFramework.Libs;

public interface IDragSource
{
	void OnStartDrag(Dragable drag);

	object GetDragData(Dragable drag);
}
