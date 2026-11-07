using System;
using System.Text;
using SSJJBase.Logger;
using utils;

namespace Assets.Sources.Modules.BattleRoom;

internal class PyLoggerAdapter : IPyLogger
{
	private LoggerAdapter _logger = new LoggerAdapter(typeof(PyLoggerAdapter));

	private StringBuilder sb = new StringBuilder();

	public void Info(string var1, params object[] var2)
	{
		if (_logger.IsInfoEnabled)
		{
			if (var2 != null && var2.Length != 0)
			{
				_logger.InfoFormat(ReplaceFormatorString(var1), var2);
			}
			else
			{
				_logger.Info(var1);
			}
		}
	}

	public void Warn(string var1, params object[] var2)
	{
		if (_logger.IsWarnEnabled)
		{
			if (var2 != null && var2.Length != 0)
			{
				_logger.WarnFormat(ReplaceFormatorString(var1), var2);
			}
			else
			{
				_logger.Warn(var1);
			}
		}
	}

	public void Error(string var1, params object[] var2)
	{
		if (_logger.IsErrorEnabled)
		{
			if (var2 != null && var2.Length != 0)
			{
				_logger.ErrorFormat(ReplaceFormatorString(var1), var2);
			}
			else
			{
				_logger.Error(var1);
			}
		}
	}

	public void Debug(string var1, params object[] var2)
	{
		if (_logger.IsDebugEnabled)
		{
			if (var2 != null && var2.Length != 0)
			{
				_logger.DebugFormat(ReplaceFormatorString(var1), var2);
			}
			else
			{
				_logger.Debug(var1);
			}
		}
	}

	public string ReplaceFormatorString(string input)
	{
		sb.Length = 0;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = input.IndexOf("{}", num2, StringComparison.Ordinal);
			if (num3 < 0)
			{
				break;
			}
			sb.Append(input.Substring(num2, num3 - num2));
			sb.Append("{");
			sb.Append(num++);
			sb.Append("}");
			num2 = num3 + 2;
		}
		if (num == 0)
		{
			return input;
		}
		sb.Append(input.Substring(num2));
		return sb.ToString();
	}
}
