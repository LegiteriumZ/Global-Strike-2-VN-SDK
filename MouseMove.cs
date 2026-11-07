using System.Runtime.InteropServices;

public class MouseMove
{
	[DllImport("SSJJ1Plugin", CharSet = CharSet.Auto)]
	public static extern void Init();

	[DllImport("SSJJ1Plugin", CharSet = CharSet.Auto)]
	public static extern int GetMovement();
}
