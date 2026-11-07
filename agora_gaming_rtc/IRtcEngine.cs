using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace agora_gaming_rtc;

public class IRtcEngine : IRtcEngineBase
{
	public delegate void JoinChannelSuccessHandler(string channelName, uint uid, int elapsed);

	public delegate void ReJoinChannelSuccessHandler(string channelName, uint uid, int elapsed);

	public delegate void ConnectionLostHandler();

	public delegate void ConnectionInterruptedHandler();

	public delegate void RequestTokenHandler();

	public delegate void UserJoinedHandler(uint uid, int elapsed);

	public delegate void UserOfflineHandler(uint uid, USER_OFFLINE_REASON reason);

	public delegate void LeaveChannelHandler(RtcStats stats);

	public delegate void VolumeIndicationHandler(AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume);

	public delegate void UserMutedHandler(uint uid, bool muted);

	public delegate void SDKWarningHandler(int warn, string msg);

	public delegate void SDKErrorHandler(int error, string msg);

	public delegate void RtcStatsHandler(RtcStats stats);

	public delegate void AudioMixingFinishedHandler();

	public delegate void AudioRouteChangedHandler(AUDIO_ROUTE route);

	public delegate void OnFirstRemoteVideoDecodedHandler(uint uid, int width, int height, int elapsed);

	public delegate void OnVideoSizeChangedHandler(uint uid, int width, int height, int elapsed);

	public delegate void OnClientRoleChangedHandler(int oldRole, int newRole);

	public delegate void OnUserMuteVideoHandler(uint uid, bool muted);

	public delegate void OnMicrophoneEnabledHandler(bool isEnabled);

	public delegate void OnFirstRemoteAudioFrameHandler(uint userId, int elapsed);

	public delegate void OnFirstLocalAudioFrameHandler(int elapsed);

	public delegate void OnApiExecutedHandler(int err, string api, string result);

	public delegate void OnLastmileQualityHandler(int quality);

	public delegate void OnAudioQualityHandler(uint userId, int quality, ushort delay, ushort lost);

	public delegate void OnStreamInjectedStatusHandler(string url, uint userId, int status);

	public delegate void OnStreamUnpublishedHandler(string url);

	public delegate void OnStreamPublishedHandler(string url, int error);

	public delegate void OnStreamMessageErrorHandler(uint userId, int streamId, int code, int missed, int cached);

	public delegate void OnStreamMessageHandler(uint userId, int streamId, string data, int length);

	public delegate void OnConnectionBannedHandler();

	public delegate void OnConnectionStateChangedHandler(int state, int reason);

	public delegate void OnTokenPrivilegeWillExpireHandler(string token);

	public delegate void OnActiveSpeakerHandler(uint uid);

	public delegate void OnVideoStoppedHandler();

	public delegate void OnFirstLocalVideoFrameHandler(int width, int height, int elapsed);

	public delegate void OnFirstRemoteVideoFrameHandler(uint uid, int width, int height, int elapsed);

	public delegate void OnUserEnableVideoHandler(uint uid, bool enabled);

	public delegate void OnUserEnableLocalVideoHandler(uint uid, bool enabled);

	public delegate void OnRemoteVideoStateChangedHandler(uint uid, int state);

	public delegate void OnLocalPublishFallbackToAudioOnlyHandler(bool isFallbackOrRecover);

	public delegate void OnRemoteSubscribeFallbackToAudioOnlyHandler(uint uid, bool isFallbackOrRecover);

	public delegate void OnNetworkQualityHandler(uint uid, int txQuality, int rxQuality);

	public delegate void OnLocalVideoStatsHandler(LocalVideoStats localVideoStats);

	public delegate void OnRemoteVideoStatsHandler(RemoteVideoStats remoteVideoStats);

	public delegate void OnRemoteAudioStatsHandler(RemoteAudioStats remoteAudioStats);

	public delegate void OnAudioDeviceStateChangedHandler(string deviceId, int deviceType, int deviceState);

	public delegate void OnCameraReadyHandler();

	public delegate void OnCameraFocusAreaChangedHandler(int x, int y, int width, int height);

	public delegate void OnCameraExposureAreaChangedHandler(int x, int y, int width, int height);

	public delegate void OnRemoteAudioMixingBeginHandler();

	public delegate void OnRemoteAudioMixingEndHandler();

	public delegate void OnAudioEffectFinishedHandler(int soundId);

	public delegate void OnVideoDeviceStateChangedHandler(string deviceId, int deviceType, int deviceState);

