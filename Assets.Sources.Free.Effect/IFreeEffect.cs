using Assets.Sources.Free.Render;

namespace Assets.Sources.Free.Effect;

public interface IFreeEffect
{
	EffectFixInfo EffectFixInfo { get; }

	int Type { get; }

	IEffectModel3D EffectModel3D { get; }

	IObject3D OriObject3D { get; }

	void SetPos(float x, float y, float z, float scaleX, float scaleY, float scaleZ, float rotationX, float rotationY, float rotationZ);

	void SetValue(int vsInt, string vsStr);

	void Initial(params object[] ini);

	void Frame(int frameTime, ISceneManage scene, FreeRenderObject freeRender);

	IFreeEffect Clone();

	void Destroy();
}
