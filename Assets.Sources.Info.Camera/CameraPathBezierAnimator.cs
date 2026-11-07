using System.Collections.Generic;
using Assets.Sources.Info.Career;
using share;

namespace Assets.Sources.Info.Camera;

public class CameraPathBezierAnimator
{
	private string _name;

	private int _time;

	private List<CameraEffectPath> _pathList;

	private Matrix3D _matrix3D = new Matrix3D();

	private Vector3D _position = new Vector3D();

	private Vector3D _rotation = new Vector3D();

	public int Time => _time;

	public string name => _name;

	public Vector3D Position => _position;

	public Vector3D Rotation => _rotation;

	public void SetData(CameraEffectConfigItem effectData)
	{
		_pathList = effectData.PathList;
		_time = effectData.Time;
		_name = effectData.EffectName;
	}

	public bool Player(int animTime, Matrix3D parentMatrix)
	{
		CameraEffectPath currentCameraPath = GetCurrentCameraPath(animTime);
		CameraEffectPath nextCameraPath = GetNextCameraPath(animTime);
		if (currentCameraPath != null && nextCameraPath != null)
		{
			int num = nextCameraPath.Time - currentCameraPath.Time;
			float t = (float)(animTime - currentCameraPath.Time) * 1f / (float)num;
			_matrix3D.Identity();
			UpdateAnimRotation(t, currentCameraPath, nextCameraPath);
			UpdateAnimPosition(t, currentCameraPath, nextCameraPath);
			_matrix3D.Append(parentMatrix);
			Vector3D[] array = _matrix3D.Decompose();
			_position = array[0];
			_rotation = array[1];
			return true;
		}
		return false;
	}

	private void UpdateAnimRotation(float t, CameraEffectPath currentCameraPath, CameraEffectPath nextCameraPath)
	{
		double angle = Maths.Lerp(currentCameraPath.RotationX, nextCameraPath.RotationX, t);
		double angle2 = Maths.Lerp(currentCameraPath.RotationY, nextCameraPath.RotationY, t);
		double angle3 = Maths.Lerp(currentCameraPath.RotationZ, nextCameraPath.RotationZ, t);
		_matrix3D.AppendRotation(angle, Vector3D.X_AXIS);
		_matrix3D.AppendRotation(angle2, Vector3D.Y_AXIS);
		_matrix3D.AppendRotation(angle3, Vector3D.Z_AXIS);
	}

	private void UpdateAnimPosition(float t, CameraEffectPath currentCameraPath, CameraEffectPath nextCameraPath)
	{
		double x = Maths.Lerp(currentCameraPath.X, nextCameraPath.X, t);
		double y = Maths.Lerp(currentCameraPath.Y, nextCameraPath.Y, t);
		double z = Maths.Lerp(currentCameraPath.Z, nextCameraPath.Z, t);
		_matrix3D.AppendTranslation(x, y, z);
	}

	private CameraEffectPath GetCurrentCameraPath(int animTime)
	{
		for (int num = _pathList.Count - 1; num >= 0; num--)
		{
			if (_pathList[num].Time < animTime)
			{
				return _pathList[num];
			}
		}
		return null;
	}

	private CameraEffectPath GetNextCameraPath(int animTime)
	{
		for (int i = 0; i < _pathList.Count; i++)
		{
			if (_pathList[i].Time > animTime)
			{
				return _pathList[i];
			}
		}
		return null;
	}
}
