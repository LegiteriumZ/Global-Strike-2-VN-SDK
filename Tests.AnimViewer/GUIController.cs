using System.Collections.Generic;
using Tests.AnimViewer.AnimObject;
using UnityEngine;

namespace Tests.AnimViewer;

public class GUIController
{
	private static GUIController _instance;

	private GameObject _canvasParent;

	private GameObject _dropDownPrefab;

	private Dictionary<int, GUIObject> _GUIObjects;

	private OverviewUIObject _overviewObj;

	private int posY;

	public static GUIController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GUIController();
			}
			return _instance;
		}
	}

	private GUIController()
	{
		_canvasParent = GameObject.Find("Canvas");
		_dropDownPrefab = GameObject.Find("DropDownPrefab");
		_overviewObj = new OverviewUIObject(GameObject.Find("Overview"));
		_GUIObjects = new Dictionary<int, GUIObject>();
		AnimController.GetMethods(GenerateGUIObject);
	}

	public void GenerateGUIObject(IMethodsExecuter methods)
	{
		GameObject gameObject = Object.Instantiate(_dropDownPrefab, _canvasParent.transform);
		gameObject.name = methods.index.ToString();
		GUIObject gUIObject = new GUIObject();
		gUIObject.InitTitle(gameObject, methods.GetName(), posY += 70);
		gUIObject.InitDropDown(methods.stateNames);
		gUIObject.InitButton(methods.PauseAnim, methods.ResumeAnim, methods.RestartAnim, methods.StopAnim);
		_GUIObjects.Add(methods.index, gUIObject);
		_overviewObj.InitButton(methods.PauseAnim, methods.ResumeAnim, methods.RestartAnim, methods.StopAnim);
		_overviewObj.InitSlider();
	}

	public string GetStateName(int index)
	{
		return _GUIObjects[index].GetStateName();
	}

	public float GetPlaySpeed()
	{
		return _overviewObj.GetSpeed();
	}
}
