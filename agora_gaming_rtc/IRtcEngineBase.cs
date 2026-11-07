using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace agora_gaming_rtc;

public abstract class IRtcEngineBase
{
	protected delegate void EngineEventOnJoinChannelSuccessHandler(string channel, uint uid, int elapsed);

	protected delegate void EngineEventOnLeaveChannelHandler(uint duration, uint txBytes, uint rxBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileQuality, uint userCount, double cpuAppUsage, double cpuTotalUsage);

	protected delegate void EngineEventOnReJoinChannelSuccessHandler(string channel, uint uid, int elapsed);

	protected delegate void EngineEventOnConnectionLostHandler();

	protected delegate void EngineEventOnConnectionInterruptedHandler();

	protected delegate void EngineEventOnRequestTokenHandler();

	protected delegate void EngineEventOnUserJoinedHandler(uint uid, int elapsed);

	protected delegate void EngineEventOnUserOfflineHandler(uint uid, int offLineReason);

	protected delegate void EngineEventOnAudioVolumeIndicationHandler(string volumeInfo, int speakerNumber, int totalVolume);

	protected delegate void EngineEventOnUserMuteAudioHandler(uint uid, bool muted);

	protected delegate void EngineEventOnSDKWarningHandler(int warn, string msg);

	protected delegate void EngineEventOnSDKErrorHandler(int error, string msg);

	protected delegate void EngineEventOnRtcStatsHandler(uint duration, uint txBytes, uint rxBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileQuality, uint userCount, double cpuAppUsage, double cpuTotalUsage);

	protected delegate void EngineEventOnAudioMixingFinishedHandler();

	protected delegate void EngineEventOnAudioRouteChangedHandler(int route);

	protected delegate void EngineEventOnFirstRemoteVideoDecodedHandler(uint uid, int width, int height, int elapsed);

	protected delegate void EngineEventOnVideoSizeChangedHandler(uint uid, int width, int height, int elapsed);

	protected delegate void EngineEventOnClientRoleChangedHandler(int oldRole, int newRole);

	protected delegate void EngineEventOnUserMuteVideoHandler(uint uid, bool muted);

	protected delegate void EngineEventOnMicrophoneEnabledHandler(bool isEnabled);

	protected delegate void EngineEventOnApiExecutedHandler(int err, string api, string result);

	protected delegate void EngineEventOnLastmileQualityHandler(int quality);

	protected delegate void EngineEventOnFirstLocalAudioFrameHandler(int elapsed);

	protected delegate void EngineEventOnFirstRemoteAudioFrameHandler(uint userId, int elapsed);

	protected delegate void EngineEventOnAudioQualityHandler(uint userId, int quality, ushort delay, ushort lost);

	protected delegate void EngineEventOnStreamInjectedStatusHandler(string url, uint userId, int status);

	protected delegate void EngineEventOnStreamUnpublishedHandler(string url);

	protected delegate void EngineEventOnStreamPublishedHandler(string url, int error);

	protected delegate void EngineEventOnStreamMessageErrorHandler(uint userId, int streamId, int code, int missed, int cached);

	protected delegate void EngineEventOnStreamMessageHandler(uint userId, int streamId, string data, int length);

	protected delegate void EngineEventOnConnectionBannedHandler();

	protected delegate void EngineEventOnConnectionStateChangedHandler(int state, int reason);

	protected delegate void EngineEventOnTokenPrivilegeWillExpireHandler(string token);

	protected delegate void EngineEventOnActiveSpeakerHandler(uint uid);

	protected delegate void EngineEventOnVideoStoppedHandler();

	protected delegate void EngineEventOnFirstLocalVideoFrameHandler(int width, int height, int elapsed);

	protected delegate void EngineEventOnFirstRemoteVideoFrameHandler(uint uid, int width, int height, int elapsed);

	protected delegate void EngineEventOnUserEnableVideoHandler(uint uid, bool enabled);

