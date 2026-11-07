namespace agora_gaming_rtc;

public struct RtcStats
{
	public uint duration;

	public uint txBytes;

	public uint rxBytes;

	public ushort txKBitRate;

	public ushort rxKBitRate;

	public ushort txAudioKBitRate;

	public ushort rxAudioKBitRate;

	public ushort txVideoKBitRate;

	public ushort rxVideoKBitRate;

	public ushort lastmileQuality;

	public uint users;

	public double cpuAppUsage;

	public double cpuTotalUsage;
}
