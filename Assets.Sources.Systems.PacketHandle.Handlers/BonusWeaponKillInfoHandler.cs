using Assets.Sources.Utils.Ui;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BonusWeaponKillInfoHandler : ApcPacketHandler<WeaponKillInfoData>
{
	private ChatContext _chatContext;

	public BonusWeaponKillInfoHandler(Contexts contexts)
	{
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 209;
	}

	public override void Handle(WeaponKillInfoData data)
	{
		if (data.IsChampionSkin)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("USEWEAPON_KILL_PLAYER_NUMBER") + "</body></message>", "hononary1", data.KillName, LanguageUtils.GetWeaponCnName(data.WeaponName) + "-" + SingletonInstance<ChampionWeaponAndSkillParser>.Instance.GetChampionWeaponAndSkillfigName(data.WeaponSkin), data.BeKilledName, data.Count));
		}
		else if (_chatContext.hasChatJobHistroy)
		{
			_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("USEWEAPON_KILL_PLAYER_NUMBER") + "</body></message>", "hononary1", data.KillName, LanguageUtils.GetWeaponCnName(data.WeaponName), data.BeKilledName, data.Count));
		}
	}
}
