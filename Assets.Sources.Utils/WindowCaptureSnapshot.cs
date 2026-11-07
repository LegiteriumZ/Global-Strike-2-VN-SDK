using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using SSJJBase.Singleton;

namespace Assets.Sources.Utils;

public class WindowCaptureSnapshot : AbstractCaptureSnapshot
{
	public override void UpdateScreen()
	{
		if (!IsSendEaseing || !IsCaping)
		{
			return;
		}
		GetPath();
		if (_iw < 256 || _ih < 256)
		{
			ScreenOver();
			return;
		}
		Bitmap bitmap = new Bitmap(_iw, _ih);
		using (Graphics graphics = Graphics.FromImage(bitmap))
		{
			graphics.CopyFromScreen(0, 0, 0, 0, new Size(_iw, _ih), CopyPixelOperation.MergeCopy);
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Jpeg);
			byte[] buffer = memoryStream.GetBuffer();
			memoryStream.Close();
			MonoBehaviourSingleton<NetEaseCloudManager>.Instance.Send(buffer, 115);
		}
		ScreenOver();
	}
}
