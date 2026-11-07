using Assets.Sources.Components.UserComand;
using Entitas;
using SSJJUserCmd;
using UnityEngine;

namespace Assets.Sources.Systems.UserCommand;

public class UserCommandInitSystem : IInitializeSystem, ISystem
{
	private readonly UserCommandContext _context;

	public UserCommandInitSystem(Contexts contexts)
	{
		_context = contexts.userCommand;
	}

	public void Initialize()
	{
		InputComponent input = _context.input;
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.W,
			KeyCode.UpArrow
		}, 1, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.S,
			KeyCode.DownArrow
		}, 2, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.A,
			KeyCode.LeftArrow
		}, 4, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.D,
			KeyCode.RightArrow
		}, 8, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.F, 4096, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.Q, 16384, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.LeftShift,
			KeyCode.RightShift
		}, 128, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.E, 2048, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.CapsLock, 16, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.V, 65536, t: false));
		input.KeyBindings.Add(new KeyBinding(KeyCode.Space, 32, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.R, 256, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.G, 1024, t: false));
		input.KeyBindings.Add(new KeyBinding(KeyCode.T, 8192, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.Y, 32768, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.P, 131072, t: false));
		input.KeyBindings.Add(new KeyBinding(KeyCode.X, 8388608, t: false));
		input.KeyBindings.Add(new KeyBinding(KeyCode.C, 262144, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.N, 524288, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.J, 16777216, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.Z, 33554432, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.Tab, 1048576, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.BackQuote, 2097152, t: true));
		input.KeyBindings.Add(new KeyBinding(KeyCode.B, 4194304, t: false));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.LeftAlt,
			KeyCode.RightAlt
		}, 536870912, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[2]
		{
			KeyCode.LeftControl,
			KeyCode.RightControl
		}, int.MinValue, t: true));
		input.KeyBindings.Add(new KeyBinding(new KeyCode[1] { KeyCode.L }, 1073741824, t: true));
	}
}
