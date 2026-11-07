namespace Assets.Sources.Utils.Chip;

public class AbstractChip<T>
{
	protected T Cvalue;

	private bool _flag;

	private bool _isOver;

	public T Value => Cvalue;

	public bool Flag
	{
		get
		{
			return _flag;
		}
		set
		{
			_flag = value;
		}
	}

	public bool IsOver
	{
		get
		{
			return _isOver;
		}
		set
		{
			_isOver = value;
		}
	}
}
