using System.Collections.Generic;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Entitas;

namespace Assets.Sources.Modules.Player.Accessory;

public class ViewAccessoryPlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _loadGroup;

	private List<string> _accessoryList = new List<string>(4);

	public ViewAccessoryPlaybackSystem(Contexts contexts)
	{
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ViewAccessory, PlayerMatcher.FirstPersonView).NoneOf(PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadViewAccessoryResource, PlayerMatcher.ViewAccessoryResource));
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _loadGroup)
		{
			_accessoryList.Clear();
			foreach (string accessory in item.basicInfo.Current.AccessoryList)
			{
				if (AccessoryConfigLoader.Instance.hasAccessoryIsView(accessory))
				{
					_accessoryList.Add(accessory);
				}
			}
			for (int num = item.viewAccessory.Renders.Count - 1; num >= 0; num--)
			{
				if (!_accessoryList.Contains(item.viewAccessory.Renders[num].getName()))
				{
					PlayerEntityUtility.CollectReusable(item.viewAccessory.Renders[num].getGameObject());
					item.viewAccessory.Renders.RemoveAt(num);
				}
			}
			if (item.viewAccessory.Renders.Count == 0)
			{
				item.RemoveViewAccessory();
			}
		}
	}
}
