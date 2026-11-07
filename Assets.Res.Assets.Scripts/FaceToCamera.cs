using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class FaceToCamera : MonoBehaviour
{
	private Renderer _render;

	private Vector3 _scalOriginal;

	public bool KeepSize;

	private float _inParaScale = 1f;

	public bool ZReverse;

	public bool KeepFov;

	public bool lightWithShadowTeShu;

	private float _originFov;

	public float KeepSizeScale = 1f;

	private void Awake()
	{
		_render = base.gameObject.GetComponent<Renderer>();
		_scalOriginal = base.transform.localScale;
	}

	private void LateUpdate()
	{
		if (Camera.main != null)
		{
			if (ZReverse)
			{
				base.transform.LookAt(Camera.main.transform);
			}
			else if (lightWithShadowTeShu)
			{
				float y = ((!Contexts.sharedInstance.player.cameraOwnerEntity.isFirstPersonView) ? (Camera.main.transform.eulerAngles.y + 180f) : (Camera.main.transform.eulerAngles.y + 90f));
				Vector3 eulerAngles = base.transform.eulerAngles;
				eulerAngles.y = y;
				base.transform.eulerAngles = eulerAngles;
			}
			else
			{
				base.transform.forward = (base.transform.position - Camera.main.transform.position).normalized;
			}
			if (KeepFov && _originFov <= 0.1f)
			{
				_originFov = Camera.main.fieldOfView;
			}
			UpdateKeepSize(KeepSize, _render, _scalOriginal, base.transform, KeepSizeScale, _inParaScale, KeepFov, _originFov);
		}
	}

	public void SetInParaScale(float scale)
	{
		_inParaScale = scale;
	}

	public static bool UpdateKeepSize(bool KeepSize, Renderer _render, Vector3 _scalOriginal, Transform transform, float setSizeScale = 1f, float inParaScale = 1f, bool keepFov = false, float originFov = 0f)
	{
		if (KeepSize && _render != null)
		{
			float num = 0f;
			if (_render is SpriteRenderer)
			{
				Sprite sprite = ((SpriteRenderer)_render).sprite;
				num = sprite.rect.height / sprite.pixelsPerUnit;
			}
			else if (_render is MeshRenderer)
			{
				num = ((MeshRenderer)_render).bounds.size.y;
			}
			if (num == 0f)
			{
				return false;
			}
			SetKeepSize(num, GetScreenScale(), _scalOriginal, transform, setSizeScale, inParaScale, keepFov, originFov);
			return true;
		}
		return false;
	}

	public static bool UpdateKeepSize(bool KeepSize, RectTransform transform, Vector3 _scalOriginal, float setSizeScale = 1f, float inParaScale = 1f, bool keepFov = false, float originFov = 0f)
	{
		float y = transform.sizeDelta.y;
		if (y == 0f)
		{
			return false;
		}
		SetKeepSize(y, GetScreenScale(), _scalOriginal, transform, setSizeScale, inParaScale, keepFov, originFov);
		return true;
	}

	public static float GetScreenScale()
	{
		float result = 1f;
		Vector2 vector = new Vector2(Display.main.systemWidth, Display.main.systemHeight);
		if (vector.y < 768f)
		{
			result = vector.y / 768f;
		}
		else if (!(vector.y < 1450f))
		{
			if (vector.y < 1800f)
			{
				result = vector.y / 1680f;
			}
			else
			{
				bool flag = false;
				for (int num = 5; num >= 2; num--)
				{
					if ((int)vector.y % num == 0 && vector.y / (float)num >= 900f)
					{
						flag = true;
						result = num;
						break;
					}
				}
				if (!flag)
				{
					result = vector.y / 1680f;
				}
			}
		}
		return result;
	}

	public static void SetKeepSize(float oriHeight, float screenScale, Vector3 _scalOriginal, Transform transform, float setSizeScale, float inParaScale, bool keepFov, float originFov)
	{
		float num = oriHeight * _scalOriginal.y;
		float num2 = 1f;
		Transform parent = transform.parent;
		while (parent != null)
		{
			num2 *= parent.transform.localScale.y;
			parent = parent.transform.parent;
		}
		num *= num2;
		float num3 = num / (float)Screen.height;
		float num4 = Vector3.Distance(transform.position, Camera.main.transform.position);
		float num5 = 0f;
		num5 = ((!keepFov) ? (2f * num4 * Mathf.Tan(Camera.main.fieldOfView / 2f * ((float)Math.PI / 180f))) : (2f * num4 * Mathf.Tan(originFov / 2f * ((float)Math.PI / 180f))));
		float num6 = oriHeight / num5;
		float num7 = num3 / num6;
		if (Mathf.Abs(num2) > 1E-05f)
		{
			transform.localScale = Vector3.one * num7 / num2 * screenScale * setSizeScale;
		}
	}
}
