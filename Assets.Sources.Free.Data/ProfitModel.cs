using System.Collections.Generic;

namespace Assets.Sources.Free.Data;

public class ProfitModel
{
	private int _totalExp;

	private int _totalExpPer;

	private int _totalGp;

	private int _totalGpPer;

	private int _totalCrystal;

	private List<int> _expPlusList = new List<int>();

	private List<int> _gpPlusList = new List<int>();

	private bool _changed;

	private int _totalAllExp;

	private int _totalAllGp;

	public bool changed
	{
		get
		{
			return _changed;
		}
		set
		{
			_changed = value;
		}
	}

	public int totalExp
	{
		get
		{
			return _totalExp;
		}
		set
		{
			_totalExp = value;
		}
	}

	public int totalExpPer
	{
		get
		{
			return _totalExpPer;
		}
		set
		{
			_totalExpPer = value;
		}
	}

	public int totalGp
	{
		get
		{
			return _totalGp;
		}
		set
		{
			_totalGp = value;
		}
	}

	public int totalGpPer
	{
		get
		{
			return _totalGpPer;
		}
		set
		{
			_totalGpPer = value;
		}
	}

	public int totalCrystal
	{
		get
		{
			return _totalCrystal;
		}
		set
		{
			_totalCrystal = value;
		}
	}

	public List<int> expPlusList => _expPlusList;

	public List<int> gpPlusList => _gpPlusList;

	public int totalAllExp
	{
		get
		{
			return _totalAllExp;
		}
		set
		{
			_totalAllExp = value;
		}
	}

	public int totalAllGp
	{
		get
		{
			return _totalAllGp;
		}
		set
		{
			_totalAllGp = value;
		}
	}
}
