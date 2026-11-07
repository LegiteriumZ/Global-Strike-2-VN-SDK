using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Effect;

public class VolumeConfigCreateSystem : IEntityCreateSystem
{
	private bool _init;

	private readonly PlayerContext _playerContext;

	public VolumeConfigCreateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnEntityCreate()
	{
		if (_init)
		{
			return;
		}
		using IContext<PlayerEntity>.Enumator enumator = _playerContext.GetEnumerator();
		if (enumator.MoveNext())
		{
			PlayerEntity current = enumator.Current;
			if (!current.isPlayerVolume)
			{
				_init = true;
				current.isPlayerVolume = true;
			}
		}
	}
}
