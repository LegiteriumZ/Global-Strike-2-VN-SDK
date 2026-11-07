using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jitbit.Utils;

public class CsvExport
{
	private List<string> _fields = new List<string>();

	private List<Dictionary<string, object>> _rows = new List<Dictionary<string, object>>();

	private readonly string _columnSeparator;

	private readonly bool _includeColumnSeparatorDefinitionPreamble;

	private Dictionary<string, object> _currentRow => _rows[_rows.Count - 1];

	public object this[string field]
	{
		set
		{
			if (!_fields.Contains(field))
			{
				_fields.Add(field);
			}
			_currentRow[field] = value;
		}
	}

	public CsvExport(string columnSeparator = ",", bool includeColumnSeparatorDefinitionPreamble = true)
	{
		_columnSeparator = columnSeparator;
		_includeColumnSeparatorDefinitionPreamble = includeColumnSeparatorDefinitionPreamble;
	}

	public void AddRow()
	{
		_rows.Add(new Dictionary<string, object>());
	}

	public void AddRows<T>(IEnumerable<T> list)
	{
		if (!list.Any())
		{
			return;
		}
		foreach (T item in list)
		{
			AddRow();
			PropertyInfo[] properties = item.GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				this[propertyInfo.Name] = propertyInfo.GetValue(item, null);
			}
		}
	}

	public static string MakeValueCsvFriendly(object value, string columnSeparator = ",")
	{
		if (value == null)
		{
			return "";
		}
		if (value is DateTime { TimeOfDay: var timeOfDay })
		{
			if (timeOfDay.TotalSeconds == 0.0)
			{
				return ((DateTime)value).ToString("yyyy-MM-dd");
			}
			return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
		}
		string text = value.ToString().Trim();
		if (text.Length > 30000)
		{
			text = text.Substring(0, 30000);
		}
		if (text.Contains(columnSeparator) || text.Contains("\"") || text.Contains("\n") || text.Contains("\r"))
		{
			text = "\"" + text.Replace("\"", "\"\"") + "\"";
		}
		return text;
	}

	private IEnumerable<string> ExportToLines(bool includeHeader = false)
	{
		if (_includeColumnSeparatorDefinitionPreamble)
		{
			yield return "sep=" + _columnSeparator;
		}
		if (includeHeader)
		{
			yield return string.Join(_columnSeparator, _fields.Select((string f) => MakeValueCsvFriendly(f, _columnSeparator)).ToArray());
		}
		foreach (Dictionary<string, object> row in _rows)
		{
			foreach (string item in _fields.Where((string f) => !row.ContainsKey(f)))
			{
				row[item] = null;
			}
			yield return string.Join(_columnSeparator, _fields.Select((string field) => MakeValueCsvFriendly(row[field], _columnSeparator)).ToArray());
		}
	}

	public string Export(bool includeHeader = false)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in ExportToLines(includeHeader))
		{
			stringBuilder.AppendLine(item);
		}
		return stringBuilder.ToString();
	}

	public void ExportToFile(string path, bool includeHeader = false)
	{
		File.WriteAllLines(path, ExportToLines(includeHeader).ToArray(), Encoding.UTF8);
	}

	public byte[] ExportToBytes(bool includeHeader = false)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(Export(includeHeader));
		return Encoding.UTF8.GetPreamble().Concat(bytes).ToArray();
	}
}
