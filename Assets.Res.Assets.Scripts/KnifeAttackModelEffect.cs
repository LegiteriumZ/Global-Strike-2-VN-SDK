using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[RequireComponent(typeof(MeshRenderer))]
public class KnifeAttackModelEffect : AbstractKnifeEffectMb
{
	private float _frameTime = 1f;

	private float _lastTime;

	private MeshRenderer _mesh;

	private float _speed;

	private int _textureIdx;

	private bool _visable;

	public int MinMap = 1;

	public Texture[] Textures;

	private Material _material;

	public bool Disable { get; set; }

	public override void Play()
	{
		if (config != null && !IsPlay())
		{
			Show(config.EffectTime);
		}
	}

	public override void Stop()
	{
		_textureIdx = 0;
		_frameTime = 0f;
		_visable = false;
	}

	public override bool IsPlay()
	{
		return _visable;
	}

	private void Awake()
	{
		_visable = false;
		_mesh = GetComponent<MeshRenderer>();
		_textureIdx = 0;
		_lastTime = 0f;
		if (Textures.Length != 0 && _mesh != null)
		{
			_material = _mesh.material;
			_material.mainTexture = Textures[0];
			_material.shader = Shader.Find("SSJJ/Diffuse");
			if (config.isFrist)
			{
				_material.SetInt("_ZTest", 8);
				_material.SetInt("_ZWrite", 0);
				_material.renderQueue = 3100;
			}
			else
			{
				_material.SetInt("_ZTest", 2);
				_material.SetInt("_ZWrite", 0);
				_material.renderQueue = 3100;
			}
			_mesh.enabled = false;
		}
	}

	private void OnEnable()
	{
		_visable = false;
	}

	private void Update()
	{
		if (!(_mesh != null))
		{
			return;
		}
		if (!_visable || Disable)
		{
			_mesh.enabled = false;
		}
		else
		{
			_mesh.enabled = true;
			_frameTime -= Time.deltaTime * 1000f;
			_lastTime += Time.deltaTime * 1000f;
			if (_lastTime > _speed)
			{
				_lastTime -= _speed;
				if (_textureIdx < Textures.Length - 1)
				{
					_textureIdx++;
				}
				_material.mainTexture = Textures[_textureIdx];
			}
		}
		if (_frameTime <= 0f)
		{
			_visable = false;
			_frameTime = 0f;
		}
	}

	public void Show(int frameTime, int start, int length)
	{
		_speed = 1f * (float)frameTime / (float)length;
		_textureIdx = start;
		_frameTime = frameTime;
		_visable = true;
	}

	public void Show(int frameTime)
	{
		Show(frameTime, 0, Textures.Length);
	}
}
