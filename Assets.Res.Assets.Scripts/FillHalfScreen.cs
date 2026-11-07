using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[ExecuteInEditMode]
public class FillHalfScreen : MonoBehaviour
{
	private Vector2 _currSize;

	private void Update()
	{
		Vector2 vector = new Vector2((float)Display.main.systemWidth * 0.5f, (float)Display.main.systemHeight * 0.5f);
		if (_currSize != vector)
		{
			_currSize = vector;
			(base.transform as RectTransform).sizeDelta = _currSize;
		}
	}
}
