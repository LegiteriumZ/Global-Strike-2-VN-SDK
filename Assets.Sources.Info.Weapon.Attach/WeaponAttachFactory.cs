using System;
using Assets.Sources.Components.Weapon;
using SSJJAnim.Attach;

namespace Assets.Sources.Info.Weapon.Attach;

public class WeaponAttachFactory : IWeaponAttachFactory
{
	private Type _attachType = typeof(DefaultAttach);

	public void SetTypeName(string name)
	{
		Type type = Type.GetType($"{typeof(WeaponAttachFactory).Namespace}.{name}Attach");
		if (type != null)
		{
			_attachType = type;
		}
	}

	public AbstractAttach Craete()
	{
		object obj = Activator.CreateInstance(_attachType);
		AbstractAttach abstractAttach = ((!(obj is AbstractAttach)) ? new DefaultAttach() : (obj as AbstractAttach));
		abstractAttach.Init();
		return abstractAttach;
	}

	public IWeaponAttachFactory WithAttach(string attach)
	{
		SetTypeName(attach);
		return this;
	}
}
