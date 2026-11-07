namespace Assets.Sources.Config;

public class GameBootConfig
{
	public string ResourceBase = "";

	public string BattleServerIp;

	public int BattleServerTcpPort;

	public int BattleServerUdpPort;

	public long RoomId;

	public long UserId;

	public long CharId;

	public string Timestamp;

	public string Sign;

	public int ServerId;

	public string ExternalUrl;

	public string Platform;

	public int GameStartCount;

	public bool IsDirectProxy;

	public bool ClientDebug;

	public string StatUrl;

	public int LoginId;

	public int GenerateId;

	public bool IsGlobalServer;

	public string SceneTcpProxy;

	public bool IsPluginReportEnable;

	public string SignFileName;

	public bool IsBootCmd;

	public bool IsNewPlayer;

	public bool IsMicroClient;

	public bool IsSpeechControlClose;

	public int HallModeRuleId;

	public bool IsSplashEffectOpen;

	public int PveSplashEffectType;

	public int PvpSplashEffectType;

	public int PveSplashEffectColor;

	public int PvpSplashEffectColor;

	public string SelfKillNormal;

	public string SelfKillHeadShot;

	public string SelfKillKnife;

	public string SelfKillSpecial;

	public string GameStartJsonAttribute;

	public bool ConfigFileRevise;

	public string configMd5;

	public bool NpOpen;

	public int UnityNp;

	public bool isGolbalRoom;

	public override string ToString()
	{
		return $"BattleServerIp: {BattleServerIp}, BattleServerTcpPort: {BattleServerTcpPort}, BattleServerUdpPort: {BattleServerUdpPort}, CharId: {CharId}, ClientDebug: {ClientDebug}, ExternalUrl: {ExternalUrl}, GameStartCount: {GameStartCount}, GenerateId: {GenerateId}, IsDirectProxy: {IsDirectProxy}, IsGlobalServer: {IsGlobalServer}, IsPluginReportEnable: {IsPluginReportEnable}, LoginId: {LoginId}, Platform: {Platform}, ResourceBase: {ResourceBase}, RoomId: {RoomId}, SceneTcpProxy: {SceneTcpProxy}, ServerId: {ServerId}, Sign: {Sign}, SignFileName: {SignFileName}, StatUrl: {StatUrl}, Timestamp: {Timestamp}, UserId: {UserId}, IsNewPlayer: {IsNewPlayer}, IsSpeechControlClose : {IsSpeechControlClose}, IsMicroClient : {IsMicroClient}, HallModeRuleId : {HallModeRuleId}, IsSplashEffectOpen : {IsSplashEffectOpen}, PveSplashEffectType : {PveSplashEffectType}, PvpSplashEffectType : {PvpSplashEffectType}, PveSplashEffectColor : {PveSplashEffectColor}, PvpSplashEffectColor : {PvpSplashEffectColor}, SelfKillNormal : {SelfKillNormal}, SelfKillHeadShot : {SelfKillHeadShot}, SelfKillKnife : {SelfKillKnife},  SelfKillSpecial :{SelfKillSpecial}, GameStartJsonAttribute : {GameStartJsonAttribute}";
	}
}