	public delegate void OnRemoteVideoTransportStatsHandler(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

	public delegate void OnRemoteAudioTransportStatsHandler(uint uid, ushort delay, ushort lost, ushort rxKBitRate);

	public delegate void OnTranscodingUpdatedHandler();

	public delegate void OnAudioDeviceVolumeChangedHandler(MEDIA_DEVICE_TYPE deviceType, int volume, bool muted);

	public delegate void OnMediaEngineStartCallSuccessHandler();

	public delegate void OnMediaEngineLoadSuccessHandler();

	private class AgoraCallBackQueue : MonoBehaviour
	{
		private static Queue<Action> queue = new Queue<Action>();

		private static AgoraCallBackQueue _current;

		public static AgoraCallBackQueue Current => _current;

		public void ClearQueue()
		{
			lock (queue)
			{
				queue.Clear();
			}
		}

		public void EnQueue(Action action)
		{
			lock (queue)
			{
				if (queue.Count >= 250)
				{
					queue.Dequeue();
				}
				queue.Enqueue(action);
			}
		}

		private Action DeQueue()
		{
			lock (queue)
			{
				return queue.Dequeue();
			}
		}

		private void Awake()
		{
			_current = this;
		}

		private void Update()
		{
			if (queue.Count > 0)
			{
				DeQueue()?.Invoke();
			}
		}
	}

	public JoinChannelSuccessHandler OnJoinChannelSuccess;

	public ReJoinChannelSuccessHandler OnReJoinChannelSuccess;

	public ConnectionLostHandler OnConnectionLost;

	public ConnectionInterruptedHandler OnConnectionInterrupted;

	public RequestTokenHandler OnRequestToken;

	public UserJoinedHandler OnUserJoined;

	public UserOfflineHandler OnUserOffline;

	public LeaveChannelHandler OnLeaveChannel;

	public VolumeIndicationHandler OnVolumeIndication;

	public UserMutedHandler OnUserMuted;

	public SDKWarningHandler OnWarning;

	public SDKErrorHandler OnError;

	public RtcStatsHandler OnRtcStats;

	public AudioMixingFinishedHandler OnAudioMixingFinished;

	public AudioRouteChangedHandler OnAudioRouteChanged;

	public OnFirstRemoteVideoDecodedHandler OnFirstRemoteVideoDecoded;

	public OnVideoSizeChangedHandler OnVideoSizeChanged;

	public OnClientRoleChangedHandler OnClientRoleChanged;

	public OnUserMuteVideoHandler OnUserMuteVideo;

	public OnMicrophoneEnabledHandler OnMicrophoneEnabled;

	public OnFirstRemoteAudioFrameHandler OnFirstRemoteAudioFrame;

	public OnFirstLocalAudioFrameHandler OnFirstLocalAudioFrame;

	public OnApiExecutedHandler OnApiExecuted;

	public OnLastmileQualityHandler OnLastmileQuality;

	public OnAudioQualityHandler OnAudioQuality;

	public OnStreamInjectedStatusHandler OnStreamInjectedStatus;

	public OnStreamUnpublishedHandler OnStreamUnpublished;

	public OnStreamPublishedHandler OnStreamPublished;

	public OnStreamMessageErrorHandler OnStreamMessageError;

	public OnStreamMessageHandler OnStreamMessage;

	public OnConnectionBannedHandler OnConnectionBanned;

	public OnConnectionStateChangedHandler OnConnectionStateChanged;

	public OnTokenPrivilegeWillExpireHandler OnTokenPrivilegeWillExpire;

	public OnActiveSpeakerHandler OnActiveSpeaker;

	public OnVideoStoppedHandler OnVideoStopped;

	public OnFirstLocalVideoFrameHandler OnFirstLocalVideoFrame;

	public OnFirstRemoteVideoFrameHandler OnFirstRemoteVideoFrame;

	public OnUserEnableVideoHandler OnUserEnableVideo;

	public OnUserEnableLocalVideoHandler OnUserEnableLocalVideo;

	public OnRemoteVideoStateChangedHandler OnRemoteVideoStateChanged;

	public OnLocalPublishFallbackToAudioOnlyHandler OnLocalPublishFallbackToAudioOnly;

	public OnRemoteSubscribeFallbackToAudioOnlyHandler OnRemoteSubscribeFallbackToAudioOnly;

	public OnNetworkQualityHandler OnNetworkQuality;

	public OnLocalVideoStatsHandler OnLocalVideoStats;

	public OnRemoteVideoStatsHandler OnRemoteVideoStats;

	public OnRemoteAudioStatsHandler OnRemoteAudioStats;

	public OnAudioDeviceStateChangedHandler OnAudioDeviceStateChanged;

	public OnCameraReadyHandler OnCameraReady;

	public OnCameraFocusAreaChangedHandler OnCameraFocusAreaChanged;

	public OnCameraExposureAreaChangedHandler OnCameraExposureAreaChanged;

	public OnRemoteAudioMixingBeginHandler OnRemoteAudioMixingBegin;

	public OnRemoteAudioMixingEndHandler OnRemoteAudioMixingEnd;

	public OnAudioEffectFinishedHandler OnAudioEffectFinished;

	public OnVideoDeviceStateChangedHandler OnVideoDeviceStateChanged;

	public OnRemoteVideoTransportStatsHandler OnRemoteVideoTransportStats;

	public OnRemoteAudioTransportStatsHandler OnRemoteAudioTransportStats;

	public OnTranscodingUpdatedHandler OnTranscodingUpdated;

	public OnAudioDeviceVolumeChangedHandler OnAudioDeviceVolumeChanged;

	public OnMediaEngineStartCallSuccessHandler OnMediaEngineStartCallSuccess;

	public OnMediaEngineLoadSuccessHandler OnMediaEngineLoadSuccess;

	private readonly AudioEffectManagerImpl mAudioEffectM;

	private readonly AudioRecordingoDeviceManager audioRecordingDeviceManager;

	private readonly AudioPlaybackDeviceManager audioPlaybackDeviceManager;

	private readonly VideoDeviceManager videoDeviceManager;

	private static IRtcEngine instance;

	private IRtcEngine(string appId)
	{
		InitGameObject();
		IRtcEngineBase.initCallBackObject();
		InitEngineCallBack();
		IRtcEngineBase.createEngine(appId);
		mAudioEffectM = new AudioEffectManagerImpl(this);
		audioRecordingDeviceManager = new AudioRecordingoDeviceManager(this);
		audioPlaybackDeviceManager = new AudioPlaybackDeviceManager(this);
		videoDeviceManager = new VideoDeviceManager(this);
	}

	private void InitGameObject()
	{
		IRtcEngineBase.agoraGameObject = new GameObject("agora_engine_CallBackGamObject");
		IRtcEngineBase.agoraGameObject.AddComponent<AgoraCallBackQueue>();
		UnityEngine.Object.DontDestroyOnLoad(IRtcEngineBase.agoraGameObject);
		IRtcEngineBase.agoraGameObject.hideFlags = HideFlags.HideInHierarchy;
	}

	private static void DeInitGameObject()
	{
		GameObject gameObject = GameObject.Find("agora_engine_CallBackGamObject");
		if ((object)gameObject != null)
		{
			AgoraCallBackQueue.Current.ClearQueue();
			UnityEngine.Object.Destroy(gameObject);
			gameObject = null;
		}
	}

	public string doFormat(string format, params object[] args)
	{
		return string.Format(CultureInfo.InvariantCulture, format, args);
	}

	public static string GetSdkVersion()
	{
		return Marshal.PtrToStringAnsi(IRtcEngineBase.getSdkVersion());
	}

	public int SetChannelProfile(CHANNEL_PROFILE profile)
	{
		return IRtcEngineBase.setChannelProfile((int)profile);
	}

	public int SetClientRole(CLIENT_ROLE role)
	{
		return IRtcEngineBase.setClientRole((int)role);
	}

	public int SetLogFilter(LOG_FILTER filter)
	{
		return IRtcEngineBase.setLogFilter((uint)filter);
	}

	public int SetLogFile(string filePath)
	{
		return IRtcEngineBase.setLogFile(filePath);
	}

	public int JoinChannel(string channelName, string info, uint uid)
	{
		return JoinChannelByKey(null, channelName, info, uid);
	}

	public int JoinChannelByKey(string channelKey, string channelName, string info, uint uid)
	{
		return IRtcEngineBase.joinChannel(channelKey, channelName, info, uid);
	}

	public int RenewToken(string token)
	{
		return IRtcEngineBase.renewToken(token);
	}

	public int LeaveChannel()
	{
		return IRtcEngineBase.leaveChannel();
	}

	public void Pause()
	{
		DisableAudio();
	}

	public void Resume()
	{
		EnableAudio();
	}

	public int SetParameters(string parameters)
	{
		return IRtcEngineBase.setParameters(parameters);
	}

	public int SetParameter(string parameter, int value)
	{
		return IRtcEngineBase.setParameters(doFormat("{{\"{0}\": {1}}}", parameter, value));
	}

	public int SetParameter(string parameter, double value)
	{
		return IRtcEngineBase.setParameters(doFormat("{{\"{0}\": {1}}}", parameter, value));
	}

	public int SetParameter(string parameter, bool value)
	{
		string text = (value ? "true" : "false");
		return IRtcEngineBase.setParameters(doFormat("{{\"{0}\": {1}}}", parameter, text));
	}

	public string GetCallId()
	{
		string result = null;
		IntPtr callId = IRtcEngineBase.getCallId();
		if (callId != IntPtr.Zero)
		{
			result = Marshal.PtrToStringAnsi(callId);
			IRtcEngineBase.freeObject(callId);
		}
		return result;
	}

	public int Rate(string callId, int rating, string desc)
	{
		return IRtcEngineBase.rate(callId, rating, desc);
	}

	public int Complain(string callId, string desc)
	{
		return IRtcEngineBase.complain(callId, desc);
	}

	public int EnableAudio()
	{
		return IRtcEngineBase.enableAudio();
	}

	public int DisableAudio()
	{
		return IRtcEngineBase.disableAudio();
	}

	public int MuteLocalAudioStream(bool mute)
	{
		return IRtcEngineBase.muteLocalAudioStream(mute);
	}

	public int MuteAllRemoteAudioStreams(bool mute)
	{
		return IRtcEngineBase.muteAllRemoteAudioStreams(mute);
	}

	public int MuteRemoteAudioStream(uint uid, bool mute)
	{
		return IRtcEngineBase.muteRemoteAudioStream(uid, mute);
	}

	public int SetEnableSpeakerphone(bool speakerphone)
	{
		return IRtcEngineBase.setEnableSpeakerphone(speakerphone);
	}

	public int SetDefaultAudioRouteToSpeakerphone(bool speakerphone)
	{
		return IRtcEngineBase.setDefaultAudioRoutetoSpeakerphone(speakerphone);
	}

	public bool IsSpeakerphoneEnabled()
	{
		return IRtcEngineBase.isSpeakerphoneEnabled() != 0;
	}

	public int SwitchCamera()
	{
		return IRtcEngineBase.switchCamera();
	}

	public int SetVideoProfile(int profile, bool swapWidthAndHeight)
	{
		return IRtcEngineBase.setVideoProfile(profile, swapWidthAndHeight);
	}

	public int MuteLocalVideoStream(bool mute)
	{
		return IRtcEngineBase.muteLocalVideoStream(mute);
	}

	public int MuteAllRemoteVideoStreams(bool mute)
	{
		return IRtcEngineBase.muteAllRemoteVideoStreams(mute);
	}

	public int MuteRemoteVideoStream(uint uid, bool mute)
	{
		return IRtcEngineBase.muteRemoteVideoStream(uid, mute);
	}

	public int EnableDualStreamMode(bool enabled)
	{
		return IRtcEngineBase.enableDualStreamMode(enabled);
	}

	public int SetEncryptionMode(string encryptionMode)
	{
		return IRtcEngineBase.setEncryptionMode(encryptionMode);
	}

	public int SetEncryptionSecret(string secret)
	{
		return IRtcEngineBase.setEncryptionSecret(secret);
	}

	public int StartRecordingService(string recordingKey)
	{
		return IRtcEngineBase.startRecordingService(recordingKey);
	}

	public int StopRecordingService(string recordingKey)
	{
		return IRtcEngineBase.stopRecordingService(recordingKey);
	}

	public int RefreshRecordingServiceStatus()
	{
		return IRtcEngineBase.refreshRecordingServiceStatus();
	}

	public int CreateDataStream(bool reliable, bool ordered)
	{
		return IRtcEngineBase.createDataStream(reliable, ordered);
	}

	public int SendStreamMessage(int streamId, string data)
	{
		return IRtcEngineBase.sendStreamMessage(streamId, data, data.Length);
	}

	public int SetRecordingAudioFrameParametersWithSampleRate(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
	{
		return IRtcEngineBase.setRecordingAudioFrameParametersWithSampleRate(sampleRate, channel, (int)mode, samplesPerCall);
	}

	public int SetPlaybackAudioFrameParametersWithSampleRate(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
	{
		return IRtcEngineBase.setPlaybackAudioFrameParametersWithSampleRate(sampleRate, channel, (int)mode, samplesPerCall);
	}

	public int SetSpeakerphoneVolume(int volume)
	{
		return IRtcEngineBase.setSpeakerphoneVolume(volume);
	}

	public int SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
	{
		return IRtcEngineBase.setVideoQualityParameters(preferFrameRateOverImageQuality);
	}

	public int StartEchoTest()
	{
		return IRtcEngineBase.startEchoTest();
	}

	public int StopEchoTest()
	{
		return IRtcEngineBase.stopEchoTest();
	}

	public int SetRemoteVideoStreamType(uint uid, REMOTE_VIDEO_STREAM_TYPE streamType)
	{
		return IRtcEngineBase.setRemoteVideoStreamType(uid, (int)streamType);
	}

	public int SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall)
	{
		return IRtcEngineBase.setMixedAudioFrameParameters(sampleRate, samplesPerCall);
	}

	public int SetAudioMixingPosition(int pos)
	{
		return IRtcEngineBase.setAudioMixingPosition(pos);
	}

	public int EnableAudioVolumeIndication(int interval, int smooth)
	{
		return IRtcEngineBase.enableAudioVolumeIndication(interval, smooth);
	}

	public int AdjustRecordingSignalVolume(int volume)
	{
		return IRtcEngineBase.adjustRecordingSignalVolume(volume);
	}

	public int AdjustPlaybackSignalVolume(int volume)
	{
		return IRtcEngineBase.adjustPlaybackSignalVolume(volume);
	}

	public int StartAudioMixing(string filePath, bool loopback, bool replace, int cycle, int playTime = 0)
	{
		return IRtcEngineBase.startAudioMixing(filePath, loopback, replace, cycle, playTime);
	}

	public int StopAudioMixing()
	{
		return IRtcEngineBase.stopAudioMixing();
	}

	public int PauseAudioMixing()
	{
		return IRtcEngineBase.pauseAudioMixing();
	}

	public int ResumeAudioMixing()
	{
		return IRtcEngineBase.resumeAudioMixing();
	}

	public int AdjustAudioMixingVolume(int volume)
	{
		return IRtcEngineBase.adjustAudioMixingVolume(volume);
	}

	public int GetAudioMixingDuration()
	{
		return IRtcEngineBase.getAudioMixingDuration();
	}

	public int GetAudioMixingCurrentPosition()
	{
		return IRtcEngineBase.getAudioMixingCurrentPosition();
	}

	public int StartAudioRecording(string filePath)
	{
		return StartAudioRecording(filePath, AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_MEDIUM);
	}

	public int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
	{
		return IRtcEngineBase.startAudioRecording(filePath, (int)quality);
	}

	public int StopAudioRecording()
	{
		return IRtcEngineBase.stopAudioRecording();
	}

	public IAudioEffectManager GetAudioEffectManager()
	{
		return mAudioEffectM;
	}

	public IAudioRecordingDeviceManager GetAudioRecordingDeviceManager()
	{
		return audioRecordingDeviceManager;
	}

	public IAudioPlaybackDeviceManager GetAudioPlaybackDeviceManager()
	{
		return audioPlaybackDeviceManager;
	}

	public IVideoDeviceManager GetVideoDeviceManager()
	{
		return videoDeviceManager;
	}

	public int EnableVideo()
	{
		return IRtcEngineBase.enableVideo();
	}

	public int DisableVideo()
	{
		return IRtcEngineBase.disableVideo();
	}

	public int EnableLocalVideo(bool enabled)
	{
		return IRtcEngineBase.enableLocalVideo(enabled);
	}

	public int EnableLocalAudio(bool enabled)
	{
		return IRtcEngineBase.enableLocalAudio(enabled);
	}

	public int StartPreview()
	{
		return IRtcEngineBase.startPreview();
	}

	public int StopPreview()
	{
		return IRtcEngineBase.stopPreview();
	}

	public int GetEffectsVolume()
	{
		return IRtcEngineBase.getEffectsVolume();
	}

	public int SetEffectsVolume(int volume)
	{
		return IRtcEngineBase.setEffectsVolume(volume);
	}

	public int PlayEffect(int soundId, string filePath, int loopCount, double pitch, double pan, int gain, bool publish)
	{
		return IRtcEngineBase.playEffect(soundId, filePath, loopCount, pitch, pan, gain, publish);
	}

	public int StopEffect(int soundId)
	{
		return IRtcEngineBase.stopEffect(soundId);
	}

	public int StopAllEffects()
	{
		return IRtcEngineBase.stopAllEffects();
	}

	public int PreloadEffect(int soundId, string filePath)
	{
		return IRtcEngineBase.preloadEffect(soundId, filePath);
	}

	public int UnloadEffect(int soundId)
	{
		return IRtcEngineBase.unloadEffect(soundId);
	}

	public int PauseEffect(int soundId)
	{
		return IRtcEngineBase.pauseEffect(soundId);
	}

	public int PauseAllEffects()
	{
		return IRtcEngineBase.pauseAllEffects();
	}

	public int ResumeEffect(int soundId)
	{
		return IRtcEngineBase.resumeEffect(soundId);
	}

	public int ResumeAllEffects()
	{
		return IRtcEngineBase.resumeAllEffects();
	}

	public int EnableVideoObserver()
	{
		return IRtcEngineBase.enableVideoObserver();
	}

	public int DisableVideoObserver()
	{
		return IRtcEngineBase.disableVideoObserver();
	}

	public int UpdateTexture(int tex, uint uid, IntPtr data, ref int width, ref int height)
	{
		int num = IRtcEngineBase.updateTexture(tex, data, uid);
		if (num == -1)
		{
			return -1;
		}
		width = num >> 16;
		height = num & 0xFFFF;
		return 0;
	}

	public int GenerateNativeTexture()
	{
		return IRtcEngineBase.generateNativeTexture();
	}

	public void DeleteTexture(int tex)
	{
		IRtcEngineBase.deleteTexture(tex);
	}

	public int SetLocalVoicePitch(double pitch)
	{
		return IRtcEngineBase.setLocalVoicePitch(pitch);
	}

	public int SetRemoteVoicePosition(uint uid, double pan, double gain)
	{
		return IRtcEngineBase.setRemoteVoicePosition(uid, pan, gain);
	}

	public int SetVoiceOnlyMode(bool enable)
	{
		return IRtcEngineBase.setVoiceOnlyMode(enable);
	}

	public int SetDefaultMuteAllRemoteAudioStreams(bool mute)
	{
		return IRtcEngineBase.setDefaultMuteAllRemoteAudioStreams(mute);
	}

	public int SetDefaultMuteAllRemoteVideoStreams(bool mute)
	{
		return IRtcEngineBase.setDefaultMuteAllRemoteVideoStreams(mute);
	}

	public int EnableLastmileTest()
	{
		return IRtcEngineBase.enableLastmileTest();
	}

	public int DisableLastmileTest()
	{
		return IRtcEngineBase.disableLastmileTest();
	}

	public int GetConnectionState()
	{
		return IRtcEngineBase.getConnectionState();
	}

	public int SetAudioProfile(AUDIO_PROFILE_TYPE audioProfile, AUDIO_SCENARIO_TYPE scenario)
	{
		return IRtcEngineBase.setAudioProfile((int)audioProfile, (int)scenario);
	}

	public int SetVideoEncoderConfiguration(VideoEncoderConfiguration configuration)
	{
		return IRtcEngineBase.setVideoEncoderConfiguration(configuration.dimensions.width, configuration.dimensions.height, (int)configuration.frameRate, configuration.bitrate, (int)configuration.orientationMode);
	}

	public int AdjustAudioMixingPlayoutVolume(int volume)
	{
		return IRtcEngineBase.adjustAudioMixingPlayoutVolume(volume);
	}

	public int AdjustAudioMixingPublishVolume(int volume)
	{
		return IRtcEngineBase.adjustAudioMixingPublishVolume(volume);
	}

	public int SetVolumeOfEffect(int soundId, int volume)
	{
		return IRtcEngineBase.setVolumeOfEffect(soundId, volume);
	}

	public int SetRecordingAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
	{
		return IRtcEngineBase.setRecordingAudioFrameParameters(sampleRate, channel, (int)mode, samplesPerCall);
	}

	public int SetPlaybackAudioFrameParameters(int sampleRate, int channel, RAW_AUDIO_FRAME_OP_MODE_TYPE mode, int samplesPerCall)
	{
		return IRtcEngineBase.setPlaybackAudioFrameParameters(sampleRate, channel, (int)mode, samplesPerCall);
	}

	public int SetLocalPublishFallbackOption(int option)
	{
		return IRtcEngineBase.setLocalPublishFallbackOption(option);
	}

	public int SetRemoteSubscribeFallbackOption(int option)
	{
		return IRtcEngineBase.setRemoteSubscribeFallbackOption(option);
	}

	public int SetRemoteDefaultVideoStreamType(REMOTE_VIDEO_STREAM_TYPE remoteVideoStreamType)
	{
		return IRtcEngineBase.setRemoteDefaultVideoStreamType((int)remoteVideoStreamType);
	}

	public int AddPublishStreamUrl(string url, bool transcodingEnabled)
	{
		return IRtcEngineBase.addPublishStreamUrl(url, transcodingEnabled);
	}

	public int RemovePublishStreamUrl(string url)
	{
		return IRtcEngineBase.removePublishStreamUrl(url);
	}

	public int StartScreenCapture(uint windowId, int captureFreq, int top, int left, int bottom, int right, int bitrate)
	{
		return IRtcEngineBase.startScreenCapture(windowId, captureFreq, top, left, bottom, right, bitrate);
	}

	public int StopScreenCapture()
	{
		return IRtcEngineBase.stopScreenCapture();
	}

	public int UpdateScreenCaptureRegion(int top, int left, int bottom, int right)
	{
		return IRtcEngineBase.updateScreenCaptureRegion(top, left, bottom, right);
	}

	public string GetErrorDescription(int code)
	{
		return Marshal.PtrToStringAnsi(IRtcEngineBase.getErrorDescription(code));
	}

	public int EnableWebSdkInteroperability(bool enabled)
	{
		return IRtcEngineBase.enableWebSdkInteroperability(enabled);
	}

	public int SetLiveTranscoding(LiveTranscoding transcoding)
	{
		return IRtcEngineBase.setLiveTranscoding(transcoding.width, transcoding.height, transcoding.videoBitrate, transcoding.videoFramerate, transcoding.lowLatency, transcoding.videoGop, (int)transcoding.videoCodecProfile, transcoding.backgroundColor, transcoding.userCount, transcoding.transcodingUsers.uid, transcoding.transcodingUsers.x, transcoding.transcodingUsers.y, transcoding.transcodingUsers.width, transcoding.transcodingUsers.height, transcoding.transcodingUsers.zOrder, transcoding.transcodingUsers.alpha, transcoding.transcodingUsers.audioChannel, transcoding.transcodingExtraInfo, transcoding.metadata, transcoding.watermark.url, transcoding.watermark.x, transcoding.watermark.y, transcoding.watermark.width, transcoding.watermark.height, transcoding.backgroundImage.url, transcoding.backgroundImage.x, transcoding.backgroundImage.y, transcoding.backgroundImage.width, transcoding.backgroundImage.height, (int)transcoding.audioSampleRate, transcoding.audioBitrate, transcoding.audioChannels);
	}

	public bool CreatAAudioRecordingDeviceManager()
	{
		return IRtcEngineBase.creatAAudioRecordingDeviceManager();
	}

	public int ReleaseAAudioRecordingDeviceManager()
	{
		return IRtcEngineBase.releaseAAudioRecordingDeviceManager();
	}

	public int GetAudioRecordingDeviceCount()
	{
		return IRtcEngineBase.getAudioRecordingDeviceCount();
	}

	public int GetAudioRecordingDevice(int index, ref string deviceName, ref string deviceId)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(512);
		IntPtr intPtr2 = Marshal.AllocHGlobal(512);
		int audioRecordingDevice = IRtcEngineBase.getAudioRecordingDevice(index, intPtr, intPtr2);
		deviceName = Marshal.PtrToStringAnsi(intPtr);
		deviceId = Marshal.PtrToStringAnsi(intPtr2);
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return audioRecordingDevice;
	}

	public int SetAudioRecordingDevice(string deviceId)
	{
		return IRtcEngineBase.setAudioRecordingDevice(deviceId);
	}

	public bool CreatAAudioPlaybackDeviceManager()
	{
		return IRtcEngineBase.creatAAudioPlaybackDeviceManager();
	}

	public int ReleaseAAudioPlaybackDeviceManager()
	{
		return IRtcEngineBase.releaseAAudioPlaybackDeviceManager();
	}

	public int GetAudioPlaybackDeviceCount()
	{
		return IRtcEngineBase.getAudioPlaybackDeviceCount();
	}

	public int GetAudioPlaybackDevice(int index, ref string deviceName, ref string deviceId)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(512);
		IntPtr intPtr2 = Marshal.AllocHGlobal(512);
		int audioPlaybackDevice = IRtcEngineBase.getAudioPlaybackDevice(index, intPtr, intPtr2);
		deviceName = Marshal.PtrToStringAnsi(intPtr);
		deviceId = Marshal.PtrToStringAnsi(intPtr2);
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return audioPlaybackDevice;
	}

