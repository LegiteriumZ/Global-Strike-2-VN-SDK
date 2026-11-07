using System;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class SkillReleaseTrigger
{
	public int key;

	public bool pressed;

	public Func<PlayerEntity, int, bool> pressedCallFun;

	public int pressedTime;

	public int startTime;

	public SkillReleaseTrigger(int key)
	{
		this.key = key;
	}

	public bool triggered(PlayerEntity player, int cmd)
	{
		if ((cmd & key) != 0)
		{
			pressed = true;
			startTime = player.clientTime.ClientTime;
			pressedCall(player, cmd);
		}
		if (pressed && (cmd & key) == 0)
		{
			pressed = false;
			pressedTime = player.clientTime.ClientTime - startTime;
			return true;
		}
		return false;
	}

	private void pressedCall(PlayerEntity player, int cmd)
	{
		if (pressedCallFun != null)
		{
			pressedCallFun(player, cmd);
		}
	}
}
