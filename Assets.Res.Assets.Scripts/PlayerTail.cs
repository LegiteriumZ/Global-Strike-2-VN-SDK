using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[RequireComponent(typeof(LineRenderer))]
public class PlayerTail : MonoBehaviour
{
	private LineRenderer _lineRenderer;

	private Queue<Vector3> _positions = new Queue<Vector3>();

	private void Awake()
	{
		_lineRenderer = GetComponent<LineRenderer>();
	}

	private void OnEnable()
	{
		_positions.Clear();
		SetLineRender();
	}

	private void Update()
	{
		_positions.Enqueue(base.transform.position);
		while (_positions.Count > 164)
		{
			_positions.Dequeue();
		}
		SetLineRender();
	}

	private void SetLineRender()
	{
		_lineRenderer.positionCount = _positions.Count;
		int num = 0;
		foreach (Vector3 position in _positions)
		{
			_lineRenderer.SetPosition(num++, position);
		}
	}
}
