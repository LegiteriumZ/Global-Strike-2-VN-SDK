public interface IrpgModelrpgplayerbufferProvider : IModuleProvider
{
	bool IsBufferItemShow(int index);

	float RefreshBufferItemAlpha(int index);

	string RefreshBufferIcon(int index);

	bool IsRpgBufferShow();
}
