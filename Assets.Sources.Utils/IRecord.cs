using System.Collections.Generic;
using SSJJNetworking.Network;

namespace Assets.Sources.Utils;

public interface IRecord : INetworkRecord
{
	void UpdateKeyDowns(ref Dictionary<int, bool> keyDowns);

	void GetKeyDown(Dictionary<int, bool> keyDowns, ref bool down, int key);

	void RecordKeyDowns(Dictionary<int, bool> keyDowns);

	void RecordMouseLock();

	void UpdateMouseLock();

	object FixSnapshot(object baseSnapshot, object snapshot, object comp);

	bool UpdateInput(ref float axisX, ref float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, ref bool leftMouse, ref bool rightMouse, ref bool middleMouse, ref float scrollWheel, ref float deltaTime, ref float diff);

	void RecordInput(float axisX, float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, bool leftMouse, bool rightMouse, bool middleMouse, float scrollWheel, float deltaTime, float diff);

	bool UpdateGame();

	bool IsPlaying();

	bool IsSelfMove();

	bool IsServerRecord();
}
