using System.Collections.Generic;
using Tests.AnimViewer.AnimSource;

namespace Tests.AnimViewer.AnimObject;

public class AnimLayer : IMethodsExecuter
{
	private string _layerName;

	private float _layerTime;

	private int _index;

	private List<string> _stateNames;

	private bool _isPlaying = true;

	public int index => _index;

	public List<string> stateNames => _stateNames;

	public AnimLayer(string name, IAnimSource source)
	{
		_layerName = name + "_" + index;
		_index = source.GetHashCode();
		_stateNames = source.StateNames;
	}

	public float UpdateLayerTime(float frameTime)
	{
		if (_isPlaying)
		{
			return _layerTime += frameTime;
		}
		return _layerTime;
	}

	public string GetName()
	{
		return _layerName;
	}

	public void PauseAnim()
	{
		_isPlaying = false;
	}

	public void ResumeAnim()
	{
		_isPlaying = true;
	}

	public void RestartAnim()
	{
		_isPlaying = true;
		_layerTime = 0f;
	}

	public void StopAnim()
	{
		_isPlaying = false;
		_layerTime = 0f;
	}
}