	public int SetAudioPlaybackDevice(string deviceId)
	{
		return IRtcEngineBase.setAudioPlaybackDevice(deviceId);
	}

	public int SetAudioPlaybackDeviceVolume(int volume)
	{
		return IRtcEngineBase.setAudioPlaybackDeviceVolume(volume);
	}

	public int GetAudioPlaybackDeviceVolume()
	{
		return IRtcEngineBase.getAudioPlaybackDeviceVolume();
	}

	public int SetAudioPlaybackDeviceMute(bool mute)
	{
		return IRtcEngineBase.setAudioPlaybackDeviceMute(mute);
	}

	public bool IsAudioPlaybackDeviceMute()
	{
		return IRtcEngineBase.isAudioPlaybackDeviceMute();
	}

	public int StartAudioPlaybackDeviceTest(string testAudioFilePath)
	{
		return IRtcEngineBase.startAudioPlaybackDeviceTest(testAudioFilePath);
	}

	public int StopAudioPlaybackDeviceTest()
	{
		return IRtcEngineBase.stopAudioPlaybackDeviceTest();
	}

	public int StartAudioRecordingDeviceTest(int indicationInterval)
	{
		return IRtcEngineBase.startAudioRecordingDeviceTest(indicationInterval);
	}

	public int StopAudioRecordingDeviceTest()
	{
		return IRtcEngineBase.stopAudioRecordingDeviceTest();
	}

