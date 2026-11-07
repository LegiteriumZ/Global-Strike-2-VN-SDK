using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerHpBar.SubRender;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using SSJJBase.Logger;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar;

public class PlayerHpBarRender : IPlayerHpBarRender
{
	public bool CareerActive;

	public Vector3 NameTextPos;

	public Vector3 TitlePos;

	public int NamePosY;

	public float NameWidth;

	public int PosY;

	public bool TimeActive;

	private Canvas _screenSpace;

	protected GameObject EffectGameObject;

	private readonly List<IHpBarRender> _updateList = new List<IHpBarRender>();

	private UnityEngine.Camera _mainCamera;

	private int _careerHeight;

	private int _ruleHeight;

	public int CareerHeight => _careerHeight + _ruleHeight;

	public void Init(PlayerEntity player, GameObject effectGameObject)
	{
		EffectGameObject = effectGameObject;
		Transform transform = effectGameObject.transform;
		_screenSpace = transform.Find("ScreenSpace").GetComponent<Canvas>();
		CanvasScaler component = _screenSpace.GetComponent<CanvasScaler>();
		component.uiScaleMode = AbstractModel.BestScaleMode;
		component.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
		component.matchWidthOrHeight = 1f;
		component.referenceResolution = AbstractModel.BestScreenSize;
		EffectGameObject.name = "PlayerHpBar_" + player.basicInfo.Current.PlayerName;
		_mainCamera = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera;
		_ruleHeight = (Contexts.sharedInstance.gameRule.currentRule.Rule.IsBighead() ? 25 : 15);
		_updateList.Add(new HpBarHp());
		_updateList.Add(new HpBarTime());
		_updateList.Add(new HpBarName());
		_updateList.Add(new HpBarKiller());
		_updateList.Add(new HpBarDistance());
		_updateList.Add(new HpBarDistanceIcon());
		_updateList.Add(new HpBarTitle());
		_updateList.Add(new HpBarHonorary());
		_updateList.Add(new HpBarFavor());
		_updateList.Add(new HpBarCareer());
		_updateList.Add(new HpBarBioLevel());
		_updateList.Add(new HpBarBioShield());
		_updateList.Add(new HpBarKnifeKill());
		_updateList.Add(new HpBarFirstProtityTitle());
		_updateList.Add(new HpRankHonor());
		_updateList.Add(new HpBarExpression());
		_updateList.Add(new HpBarBroadSwordLevel());
		_updateList.Add(new BuffNum());
		_updateList.Add(new HpBarYuetuSkill());
		_updateList.Add(new HPBarMonter());
		_updateList.Add(new HPBarAddResis());
		for (int i = 0; i < _updateList.Count; i++)
		{
			try
			{
				_updateList[i].Init(player, effectGameObject, Contexts.sharedInstance, this);
			}
			catch (Exception message)
			{
				this.LogError(message);
			}
		}
	}

	public bool Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Vector3 vector = VectorCoordConverter.SsjjToUnity(targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex()));
		bool flag = InScreenUtils.InScreen(vector, _mainCamera) > 0f;
		PosY = 0;
		if (flag)
		{
			try
			{
				_careerHeight = (TimeActive ? 50 : PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer(), targetPlayer.GetScale()));
				BaseHpBar.Render(Contexts.sharedInstance.player.cameraOwnerEntity, frameTime);
				for (int i = 0; i < _updateList.Count; i++)
				{
					_updateList[i].Update(targetPlayer, vector);
				}
			}
			catch (Exception message)
			{
				this.LogError(message);
			}
			EffectGameObject.SetObjectActive(isactive: true);
			if (targetPlayer.HasState(131072))
			{
				EffectGameObject.SetObjectActive(isactive: false);
			}
		}
		else
		{
			EffectGameObject.SetObjectActive(isactive: false);
		}
		return flag;
	}
}
