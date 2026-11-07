using System;
using System.Collections.Generic;
using System.Reflection;
using CommonUtils;
using UnityEngine;

namespace Assets.Tests.PlayMode;

public class TestField
{
	private int _sub;

	private int _index;

	public const int Time = 3000;

	private ParameterInfo _param;

	private List<GameTestProperty> _properties;

	public TestField(int idx, ParameterInfo info)
	{
		_index = idx;
		_param = info;
		_properties = new List<GameTestProperty>();
	}

	public void AddProperty(GameTestProperty property)
	{
		_properties.Add(property);
	}

	public object Next(int step)
	{
		if (_param.ParameterType.IsClass && _param.ParameterType != typeof(string))
		{
			return CreateObject(_param.ParameterType, _index, step, 0);
		}
		return GetCommonValueType(_param.ParameterType, _index, step);
	}

	private object GetCommonValueType(Type type, int idx, int step)
	{
		if (type == typeof(int) || type == typeof(short) || type == typeof(Enum))
		{
			return GetInt(step, idx);
		}
		if (type == typeof(float) || type == typeof(double))
		{
			return Getfloat(step, idx);
		}
		if (type == typeof(bool))
		{
			return Getbool(step, idx);
		}
		if (type == typeof(string))
		{
			return Getstring(step, idx);
		}
		if (type == typeof(Vector3))
		{
			return GetVector3(step, idx);
		}
		if (type == typeof(Color))
		{
			return GetColor(step, idx);
		}
		if (type.IsValueType)
		{
			return Activator.CreateInstance(type);
		}
		return step;
	}

	private int GetInt(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property is GameTestFloatRange)
			{
				GameTestFloatRange gameTestFloatRange = property as GameTestFloatRange;
				if (gameTestFloatRange.IsMatch(typeof(int)))
				{
					return gameTestFloatRange.GetValue<int>(idx, step);
				}
			}
		}
		return step;
	}

	private float Getfloat(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property.IsMatch(typeof(float)))
			{
				return property.GetValue<float>(idx, step);
			}
		}
		return (float)step / 3000f;
	}

	private bool Getbool(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property.IsMatch(typeof(bool)))
			{
				return property.GetValue<bool>(idx, step);
			}
		}
		return step % 2 == 0;
	}

	private Vector3 GetVector3(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property.IsMatch(typeof(Vector3)))
			{
				return (Vector3)property.Get(idx, typeof(Vector3), step);
			}
		}
		return new Vector3(Getfloat(step - 53, -100), Getfloat(step, -100), Getfloat(step + 37, -100));
	}

	private Color GetColor(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property.IsMatch(typeof(Color)))
			{
				return (Color)property.Get(idx, typeof(Color), step);
			}
		}
		return new Color(Getfloat(step - 33, -100), Getfloat(step - 23, -100), Getfloat(step + 97, -100));
	}

	private string Getstring(int step, int idx)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property.IsMatch(typeof(string)))
			{
				return property.GetValue<string>(idx, step);
			}
		}
		return step.ToString();
	}

	private object CreateObject(Type type, int idx, int step, int depth = -1)
	{
		object obj = null;
		if (type.IsByRef)
		{
			throw new NotSupportedException("不支持ref /Out 因为需要保存实例数组");
		}
		if (type.GetConstructor(Type.EmptyTypes) == null || type.GetConstructor(Type.EmptyTypes).IsPrivate)
		{
			return null;
		}
		obj = Activator.CreateInstance(type);
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public;
		FieldInfo[] fields = type.GetFields(bindingAttr);
		_sub = 0;
		FieldInfo[] array = fields;
		foreach (FieldInfo fieldInfo in array)
		{
			try
			{
				if (fieldInfo.FieldType.IsClass && fieldInfo.FieldType != typeof(string))
				{
					fieldInfo.SetValue(obj, ConvertFromAttribute(fieldInfo, idx, step + 1));
				}
				else
				{
					fieldInfo.SetValue(obj, ConvertFromCommonAttribute(fieldInfo, idx, step + 1));
				}
			}
			catch (Exception exception)
			{
				DebugLogger.Log(string.Concat(fieldInfo.FieldType, " named ", fieldInfo.Name));
				DebugLogger.LogException(exception);
			}
		}
		return obj;
	}

	private object ConvertFromAttribute(FieldInfo info, int idx, int step)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property is GameTestClassRange)
			{
				GameTestClassRange gameTestClassRange = property as GameTestClassRange;
				if (gameTestClassRange.IsMatch(info.FieldType) && gameTestClassRange.TryGet(idx, info.Name, out var propertyindex))
				{
					object result = gameTestClassRange.Get(idx, propertyindex, info.FieldType, step - 1);
					_sub++;
					return result;
				}
			}
		}
		return CreateObject(info.FieldType, idx, step);
	}

	private object ConvertFromCommonAttribute(FieldInfo info, int idx, int step)
	{
		foreach (GameTestProperty property in _properties)
		{
			if (property is GameTestClassRange)
			{
				GameTestClassRange gameTestClassRange = property as GameTestClassRange;
				if (gameTestClassRange.IsMatch(info.FieldType) && gameTestClassRange.TryGet(idx, info.Name, out var propertyindex))
				{
					object result = gameTestClassRange.Get(idx, propertyindex, info.FieldType, step - 1);
					_sub++;
					return result;
				}
			}
		}
		return GetCommonValueType(info.FieldType, idx, step);
	}
}
