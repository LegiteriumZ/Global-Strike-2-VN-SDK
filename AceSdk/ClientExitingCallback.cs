using System;
using System.Runtime.InteropServices;

namespace AceSdk;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void ClientExitingCallback(IntPtr ctx);