	protected delegate void EngineEventOnUserEnableLocalVideoHandler(uint uid, bool enabled);

	protected delegate void EngineEventOnRemoteVideoStateChangedHandler(uint uid, int state);

	protected delegate void EngineEventOnLocalPublishFallbackToAudioOnlyHandler(bool isFallbackOrRecover);

	protected delegate void EngineEventOnRemoteSubscribeFallbackToAudioOnlyHandler(uint uid, bool isFallbackOrRecover);

	protected delegate void EngineEventOnNetworkQualityHandler(uint uid, int txQuality, int rxQuality);

	protected delegate void EngineEventOnLocalVideoStatsHandler(int sentBitrate, int sentFramRate);

	protected delegate void EngineEventOnRemoteVideoStatsHandler(uint uid, int delay, int width, int height, int receivedBitrate, int receivedFrameRate, int remoteVideoStreamType);

	protected delegate void EngineEventOnRemoteAudioStatsHandler(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate);

	protected delegate void EngineEventOnAudioDeviceStateChangedHandler(string deviceId, int deviceType, int deviceState);

	protected delegate void EngineEventOnCameraReadyHandler();

	protected delegate void EngineEventOnCameraFocusAreaChangedHandler(int x, int y, int width, int height);

	protected delegate void EngineEventOnCameraExposureAreaChangedHandler(int x, int y, int width, int height);

	protected delegate void EngineEventOnRemoteAudioMixingBeginHandler();

	protected delegate void EngineEventOnRemoteAudioMixingEndHandler();

	protected delegate void EngineEventOnAudioEffectFinishedHandler(int soundId);

	protected delegate void EngineEventOnVideoDeviceStateChangedHandler(string deviceId, int deviceType, int deviceState);

