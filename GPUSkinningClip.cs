using System;

[Serializable]
public class GPUSkinningClip
{
	public string name;

	public float length;

	public int fps;

	public GPUSkinningWrapMode wrapMode;

	public GPUSkinningFrame[] frames;

	public int pixelSegmentation;

	public bool rootMotionEnabled;

	public bool individualDifferenceEnabled;
}
