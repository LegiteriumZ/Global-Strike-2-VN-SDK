using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class WindowMod : MonoBehaviour
{
	public enum appStyle
	{
		FullScreen,
		WindowedFullScreen,
		Windowed,
		WindowedWithoutBorder,
		WindowedFullScreenWithoutBorder
	}

	public enum zDepth
	{
		Normal,
		Top,
		TopMost
	}

	public appStyle AppWindowStyle = appStyle.WindowedFullScreen;

	public zDepth ScreenDepth;

	public int windowLeft = 10;

	public int windowTop = 10;

	public int windowWidth = 800;

	public int windowHeight = 600;

	private const uint SWP_SHOWWINDOW = 64u;

	private const int GWL_STYLE = -16;

	private const int WS_BORDER = 1;

	private Rect screenPosition;

	private const int GWL_EXSTYLE = -20;

	private const int WS_CAPTION = 12582912;

	private const int WS_POPUP = 8388608;

	private IntPtr HWND_TOP = new IntPtr(0);

	private IntPtr HWND_TOPMOST = new IntPtr(-1);

	private IntPtr HWND_NORMAL = new IntPtr(-2);

	private const int SM_CXSCREEN = 0;

	private const int SM_CYSCREEN = 1;

	private int Xscreen;

	private int Yscreen;

	private int i;

	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hPos, int x, int y, int cx, int cy, uint nflags);

	[DllImport("User32.dll")]
	private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

	[DllImport("User32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

	[DllImport("User32.dll")]
	private static extern int GetWindowLong(IntPtr hWnd, int dwNewLong);

	[DllImport("User32.dll")]
	private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wP, IntPtr IP);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr SetParent(IntPtr hChild, IntPtr hParent);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	public static extern IntPtr GetParent(IntPtr hChild);

	[DllImport("User32.dll")]
	public static extern IntPtr GetSystemMetrics(int nIndex);

	private void Start()
	{
		Xscreen = (int)GetSystemMetrics(0);
		Yscreen = (int)GetSystemMetrics(1);
		if (AppWindowStyle == appStyle.FullScreen)
		{
			Screen.SetResolution(Xscreen, Yscreen, fullscreen: true);
		}
		else if (AppWindowStyle == appStyle.WindowedFullScreen)
		{
			Screen.SetResolution(Xscreen - 1, Yscreen - 1, fullscreen: false);
			screenPosition = new Rect(0f, 0f, Xscreen - 1, Yscreen - 1);
		}
		else if (AppWindowStyle == appStyle.Windowed)
		{
			Screen.SetResolution(windowWidth, windowWidth, fullscreen: false);
		}
		else if (AppWindowStyle == appStyle.WindowedWithoutBorder)
		{
			Screen.SetResolution(windowWidth, windowWidth, fullscreen: false);
			screenPosition = new Rect(windowLeft, windowTop, windowWidth, windowWidth);
		}
		else if (AppWindowStyle == appStyle.WindowedFullScreenWithoutBorder)
		{
			Screen.SetResolution(Screen.width, Screen.height, fullscreen: false);
			screenPosition = new Rect(0f, 0f, Screen.width, Screen.height);
		}
	}

	private void Update()
	{
		if (i < 5)
		{
			if (AppWindowStyle == appStyle.WindowedFullScreen)
			{
				SetWindowLong(GetForegroundWindow(), -16, 369164288);
				if (ScreenDepth == zDepth.Normal)
				{
					SetWindowPos(GetForegroundWindow(), HWND_NORMAL, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.Top)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOP, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.TopMost)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOPMOST, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				ShowWindow(GetForegroundWindow(), 3);
			}
			if (AppWindowStyle == appStyle.Windowed)
			{
				if (ScreenDepth == zDepth.Normal)
				{
					SetWindowPos(GetForegroundWindow(), HWND_NORMAL, 0, 0, 0, 0, 3u);
					SetWindowPos(GetForegroundWindow(), HWND_NORMAL, 0, 0, 0, 0, 35u);
				}
				if (ScreenDepth == zDepth.Top)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOP, 0, 0, 0, 0, 3u);
					SetWindowPos(GetForegroundWindow(), HWND_TOP, 0, 0, 0, 0, 35u);
				}
				if (ScreenDepth == zDepth.TopMost)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOPMOST, 0, 0, 0, 0, 3u);
					SetWindowPos(GetForegroundWindow(), HWND_TOPMOST, 0, 0, 0, 0, 35u);
				}
			}
			if (AppWindowStyle == appStyle.WindowedWithoutBorder)
			{
				SetWindowLong(GetForegroundWindow(), -16, 369164288);
				if (ScreenDepth == zDepth.Normal)
				{
					SetWindowPos(GetForegroundWindow(), HWND_NORMAL, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.Top)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOP, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.TopMost)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOPMOST, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
			}
			if (AppWindowStyle == appStyle.WindowedFullScreenWithoutBorder)
			{
				SetWindowLong(GetForegroundWindow(), -16, 369164288);
				if (ScreenDepth == zDepth.Normal)
				{
					SetWindowPos(GetForegroundWindow(), HWND_NORMAL, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.Top)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOP, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
				if (ScreenDepth == zDepth.TopMost)
				{
					SetWindowPos(GetForegroundWindow(), HWND_TOPMOST, (int)screenPosition.x, (int)screenPosition.y, (int)screenPosition.width, (int)screenPosition.height, 64u);
				}
			}
		}
		i++;
	}
}
