using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Sources.Utils;

public class ReferenceResPickerHelper : MonoBehaviourSingleton<ReferenceResPickerHelper>
{
	private readonly List<UnityEngine.Object> _references = new List<UnityEngine.Object>();

	private readonly List<TextureUnit> _textureUnits = new List<TextureUnit>();

	private readonly List<SceneUnit> _sceneUnits = new List<SceneUnit>();

	private string _logDirectory = "ReferenceRef/";

	public void Init()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			Collect();
		}
	}

	private void Collect()
	{
		UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(Texture));
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i] == null) && !array[i].Equals(null) && (array[i].hideFlags == HideFlags.None || array[i].hideFlags == HideFlags.NotEditable || array[i].hideFlags == HideFlags.HideInHierarchy || array[i].hideFlags == HideFlags.HideInInspector))
			{
				Texture texture = (Texture)array[i];
				if (texture.width > 128 || texture.height > 128)
				{
					_references.Add(array[i]);
				}
			}
		}
		SortRef();
		for (int j = 0; j < _references.Count; j++)
		{
			Texture texture2 = (Texture)_references[j];
			TextureUnit textureUnit = new TextureUnit();
			textureUnit.Height = texture2.height;
			textureUnit.Width = texture2.width;
			textureUnit.TextureName = texture2.name;
			_textureUnits.Add(textureUnit);
		}
		List<Scene> list = new List<Scene>();
		for (int k = 0; k < SceneManager.sceneCount; k++)
		{
			Scene sceneAt = SceneManager.GetSceneAt(k);
			list.Add(sceneAt);
		}
		Scene scene = base.gameObject.scene;
		list.Add(scene);
		for (int l = 0; l < list.Count; l++)
		{
			Scene scene2 = list[l];
			SceneUnit sceneUnit = new SceneUnit();
			sceneUnit.SceneName = scene2.name;
			ParseScene(sceneUnit, scene2);
			_sceneUnits.Add(sceneUnit);
		}
		Save();
		_references.Clear();
		_textureUnits.Clear();
		_sceneUnits.Clear();
	}

	private void ParseScene(SceneUnit unit, Scene scene)
	{
		GameObject[] rootGameObjects = scene.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			GameObjectUnit gameObjectUnit = new GameObjectUnit();
			gameObjectUnit.UnitName = rootGameObjects[i].name;
			gameObjectUnit.ParentInstanceId = "";
			gameObjectUnit.InstanceId = rootGameObjects[i].GetInstanceID() + rootGameObjects[i].name;
			unit.Units.Add(gameObjectUnit);
			ParseGameObject(unit.Units, rootGameObjects[i]);
		}
	}

	private void ParseGameObject(List<GameObjectUnit> units, GameObject objGameObject)
	{
		for (int i = 0; i < objGameObject.transform.childCount; i++)
		{
			GameObjectUnit gameObjectUnit = new GameObjectUnit();
			gameObjectUnit.UnitName = objGameObject.transform.GetChild(i).name;
			gameObjectUnit.InstanceId = objGameObject.transform.GetChild(i).gameObject.GetInstanceID() + gameObjectUnit.UnitName;
			gameObjectUnit.ParentInstanceId = objGameObject.GetInstanceID() + objGameObject.name;
			units.Add(gameObjectUnit);
			ParseGameObject(units, objGameObject.transform.GetChild(i).gameObject);
		}
	}

	private void SortRef()
	{
		_references.Sort((UnityEngine.Object y, UnityEngine.Object x) => ((Texture)x).width * ((Texture)x).height - ((Texture)y).width * ((Texture)y).height);
	}

	private void Save()
	{
		string text = "";
		foreach (TextureUnit textureUnit in _textureUnits)
		{
			_ = textureUnit;
		}
		foreach (SceneUnit sceneUnit in _sceneUnits)
		{
			text = text + sceneUnit.ToSave() + ":";
		}
		if (!Directory.Exists(_logDirectory))
		{
			Directory.CreateDirectory(_logDirectory);
		}
		string text2 = DateTime.Now.ToString("_yyyy_MM_dd HH_mm_ss");
		if (!Directory.Exists(_logDirectory + text2))
		{
			Directory.CreateDirectory(_logDirectory + text2);
		}
		string path = _logDirectory + text2 + "/scene.txt";
		string filename = _logDirectory + text2 + "/texture.xml";
		File.WriteAllText(path, text);
		XmlDocument xmlDocument = new XmlDocument();
		XmlElement xmlElement = xmlDocument.CreateElement("Texture");
		xmlDocument.AppendChild(xmlElement);
		foreach (TextureUnit textureUnit2 in _textureUnits)
		{
			XmlElement xmlElement2 = xmlDocument.CreateElement("TextureDetail");
			xmlElement2.SetAttribute("Name", textureUnit2.TextureName ?? "");
			xmlElement2.SetAttribute("Width", string.Concat(textureUnit2.Width));
			xmlElement2.SetAttribute("Height", string.Concat(textureUnit2.Height));
			int num = textureUnit2.Width * textureUnit2.Height * 32 / 8 / 1024;
			xmlElement2.SetAttribute("Size", num + "kb");
			xmlElement.AppendChild(xmlElement2);
		}
		xmlDocument.Save(filename);
	}
}
