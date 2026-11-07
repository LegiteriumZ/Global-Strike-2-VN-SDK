using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Sources.Components.Time;
using Tests.AnimViewer.AnimObject;
using Tests.AnimViewer.AnimSource;
using UnityEngine;

namespace Tests.AnimViewer;

public class AnimController : MonoBehaviour
{
	public GameObject prefab;

	public GameObject[] prefabList;

	public TextAsset[] sourceList0;

	public TextAsset[] sourceList1;

	public AnimSourceType[] sourceTypeArray0;

	public AnimSourceType[] sourceTypeArray1;

	public TextAsset torsoAnimSource;

	public TextAsset legAnimSource;

	private TimeComponent _timeComponent;

	private Dictionary<AnimSourceType, Type> _typeDic;

	private AnimatedObject _object0;

	private AnimatedObject _object1;

	private static List<IMethodsExecuter> executers;

	private static AnimController _instance;

	public static AnimController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AnimController();
			}
			return _instance;
		}
	}

	public void ParseType()
	{
		Type[] array = (from t in Assembly.GetExecutingAssembly().GetTypes()
			where t.Namespace == "Tests.AnimViewer.AnimSource"
			select t).ToArray();
		if (array.Length == 0)
		{
			return;
		}
		Type[] array2 = array;
		foreach (Type type in array2)
		{
			object[] customAttributes = type.GetCustomAttributes(inherit: true);
			foreach (object obj in customAttributes)
			{
				if (obj is AnimSourceAttribute)
				{
					_typeDic.Add((obj as AnimSourceAttribute).type, type);
				}
			}
		}
	}

	public void InstantiateGameObject()
	{
		if (prefabList != null && prefabList.Length == 2)
		{
			if (prefabList[0] != null)
			{
				_object0 = new AnimatedObject(UnityEngine.Object.Instantiate(prefabList[0]));
			}
			if (prefabList[1] != null)
			{
				_object1 = new AnimatedObject(UnityEngine.Object.Instantiate(prefabList[1]));
			}
		}
	}

	public void ParseAnimation()
	{
		ParseAnimationHelper(sourceList0, sourceTypeArray0, _object0);
		ParseAnimationHelper(sourceList1, sourceTypeArray0, _object1);
	}

	private void ParseAnimationHelper(TextAsset[] sourceList, AnimSourceType[] sourceTypeList, AnimatedObject obj)
	{
		if (sourceList == null || obj == null)
		{
			return;
		}
		for (int i = 0; i < sourceList.Length; i++)
		{
			if (!(sourceList[i] == null) && sourceTypeList[i] != 0)
			{
				IAnimSource animSource = Activator.CreateInstance(_typeDic[sourceTypeList[i]]) as IAnimSource;
				animSource.Parse(sourceList[i]);
				IMethodsExecuter methodsExecuter = obj.AddSource(animSource);
				if (methodsExecuter != null)
				{
					executers.Add(methodsExecuter);
				}
			}
		}
	}

	public void InitializeController()
	{
		prefabList = new GameObject[2];
		sourceList0 = new TextAsset[1];
		sourceList1 = new TextAsset[1];
		sourceTypeArray0 = new AnimSourceType[1];
		sourceTypeArray1 = new AnimSourceType[1];
	}

	public void AddNewSource(int index)
	{
		switch (index)
		{
		case 0:
			AddNewSourceHelper(ref sourceList0, ref sourceTypeArray0);
			break;
		case 1:
			AddNewSourceHelper(ref sourceList1, ref sourceTypeArray0);
			break;
		}
	}

	private void AddNewSourceHelper(ref TextAsset[] array, ref AnimSourceType[] typeArray)
	{
		TextAsset[] array2 = new TextAsset[array.Length + 1];
		AnimSourceType[] array3 = new AnimSourceType[array.Length + 1];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i];
			array3[i] = typeArray[i];
		}
		array = array2;
		typeArray = array3;
	}

	public void Awake()
	{
		_instance = this;
		TimeEntity timeEntity = Contexts.sharedInstance.time.CreateEntity();
		timeEntity.AddComponent(1, new TimeComponent());
		_timeComponent = timeEntity.time;
		_typeDic = new Dictionary<AnimSourceType, Type>();
		executers = new List<IMethodsExecuter>();
	}

	public void Start()
	{
		ParseType();
		InstantiateGameObject();
		ParseAnimation();
	}

	public void Update()
	{
		if (Application.isPlaying)
		{
			int num = (int)(Time.deltaTime * 1000f);
			_timeComponent.RenderTime += num;
			if (_object0 != null)
			{
				_object0.PlayAnim(Time.deltaTime);
			}
			if (_object1 != null)
			{
				_object1.PlayAnim(Time.deltaTime);
			}
		}
	}

	public static void GetMethods(Action<IMethodsExecuter> callback)
	{
		foreach (IMethodsExecuter executer in executers)
		{
			callback(executer);
		}
	}
}
