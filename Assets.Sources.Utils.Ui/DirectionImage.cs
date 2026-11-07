using System.Collections.Generic;
using Assets.Sources.Free.UI;
using Assets.Sources.Free.Utility;
using Res.Assets.Scripts.ExImage;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Utils.Ui;

public class DirectionImage : ProtectImage
{
	private Vector2 _uvLeftTop;

	private Vector2 _uvRightTop;

	private Vector2 _uvLeftBottom;

	private Vector2 _uvRightBottom;

	private float _width;

	private float _height;

	private float _opacityUvWidthPercent;

	private float _opacityUvHeightPercent;

	private bool _haveSetOpacityUvPercent;

	private Vector4 _uv = new Vector4(0f, 0f, 1f, 1f);

	private bool _isUvSelfContorl;

	public Dictionary<string, Sprite> SpriteDirs = new Dictionary<string, Sprite>();

	private float _originWidth;

	private float _originHeight;

	public void SetOpacityUvOnce(float width, float height)
	{
		if (!_haveSetOpacityUvPercent)
		{
			width = Mathf.Clamp01(width);
			height = Mathf.Clamp01(height);
			_haveSetOpacityUvPercent = true;
			_opacityUvWidthPercent = width;
			_opacityUvHeightPercent = height;
			_uvLeftTop = Vector2.zero;
			_uvRightTop = new Vector2(width, 0f);
			_uvLeftBottom = new Vector2(0f, height);
			_uvRightBottom = new Vector2(width, height);
		}
	}

	public Rect GetTextureRect(Texture2D tex)
	{
		float x = _uvLeftTop.x * (float)tex.width;
		float y = (1f - _uvLeftBottom.y) * (float)tex.height;
		float width = (_uvRightTop.x - _uvLeftTop.x) * (float)tex.width;
		float height = (_uvLeftBottom.y - _uvLeftTop.y) * (float)tex.height;
		_width = width;
		_height = height;
		return new Rect(x, y, width, height);
	}

	public void SetSpriteForTexture(string assetName, FreeImageComponent.ImageComponentData componentData)
	{
		base.sprite = SpriteDirs[assetName];
		base.rectTransform.anchorMax = base.rectTransform.anchorMin;
	}

	public void SetOriginUv(float originWidth, float originHeight, FreeImageComponent.ImageComponentData componentData)
	{
		_originWidth = originWidth;
		_originHeight = originHeight;
		base.rectTransform.sizeDelta = new Vector2(componentData.ImageWidth, componentData.ImageHeight);
	}

	public void SetUvOrigin(ImageCoverUv coverUv)
	{
		float num = (float)(coverUv.coverX % 1000) / 1000f;
		float num2 = (float)(coverUv.coverY % 1000) / 1000f;
		float num3 = 1f - _opacityUvWidthPercent;
		float opacityUvWidthPercent = _opacityUvWidthPercent;
		float num4 = 1f - _opacityUvHeightPercent;
		float opacityUvHeightPercent = _opacityUvHeightPercent;
		_uvLeftTop.x = num3 * num;
		_uvLeftTop.y = num4 * num2;
		_uvRightTop.x = _uvLeftTop.x + opacityUvWidthPercent;
		_uvRightTop.y = _uvLeftTop.y;
		_uvLeftBottom.x = _uvLeftTop.x;
		_uvLeftBottom.y = _uvLeftTop.y + opacityUvHeightPercent;
		_uvRightBottom.x = _uvLeftTop.x + opacityUvWidthPercent;
		_uvRightBottom.y = _uvLeftTop.y + opacityUvHeightPercent;
	}

	public void SetPercentHeightWithAtlas(float percent)
	{
		if (base.type != Type.Filled)
		{
			base.type = Type.Filled;
			base.fillMethod = FillMethod.Vertical;
			base.fillOrigin = 0;
		}
		base.fillAmount = percent;
	}

	public void SetUvControl(Vector4 uv)
	{
		_uv = uv;
		_isUvSelfContorl = true;
		SetAllDirty();
	}

	public void SetImageUvReverse(bool isReverseX, bool isReverseY, float width, float height)
	{
		if (isReverseX || isReverseY)
		{
			if (isReverseX)
			{
				base.transform.localScale = new Vector3(0f - base.transform.localScale.x, base.transform.localScale.y, base.transform.localScale.z);
				base.transform.localPosition += new Vector3(width, 0f, 0f);
			}
			if (isReverseY)
			{
				base.transform.localScale = new Vector3(base.transform.localScale.x, 0f - base.transform.localScale.y, base.transform.localScale.z);
				base.transform.localPosition += new Vector3(0f, 0f - height, 0f);
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		if (!_isUvSelfContorl)
		{
			base.OnPopulateMesh(vh);
			return;
		}
		Texture texture = mainTexture;
		vh.Clear();
		if (texture != null)
		{
			Vector4 vector = new Vector4(0f, 0f - _originHeight, _originWidth, 0f);
			Color color = this.color;
			vh.AddVert(new Vector3(vector.x, vector.y), color, new Vector2(_uv.x, _uv.y));
			vh.AddVert(new Vector3(vector.x, vector.w), color, new Vector2(_uv.x, _uv.w));
			vh.AddVert(new Vector3(vector.z, vector.w), color, new Vector2(_uv.z, _uv.w));
			vh.AddVert(new Vector3(vector.z, vector.y), color, new Vector2(_uv.z, _uv.y));
			vh.AddTriangle(0, 1, 2);
			vh.AddTriangle(2, 3, 0);
		}
	}
}
