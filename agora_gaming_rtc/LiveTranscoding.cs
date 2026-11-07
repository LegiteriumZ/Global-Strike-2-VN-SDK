namespace agora_gaming_rtc;

public struct LiveTranscoding
{
	public int width;

	public int height;

	public int videoBitrate;

	public int videoFramerate;

	public bool lowLatency;

	public int videoGop;

	public VIDEO_CODEC_PROFILE_TYPE videoCodecProfile;

	public uint backgroundColor;

	public uint userCount;

	public TranscodingUser transcodingUsers;

	public string transcodingExtraInfo;

	public string metadata;

	public RtcImage watermark;

	public RtcImage backgroundImage;

	public AUDIO_SAMPLE_RATE_TYPE audioSampleRate;

	public int audioBitrate;

	public int audioChannels;
}
