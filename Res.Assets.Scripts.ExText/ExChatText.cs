using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Res.Assets.Scripts.ExText;

public class ExChatText : Text
{
	public static readonly char no_breaking_space = '\u00a0';

	private readonly UIVertex[] m_TempVerts = new UIVertex[4];

	private static StringBuilder _builder = new StringBuilder();

	private float _spaceSize = -1f;

	private string _finaltext;

	[SerializeField]
	private string _headtext;

	public string HeadText
	{
		get
		{
			return _headtext;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (!string.IsNullOrEmpty(m_Text))
				{
					_headtext = "";
					_finaltext = text;
					SetVerticesDirty();
				}
			}
			else if (_headtext != value)
			{
				_headtext = value;
				UpdateFinianText(text);
				SetVerticesDirty();
				SetLayoutDirty();
			}
		}
	}

	public override string text
	{
		get
		{
			return base.text;
		}
		set
		{
			if (text != value)
			{
				UpdateSpaceSize();
				if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(HeadText))
				{
					UpdateFinianText(value);
				}
				else if (string.IsNullOrEmpty(value))
				{
					_finaltext = "";
				}
				else
				{
					_finaltext = value;
				}
				SetVerticesDirty();
			}
			base.text = value;
		}
	}

	private string FinalText
	{
		get
		{
			if (string.IsNullOrEmpty(_finaltext))
			{
				return text;
			}
			return _finaltext;
		}
	}

	private void UpdateFinianText(string info)
	{
		int num = Mathf.RoundToInt(GetHeadWidth() / _spaceSize);
		if (num > 0)
		{
			_builder.Length = 0;
			for (int i = 0; i < num; i++)
			{
				_builder.Append(no_breaking_space);
			}
			_builder.Append(info);
			_finaltext = _builder.ToString();
		}
	}

	private float GetHeadWidth()
	{
		if (!string.IsNullOrEmpty(HeadText))
		{
			TextGenerationSettings generationSettings = GetGenerationSettings(Vector2.zero);
			generationSettings.richText = true;
			return base.cachedTextGeneratorForLayout.GetPreferredWidth(HeadText, generationSettings) / base.pixelsPerUnit;
		}
		return 0f;
	}

	private void UpdateSpaceSize()
	{
		if (_spaceSize < 0f)
		{
			Vector2 size = base.rectTransform.rect.size;
			TextGenerationSettings generationSettings = GetGenerationSettings(size);
			base.cachedTextGenerator.PopulateWithErrors(HeadText, generationSettings, base.gameObject);
			IList<UIVertex> verts = base.cachedTextGenerator.verts;
			if (verts != null && verts.Count >= 2)
			{
				_spaceSize = verts[1].position.x - verts[0].position.x;
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.font == null)
		{
			return;
		}
		m_DisableFontTextureRebuiltCallback = true;
		Vector2 size = base.rectTransform.rect.size;
		TextGenerationSettings settings = GetGenerationSettings(size);
		using (ExVertexHelper exVertexHelper = new ExVertexHelper())
		{
			if (!string.IsNullOrEmpty(HeadText))
			{
				settings.richText = true;
				AddTextVerts(exVertexHelper, HeadText, ref settings);
			}
			if (!string.IsNullOrEmpty(FinalText))
			{
				settings.richText = false;
				AddTextVerts(exVertexHelper, FinalText, ref settings);
			}
			toFill.Clear();
			int currentVertCount = exVertexHelper.currentVertCount;
			for (int i = 0; i < currentVertCount; i++)
			{
				UIVertex vertex = default(UIVertex);
				exVertexHelper.PopulateUIVertex(ref vertex, i);
				toFill.AddVert(vertex);
			}
			toFill.AddUIVertexStream(null, exVertexHelper.m_Indices);
		}
		m_DisableFontTextureRebuiltCallback = false;
	}

	private IList<UIVertex> AddTextVerts(ExVertexHelper toFill, string info, ref TextGenerationSettings settings)
	{
		base.cachedTextGenerator.PopulateWithErrors(info, settings, base.gameObject);
		IList<UIVertex> verts = base.cachedTextGenerator.verts;
		float num = 1f / base.pixelsPerUnit;
		int count = verts.Count;
		Vector2 vector = new Vector2(verts[0].position.x, verts[0].position.y) * num;
		vector = PixelAdjustPoint(vector) - vector;
		if (vector != Vector2.zero)
		{
			for (int i = 0; i < count; i++)
			{
				int num2 = i & 3;
				m_TempVerts[num2] = verts[i];
				m_TempVerts[num2].position *= num;
				m_TempVerts[num2].position.x += vector.x;
				m_TempVerts[num2].position.y += vector.y;
				if (num2 == 3)
				{
					toFill.AddUIVertexQuad(m_TempVerts);
				}
			}
		}
		else
		{
			for (int j = 0; j < count; j++)
			{
				int num3 = j & 3;
				m_TempVerts[num3] = verts[j];
				m_TempVerts[num3].position *= num;
				if (num3 == 3)
				{
					toFill.AddUIVertexQuad(m_TempVerts);
				}
			}
		}
		return verts;
	}
}
