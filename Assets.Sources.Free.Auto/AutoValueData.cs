using share;

namespace Assets.Sources.Free.Auto;

public struct AutoValueData
{
	public double Float;

	public string String;

	public Matrix3D Matrix3D;

	public Vector3D Vector3D;

	public AutoValueData(float f, string s, Matrix3D m, Vector3D v)
	{
		Float = f;
		String = s;
		Matrix3D = m;
		Vector3D = v;
	}

	public AutoValueData S(string s)
	{
		String = s;
		return this;
	}

	public AutoValueData V(Vector3D v)
	{
		Vector3D = v;
		return this;
	}

	public AutoValueData M(Matrix3D m)
	{
		Matrix3D = m;
		return this;
	}

	public AutoValueData F(double f)
	{
		Float = f;
		return this;
	}
}
