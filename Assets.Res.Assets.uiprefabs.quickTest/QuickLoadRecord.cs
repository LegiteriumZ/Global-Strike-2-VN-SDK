using System.IO;
using Assets.Sources.Ui.ForUiTest;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Res.Assets.uiprefabs.quickTest;

public class QuickLoadRecord : MonoBehaviour
{
	public GameObject ButtonTemplate;

	private void Awake()
	{
		Transform parent = base.transform.Find("Show");
		if (Directory.Exists(Application.dataPath + "/../Records/"))
		{
			string[] files = Directory.GetFiles(Application.dataPath + "/../Records/", "Record_*.txt");
			foreach (string path in files)
			{
				GameObject btn2 = Object.Instantiate(ButtonTemplate);
				btn2.transform.SetParent(parent);
				btn2.SetActive(value: true);
				btn2.name = Path.GetFileNameWithoutExtension(path).Substring(7);
				btn2.transform.Find("Text").GetComponent<Text>().text = btn2.name;
				btn2.GetComponent<Button>().onClick.AddListener(delegate
				{
					OnLoadRecord(btn2.name);
				});
			}
		}
		if (Directory.Exists(Application.dataPath + "/../ServerRecords/"))
		{
			string[] files = Directory.GetDirectories(Application.dataPath + "/../ServerRecords/");
			foreach (string path2 in files)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path2);
				string[] files2 = Directory.GetFiles(path2, "*.snp");
				foreach (string path3 in files2)
				{
					GameObject btn = Object.Instantiate(ButtonTemplate);
					btn.transform.SetParent(parent);
					btn.SetActive(value: true);
					string text = Path.GetFileNameWithoutExtension(path3).Split('-')[2];
					btn.name = fileNameWithoutExtension + "/" + Path.GetFileNameWithoutExtension(path3);
					btn.transform.Find("Text").GetComponent<Text>().text = fileNameWithoutExtension + "|" + text;
					btn.GetComponent<Button>().onClick.AddListener(delegate
					{
						OnLoadRecord2(btn.name);
					});
				}
			}
		}
		base.transform.Find("FinishQuit").GetComponent<Toggle>().isOn = true;
	}

	public void OnLoadRecord2(string recordName)
	{
		base.gameObject.SetActive(value: false);
		string[] array = recordName.Split('/');
		string arg = array[0];
		string arg2 = array[1];
		NetRecordManager.Read(ServerRecordParser.parse($"ServerRecords/{arg}/{arg2}.snp"));
		NetRecordManager.UpdateObserverPlayerId(ServerRecordParser.snapSelf);
		NetRecordManager.Start(GetToggleValue("AutoInput", deft: true), GetToggleValue("FinishQuit", deft: true), GetToggleValue("TimeSync", deft: true));
	}

	public void OnLoadRecord(string recordName)
	{
		base.gameObject.SetActive(value: false);
		NetRecordManager.Read(recordName);
		NetRecordManager.Start(GetToggleValue("AutoInput", deft: true), GetToggleValue("FinishQuit", deft: true), GetToggleValue("TimeSync", deft: true));
	}

	private bool GetToggleValue(string objName, bool deft)
	{
		Transform transform = base.transform.Find(objName);
		if (transform != null)
		{
			Toggle component = transform.GetComponent<Toggle>();
			if (component != null)
			{
				return component.isOn;
			}
		}
		return deft;
	}
}
