using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Player.UnityObjects;

public struct AccessoryRenderComponent : IAccessoryRenderComponent
{
	public string Name;

	public GameObject GameObject;

	public object SjAnimator;

	public object AnimList;

	public int AnimCurrentTime;

	private string _AnimationName;

	public object CustomRender;

	public SkinnedMeshRenderer[] SkinRenders;

	public MeshRenderer[] MeshRenders;

	public IPaticlePrefabInstancecs[] Patricles;

	public Color RenderColor;

	public WeaponColorData ColorData;

	public string getName()
	{
		return Name;
	}

	public GameObject getGameObject()
	{
		return GameObject;
	}

	public object getSjAnimator()
	{
		return SjAnimator;
	}

	public object getAnimList()
	{
		return AnimList;
	}

	public int getAnimCurrentTime()
	{
		return AnimCurrentTime;
	}

	public void setAnimCurrentTime(int value)
	{
		AnimCurrentTime = value;
	}

	public object getCustomRender()
	{
		return CustomRender;
	}

	public SkinnedMeshRenderer[] getSkinRenders()
	{
		return SkinRenders;
	}

	public MeshRenderer[] getMeshRenders()
	{
		return MeshRenders;
	}

	public IPaticlePrefabInstancecs[] getPatricles()
	{
		return Patricles;
	}

	public Color getRenderColor()
	{
		return RenderColor;
	}

	public void setRenderColor(Color color)
	{
		RenderColor.r = color.r;
		RenderColor.g = color.g;
		RenderColor.b = color.b;
		RenderColor.a = color.a;
	}

	public WeaponColorData getWeaponColorData()
	{
		return ColorData;
	}

	public void setWeaponColorData(WeaponColorData value)
	{
		ColorData = value;
	}

	public void setAnimationName(string value)
	{
		_AnimationName = value;
	}

	public string getAnimationName()
	{
		return _AnimationName;
	}

	public AccessoryRenderComponent(string name, GameObject model, object anim, object animinfo, IPaticlePrefabInstancecs[] dict)
	{
		Name = name;
		GameObject = model;
		SkinRenders = model.GetComponentsInChildren<SkinnedMeshRenderer>();
		MeshRenders = model.GetComponentsInChildren<MeshRenderer>();
		Patricles = dict;
		CustomRender = null;
		SjAnimator = anim;
		AnimCurrentTime = 0;
		AnimList = animinfo;
		RenderColor = new Color(0f, 0f, 0f, 0f);
		ColorData = new WeaponColorData
		{
			R = 1f,
			G = 1f,
			B = 1f,
			A = 1f
		};
		_AnimationName = "";
	}

	public AccessoryRenderComponent(string name, GameObject model, object anim, object animinfo, IPaticlePrefabInstancecs[] dict, object rd)
	{
		Name = name;
		GameObject = model;
		SkinRenders = model.GetComponentsInChildren<SkinnedMeshRenderer>();
		MeshRenders = model.GetComponentsInChildren<MeshRenderer>();
		Patricles = dict;
		CustomRender = rd;
		SjAnimator = anim;
		AnimCurrentTime = 0;
		RenderColor = new Color(0f, 0f, 0f, 0f);
		AnimList = animinfo;
		ColorData = new WeaponColorData
		{
			R = 1f,
			G = 1f,
			B = 1f,
			A = 1f
		};
		_AnimationName = "";
	}
}
