using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public abstract class WeaponInitSystemBase<T> : IPredicationInitSystem where T : IPredicationInitComponent<T>, new()
{
	private readonly WeaponContext _weaponContext;

	private readonly Dictionary<int, PredicationInitComponentHistory<T>> _initComponentHistory = new Dictionary<int, PredicationInitComponentHistory<T>>();

	public T TempValue = new T();

	private string _lastErrorMsg;

	public string LastErrorMsg => _lastErrorMsg;

	protected WeaponInitSystemBase(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
	}

	public void OnPredicatoinInit()
	{
		foreach (WeaponEntity item in _weaponContext)
		{
			SetWeaponEntity(item, item.basicInfo.Data);
		}
	}

	public void SavePredicationState(int cmdSeq)
	{
		foreach (WeaponEntity item in _weaponContext)
		{
			T component = GetComponent(item);
			SaveHistory(item.weaponId.Value, cmdSeq, component);
		}
	}

	private PredicationInitComponentHistory<T> GetHistory(int weaponId)
	{
		if (!_initComponentHistory.TryGetValue(weaponId, out var value))
		{
			value = new PredicationInitComponentHistory<T>();
			_initComponentHistory.Add(weaponId, value);
		}
		return value;
	}

	private void SaveHistory(int weaponId, int cmdSeq, T clone)
	{
		GetHistory(weaponId).Save(cmdSeq, clone);
	}

	public bool HasPredicatonError(int cmdSeq)
	{
		foreach (WeaponEntity item in _weaponContext)
		{
			InitComponent(TempValue, item.basicInfo.Data);
			if (!GetHistory(item.weaponId.Value).IsApproximatelyEqual(cmdSeq, TempValue))
			{
				return true;
			}
		}
		_lastErrorMsg = null;
		return false;
	}

	public void OnPredicatoinError(int cmdSeq)
	{
	}

	public void OnPredicatoinSucc(int cmdSeq)
	{
	}

	public virtual bool ShouldResetAll()
	{
		return true;
	}

	private void SetWeaponEntity(WeaponEntity entity, BaseWeaponData weaponData)
	{
		T component = GetComponent(entity);
		InitComponent(component, weaponData);
	}

	protected abstract T GetComponent(WeaponEntity entity);

	protected abstract void InitComponent(T comp, BaseWeaponData data);
}