	protected delegate void EngineEventOnRemoteVideoTransportStatsHandler(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

	protected delegate void EngineEventOnRemoteAudioTransportStatsHandler(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

	protected delegate void EngineEventOnTranscodingUpdatedHandler();

	protected delegate void EngineEventOnAudioDeviceVolumeChangedHandler(int deviceType, int volume, bool muted);

	protected delegate void EngineEventOnMediaEngineStartCallSuccessHandler();

	protected delegate void EngineEventOnMediaEngineLoadSuccessHandler();

	protected delegate void OnEngineEventHandler(int methodNumber, string data);

	public const string MyLibName = "agoraSdkCWrapper";

	protected const string agoraGameObjectName = "agora_engine_CallBackGamObject";

	protected static GameObject agoraGameObject;

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void createEngine(string appId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void deleteEngine();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern IntPtr getSdkVersion();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int joinChannel(string channelKey, string channelName, string info, uint uid);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setLocalVoicePitch(double pitch);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRemoteVoicePosition(uint uid, double pan, double gain);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVoiceOnlyMode(bool enable);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int leaveChannel();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableLastmileTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int disableLastmileTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableVideo();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int disableVideo();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableLocalVideo(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableLocalAudio(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startPreview();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopPreview();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableAudio();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int disableAudio();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setParameters(string options);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern IntPtr getCallId();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int rate(string callId, int rating, string desc);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int complain(string callId, string desc);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setEnableSpeakerphone(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int isSpeakerphoneEnabled();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setDefaultAudioRoutetoSpeakerphone(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableAudioVolumeIndication(int interval, int smooth);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startAudioRecording(string filePath, int quality);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopAudioRecording();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startAudioMixing(string filePath, bool loopBack, bool replace, int cycle, int playTime);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopAudioMixing();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int pauseAudioMixing();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int resumeAudioMixing();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int adjustAudioMixingVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioMixingDuration();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioMixingCurrentPosition();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteLocalAudioStream(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteAllRemoteAudioStreams(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteRemoteAudioStream(uint uid, bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int switchCamera();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVideoProfile(int profile, bool swapWidthAndHeight);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteLocalVideoStream(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteAllRemoteVideoStreams(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int muteRemoteVideoStream(uint uid, bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setLogFile(string filePath);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int renewToken(string token);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setChannelProfile(int profile);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setClientRole(int role);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableDualStreamMode(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setEncryptionMode(string encryptionMode);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setEncryptionSecret(string secret);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startRecordingService(string recordingKey);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopRecordingService(string recordingKey);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int refreshRecordingServiceStatus();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int createDataStream(bool reliable, bool ordered);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int sendStreamMessage(int streamId, string data, long length);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRecordingAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setPlaybackAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setSpeakerphoneVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int adjustRecordingSignalVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int adjustPlaybackSignalVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setHighQualityAudioParametersWithFullband(int fullband, int stereo, int fullBitrate);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableInEarMonitoring(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableWebSdkInteroperability(bool enabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVideoQualityParameters(bool preferFrameRateOverImageQuality);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startEchoTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopEchoTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRemoteVideoStreamType(uint uid, int streamType);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setMixedAudioFrameParameters(int sampleRate, int samplesPerCall);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioMixingPosition(int pos);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setLogFilter(uint filter);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int enableVideoObserver();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int disableVideoObserver();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int generateNativeTexture();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int updateTexture(int tex, IntPtr data, uint uid);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void deleteTexture(int tex);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setPlaybackDeviceVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getEffectsVolume();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setEffectsVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int playEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopEffect(int soundId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopAllEffects();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int preloadEffect(int soundId, string filePath);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int unloadEffect(int soundId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int pauseEffect(int soundId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int pauseAllEffects();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int resumeEffect(int soundId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int resumeAllEffects();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setDefaultMuteAllRemoteAudioStreams(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setDefaultMuteAllRemoteVideoStreams(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void freeObject(IntPtr obj);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getConnectionState();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioProfile(int audioProfile, int scenario);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVideoEncoderConfiguration(int width, int height, int frameRate, int bitrate, int orientationMode);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int adjustAudioMixingPlayoutVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int adjustAudioMixingPublishVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVolumeOfEffect(int soundId, int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRecordingAudioFrameParameters(int sampleRate, int channel, int mode, int samplesPerCall);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setPlaybackAudioFrameParameters(int sampleRate, int channel, int mode, int samplesPerCall);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setLocalPublishFallbackOption(int option);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRemoteSubscribeFallbackOption(int option);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setRemoteDefaultVideoStreamType(int remoteVideoStreamType);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int addPublishStreamUrl(string url, bool transcodingEnabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int removePublishStreamUrl(string url);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startScreenCapture(uint windowId, int captureFreq, int top, int left, int bottom, int right, int bitrate);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopScreenCapture();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int updateScreenCaptureRegion(int top, int left, int bottom, int right);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern IntPtr getErrorDescription(int code);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setLiveTranscoding(int width, int height, int videoBitrate, int videoFramerate, bool lowLatency, int videoGroup, int video_codec_profile, uint backgroundColor, uint userCount, uint transcodingUserUid, int transcodingUsersX, int transcodingUsersY, int transcodingUsersWidth, int transcodingUsersHeight, int transcodingUsersZorder, double transcodingUsersAlpha, int transcodingUsersAudioChannel, string transcodingExtraInfo, string metaData, string watermarkRtcImageUrl, int watermarkRtcImageX, int watermarkRtcImageY, int watermarkRtcImageWidth, int watermarkRtcImageHeight, string backgroundImageRtcImageUrl, int backgroundImageRtcImageX, int backgroundImageRtcImageY, int backgroundImageRtcImageWidth, int backgroundImageRtcImageHeight, int audioSampleRate, int audioBitrate, int audioChannels);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern bool createAVideoDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int releaseAVideoDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startVideoDeviceTest(IntPtr hwnd);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopVideoDeviceTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getVideoDeviceCollectionCount();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getVideoDeviceCollectionDevice(int index, IntPtr deviceName, IntPtr deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setVideoDeviceCollectionDevice(string deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern bool creatAAudioRecordingDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int releaseAAudioRecordingDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioRecordingDeviceCount();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioRecordingDevice(int index, IntPtr deviceName, IntPtr deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioRecordingDevice(string deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioRecordingDeviceVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioRecordingDeviceVolume();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioRecordingDeviceMute(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern bool isAudioRecordingDeviceMute();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioPlaybackDeviceCount();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern bool creatAAudioPlaybackDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int releaseAAudioPlaybackDeviceManager();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioPlaybackDevice(int index, IntPtr deviceName, IntPtr deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioPlaybackDevice(string deviceId);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioPlaybackDeviceVolume(int volume);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int getAudioPlaybackDeviceVolume();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int setAudioPlaybackDeviceMute(bool mute);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern bool isAudioPlaybackDeviceMute();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startAudioPlaybackDeviceTest(string testAudioFilePath);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopAudioPlaybackDeviceTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int startAudioRecordingDeviceTest(int indicationInterval);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern int stopAudioRecordingDeviceTest();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initCallBackObject();

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnJoinChannelSuccess(EngineEventOnJoinChannelSuccessHandler OnJoinChannelSuccess);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnLeaveChannel(EngineEventOnLeaveChannelHandler OnLeaveChannel);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnReJoinChannelSuccess(EngineEventOnReJoinChannelSuccessHandler OnReJoinChannelSuccess);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnConnectionLost(EngineEventOnConnectionLostHandler OnConnectionLost);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnConnectionInterrupted(EngineEventOnConnectionInterruptedHandler OnConnectionInterrupted);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRequestToken(EngineEventOnRequestTokenHandler OnRequestToken);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserJoined(EngineEventOnUserJoinedHandler OnUserJoined);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserOffline(EngineEventOnUserOfflineHandler OnUserOffline);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioVolumeIndication(EngineEventOnAudioVolumeIndicationHandler OnAudioVolumeIndication);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserMuteAudio(EngineEventOnUserMuteAudioHandler OnUserMuteAudio);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnSDKWarning(EngineEventOnSDKWarningHandler OnSDKWarning);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnSDKError(EngineEventOnSDKErrorHandler OnSDKError);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRtcStats(EngineEventOnRtcStatsHandler OnRtcStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioMixingFinished(EngineEventOnAudioMixingFinishedHandler OnAudioMixingFinished);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioRouteChanged(EngineEventOnAudioRouteChangedHandler OnAudioRouteChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnFirstRemoteVideoDecoded(EngineEventOnFirstRemoteVideoDecodedHandler OnFirstRemoteVideoDecoded);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnVideoSizeChanged(EngineEventOnVideoSizeChangedHandler OnVideoSizeChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnClientRoleChanged(EngineEventOnClientRoleChangedHandler OnVideoSizeChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserMuteVideo(EngineEventOnUserMuteVideoHandler OnUserMuteVideo);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnMicrophoneEnabled(EngineEventOnMicrophoneEnabledHandler OnMicrophoneEnabled);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnApiExecuted(EngineEventOnApiExecutedHandler OnApiExecuted);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnFirstLocalAudioFrame(EngineEventOnFirstLocalAudioFrameHandler OnFirstLocalAudioFrame);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnFirstRemoteAudioFrame(EngineEventOnFirstRemoteAudioFrameHandler OnFirstRemoteAudioFrame);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnLastmileQuality(EngineEventOnLastmileQualityHandler OnLastmileQuality);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioQuality(EngineEventOnAudioQualityHandler onAudioQuality);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnStreamInjectedStatus(EngineEventOnStreamInjectedStatusHandler onStreamInjectedStatus);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnStreamUnpublished(EngineEventOnStreamUnpublishedHandler onStreamUnpublished);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnStreamPublished(EngineEventOnStreamPublishedHandler onStreamPublished);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnStreamMessageError(EngineEventOnStreamMessageErrorHandler onStreamMessageError);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnStreamMessage(EngineEventOnStreamMessageHandler onStreamMessage);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnConnectionBanned(EngineEventOnConnectionBannedHandler onConnectionBanned);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnConnectionStateChanged(EngineEventOnConnectionStateChangedHandler onConnectionStateChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnTokenPrivilegeWillExpire(EngineEventOnTokenPrivilegeWillExpireHandler onTokenPrivilegeWillExpire);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnActiveSpeaker(EngineEventOnActiveSpeakerHandler onActiveSpeaker);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnVideoStopped(EngineEventOnVideoStoppedHandler OnVideoStopped);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnFirstLocalVideoFrame(EngineEventOnFirstLocalVideoFrameHandler OnFirstLocalVideoFrame);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnFirstRemoteVideoFrame(EngineEventOnFirstRemoteVideoFrameHandler OnFirstRemoteVideoFrame);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserEnableVideo(EngineEventOnUserEnableVideoHandler OnUserEnableVideo);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnUserEnableLocalVideo(EngineEventOnUserEnableLocalVideoHandler OnUserEnableLocalVideo);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteVideoStateChanged(EngineEventOnRemoteVideoStateChangedHandler OnRemoteVideoStateChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnLocalPublishFallbackToAudioOnly(EngineEventOnLocalPublishFallbackToAudioOnlyHandler OnLocalPublishFallbackToAudioOnly);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnNetworkQuality(EngineEventOnNetworkQualityHandler onNetworkQuality);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnLocalVideoStats(EngineEventOnLocalVideoStatsHandler onLocalVideoStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteVideoStats(EngineEventOnRemoteVideoStatsHandler onRemoteVideoStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteAudioStats(EngineEventOnRemoteAudioStatsHandler onRemoteAudioStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioDeviceStateChanged(EngineEventOnAudioDeviceStateChangedHandler onAudioDeviceStateChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnCameraReady(EngineEventOnCameraReadyHandler onCameraReady);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnCameraFocusAreaChanged(EngineEventOnCameraFocusAreaChangedHandler onCameraFocusAreaChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnCameraExposureAreaChanged(EngineEventOnCameraExposureAreaChangedHandler onCameraExposureAreaChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteAudioMixingBegin(EngineEventOnRemoteAudioMixingBeginHandler onRemoteAudioMixingBegin);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteAudioMixingEnd(EngineEventOnRemoteAudioMixingEndHandler onRemoteAudioMixingEnd);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioEffectFinished(EngineEventOnAudioEffectFinishedHandler onAudioEffectFinished);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnVideoDeviceStateChanged(EngineEventOnVideoDeviceStateChangedHandler onVideoDeviceStateChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteSubscribeFallbackToAudioOnly(EngineEventOnRemoteSubscribeFallbackToAudioOnlyHandler onRemoteSubscribeFallbackToAudioOnly);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteVideoTransportStats(EngineEventOnRemoteVideoTransportStatsHandler onRemoteVideoTransportStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnRemoteAudioTransportStats(EngineEventOnRemoteAudioTransportStatsHandler onRemoteAudioTransportStats);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnTranscodingUpdated(EngineEventOnTranscodingUpdatedHandler onTranscodingUpdated);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnAudioDeviceVolumeChanged(EngineEventOnAudioDeviceVolumeChangedHandler onAudioDeviceVolumeChanged);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnMediaEngineStartCallSuccess(EngineEventOnMediaEngineStartCallSuccessHandler onMediaEngineStartCallSuccess);

	[DllImport("agoraSdkCWrapper", CharSet = CharSet.Ansi)]
	protected static extern void initEventOnMediaEngineLoadSuccess(EngineEventOnMediaEngineLoadSuccessHandler onMediaEngineLoadSuccess);
}
