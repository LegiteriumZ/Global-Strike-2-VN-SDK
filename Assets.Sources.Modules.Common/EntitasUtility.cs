using System;
using Entitas;

namespace Assets.Sources.Modules.Common;

internal static class EntitasUtility
{
	public static object GetValueComponent(Entity entity, int compId, Type compType)
	{
		IComponent component = entity.GetComponent(compId);
		return compType.GetField("value").GetValue(component);
	}

	public static void AddValueComponent(Entity entity, int compId, Type compType, object value)
	{
		IComponent component = entity.CreateComponent(compId, compType);
		compType.GetField("value").SetValue(component, value);
		entity.AddComponent(compId, component);
	}
}
