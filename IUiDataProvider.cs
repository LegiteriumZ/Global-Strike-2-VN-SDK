public interface IUiDataProvider : IDataProvider
{
	bool KeyCodeInput(int a, int b);

	bool KeyCodeStayInput(int a, int b, int c);

	bool KeyCodeExit(int a, int b);

	bool UiLeftClickListener(int a);

	bool UiRightClickListener(int a);

	bool UiMoveInListener();

	bool UiMoveOutListener();
}
