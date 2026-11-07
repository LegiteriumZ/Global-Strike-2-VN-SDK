using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.ViewModel.QuickTest;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.Input;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.QuickTest;

[GameUiTest]
public class QuickTestModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ICursorControl, ISetGameRuleContext
{
	private QuickTestViewModel _viewModel;

	private int _startWait = int.MaxValue;

	private List<QuickTestCase> _caseList = new List<QuickTestCase>();

	private int _closeDelay;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay
	{
		get
		{
			return _closeDelay;
		}
		set
		{
			_closeDelay = value;
		}
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new QuickTestViewModel();
	}

	private void FindGameObject(List<GameObject> list, GameObject gameObj, string path, List<string> paths, string[] names, int index)
	{
		for (int i = 0; i < ((gameObj == null) ? 1 : gameObj.transform.childCount); i++)
		{
			Transform transform = ((gameObj == null) ? GameObject.Find(names[index]).transform : gameObj.transform.GetChild(i));
			if (transform.name == names[index] || (names[index].EndsWith("*") && transform.name.StartsWith(names[index].Substring(0, names[index].Length - 1))))
			{
				if (index == names.Length - 1)
				{
					list.Add(transform.gameObject);
					paths.Add(path + "/" + transform.gameObject.name);
				}
				else
				{
					FindGameObject(list, transform.gameObject, path + "/" + transform.gameObject.name, paths, names, index + 1);
				}
			}
		}
	}

	private void FindGameObjectData(List<GameObjectData> list, GameObjectData data, string path, string[] names, int index)
	{
		for (int i = 0; i < data.Children.Count; i++)
		{
			if (data.Children[i].Name == names[index] || (names[index].EndsWith("*") && data.Children[i].Name.StartsWith(names[index].Substring(0, names[index].Length - 1))))
			{
				if (index == names.Length - 1)
				{
					list.Add(data.Children[i]);
				}
				else
				{
					FindGameObjectData(list, data.Children[i], path + "/" + data.Children[i].Name, names, index + 1);
				}
			}
		}
	}

