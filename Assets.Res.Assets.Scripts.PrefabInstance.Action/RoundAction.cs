using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance.Action;

public class RoundAction : EffectAnimBase
{
	public float _radius_length = 100f;

	public float _angle_speed = 1.06f;

	public float _start_y = 180f;

	private float temp_angle;

	private Vector3 _pos_new;

	public Vector3 _center_pos;

	public bool _round_its_center;

	public float _start_angle;

	private void Start()
	{
		if (!string.IsNullOrEmpty(animParameter))
		{
			string[] array = animParameter.Split('|');
			if (array.Length > 3)
			{
				float.TryParse(array[0], out _radius_length);
				float.TryParse(array[1], out _angle_speed);
				float.TryParse(array[2], out _start_y);
				float.TryParse(array[3], out _start_angle);
			}
		}
		if (_round_its_center)
		{
			_center_pos = base.transform.localPosition;
		}
		temp_angle = _start_angle * 0.01745f;
	}

	private void Update()
	{
		temp_angle += _angle_speed * Time.deltaTime;
		_pos_new.x = _center_pos.x + Mathf.Cos(temp_angle) * _radius_length;
		_pos_new.z = _center_pos.z + Mathf.Sin(temp_angle) * _radius_length;
		_pos_new.y = _start_y;
		base.transform.localPosition = _pos_new;
	}
}
