namespace agora_gaming_rtc;

public struct RemoteAudioStats
{
	public uint uid;

	public int quality;

	public int networkTransportDelay;

	public int jitterBufferDelay;

	public int audioLossRate;
}