	public bool CreateAVideoDeviceManager()
	{
		return IRtcEngineBase.createAVideoDeviceManager();
	}

	public int ReleaseAVideoDeviceManager()
	{
		return IRtcEngineBase.releaseAVideoDeviceManager();
	}

	public int StartVideoDeviceTest(IntPtr hwnd)
	{
		return IRtcEngineBase.startVideoDeviceTest(hwnd);
	}

	public int StopVideoDeviceTest()
	{
		return IRtcEngineBase.stopVideoDeviceTest();
	}

	public int GetVideoDeviceCollectionCount()
	{
		return IRtcEngineBase.getVideoDeviceCollectionCount();
	}

	public int GetVideoDeviceCollectionDevice(int index, ref string deviceName, ref string deviceId)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(512);
		IntPtr intPtr2 = Marshal.AllocHGlobal(512);
		int videoDeviceCollectionDevice = IRtcEngineBase.getVideoDeviceCollectionDevice(index, intPtr, intPtr2);
		deviceName = Marshal.PtrToStringAnsi(intPtr);
		deviceId = Marshal.PtrToStringAnsi(intPtr2);
		Marshal.FreeHGlobal(intPtr);
		Marshal.FreeHGlobal(intPtr2);
		return videoDeviceCollectionDevice;
	}

	public int SetVideoDeviceCollectionDevice(string deviceId)
	{
		return IRtcEngineBase.setVideoDeviceCollectionDevice(deviceId);
	}

	public static IRtcEngine GetEngine(string appId)
	{
		if (instance == null)
		{
			instance = new IRtcEngine(appId);
		}
		return instance;
	}

	public static IRtcEngine getEngine(string appId)
	{
		return GetEngine(appId);
	}

	public static void Destroy()
	{
		if (instance != null)
		{
			((AudioEffectManagerImpl)instance.GetAudioEffectManager()).SetEngine(null);
			((AudioRecordingoDeviceManager)instance.GetAudioRecordingDeviceManager()).SetEngine(null);
			((AudioPlaybackDeviceManager)instance.GetAudioPlaybackDeviceManager()).SetEngine(null);
			((VideoDeviceManager)instance.GetVideoDeviceManager()).SetEngine(null);
			IRtcEngineBase.deleteEngine();
			instance = null;
			DeInitGameObject();
		}
	}

	public static IRtcEngine QueryEngine()
	{
		return instance;
	}

	[MonoPInvokeCallback(typeof(EngineEventOnJoinChannelSuccessHandler))]
	private static void OnJoinChannelSuccessCallBack(string channel, uint uid, int elapsed)
	{
		if (instance != null && instance.OnJoinChannelSuccess != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnJoinChannelSuccess(channel, uid, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnLeaveChannelHandler))]
	private static void OnLeaveChannelCallBack(uint duration, uint txBytes, uint rxBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileQuality, uint userCount, double cpuAppUsage, double cpuTotalUsage)
	{
		if (instance != null && instance.OnLeaveChannel != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				RtcStats stats = default(RtcStats);
				stats.duration = duration;
				stats.txBytes = txBytes;
				stats.rxBytes = rxBytes;
				stats.txKBitRate = txKBitRate;
				stats.rxKBitRate = rxKBitRate;
				stats.rxAudioKBitRate = rxAudioKBitRate;
				stats.txAudioKBitRate = txAudioKBitRate;
				stats.rxVideoKBitRate = rxVideoKBitRate;
				stats.txVideoKBitRate = txVideoKBitRate;
				stats.lastmileQuality = lastmileQuality;
				stats.users = userCount;
				stats.cpuAppUsage = cpuAppUsage;
				stats.cpuTotalUsage = cpuTotalUsage;
				instance.OnLeaveChannel(stats);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnReJoinChannelSuccessHandler))]
	private static void OnReJoinChannelSuccessCallBack(string channelName, uint uid, int elapsed)
	{
		if (instance != null && instance.OnReJoinChannelSuccess != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnReJoinChannelSuccess(channelName, uid, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnConnectionLostHandler))]
	private static void OnConnectionLostCallBack()
	{
		if (instance != null && instance.OnConnectionLost != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnConnectionLost();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnConnectionInterruptedHandler))]
	private static void OnConnectionInterruptedCallBack()
	{
		if (instance != null && instance.OnConnectionInterrupted != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnConnectionInterrupted();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRequestTokenHandler))]
	private static void OnRequestTokenCallBack()
	{
		if (instance != null && instance.OnRequestToken != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRequestToken();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserJoinedHandler))]
	private static void OnUserJoinedCallBack(uint uid, int elapsed)
	{
		if (instance != null && instance.OnUserJoined != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserJoined(uid, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserOfflineHandler))]
	private static void OnUserOfflineCallBack(uint uid, int reason)
	{
		if (instance != null && instance.OnUserOffline != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserOffline(uid, (USER_OFFLINE_REASON)reason);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioVolumeIndicationHandler))]
	private static void OnAudioVolumeIndicationCallBack(string volumeInfo, int speakerNumber, int totalVolume)
	{
		if (instance == null || instance.OnVolumeIndication == null)
		{
			return;
		}
		AgoraCallBackQueue.Current.EnQueue(delegate
		{
			string[] array = volumeInfo.Split('\t');
			int num = 1;
			AudioVolumeInfo[] array2 = new AudioVolumeInfo[speakerNumber];
			if (speakerNumber > 0)
			{
				for (int i = 0; i < speakerNumber; i++)
				{
					uint result = 0u;
					uint result2 = 0u;
					uint.TryParse(array[num++], out result);
					uint.TryParse(array[num++], out result2);
					array2[i].uid = result;
					array2[i].volume = result2;
				}
			}
			instance.OnVolumeIndication(array2, speakerNumber, totalVolume);
		});
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserMuteAudioHandler))]
	private static void OnUserMuteAudioCallBack(uint uid, bool muted)
	{
		if (instance != null && instance.OnUserMuted != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserMuted(uid, muted);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnSDKWarningHandler))]
	private static void OnSDKWarningCallBack(int warn, string msg)
	{
		if (instance != null && instance.OnWarning != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnWarning(warn, msg);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnSDKErrorHandler))]
	private static void OnSDKErrorCallBack(int error, string msg)
	{
		if (instance != null && instance.OnError != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnError(error, msg);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRtcStatsHandler))]
	private static void OnRtcStatsCallBack(uint duration, uint txBytes, uint rxBytes, ushort txKBitRate, ushort rxKBitRate, ushort rxAudioKBitRate, ushort txAudioKBitRate, ushort rxVideoKBitRate, ushort txVideoKBitRate, ushort lastmileQuality, uint userCount, double cpuAppUsage, double cpuTotalUsage)
	{
		if (instance != null && instance.OnRtcStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				RtcStats stats = default(RtcStats);
				stats.duration = duration;
				stats.txBytes = txBytes;
				stats.rxBytes = rxBytes;
				stats.txKBitRate = txKBitRate;
				stats.rxKBitRate = rxKBitRate;
				stats.rxAudioKBitRate = rxAudioKBitRate;
				stats.txAudioKBitRate = txAudioKBitRate;
				stats.rxVideoKBitRate = rxVideoKBitRate;
				stats.txVideoKBitRate = txVideoKBitRate;
				stats.lastmileQuality = lastmileQuality;
				stats.users = userCount;
				stats.cpuAppUsage = cpuAppUsage;
				stats.cpuTotalUsage = cpuTotalUsage;
				instance.OnRtcStats(stats);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioMixingFinishedHandler))]
	private static void OnAudioMixingFinishedCallBack()
	{
		if (instance != null && instance.OnAudioMixingFinished != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioMixingFinished();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioRouteChangedHandler))]
	private static void OnAudioRouteChangedCallBack(int route)
	{
		if (instance != null && instance.OnAudioRouteChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioRouteChanged((AUDIO_ROUTE)route);
			});
		}
	}

	[MonoPInvokeCallback(typeof(OnFirstRemoteVideoDecodedHandler))]
	private static void OnFirstRemoteVideoDecodedCallBack(uint uid, int width, int height, int elapsed)
	{
		if (instance != null && instance.OnFirstRemoteVideoDecoded != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnFirstRemoteVideoDecoded(uid, width, height, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnVideoSizeChangedHandler))]
	private static void OnVideoSizeChangedCallBack(uint uid, int width, int height, int elapsed)
	{
		if (instance != null)
		{
			_ = instance.OnVideoSizeChanged;
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnClientRoleChangedHandler))]
	private static void OnClientRoleChangedCallBack(int oldRole, int newRole)
	{
		if (instance != null && instance.OnClientRoleChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnClientRoleChanged(oldRole, newRole);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserMuteVideoHandler))]
	private static void OnUserMuteVideoCallBack(uint uid, bool muted)
	{
		if (instance != null && instance.OnUserMuteVideo != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserMuteVideo(uid, muted);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnMicrophoneEnabledHandler))]
	private static void OnMicrophoneEnabledCallBack(bool isEnabled)
	{
		if (instance != null && instance.OnMicrophoneEnabled != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnMicrophoneEnabled(isEnabled);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnApiExecutedHandler))]
	private static void OnApiExecutedCallBack(int err, string api, string result)
	{
		if (instance != null && instance.OnApiExecuted != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnApiExecuted(err, api, result);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnFirstLocalAudioFrameHandler))]
	private static void OnFirstLocalAudioFrameCallBack(int elapsed)
	{
		if (instance != null && instance.OnFirstLocalAudioFrame != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnFirstLocalAudioFrame(elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnFirstRemoteAudioFrameHandler))]
	private static void OnFirstRemoteAudioFrameCallBack(uint userId, int elapsed)
	{
		if (instance != null && instance.OnFirstRemoteAudioFrame != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnFirstRemoteAudioFrame(userId, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnLastmileQualityHandler))]
	private static void OnLastmileQualityCallBack(int quality)
	{
		if (instance != null && instance.OnLastmileQuality != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnLastmileQuality(quality);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioQualityHandler))]
	private static void OnAudioQualityCallBack(uint userId, int quality, ushort delay, ushort lost)
	{
		if (instance != null && instance.OnAudioQuality != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioQuality(userId, quality, delay, lost);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnStreamInjectedStatusHandler))]
	private static void OnStreamInjectedStatusCallBack(string url, uint userId, int status)
	{
		if (instance != null && instance.OnStreamInjectedStatus != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnStreamInjectedStatus(url, userId, status);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnStreamUnpublishedHandler))]
	private static void OnStreamUnpublishedCallBack(string url)
	{
		if (instance != null && instance.OnStreamUnpublished != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnStreamUnpublished(url);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnStreamPublishedHandler))]
	private static void OnStreamPublishedCallBack(string url, int error)
	{
		if (instance != null && instance.OnStreamPublished != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnStreamPublished(url, error);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnStreamMessageErrorHandler))]
	private static void OnStreamMessageErrorCallBack(uint userId, int streamId, int code, int missed, int cached)
	{
		if (instance != null && instance.OnStreamMessageError != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnStreamMessageError(userId, streamId, code, missed, cached);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnStreamMessageHandler))]
	private static void OnStreamMessageCallBack(uint userId, int streamId, string data, int length)
	{
		if (instance != null && instance.OnStreamMessage != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnStreamMessage(userId, streamId, data, length);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnConnectionBannedHandler))]
	private static void OnConnectionBannedCallBack()
	{
		if (instance != null && instance.OnConnectionBanned != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnConnectionBanned();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnConnectionStateChangedHandler))]
	private static void OnConnectionStateChangedCallBack(int state, int reason)
	{
		if (instance != null && instance.OnConnectionStateChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnConnectionStateChanged(state, reason);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnTokenPrivilegeWillExpireHandler))]
	private static void OnTokenPrivilegeWillExpireCallBack(string token)
	{
		if (instance != null && instance.OnTokenPrivilegeWillExpire != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnTokenPrivilegeWillExpire(token);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnActiveSpeakerHandler))]
	private static void OnActiveSpeakerCallBack(uint uid)
	{
		if (instance != null && instance.OnActiveSpeaker != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnActiveSpeaker(uid);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnVideoStoppedHandler))]
	private static void OnVideoStoppedCallBack()
	{
		if (instance != null && instance.OnVideoStopped != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnVideoStopped();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnFirstLocalVideoFrameHandler))]
	private static void OnFirstLocalVideoFrameCallBack(int width, int height, int elapsed)
	{
		if (instance != null && instance.OnFirstLocalVideoFrame != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnFirstLocalVideoFrame(width, height, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnFirstRemoteVideoFrameHandler))]
	private static void OnFirstRemoteVideoFrameCallBack(uint uid, int width, int height, int elapsed)
	{
		if (instance != null && instance.OnFirstRemoteVideoFrame != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnFirstRemoteVideoFrame(uid, width, height, elapsed);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserEnableVideoHandler))]
	private static void OnUserEnableVideoCallBack(uint uid, bool enabled)
	{
		if (instance != null && instance.OnUserEnableVideo != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserEnableVideo(uid, enabled);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnUserEnableLocalVideoHandler))]
	private static void OnUserEnableLocalVideoCallBack(uint uid, bool enabled)
	{
		if (instance != null && instance.OnUserEnableLocalVideo != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnUserEnableLocalVideo(uid, enabled);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteVideoStateChangedHandler))]
	private static void OnRemoteVideoStateChangedCallBack(uint uid, int state)
	{
		if (instance != null && instance.OnRemoteVideoStateChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteVideoStateChanged(uid, state);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnLocalPublishFallbackToAudioOnlyHandler))]
	private static void OnLocalPublishFallbackToAudioOnlyCallBack(bool isFallbackOrRecover)
	{
		if (instance != null && instance.OnLocalPublishFallbackToAudioOnly != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnLocalPublishFallbackToAudioOnly(isFallbackOrRecover);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteSubscribeFallbackToAudioOnlyHandler))]
	private static void OnRemoteSubscribeFallbackToAudioOnlyCallBack(uint uid, bool isFallbackOrRecover)
	{
		if (instance != null && instance.OnRemoteSubscribeFallbackToAudioOnly != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteSubscribeFallbackToAudioOnly(uid, isFallbackOrRecover);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnNetworkQualityHandler))]
	private static void OnNetworkQualityCallBack(uint uid, int txQuality, int rxQuality)
	{
		if (instance != null && instance.OnNetworkQuality != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnNetworkQuality(uid, txQuality, rxQuality);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnLocalVideoStatsHandler))]
	private static void OnLocalVideoStatsCallBack(int sentBitrate, int sentFramRate)
	{
		if (instance != null && instance.OnLocalVideoStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				LocalVideoStats localVideoStats = default(LocalVideoStats);
				localVideoStats.sentBitrate = sentBitrate;
				localVideoStats.sentFrameRate = sentFramRate;
				instance.OnLocalVideoStats(localVideoStats);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteVideoStatsHandler))]
	private static void OnRemoteVideoStatsCallBack(uint uid, int delay, int width, int height, int receivedBitrate, int receivedFrameRate, int remoteVideoStreamType)
	{
		if (instance != null && instance.OnRemoteVideoStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				RemoteVideoStats remoteVideoStats = default(RemoteVideoStats);
				remoteVideoStats.uid = uid;
				remoteVideoStats.delay = delay;
				remoteVideoStats.width = width;
				remoteVideoStats.height = height;
				remoteVideoStats.receivedBitrate = receivedBitrate;
				remoteVideoStats.receivedFrameRate = receivedFrameRate;
				remoteVideoStats.rxStreamType = (REMOTE_VIDEO_STREAM_TYPE)remoteVideoStreamType;
				instance.OnRemoteVideoStats(remoteVideoStats);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteAudioStatsHandler))]
	private static void OnRemoteAudioStatsCallBack(uint uid, int quality, int networkTransportDelay, int jitterBufferDelay, int audioLossRate)
	{
		if (instance != null && instance.OnRemoteAudioStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				RemoteAudioStats remoteAudioStats = default(RemoteAudioStats);
				remoteAudioStats.uid = uid;
				remoteAudioStats.quality = quality;
				remoteAudioStats.networkTransportDelay = networkTransportDelay;
				remoteAudioStats.jitterBufferDelay = jitterBufferDelay;
				remoteAudioStats.audioLossRate = audioLossRate;
				instance.OnRemoteAudioStats(remoteAudioStats);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioDeviceStateChangedHandler))]
	private static void OnAudioDeviceStateChangedCallBack(string deviceId, int deviceType, int deviceState)
	{
		if (instance != null && instance.OnAudioDeviceStateChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioDeviceStateChanged(deviceId, deviceType, deviceState);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnCameraReadyHandler))]
	private static void OnCameraReadyCallBack()
	{
		if (instance != null && instance.OnCameraReady != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnCameraReady();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnCameraFocusAreaChangedHandler))]
	private static void OnCameraFocusAreaChangedCallBack(int x, int y, int width, int height)
	{
		if (instance != null && instance.OnCameraFocusAreaChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnCameraExposureAreaChanged(x, y, width, height);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnCameraExposureAreaChangedHandler))]
	private static void OnCameraExposureAreaChangedCallBack(int x, int y, int width, int height)
	{
		if (instance != null && instance.OnCameraExposureAreaChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnCameraExposureAreaChanged(x, y, width, height);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteAudioMixingBeginHandler))]
	private static void OnRemoteAudioMixingBeginCallBack()
	{
		if (instance != null && instance.OnRemoteAudioMixingBegin != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteAudioMixingBegin();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteAudioMixingEndHandler))]
	private static void OnRemoteAudioMixingEndCallBack()
	{
		if (instance != null && instance.OnRemoteAudioMixingEnd != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteAudioMixingEnd();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioEffectFinishedHandler))]
	private static void OnAudioEffectFinishedCallBack(int soundId)
	{
		if (instance != null && instance.OnAudioEffectFinished != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioEffectFinished(soundId);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnVideoDeviceStateChangedHandler))]
	private static void OnVideoDeviceStateChangedCallBack(string deviceId, int deviceType, int deviceState)
	{
		if (instance != null && instance.OnVideoDeviceStateChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnVideoDeviceStateChanged(deviceId, deviceType, deviceState);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteVideoTransportStatsHandler))]
	private static void OnRemoteVideoTransportStatsCallBack(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
	{
		if (instance != null && instance.OnRemoteVideoTransportStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteVideoTransportStats(uid, delay, lost, rxKBitRate);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnRemoteAudioTransportStatsHandler))]
	private static void OnRemoteAudioTransportStatsCallBack(uint uid, ushort delay, ushort lost, ushort rxKBitRate)
	{
		if (instance != null && instance.OnRemoteAudioTransportStats != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnRemoteAudioTransportStats(uid, delay, lost, rxKBitRate);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnTranscodingUpdatedHandler))]
	private static void OnTranscodingUpdatedCallBack()
	{
		if (instance != null && instance.OnTranscodingUpdated != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnTranscodingUpdated();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnAudioDeviceVolumeChangedHandler))]
	private static void OnAudioDeviceVolumeChangedCallBack(int deviceType, int volume, bool muted)
	{
		if (instance != null && instance.OnAudioDeviceVolumeChanged != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnAudioDeviceVolumeChanged((MEDIA_DEVICE_TYPE)deviceType, volume, muted);
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnMediaEngineStartCallSuccessHandler))]
	private static void OnMediaEngineStartCallSuccessCallBack()
	{
		if (instance != null && instance.OnMediaEngineStartCallSuccess != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnMediaEngineStartCallSuccess();
			});
		}
	}

	[MonoPInvokeCallback(typeof(EngineEventOnMediaEngineLoadSuccessHandler))]
	private static void OnMediaEngineLoadSuccessCallBack()
	{
		if (instance != null && instance.OnMediaEngineLoadSuccess != null)
		{
			AgoraCallBackQueue.Current.EnQueue(delegate
			{
				instance.OnMediaEngineLoadSuccess();
			});
		}
	}

	private void InitEngineCallBack()
	{
		IRtcEngineBase.initEventOnJoinChannelSuccess(OnJoinChannelSuccessCallBack);
		IRtcEngineBase.initEventOnLeaveChannel(OnLeaveChannelCallBack);
		IRtcEngineBase.initEventOnReJoinChannelSuccess(OnReJoinChannelSuccessCallBack);
		IRtcEngineBase.initEventOnConnectionLost(OnConnectionLostCallBack);
		IRtcEngineBase.initEventOnConnectionInterrupted(OnConnectionInterruptedCallBack);
		IRtcEngineBase.initEventOnRequestToken(OnRequestTokenCallBack);
		IRtcEngineBase.initEventOnUserJoined(OnUserJoinedCallBack);
		IRtcEngineBase.initEventOnUserOffline(OnUserOfflineCallBack);
		IRtcEngineBase.initEventOnAudioVolumeIndication(OnAudioVolumeIndicationCallBack);
		IRtcEngineBase.initEventOnUserMuteAudio(OnUserMuteAudioCallBack);
		IRtcEngineBase.initEventOnSDKWarning(OnSDKWarningCallBack);
		IRtcEngineBase.initEventOnSDKError(OnSDKErrorCallBack);
		IRtcEngineBase.initEventOnRtcStats(OnRtcStatsCallBack);
		IRtcEngineBase.initEventOnAudioMixingFinished(OnAudioMixingFinishedCallBack);
		IRtcEngineBase.initEventOnAudioRouteChanged(OnAudioRouteChangedCallBack);
		IRtcEngineBase.initEventOnFirstRemoteVideoDecoded(OnFirstRemoteVideoDecodedCallBack);
		IRtcEngineBase.initEventOnVideoSizeChanged(OnVideoSizeChangedCallBack);
		IRtcEngineBase.initEventOnClientRoleChanged(OnClientRoleChangedCallBack);
		IRtcEngineBase.initEventOnUserMuteVideo(OnUserMuteVideoCallBack);
		IRtcEngineBase.initEventOnMicrophoneEnabled(OnMicrophoneEnabledCallBack);
		IRtcEngineBase.initEventOnApiExecuted(OnApiExecutedCallBack);
		IRtcEngineBase.initEventOnFirstLocalAudioFrame(OnFirstLocalAudioFrameCallBack);
		IRtcEngineBase.initEventOnFirstRemoteAudioFrame(OnFirstRemoteAudioFrameCallBack);
		IRtcEngineBase.initEventOnLastmileQuality(OnLastmileQualityCallBack);
		IRtcEngineBase.initEventOnAudioQuality(OnAudioQualityCallBack);
		IRtcEngineBase.initEventOnStreamInjectedStatus(OnStreamInjectedStatusCallBack);
		IRtcEngineBase.initEventOnStreamUnpublished(OnStreamUnpublishedCallBack);
		IRtcEngineBase.initEventOnStreamPublished(OnStreamPublishedCallBack);
		IRtcEngineBase.initEventOnStreamMessageError(OnStreamMessageErrorCallBack);
		IRtcEngineBase.initEventOnStreamMessage(OnStreamMessageCallBack);
		IRtcEngineBase.initEventOnConnectionBanned(OnConnectionBannedCallBack);
		IRtcEngineBase.initEventOnConnectionStateChanged(OnConnectionStateChangedCallBack);
		IRtcEngineBase.initEventOnTokenPrivilegeWillExpire(OnTokenPrivilegeWillExpireCallBack);
		IRtcEngineBase.initEventOnActiveSpeaker(OnActiveSpeakerCallBack);
		IRtcEngineBase.initEventOnVideoStopped(OnVideoStoppedCallBack);
		IRtcEngineBase.initEventOnFirstLocalVideoFrame(OnFirstLocalVideoFrameCallBack);
		IRtcEngineBase.initEventOnFirstRemoteVideoFrame(OnFirstRemoteVideoFrameCallBack);
		IRtcEngineBase.initEventOnUserEnableVideo(OnUserEnableVideoCallBack);
		IRtcEngineBase.initEventOnUserEnableLocalVideo(OnUserEnableLocalVideoCallBack);
		IRtcEngineBase.initEventOnRemoteVideoStateChanged(OnRemoteVideoStateChangedCallBack);
		IRtcEngineBase.initEventOnLocalPublishFallbackToAudioOnly(OnLocalPublishFallbackToAudioOnlyCallBack);
		IRtcEngineBase.initEventOnRemoteSubscribeFallbackToAudioOnly(OnRemoteSubscribeFallbackToAudioOnlyCallBack);
		IRtcEngineBase.initEventOnNetworkQuality(OnNetworkQualityCallBack);
		IRtcEngineBase.initEventOnLocalVideoStats(OnLocalVideoStatsCallBack);
		IRtcEngineBase.initEventOnRemoteVideoStats(OnRemoteVideoStatsCallBack);
		IRtcEngineBase.initEventOnRemoteAudioStats(OnRemoteAudioStatsCallBack);
		IRtcEngineBase.initEventOnAudioDeviceStateChanged(OnAudioDeviceStateChangedCallBack);
		IRtcEngineBase.initEventOnCameraReady(OnCameraReadyCallBack);
		IRtcEngineBase.initEventOnCameraFocusAreaChanged(OnCameraFocusAreaChangedCallBack);
		IRtcEngineBase.initEventOnCameraExposureAreaChanged(OnCameraExposureAreaChangedCallBack);
		IRtcEngineBase.initEventOnRemoteAudioMixingBegin(OnRemoteAudioMixingBeginCallBack);
		IRtcEngineBase.initEventOnRemoteAudioMixingEnd(OnRemoteAudioMixingEndCallBack);
		IRtcEngineBase.initEventOnAudioEffectFinished(OnAudioEffectFinishedCallBack);
		IRtcEngineBase.initEventOnVideoDeviceStateChanged(OnVideoDeviceStateChangedCallBack);
		IRtcEngineBase.initEventOnRemoteSubscribeFallbackToAudioOnly(OnRemoteSubscribeFallbackToAudioOnlyCallBack);
		IRtcEngineBase.initEventOnRemoteVideoTransportStats(OnRemoteVideoTransportStatsCallBack);
		IRtcEngineBase.initEventOnRemoteAudioTransportStats(OnRemoteAudioTransportStatsCallBack);
		IRtcEngineBase.initEventOnTranscodingUpdated(OnTranscodingUpdatedCallBack);
		IRtcEngineBase.initEventOnAudioDeviceVolumeChanged(OnAudioDeviceVolumeChangedCallBack);
		IRtcEngineBase.initEventOnMediaEngineStartCallSuccess(OnMediaEngineStartCallSuccessCallBack);
		IRtcEngineBase.initEventOnMediaEngineLoadSuccess(OnMediaEngineLoadSuccessCallBack);
	}
}
