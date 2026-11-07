using System;
using System.Collections.Generic;
using Assets.Scripts.Asset;
using Assets.Scripts.Utility;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.Scene;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneHomeGunGridSystem : IResourceLoadSystem, IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _group;

	private readonly IGroup<SceneObjectEntity> _groupweapon;

	private Dictionary<int, SceneHomeGunGridData> _sceneHomeGunGridDatas;

	private readonly SceneObjectContext _sceneWeaponContext;

	private readonly MessageContext _messageContext;

	private SceneObjectEntity entity;

	private Dictionary<long, SceneObjectEntity> entityDic = new Dictionary<long, SceneObjectEntity>();

	private Dictionary<long, HomelandWeaponData> weaponInfo = new Dictionary<long, HomelandWeaponData>();

	private List<Transform> xian_g = new List<Transform>(4);

	private List<Transform> xian_r = new List<Transform>(4);

	private List<Transform> xian_y = new List<Transform>(4);

	private int entity_item_Temp_Id;

	private WeaponGameObject weapon_Temp;

	private SJAnimator sjanim;

	private GameObject grid_temp;

	private WeaponGameObject weaponGameObject;

	private WeaponEntity currentWeapon;

	private bool isGame;

	public Dictionary<long, List<SceneHomeGunGriditemData>> weapon_grid = new Dictionary<long, List<SceneHomeGunGriditemData>>();

	public Dictionary<long, int> weaponid_grid = new Dictionary<long, int>();

	public Dictionary<long, Vector4> weaponid_size = new Dictionary<long, Vector4>();

	private LoadRequests loadRequests;

	private Dictionary<int, GameObject> list_g = new Dictionary<int, GameObject>();

	private Dictionary<int, GameObject> lock_go = new Dictionary<int, GameObject>();

	private Dictionary<int, Vector3> list_s = new Dictionary<int, Vector3>();

	private MaterialPropertyBlock _materialPropertyBlock;

	public SceneHomeGunGridSystem(Contexts contexts)
	{
		_sceneWeaponContext = contexts.sceneObject;
		_messageContext = contexts.message;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap).NoneOf(SceneObjectMatcher.MapHomeGunGrid));
		_groupweapon = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.HomeWeapon, SceneObjectMatcher.UnityObjects));
		Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon = new Dictionary<int, List<HomelandWeaponData>>();
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (SceneObjectEntity item in _group)
		{
			SceneHomeGunGrid(item);
		}
	}

	public bool isLock(int id)
	{
		if (_messageContext.homeLandScene.UnlockedIds != null && _messageContext.homeLandScene.UnlockedIds.Contains(id))
		{
			return false;
		}
		return true;
	}

	public WeaponGameObject UpdateWeaponPos(GameObject grid, SceneObjectEntity entity_item, int worn, string skillName, int boothType = 0)
	{
		if (weapon_Temp == null || entity_item.creationIndex != entity_item_Temp_Id)
		{
			grid_temp = null;
			entity_item_Temp_Id = entity_item.creationIndex;
			weapon_Temp = entity_item.unityObjects.LoadResults["WeaponModel"].GameObject.GetComponent<WeaponGameObject>();
			GameObject weaponObj = weapon_Temp.gameObject;
			SkinUtility.InitSkin(ref weaponObj, entity_item.unityObjects.LoadResults, worn, 0, BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(skillName));
			if (entity_item.unityObjects.LoadResults.ContainsKey("WeaponAnim"))
			{
				SJAnimationAsset sJAnimationAsset = entity_item.unityObjects.LoadResults["WeaponAnim"].Object as SJAnimationAsset;
				sjanim = weapon_Temp.GetComponent<SJAnimator>();
				if (sJAnimationAsset != null)
				{
					sjanim.AddAnimationClips(0, sJAnimationAsset.Clips);
				}
			}
			FollowTransform2[] componentsInChildren = weapon_Temp.GetComponentsInChildren<FollowTransform2>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Restore();
				componentsInChildren[i].enabled = false;
			}
		}
		if (grid_temp == null || grid_temp != grid)
		{
			grid_temp = grid;
			weapon_Temp.transform.position = grid.transform.position;
			weapon_Temp.transform.rotation = grid.transform.rotation * Quaternion.Euler(0f, 270f, 0f);
			weapon_Temp.transform.localScale = Vector3.one;
			if (boothType == 1)
			{
				weapon_Temp.transform.rotation = grid.transform.rotation * Quaternion.Euler(90f, 270f, 0f);
			}
			return weapon_Temp;
		}
		return null;
	}

	public void OnRender()
	{
		foreach (long key3 in entityDic.Keys)
		{
			int key = weaponid_grid[key3] / 10000;
			if (!this.weaponInfo[key3].IsRentOut && _sceneHomeGunGridDatas[key].type == 1)
			{
				entityDic[key3].unityObjects.LoadResults["WeaponModel"].GameObject.transform.rotation *= Quaternion.Euler(0f, 0f, 120f * Time.deltaTime);
			}
		}
		foreach (int key4 in list_g.Keys)
		{
			if (_messageContext.homeLandScene.UnlockedIds != null && _messageContext.homeLandScene.UnlockedIds.Contains(key4))
			{
				if (!list_g[key4].activeSelf)
				{
					list_g[key4].SetActive(value: true);
				}
				if (lock_go.ContainsKey(key4) && lock_go[key4].activeSelf)
				{
					lock_go[key4].SetActive(value: false);
				}
			}
		}
		foreach (SceneObjectEntity item in _groupweapon)
		{
			if (item.hasHomeWeapon && item.homeWeapon.id == -9)
			{
				for (int i = 0; i < 4; i++)
				{
					xian_g.Add(item.unityObjects.LoadResults["Xian_G" + i].GameObject.transform);
					xian_r.Add(item.unityObjects.LoadResults["Xian_R" + i].GameObject.transform);
					xian_y.Add(item.unityObjects.LoadResults["Xian_Y" + i].GameObject.transform);
				}
				item.Destroy();
			}
			if (item.hasHomeWeapon && item.homeWeapon.id == -10)
			{
				foreach (int key5 in list_g.Keys)
				{
					if (item.unityObjects.LoadResults["jz_" + key5].GameObject != null)
					{
						item.unityObjects.LoadResults["jz_" + key5].GameObject.transform.position = list_g[key5].transform.position;
						item.unityObjects.LoadResults["jz_" + key5].GameObject.transform.rotation = list_g[key5].transform.rotation * Quaternion.Euler(90f, 90f, 0f);
						item.unityObjects.LoadResults["jz_" + key5].GameObject.transform.localScale = list_s[key5];
						lock_go.Add(key5, item.unityObjects.LoadResults["jz_" + key5].GameObject);
					}
				}
				item.Destroy();
			}
			if (!item.hasHomeWeapon || item.homeWeapon.id < 0)
			{
				continue;
			}
			int num = item.homeWeapon.id / 10000;
			int num2 = item.homeWeapon.id % 10000;
			if (_sceneHomeGunGridDatas.ContainsKey(num) && _sceneHomeGunGridDatas[num].gridDic.ContainsKey(num2))
			{
				GameObject go = _sceneHomeGunGridDatas[num].gridDic[num2].go;
				WeaponGameObject go2 = UpdateWeaponPos(go, item, this.weaponInfo[item.homeWeapon.weaponId].Worn, this.weaponInfo[item.homeWeapon.weaponId].SkinName, _sceneHomeGunGridDatas[num].type);
				if (sjanim != null)
				{
					sjanim.PlayAtFixedTime(0, "TORSO_STAND", 0f);
				}
				SceneHomeGunGridData sceneHomeGunGridData = _sceneHomeGunGridDatas[num];
				int l_occupu_x = 0;
				int u_occupu_y = 0;
				int r_occupu_x = 0;
				int d_occupu_y = 0;
				WeaponSizw(go2, num, ref l_occupu_x, ref u_occupu_y, ref r_occupu_x, ref d_occupu_y);
				try
				{
					UpLoadWeapon(num2, l_occupu_x, r_occupu_x, u_occupu_y, d_occupu_y, sceneHomeGunGridData, item.homeWeapon.weaponId);
				}
				catch (Exception)
				{
				}
				weaponid_grid.Add(item.homeWeapon.weaponId, item.homeWeapon.id);
				weaponid_size.Add(item.homeWeapon.weaponId, new Vector4(u_occupu_y, d_occupu_y, l_occupu_x, r_occupu_x));
				if (this.weaponInfo[item.homeWeapon.weaponId].IsRentOut)
				{
					Color white = Color.white;
					white.a *= 0.3f;
					SetWeaponColor(go2, white);
				}
				entityDic.Add(item.homeWeapon.weaponId, item);
				item.RemoveHomeWeapon();
			}
		}
		if (_messageContext.homeLandScene.msg_List != null)
		{
			for (int j = 0; j < _messageContext.homeLandScene.msg_List.Count; j++)
			{
				HomelandWeaponData homelandWeaponData = _messageContext.homeLandScene.msg_List[j];
				UnLoadWeapon(homelandWeaponData);
				if (homelandWeaponData.StorageId != 0L)
				{
					int key2 = homelandWeaponData.Idx / 10000;
					if (!Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon.ContainsKey(key2))
					{
						Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon.Add(key2, new List<HomelandWeaponData>());
					}
					if (!Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon[key2].Contains(homelandWeaponData))
					{
						Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon[key2].Add(homelandWeaponData);
					}
					AddLoadWeapon(homelandWeaponData.Idx, homelandWeaponData.CodeName, homelandWeaponData.SkinName, homelandWeaponData.StorageId);
					if (!this.weaponInfo.ContainsKey(homelandWeaponData.StorageId))
					{
						this.weaponInfo.Add(homelandWeaponData.StorageId, homelandWeaponData);
					}
					else
					{
						this.weaponInfo[homelandWeaponData.StorageId] = homelandWeaponData;
					}
				}
			}
			_messageContext.homeLandScene.msg_List.Clear();
		}
		if (Contexts.sharedInstance.player.myPlayerEntity == null || (_messageContext.homeLandScene.teamId > 0 && Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Current.TeamId != _messageContext.homeLandScene.teamId))
		{
			return;
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		HomeGunGridItem homeGunGridItem = null;
		_messageContext.homeLandScene.isShowEP = false;
		_messageContext.homeLandScene.isShowET = false;
		if (Physics.Raycast(ray, out var hitInfo, 300f))
		{
			homeGunGridItem = hitInfo.collider.transform.GetComponent<HomeGunGridItem>();
			if (homeGunGridItem != null)
			{
				if (isLock(homeGunGridItem.backid))
				{
					if (_messageContext.homeLandScene.CameraTargetId != homeGunGridItem.listID)
					{
						HomelandUnlockData homelandUnlockData = new HomelandUnlockData();
						homelandUnlockData.UnlockId = homeGunGridItem.backid;
						homelandUnlockData.Type = 1;
						Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(126, homelandUnlockData);
						_messageContext.homeLandScene.CameraTargetId = homeGunGridItem.listID;
					}
					return;
				}
				long weaponid = _sceneHomeGunGridDatas[homeGunGridItem.listID].gridDic[homeGunGridItem.gridid].weaponid;
				if (Contexts.sharedInstance.player.myPlayerEntity.GetCharacterId() != _messageContext.homeLandScene.CharacterId)
				{
					if (this.weaponInfo.ContainsKey(weaponid) && !this.weaponInfo[weaponid].IsRentOut)
					{
						_messageContext.homeLandScene.isShowET = true;
						_messageContext.homeLandScene.isRentid = homeGunGridItem.listID;
					}
					return;
				}
				_messageContext.homeLandScene.CameraTargetId = -1L;
				if (currentWeapon != Contexts.sharedInstance.weapon.currentWeaponEntity)
				{
					currentWeapon = Contexts.sharedInstance.weapon.currentWeaponEntity;
					if (entity != null && entity.hasUnityObjects)
					{
						entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.rotation = Quaternion.identity;
						PlayerEntityUtility.CollectReusable(entity.unityObjects.LoadResults["WeaponModel"].GameObject);
						entity.Destroy();
						entity = null;
					}
				}
				if (currentWeapon != null && entity == null)
				{
					entity = _sceneWeaponContext.CreateEntity();
					string weaponName = currentWeapon.basicInfo.Data.WeaponName;
					string weaponSkinName = currentWeapon.basicInfo.Data.WeaponSkinName;
					IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weaponName);
					if (weaponInfo == null)
					{
						weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weaponName + "_ct");
					}
					if (weaponInfo == null)
					{
						return;
					}
					WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(weaponSkinName);
					LoadRequests newLoadRequests = new LoadRequests();
					if (!isViewWeapon(homeGunGridItem.type))
					{
						SkinUtility.AddSceneModelRequest(newLoadRequests, weaponInfo, skinInfo);
					}
					else
					{
						SkinUtility.AddViewModelRequest(newLoadRequests, weaponInfo, skinInfo);
					}
					entity.AddLoadUnityObjects(newLoadRequests, weaponInfo);
					entity.AddHomeWeapon(-1, 0L);
				}
				foreach (SceneObjectEntity item2 in _groupweapon)
				{
					if (item2.hasUnityObjects && item2.hasHomeWeapon && item2.homeWeapon.id >= -1)
					{
						weaponGameObject = UpdateWeaponPos(homeGunGridItem.gameObject, item2, currentWeapon.basicInfo.Data.WeaponWorn, currentWeapon.basicInfo.Data.WeaponSkinName, homeGunGridItem.type);
						if (sjanim != null)
						{
							sjanim.PlayAtFixedTime(0, "TORSO_STAND", 0f);
						}
					}
				}
				if (weaponGameObject != null)
				{
					int l_occupu_x2 = 0;
					int u_occupu_y2 = 0;
					int r_occupu_x2 = 0;
					int d_occupu_y2 = 0;
					WeaponSizw(weaponGameObject, homeGunGridItem.listID, ref l_occupu_x2, ref u_occupu_y2, ref r_occupu_x2, ref d_occupu_y2);
					SceneHomeGunGridData sceneHomeGunGridData2 = _sceneHomeGunGridDatas[homeGunGridItem.listID];
					int gridid = homeGunGridItem.gridid;
					int idtemp = gridid;
					long weaponID = -1L;
					if (homeGunGridItem.type != 0)
					{
						l_occupu_x2 = (u_occupu_y2 = (r_occupu_x2 = (d_occupu_y2 = 0)));
					}
					SceneHomeGunGriditemData around = GetAround(l_occupu_x2, r_occupu_x2, gridid, idtemp, sceneHomeGunGridData2, ref weaponID);
					if (around == null)
					{
						SetWeaponColor(homeGunGridItem.listID, u_occupu_y2, d_occupu_y2, l_occupu_x2, r_occupu_x2, xian_r, weaponGameObject.transform);
						return;
					}
					around = sceneHomeGunGridData2.gridDic[homeGunGridItem.gridid];
					for (int k = 0; k < u_occupu_y2; k++)
					{
						idtemp = (gridid = around.uid);
						around = GetAround(l_occupu_x2, r_occupu_x2, gridid, idtemp, sceneHomeGunGridData2, ref weaponID);
						if (around == null)
						{
							SetWeaponColor(homeGunGridItem.listID, u_occupu_y2, d_occupu_y2, l_occupu_x2, r_occupu_x2, xian_r, weaponGameObject.transform);
							return;
						}
					}
					around = sceneHomeGunGridData2.gridDic[homeGunGridItem.gridid];
					for (int l = 0; l < d_occupu_y2; l++)
					{
						idtemp = (gridid = around.did);
						around = GetAround(l_occupu_x2, r_occupu_x2, gridid, idtemp, sceneHomeGunGridData2, ref weaponID);
						if (around == null)
						{
							SetWeaponColor(homeGunGridItem.listID, u_occupu_y2, d_occupu_y2, l_occupu_x2, r_occupu_x2, xian_r, weaponGameObject.transform);
							return;
						}
					}
					SetWeaponColor(homeGunGridItem.listID, u_occupu_y2, d_occupu_y2, l_occupu_x2, r_occupu_x2, xian_g, weaponGameObject.transform);
					if (weaponid_grid.ContainsKey(weaponID))
					{
						SetWeaponColor(weaponid_grid[weaponID] / 10000, (int)weaponid_size[weaponID].x, (int)weaponid_size[weaponID].y, (int)weaponid_size[weaponID].z, (int)weaponid_size[weaponID].w, xian_y, entityDic[weaponID].unityObjects.LoadResults["WeaponModel"].GameObject.transform);
					}
					else
					{
						SetWeaponColor(-1, 0, 0, 0, 0, xian_y, null);
					}
					SetWeaponColor(-1, 0, 0, 0, 0, xian_r, null);
					_messageContext.homeLandScene.putdown = (weaponid_grid.ContainsKey(weaponID) ? weaponid_grid[weaponID] : (-1));
					_messageContext.homeLandScene.pickup = homeGunGridItem.gridid + homeGunGridItem.listID * 10000;
				}
				if (this.weaponInfo.ContainsKey(weaponid))
				{
					if (this.weaponInfo[weaponid].IsRentOut)
					{
						_messageContext.homeLandScene.putdown = -1;
					}
					else
					{
						_messageContext.homeLandScene.pickup = -1;
					}
				}
				_messageContext.homeLandScene.isShowEP = true;
			}
			_messageContext.homeLandScene.CameraTargetId = -1L;
		}
		else if (entity != null && entity.hasUnityObjects)
		{
			_messageContext.homeLandScene.CameraTargetId = -1L;
			entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.rotation = Quaternion.identity;
			PlayerEntityUtility.CollectReusable(entity.unityObjects.LoadResults["WeaponModel"].GameObject);
			weaponGameObject = null;
			weapon_Temp = null;
			grid_temp = null;
			entity.Destroy();
			entity = null;
			SetWeaponColor(-1, 0, 0, 0, 0, xian_g, null);
			SetWeaponColor(-1, 0, 0, 0, 0, xian_r, null);
			SetWeaponColor(-1, 0, 0, 0, 0, xian_y, null);
		}
		_messageContext.homeLandScene.CameraTargetId = -1L;
	}

	public void SetWeaponColor(int tc, int u_occupu_y, int d_occupu_y, int l_occupu_x, int r_occupu_x, List<Transform> list, Transform go)
	{
		if (tc < 0)
		{
			for (int i = 0; i < 4; i++)
			{
				list[i].localScale = Vector3.zero;
				if (list[i].gameObject.activeSelf)
				{
					list[i].gameObject.SetActive(value: false);
				}
			}
			return;
		}
		for (int j = 0; j < 4; j++)
		{
			if (!list[j].gameObject.activeSelf)
			{
				list[j].gameObject.SetActive(value: true);
			}
		}
		float size = _sceneHomeGunGridDatas[tc].size;
		Vector3 one = Vector3.one;
		one.x = ((float)l_occupu_x + 0.5f) * size + ((float)r_occupu_x + 0.5f) * size;
		Quaternion rotation = go.rotation;
		list[0].SetParent(go, worldPositionStays: false);
		list[0].localPosition = Vector3.forward * ((float)u_occupu_y + 0.5f) * size * 100f;
		list[0].rotation = rotation * Quaternion.Euler(90f, 180f, 0f);
		list[0].localScale = one;
		list[1].SetParent(go, worldPositionStays: false);
		list[1].localPosition = Vector3.back * ((float)d_occupu_y + 0.5f) * size * 100f;
		list[1].rotation = rotation * Quaternion.Euler(90f, 180f, 0f);
		list[1].localScale = one;
		Vector3 one2 = Vector3.one;
		one2.x = ((float)u_occupu_y + 0.5f) * size + ((float)d_occupu_y + 0.5f) * size;
		list[2].SetParent(go, worldPositionStays: false);
		list[2].localPosition = Vector3.left * ((float)l_occupu_x + 0.5f) * size * 100f;
		list[2].rotation = rotation * Quaternion.Euler(90f, 90f, 0f);
		list[2].localScale = one2;
		list[3].SetParent(go, worldPositionStays: false);
		list[3].localPosition = Vector3.right * ((float)r_occupu_x + 0.5f) * size * 100f;
		list[3].rotation = rotation * Quaternion.Euler(90f, 90f, 0f);
		list[3].localScale = one2;
	}

	private void UpLoadWeapon(int gridid, int l_occupu_x, int r_occupu_x, int u_occupu_y, int d_occupu_y, SceneHomeGunGridData sceneHomeGunGridData, long weaponid)
	{
		int num = gridid;
		int idtemp = num;
		SceneHomeGunGriditemData sceneHomeGunGriditemData = SetWeapon(l_occupu_x, r_occupu_x, num, idtemp, sceneHomeGunGridData, weaponid);
		sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[gridid];
		SetOccupy(sceneHomeGunGriditemData, weaponid);
		for (int i = 0; i < u_occupu_y; i++)
		{
			idtemp = (num = sceneHomeGunGriditemData.uid);
			sceneHomeGunGriditemData = SetWeapon(l_occupu_x, r_occupu_x, num, idtemp, sceneHomeGunGridData, weaponid);
		}
		sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[gridid];
		for (int j = 0; j < d_occupu_y; j++)
		{
			idtemp = (num = sceneHomeGunGriditemData.did);
			sceneHomeGunGriditemData = SetWeapon(l_occupu_x, r_occupu_x, num, idtemp, sceneHomeGunGridData, weaponid);
		}
	}

	private void UnLoadWeapon(HomelandWeaponData weaponData)
	{
		long num = 0L;
		foreach (KeyValuePair<long, int> item in weaponid_grid)
		{
			if (item.Value == weaponData.Idx)
			{
				num = item.Key;
			}
		}
		if (num <= 0)
		{
			return;
		}
		if (weapon_grid.ContainsKey(num))
		{
			for (int i = 0; i < weapon_grid[num].Count; i++)
			{
				weapon_grid[num][i].weaponid = -1L;
				weapon_grid[num][i].isOccupy = false;
				SetColor(weapon_grid[num][i].go, Color.white);
			}
			if (entityDic.ContainsKey(num))
			{
				entityDic[num].unityObjects.LoadResults["WeaponModel"].GameObject.transform.rotation = Quaternion.identity;
				PlayerEntityUtility.CollectReusable(entityDic[num].unityObjects.LoadResults["WeaponModel"].GameObject);
				entityDic[num].Destroy();
				entityDic[num] = null;
				entityDic.Remove(num);
			}
			weapon_grid.Remove(num);
			weaponid_grid.Remove(num);
			weaponid_size.Remove(num);
		}
		int key = weaponData.Idx / 10000;
		if (Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon.ContainsKey(key) && Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon[key].Contains(weaponData))
		{
			Contexts.sharedInstance.message.homeLandScene.dicGid_Weapon[key].Remove(weaponData);
		}
	}

	public bool isViewWeapon(int id)
	{
		return false;
	}

	private void AddLoadWeapon(int id, string weaponName, string weaponskinname, long weaponID)
	{
		SceneObjectEntity sceneObjectEntity = _sceneWeaponContext.CreateEntity();
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weaponName);
		if (weaponInfo == null)
		{
			weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weaponName + "_ct");
		}
		if (weaponInfo != null)
		{
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(weaponskinname);
			LoadRequests newLoadRequests = new LoadRequests();
			int key = id / 10000;
			if (!isViewWeapon(_sceneHomeGunGridDatas[key].type))
			{
				SkinUtility.AddSceneModelRequest(newLoadRequests, weaponInfo, skinInfo);
			}
			else
			{
				SkinUtility.AddViewModelRequest(newLoadRequests, weaponInfo, skinInfo);
			}
			sceneObjectEntity.AddLoadUnityObjects(newLoadRequests, weaponInfo);
			sceneObjectEntity.AddHomeWeapon(id, weaponID);
		}
	}

	private void WeaponSizw(WeaponGameObject weaponGameObject, int listID, ref int l_occupu_x, ref int u_occupu_y, ref int r_occupu_x, ref int d_occupu_y)
	{
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		foreach (Renderer skinRenderer in weaponGameObject.GetSkinRenderers())
		{
			if (skinRenderer.enabled)
			{
				vector = skinRenderer.bounds.max - skinRenderer.bounds.center;
				vector2 = skinRenderer.bounds.center - skinRenderer.bounds.min;
			}
		}
		float num = (_sceneHomeGunGridDatas[listID].size + _sceneHomeGunGridDatas[listID].gap) * 100f;
		l_occupu_x = Mathf.CeilToInt(Mathf.Abs(vector.x) / num - 0.5f);
		u_occupu_y = Mathf.CeilToInt(Mathf.Abs(vector.y) / num - 0.5f);
		r_occupu_x = Mathf.CeilToInt(Mathf.Abs(vector2.x) / num - 0.5f);
		d_occupu_y = Mathf.CeilToInt(Mathf.Abs(vector2.y) / num - 0.5f);
	}

	public bool GetWeaponAround(SceneHomeGunGriditemData sceneHomeGunGriditemData, ref long weaponID)
	{
		if (weaponInfo[sceneHomeGunGriditemData.weaponid].IsRentOut)
		{
			return false;
		}
		if (weaponID != sceneHomeGunGriditemData.weaponid)
		{
			if (weaponID > 0)
			{
				return false;
			}
			weaponID = sceneHomeGunGriditemData.weaponid;
		}
		return true;
	}

	public SceneHomeGunGriditemData GetAround(int l_occupu_x, int r_occupu_x, int id, int idtemp, SceneHomeGunGridData sceneHomeGunGridData, ref long weaponID)
	{
		SceneHomeGunGriditemData sceneHomeGunGriditemData = null;
		if (id >= 0)
		{
			sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
			if (sceneHomeGunGriditemData.isOccupy && !GetWeaponAround(sceneHomeGunGriditemData, ref weaponID))
			{
				return null;
			}
			for (int i = 0; i < l_occupu_x; i++)
			{
				id = sceneHomeGunGriditemData.lid;
				if (id >= 0)
				{
					sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
					if (sceneHomeGunGriditemData.isOccupy && !GetWeaponAround(sceneHomeGunGriditemData, ref weaponID))
					{
						return null;
					}
					continue;
				}
				return null;
			}
			id = idtemp;
			sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
			if (sceneHomeGunGriditemData.isOccupy && !GetWeaponAround(sceneHomeGunGriditemData, ref weaponID))
			{
				return null;
			}
			for (int j = 0; j < r_occupu_x; j++)
			{
				id = sceneHomeGunGriditemData.rid;
				if (id >= 0)
				{
					sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
					if (sceneHomeGunGriditemData.isOccupy && !GetWeaponAround(sceneHomeGunGriditemData, ref weaponID))
					{
						return null;
					}
					continue;
				}
				return null;
			}
			id = idtemp;
			sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
			if (sceneHomeGunGriditemData.isOccupy && !GetWeaponAround(sceneHomeGunGriditemData, ref weaponID))
			{
				return null;
			}
			return sceneHomeGunGriditemData;
		}
		return null;
	}

	public SceneHomeGunGriditemData SetWeapon(int l_occupu_x, int r_occupu_x, int id, int idtemp, SceneHomeGunGridData sceneHomeGunGridData, long weaponid)
	{
		SceneHomeGunGriditemData sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
		SetOccupy(sceneHomeGunGriditemData, weaponid);
		for (int i = 0; i < l_occupu_x; i++)
		{
			id = sceneHomeGunGriditemData.lid;
			sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
			SetOccupy(sceneHomeGunGriditemData, weaponid);
		}
		id = idtemp;
		sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
		SetOccupy(sceneHomeGunGriditemData, weaponid);
		for (int j = 0; j < r_occupu_x; j++)
		{
			id = sceneHomeGunGriditemData.rid;
			sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
			SetOccupy(sceneHomeGunGriditemData, weaponid);
		}
		id = idtemp;
		sceneHomeGunGriditemData = sceneHomeGunGridData.gridDic[id];
		SetOccupy(sceneHomeGunGriditemData, weaponid);
		return sceneHomeGunGriditemData;
	}

	public void SetOccupy(SceneHomeGunGriditemData sceneHomeGunGriditemData, long weaponid)
	{
		sceneHomeGunGriditemData.isOccupy = true;
		sceneHomeGunGriditemData.weaponid = weaponid;
		SetColor(sceneHomeGunGriditemData.go, Color.cyan);
		if (!weapon_grid.ContainsKey(weaponid))
		{
			weapon_grid.Add(weaponid, new List<SceneHomeGunGriditemData>());
		}
		weapon_grid[weaponid].Add(sceneHomeGunGriditemData);
	}

	private void SceneHomeGunGrid(SceneObjectEntity entity)
	{
		string sceneHomeGunGridConfigData = entity.sceneMap.AssetLoader.GetSceneHomeGunGridConfigData();
		if (sceneHomeGunGridConfigData == null)
		{
			return;
		}
		SceneObjectEntity sceneObjectEntity = _sceneWeaponContext.CreateEntity();
		loadRequests = new LoadRequests(12);
		for (int i = 0; i < 4; i++)
		{
			loadRequests.AddAsset("Xian_G" + i, new AssetInfo("effect/homemodel", "Assets/Res/Assets/effect/homeModel/effect/Xian_G/Prefab/Xian_G.prefab", typeof(GameObject), optional: true));
			loadRequests.AddAsset("Xian_R" + i, new AssetInfo("effect/homemodel", "Assets/Res/Assets/effect/homeModel/effect/Xian_R/Prefab/Xian_R.prefab", typeof(GameObject), optional: true));
			loadRequests.AddAsset("Xian_Y" + i, new AssetInfo("effect/homemodel", "Assets/Res/Assets/effect/homeModel/effect/Xian_Y/Prefab/Xian_Y.prefab", typeof(GameObject), optional: true));
		}
		sceneObjectEntity.AddLoadUnityObjects(loadRequests, this);
		sceneObjectEntity.AddHomeWeapon(-9, 0L);
		GameObject newRoot = new GameObject("SceenHomeGunGrid");
		entity.AddMapHomeGunGrid(newRoot);
		_sceneHomeGunGridDatas = SceneHomeGunGridConfig.ReadConfig(sceneHomeGunGridConfigData);
		SceneObjectEntity sceneObjectEntity2 = _sceneWeaponContext.CreateEntity();
		loadRequests = new LoadRequests(1);
		foreach (int key in _sceneHomeGunGridDatas.Keys)
		{
			GameObject gameObject = new GameObject(key.ToString());
			gameObject.transform.position = VectorCoordConverter.SsjjToUnity(_sceneHomeGunGridDatas[key].pos) * 100f;
			gameObject.transform.rotation = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(_sceneHomeGunGridDatas[key].rot));
			gameObject.transform.localScale = VectorCoordConverter.SsjjScaleToUnity(_sceneHomeGunGridDatas[key].sle) * 100f;
			loadRequests.AddAsset("jz_" + key, new AssetInfo("effect/homemodel", "Assets/Res/Assets/effect/homeModel/effect/KUANG/Prefab/KUANG.prefab", typeof(GameObject), optional: true));
			Vector3 vector = new Vector3(2.1474836E+09f, 2.1474836E+09f, 2.1474836E+09f);
			Vector3 vector2 = new Vector3(-2.1474836E+09f, -2.1474836E+09f, -2.1474836E+09f);
			foreach (SceneHomeGunGriditemData value in _sceneHomeGunGridDatas[key].gridDic.Values)
			{
				GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
				gameObject2.GetComponent<Renderer>().enabled = false;
				gameObject2.name = value.gridid.ToString();
				gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
				gameObject2.transform.localPosition = VectorCoordConverter.SsjjToUnity(value.localPos);
				if (_sceneHomeGunGridDatas[key].type == 1)
				{
					gameObject2.transform.localScale = new Vector3(0.99f, 10f, 0.99f) * _sceneHomeGunGridDatas[key].size;
				}
				else
				{
					gameObject2.transform.localScale = new Vector3(0.99f, 0.99f, 0.99f) * _sceneHomeGunGridDatas[key].size;
				}
				gameObject2.AddComponent<HomeGunGridItem>().Init(key, value.gridid, key, _sceneHomeGunGridDatas[key].type);
				value.go = gameObject2;
				value.isOccupy = false;
				vector = Vector3.Min(vector, value.localPos);
				vector2 = Vector3.Max(vector2, value.localPos);
			}
			list_g.Add(key, gameObject);
			list_s.Add(key, vector2 - vector + Vector3.one * _sceneHomeGunGridDatas[key].size);
		}
		sceneObjectEntity2.AddLoadUnityObjects(loadRequests, this);
		sceneObjectEntity2.AddHomeWeapon(-10, 0L);
	}

	public void SetWeaponColor(WeaponGameObject go, Color color)
	{
		if (_materialPropertyBlock == null)
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
		}
		if (!(go != null))
		{
			return;
		}
		foreach (Renderer skinRenderer in go.GetSkinRenderers())
		{
			_materialPropertyBlock.SetColor("_WeaponColor", color);
			skinRenderer.SetPropertyBlock(_materialPropertyBlock);
		}
	}

	public void SetColor(GameObject go, Color color)
	{
	}
}