	private void Check(GameObject gameObj, GameObjectData objData, bool checkChildren, string path, int checkNum, ref bool result)
	{
		if (gameObj == null || objData == null || gameObj.transform.childCount != objData.Children.Count || gameObj.name != objData.Name)
		{
			QuickTestCase.Assert(condition: false, "Out of date : " + path);
			return;
		}
		if (!gameObj.activeInHierarchy)
		{
			QuickTestCase.Assert(gameObj.activeInHierarchy == objData.ActiveInHierarchy, "[ActiveInHierarchy] " + path, checkNum, ref result);
			return;
		}
		QuickTestCase.Assert(gameObj.activeSelf == objData.Active, "[Active] " + path, checkNum, ref result);
		Text component = gameObj.GetComponent<Text>();
		if (component != null)
		{
			QuickTestCase.Assert(component.enabled == objData.Enabled, "[Enabled] " + path, checkNum, ref result);
			QuickTestCase.Assert(component.text == objData.Text, "[Text] " + path, checkNum, ref result);
		}
		Image component2 = gameObj.GetComponent<Image>();
		if (component2 != null)
		{
			QuickTestCase.Assert(component2.enabled == objData.Enabled, "[Enabled] " + path, checkNum, ref result);
			QuickTestCase.Assert(((component2.sprite != null) ? component2.sprite.name : "") == objData.Image, string.Format("[Sprite] {0} c:{1} r:{2}", path, (component2.sprite != null) ? component2.sprite.name : "", objData.Image), checkNum, ref result);
		}
		Camera component3 = gameObj.GetComponent<Camera>();
		if (component3 != null)
		{
			QuickTestCase.Assert(Math.Abs(component3.transform.localPosition.x - objData.Position[0]) + Math.Abs(component3.transform.localPosition.y - objData.Position[1]) + Math.Abs(component3.transform.localPosition.z - objData.Position[2]) < 0.1f, "[localPosition] " + path, checkNum, ref result);
			QuickTestCase.Assert(Math.Abs(component3.transform.localRotation.x - objData.Rotation[0]) + Math.Abs(component3.transform.localRotation.y - objData.Rotation[1]) + Math.Abs(component3.transform.localRotation.z - objData.Rotation[2]) < 0.1f, "[localRotation] " + path, checkNum, ref result);
			QuickTestCase.Assert(Math.Abs(component3.transform.localScale.x - objData.Scale[0]) + Math.Abs(component3.transform.localScale.y - objData.Scale[1]) + Math.Abs(component3.transform.localScale.z - objData.Scale[2]) < 0.01f, "[localScale] " + path, checkNum, ref result);
		}
		if (checkChildren)
		{
			for (int i = 0; i < gameObj.transform.childCount; i++)
			{
				Transform child = gameObj.transform.GetChild(i);
				GameObjectData objData2 = objData.Children[i];
				Check(child.gameObject, objData2, checkChildren: true, path + "/" + child.name, checkNum, ref result);
			}
		}
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (NetRecordManager.TestCases.ContainsKey(NetRecordManager.Index))
		{
			string[] array = NetRecordManager.TestCases[NetRecordManager.Index];
			GameObjectData data = NetRecordManager.Answers[NetRecordManager.Index];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].StartsWith("//"))
				{
					continue;
				}
				int num = 0;
				string[] array2 = null;
				string text = array[i];
				if (text.IndexOf("+") > 0)
				{
					array2 = text.Split('+');
					text = array2[0];
					num = int.Parse(array2[1]);
				}
				QuickTestCase.Assert(condition: true, string.Format("------------Auto Test UI {0} ({2}): {1}-----------", NetRecordManager.Index, array[i], num));
				bool checkChildren = text.EndsWith("..");
				text = text.Replace("..", "").Replace(".", "/");
				string[] names = text.Split('/');
				List<string> list = new List<string>();
				List<GameObject> list2 = new List<GameObject>();
				FindGameObject(list2, null, "", list, names, 0);
				List<GameObjectData> list3 = new List<GameObjectData>();
				FindGameObjectData(list3, data, text, names, 0);
				QuickTestCase.Assert(list3.Count == list2.Count, "[gameDatas.Count == gameObjs.Count] ");
				bool result = true;
				for (int j = 0; j < list3.Count; j++)
				{
					for (int k = 0; k < list2.Count; k++)
					{
						GameObjectData gameObjectData = list3[j];
						GameObject gameObject = list2[k];
						if (gameObjectData.Name == gameObject.name)
						{
							Check(gameObject, gameObjectData, checkChildren, list[k].Substring(1), num, ref result);
						}
					}
				}
				if (num > 0 && !result)
				{
					QuickTestCase.Assert(condition: true, $"Failed Check Num {num} !");
					string[] array4;
					if (NetRecordManager.TestCases.ContainsKey(NetRecordManager.Index + 1))
					{
						string[] array3 = NetRecordManager.TestCases[NetRecordManager.Index + 1];
						array4 = new string[array3.Length + 1];
						Array.Copy(array3, array4, array3.Length);
					}
					else
					{
						array4 = new string[1];
					}
					array4[array4.Length - 1] = array2[0] + "+" + (num - 1);
					NetRecordManager.TestCases[NetRecordManager.Index + 1] = array4;
					NetRecordManager.Answers[NetRecordManager.Index + 1] = NetRecordManager.Answers[NetRecordManager.Index];
				}
				QuickTestCase.Assert(condition: true, $"------------ Check Num ({num})-----------");
			}
			QuickTestCase.Assert(condition: true, $"Auto Test UI {NetRecordManager.Index} Finish !");
		}
		if (_caseList.Count == 0)
		{
			return;
		}
		if (_caseList[0].Actions.Count == 0)
		{
			_caseList.RemoveAt(0);
			if (_caseList.Count == 0)
			{
				QuickTestCase.Assert(condition: true, "测试结束");
				NetRecordManager.FinishedQuit = false;
				if (NetRecordManager.FinishedQuit)
				{
					MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
					ExecuteGG.CloseNPGameMon();
					Process.GetCurrentProcess().Kill();
				}
			}
		}
		else
		{
			if (_timeComponent.ClientRealTime - _startWait < _caseList[0].Actions[0].Delay || (_caseList[0].Actions[0].Delay <= 10 && _caseList[0].Actions[0].Delay-- > 0))
			{
				return;
			}
			try
			{
				if (_caseList[0].Actions[0].Condition == null || _caseList[0].Actions[0].Condition())
				{
					_caseList[0].Actions[0].Action();
					_startWait = _timeComponent.ClientRealTime;
					_caseList[0].Actions.RemoveAt(0);
				}
			}
			catch (Exception ex)
			{
				QuickTestCase.Assert(condition: false, ex.ToString());
				_startWait = _timeComponent.ClientRealTime;
				_caseList[0].Actions.RemoveAt(0);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.SaveButtonClicked.AddListener(OnSaveButtonClicked);
		_viewModel.TestButtonClicked.AddListener(OnTestButtonClicked);
		_viewModel.HandButtonClicked.AddListener(OnHandButtonClicked);
		if (NetRecordManager.AutoTest)
		{
			OnTestButtonClicked();
		}
	}

	private void OnHandButtonClicked()
	{
		_gameRuleContext.selectZombie.Data = new SelectZombieData
		{
			Career1 = "petrified",
			Career2 = "phantom",
			CurrentId = 1
		};
		_gameRuleContext.selectZombie.Time = 5000;
	}

	private void OnTestButtonClicked()
	{
		_startWait = Contexts.sharedInstance.time.time.ClientRealTime + 1000;
		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
		Type typeFromHandle = typeof(QuickTestCase);
		List<QuickTestCase> list = new List<QuickTestCase>();
		Type[] array = types;
		foreach (Type type in array)
		{
			if (type.IsClass && type.IsSubclassOf(typeFromHandle))
			{
				try
				{
					list.Add(Activator.CreateInstance(type, Contexts.sharedInstance) as QuickTestCase);
				}
				catch (Exception message)
				{
					UnityEngine.Debug.LogError(message);
				}
			}
		}
		foreach (QuickTestCase item in list)
		{
			if ((QuickTestCase.TestList.Count == 0 || QuickTestCase.TestList.Contains(item)) && !QuickTestCase.IgnoreList.Contains(item))
			{
				_caseList.Add(item);
			}
		}
	}

	private void OnSaveButtonClicked()
	{
		NetRecordManager.Save();
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.F9)
		{
			_viewModel.ShowShow = !_viewModel.ShowShow;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 1024;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
