using System.Collections.Generic;
using System.IO;
using System.Text;

namespace C2TPro;

public class CsvParser
{
	private abstract class ParserState
	{
		public static readonly LineStartState LineStartState = new LineStartState();

		public static readonly ValueStartState ValueStartState = new ValueStartState();

		public static readonly ValueState ValueState = new ValueState();

		public static readonly QuotedValueState QuotedValueState = new QuotedValueState();

		public static readonly QuoteState QuoteState = new QuoteState();

		public abstract ParserState AnyChar(char ch, ParserContext context);

		public abstract ParserState Comma(ParserContext context);

		public abstract ParserState Quote(ParserContext context);

		public abstract ParserState EndOfLine(ParserContext context);
	}

	private class LineStartState : ParserState
	{
		public override ParserState AnyChar(char ch, ParserContext context)
		{
			context.AddChar(ch);
			return ParserState.ValueState;
		}

		public override ParserState Comma(ParserContext context)
		{
			context.AddValue();
			return ParserState.ValueStartState;
		}

		public override ParserState Quote(ParserContext context)
		{
			return ParserState.QuotedValueState;
		}

		public override ParserState EndOfLine(ParserContext context)
		{
			context.AddLine();
			return ParserState.LineStartState;
		}
	}

	private class ValueStartState : LineStartState
	{
		public override ParserState EndOfLine(ParserContext context)
		{
			context.AddValue();
			context.AddLine();
			return ParserState.LineStartState;
		}
	}

	private class ValueState : ParserState
	{
		public override ParserState AnyChar(char ch, ParserContext context)
		{
			context.AddChar(ch);
			return ParserState.ValueState;
		}

		public override ParserState Comma(ParserContext context)
		{
			context.AddValue();
			return ParserState.ValueStartState;
		}

		public override ParserState Quote(ParserContext context)
		{
			context.AddChar('"');
			return ParserState.ValueState;
		}

		public override ParserState EndOfLine(ParserContext context)
		{
			context.AddValue();
			context.AddLine();
			return ParserState.LineStartState;
		}
	}

	private class QuotedValueState : ParserState
	{
		public override ParserState AnyChar(char ch, ParserContext context)
		{
			context.AddChar(ch);
			return ParserState.QuotedValueState;
		}

		public override ParserState Comma(ParserContext context)
		{
			context.AddChar(',');
			return ParserState.QuotedValueState;
		}

		public override ParserState Quote(ParserContext context)
		{
			return ParserState.QuoteState;
		}

		public override ParserState EndOfLine(ParserContext context)
		{
			context.AddChar('\r');
			context.AddChar('\n');
			return ParserState.QuotedValueState;
		}
	}

	private class QuoteState : ParserState
	{
		public override ParserState AnyChar(char ch, ParserContext context)
		{
			context.AddChar(ch);
			return ParserState.QuotedValueState;
		}

		public override ParserState Comma(ParserContext context)
		{
			context.AddValue();
			return ParserState.ValueStartState;
		}

		public override ParserState Quote(ParserContext context)
		{
			context.AddChar('"');
			return ParserState.QuotedValueState;
		}

		public override ParserState EndOfLine(ParserContext context)
		{
			context.AddValue();
			context.AddLine();
			return ParserState.LineStartState;
		}
	}

	private class ParserContext
	{
		private readonly StringBuilder _currentValue = new StringBuilder();

		private readonly List<string[]> _lines = new List<string[]>();

		private readonly List<string> _currentLine = new List<string>();

		public int MaxColumnsToRead { get; set; }

		public ParserContext()
		{
			MaxColumnsToRead = 1000;
		}

		public void AddChar(char ch)
		{
			_currentValue.Append(ch);
		}

		public void AddValue()
		{
			if (_currentLine.Count < MaxColumnsToRead)
			{
				_currentLine.Add(_currentValue.ToString());
			}
			_currentValue.Remove(0, _currentValue.Length);
		}

		public void AddLine()
		{
			_lines.Add(_currentLine.ToArray());
			_currentLine.Clear();
		}

		public List<string[]> GetAllLines()
		{
			if (_currentValue.Length > 0)
			{
				AddValue();
			}
			if (_currentLine.Count > 0)
			{
				AddLine();
			}
			return _lines;
		}
	}

	private const char CommaCharacter = ',';

	private const char QuoteCharacter = '"';

	public bool TrimTrailingEmptyLines { get; set; }

	public int MaxColumnsToRead { get; set; }

	public string[][] Parse(TextReader reader)
	{
		ParserContext parserContext = new ParserContext();
		if (MaxColumnsToRead != 0)
		{
			parserContext.MaxColumnsToRead = MaxColumnsToRead;
		}
		ParserState parserState = ParserState.LineStartState;
		string text;
		while ((text = reader.ReadLine()) != null)
		{
			string text2 = text;
			foreach (char c in text2)
			{
				parserState = c switch
				{
					',' => parserState.Comma(parserContext), 
					'"' => parserState.Quote(parserContext), 
					_ => parserState.AnyChar(c, parserContext), 
				};
			}
			parserState = parserState.EndOfLine(parserContext);
		}
		List<string[]> allLines = parserContext.GetAllLines();
		if (TrimTrailingEmptyLines && allLines.Count > 0)
		{
			bool flag = true;
			for (int num = allLines.Count - 1; num >= 0; num--)
			{
				flag = true;
				for (int j = 0; j < allLines[num].Length; j++)
				{
					if (!string.IsNullOrEmpty(allLines[num][j]))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					if (num < allLines.Count - 1)
					{
						allLines.RemoveRange(num + 1, allLines.Count - num - 1);
					}
					break;
				}
			}
			if (flag)
			{
				allLines.RemoveRange(0, allLines.Count);
			}
		}
		return allLines.ToArray();
	}

	public static string[][] Parse(string input)
	{
		CsvParser csvParser = new CsvParser();
		using StringReader reader = new StringReader(input);
		return csvParser.Parse(reader);
	}
}
