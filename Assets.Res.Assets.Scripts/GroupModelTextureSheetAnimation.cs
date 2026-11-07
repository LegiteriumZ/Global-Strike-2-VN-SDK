using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class GroupModelTextureSheetAnimation : MonoBehaviour, IGroupModelTextureSheetAnimation
{
	private float _lastTime;

	private Material _material;

	private int _textureIdx;

	public bool IsLoop = true;

	public int MinMap = 1;

	public int Speed = 50;

	public int Group;

	public int GroupCount;

	public int[] Lengths;

	public int[] Starts;

	public Texture[] Textures;

	public void setGroup(int value)
	{
		Group = value;
	}

	private void Start()
	{
		SkinnedMeshRenderer component = GetComponent<SkinnedMeshRenderer>();
		_textureIdx = 0;
		_lastTime = 0f;
		if (Textures.Length == 0)
		{
			return;
		}
		if (component != null)
		{
			_material = component.material;
			return;
		}
		MeshRenderer component2 = GetComponent<MeshRenderer>();
		if (component2 != null)
		{
			_material = component2.material;
			_material.mainTexture = Textures[0];
		}
	}

	private void OnEnable()
	{
		_lastTime = 0f;
		_textureIdx = 0;
		if (Group >= GroupCount)
		{
			Group = 0;
		}
		if (_material != null && Textures.Length != 0)
		{
			_material.mainTexture = Textures[Starts[Group] + _textureIdx];
		}
	}

	private void Update()
	{
		if (Group >= GroupCount)
		{
			Group = 0;
		}
		if (!(_material != null))
		{
			return;
		}
		_lastTime += Time.deltaTime * 1000f;
		if (_lastTime > (float)Speed)
		{
			_lastTime -= Speed;
			_textureIdx++;
			if (IsLoop || _textureIdx < Lengths[Group])
			{
				_textureIdx %= Lengths[Group];
				_material.mainTexture = Textures[Starts[Group] + _textureIdx];
			}
		}
	}
}
