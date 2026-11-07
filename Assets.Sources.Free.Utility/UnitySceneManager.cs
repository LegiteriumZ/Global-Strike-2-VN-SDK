using Assets.Sources.Free.Render;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.Utility;

public class UnitySceneManager : MonoBehaviourSingleton<UnitySceneManager>, ISceneManage
{
	public int frameTime => (int)(Time.deltaTime * 1000f);
}
