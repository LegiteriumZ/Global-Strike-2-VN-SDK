using Assets.Sources.Utils;
using CommonUtils;
using log4net.Appender;
using log4net.Core;

namespace Loxodon.Log.Appender;

public class UnityDebugAppender : AppenderSkeleton
{
	protected override void Append(LoggingEvent loggingEvent)
	{
		Level level = loggingEvent.Level;
		if (Level.Fatal.Equals(level) || Level.Error.Equals(level))
		{
			SpecailDebug.Instance.ErrorCount++;
			DebugLogger.LogError(RenderLoggingEvent(loggingEvent));
		}
		else if (Level.Warn.Equals(level))
		{
			DebugLogger.LogWarning(RenderLoggingEvent(loggingEvent));
		}
		else
		{
			DebugLogger.Log(RenderLoggingEvent(loggingEvent));
		}
	}
}
