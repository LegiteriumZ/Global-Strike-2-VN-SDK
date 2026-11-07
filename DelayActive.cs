using System.Collections.Generic;
using UnityEngine;

public class DelayActive : MonoBehaviour
{
	private float startTime;

	public bool InitActive;

	public List<float> Delay = new List<float>();

	public List<bool> DesActive = new List<bool>();

	private int _index;

	public bool ResetOnEnable;

	private List<GameObject> _children;

	private void Start()
	{
		if (!ResetOnEnable)
		{
			Reset();
		}
	}

	private void OnEnable()
	{
		if (ResetOnEnable)
		{
			Reset();
		}
	}

	private void Reset()
	{
		startTime = Time.time;
		_index = 0;
		_children = new List<GameObject>();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			_children.Add(base.transform.GetChild(i).gameObject);
			_children[i].SetObjectActive(InitActive);
		}
	}

	private void FixedUpdate()
	{
		if (Delay.Count <= _index || !(Time.time - startTime >= Delay[_index]))
		{
			return;
		}
		foreach (GameObject child in _children)
		{
			child.SetObjectActive(DesActive[_index]);
		}
		_index++;
	}
}
