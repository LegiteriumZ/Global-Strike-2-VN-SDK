using System.IO;
using weapon.nets;

public class NetFluxInputStreamImpl : INetFluxInputStream
{
	private MemoryStream stream;

	public NetFluxInputStreamImpl(MemoryStream stream)
	{
		this.stream = stream;
	}

	public int GetPos()
	{
		return (int)stream.Position;
	}

	public float ReadAngle()
	{
		return NetTableBase.readAngle(stream);
	}

	public float ReadDeltaFloat(float @base)
	{
		return NetTableBase.readDeltaFloat(stream, @base);
	}

	public byte ReadRawByte()
	{
		return (byte)stream.ReadByte();
	}

	public int ReadRawVarint32()
	{
		return NetTableBase.readVarint64(stream);
	}

	public float ReadWholeFloat()
	{
		return NetTableBase.readWholeFloat(stream);
	}

	public void SetPos(int value)
	{
		stream.Position = value;
	}
}
