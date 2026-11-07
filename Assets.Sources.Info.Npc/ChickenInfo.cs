using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Npc;

public class ChickenInfo : AbstractBattlePetInfo
{
	private Image _progress;

	private Text _time;

	private GameObject _weird;

	public override void LoadEntityResource(SceneObjectEntity npcEntity)
	{
		base.LoadEntityResource(npcEntity);
		npcEntity.loadNpcResource.LoadRequests.AddAsset("WeirdTransformPistol", new AssetInfo("playereffectprefab/weirdtransformpistol", "WeirdTransformPistol"));
	}

	public override void InitEntityResource(SceneObjectEntity npcEntity)
	{
		base.InitEntityResource(npcEntity);
		if (_npcName != null)
		{
			_npcName.transform.Find("Canvas/NameText").GetComponent<Text>().text = "";
		}
		LoadResults loadResults = npcEntity.npcResource.LoadResults;
		_weird = loadResults["WeirdTransformPistol"].GameObject;
		if (_weird != null)
		{
			_weird.transform.parent = _npcWrapper.transform;
			_weird.transform.localPosition = new Vector3(0f, 100f);
			_progress = _weird.transform.Find("WorldSpace/Back/Progress").GetComponent<Image>();
			_time = _weird.transform.Find("WorldSpace/Back/Time").GetComponent<Text>();
		}
	}

	public override void RenderEntity(SceneObjectEntity npcEntity)
	{
		base.RenderEntity(npcEntity);
		if (_weird != null)
		{
			bool flag = (int)npcEntity.npc.Current.SkillEffectLevel == 3;
			if (_weird.IsActiveSelf() != flag)
			{
				_weird.SetObjectActive(flag);
			}
			if (flag)
			{
				_progress.fillAmount = (float)npcEntity.npc.Current.EffectLevel / 10f;
				_time.text = npcEntity.npc.Current.EffectLevel.ToString();
			}
		}
	}
}
