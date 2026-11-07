using Assets.Scripts.Input;
using Assets.Sources.Free.Data;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Systems.UserCommand;

public class LocalKeyDownSystem : IExecuteSystem, ISystem
{
	public LocalKeyDownSystem(Contexts contexts)
	{
	}

	public void Execute()
	{
		checkCameraOwner();
		HandleLocalKeyDown();
	}

	private void checkCameraOwner()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			bool isCameraOwner = myPlayerEntity.isCameraOwner;
			if (isCameraOwner != myPlayerEntity.isMyPlayerLastCameraOwner)
			{
				Contexts.sharedInstance.battleRoom.gameStateEntity.isSeeAllPlayer = false;
			}
			myPlayerEntity.isMyPlayerLastCameraOwner = isCameraOwner;
		}
	}

	private void HandleLocalKeyDown()
	{
		if (GameModelLocator.GetInstance().GameModel.IsObserver)
		{
			PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			if (myPlayerEntity != null && (GetKeysDown(KeyCode.Z) || GetKeysDown(KeyCode.X) || GetKeysDown(KeyCode.C)) && !myPlayerEntity.isCameraOwner)
			{
				Contexts.sharedInstance.battleRoom.gameStateEntity.isSeeAllPlayer = !Contexts.sharedInstance.battleRoom.gameStateEntity.isSeeAllPlayer;
			}
		}
	}

	private bool GetKeysDown(KeyCode key)
	{
		return InputCollector.Instance.GetKeyDown(key);
	}
}
