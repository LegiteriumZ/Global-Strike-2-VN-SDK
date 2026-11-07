namespace Assets.UiFramework.Libs;

public interface IDragTarget
{
	void OnEndDrag(DropZone target, Dragable drag);

	void OnDragHover(DropZone drop, Dragable drag);
}
