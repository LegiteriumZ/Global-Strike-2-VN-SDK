using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utility.ParticleSize;

public class RunTimeCalculateParticleSize : MonoBehaviour
{
	public class CalParticle
	{
		public string Path;

		public string Md5;

		public float LifeTime;
	}

	private string[] _preDirs = new string[7] { "Assets/Res/Assets/player", "Assets/Res/Assets/npc", "Assets/Res/Assets/weapon", "Assets/Res/Assets/accessory", "Assets/Res/Assets/skill", "Assets/Res/Assets/playerskin", "Assets/Res/Assets/weaponskin" };

	private string _writePath = "CaculateParticlePath.txt";

	private List<CalParticle> _cals = new List<CalParticle>();

	private List<string> _reimportPaths = new List<string>();

	private List<string> _checkEffectDirs = new List<string>();

	private bool _doNotCompareMd5Equal;

	private bool _isOver;

	private bool _isCaculate;

	private float _caculateTime;

	private GameObject _particleObjGameObject;

	private CalParticle _calParticle;

	private float _caculateSumTime;

	private float _alphaThorld = 0.35f;

	private float _maxVacancyPercent = 0.8f;

	private float _checkDirTime;

	private int _caculateAllDirCount;

	private int _maxCaculateAllDirCount = 200;

	private void Reset()
	{
		_cals.Clear();
		_reimportPaths.Clear();
		_checkEffectDirs.Clear();
		_isOver = false;
		_caculateAllDirCount = 0;
		_caculateSumTime = 0f;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
