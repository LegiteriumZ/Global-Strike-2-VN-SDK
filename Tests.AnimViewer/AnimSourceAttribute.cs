using System;

namespace Tests.AnimViewer;

[AttributeUsage(AttributeTargets.Class)]
public class AnimSourceAttribute : Attribute
{
	public AnimSourceType type;
}
