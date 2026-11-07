using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Free.UI;

public class TipsMessageHandler : ISimpleMesssageHandler
{
	private const string TYPE_DESC = "desc";

	private const string TYPE_TIP = "tip";

	public bool CanHandle(int key)
	{
		return key == 53;
	}

	public void Handle(SimpleProto simpleUI)
	{
		string free = simpleUI.Ss[0];
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		for (int i = 1; i < simpleUI.Ss.Count - 1; i += 3)
		{
			string text = simpleUI.Ss[i];
			string text2 = simpleUI.Ss[i + 1];
			string text3 = simpleUI.Ss[i + 2];
			if (text2 == "desc")
			{
				ModeTips.SetDesc(text, free, text3);
				continue;
			}
			if (!dictionary.ContainsKey(text))
			{
				dictionary.Add(text, new List<string>());
			}
			dictionary[text].Add(text3);
		}
		foreach (KeyValuePair<string, List<string>> item in dictionary)
		{
			string key = item.Key;
			ModeTips.AddTip(key, free, dictionary[key]);
		}
	}
}
