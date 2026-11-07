using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class GhostShadow : MonoBehaviour
{
	private readonly float _duration = 0.5f;

	public float Interval = 0.2f;

	[Range(-1f, 2f)]
	public float Intension = 0.1f;

	public Color RimColor = Color.blue;

	private Shader _ghostShader;

	private float _lastTime;

	private Vector3 _lastPos = Vector3.zero;

	private void Start()
	{
		_ghostShader = Shader.Find("SSJJ/XRay");
	}

	public void Render(SkinnedMeshRenderer meshRender, PlayerEntity entity)
	{
		if (meshRender == null || (Mathf.Approximately(_lastPos.x, base.transform.position.x) && Mathf.Approximately(_lastPos.y, base.transform.position.y) && Mathf.Approximately(_lastPos.z, base.transform.position.z)))
		{
			return;
		}
		_lastPos = base.transform.position;
		if (Time.time - _lastTime < Interval)
		{
			return;
		}
		_lastTime = Time.time;
		GhostShadowFactory.GhostShadowAssembly orCreate = GhostShadowFactory.Instance.GetOrCreate(entity, meshRender, _ghostShader);
		if (orCreate != null && (!entity.hasVisiable || entity.visiable.IsVisiable || entity.visiable.IsNear))
		{
			meshRender.BakeMesh(orCreate.Mesh);
			orCreate.Item.InitData(_duration, Time.time + _duration, RimColor, orCreate);
			for (int i = 0; i < orCreate.Materials.Length; i++)
			{
				orCreate.Block.SetFloat("_RimIntensity", Intension);
				orCreate.Block.SetColor("_RimColor", RimColor);
				orCreate.MeshRenderer.SetPropertyBlock(orCreate.Block);
			}
			orCreate.Obj.transform.localScale = meshRender.transform.localScale;
			orCreate.Obj.transform.position = meshRender.transform.position;
			orCreate.Obj.transform.rotation = meshRender.transform.rotation;
		}
	}
}
