namespace agora_gaming_rtc;

public struct RemoteVideoStats
{
	public uint uid;

	public int delay;

	public int width;

	public int height;

	public int receivedBitrate;

	public int receivedFrameRate;

	public REMOTE_VIDEO_STREAM_TYPE rxStreamType;
}
