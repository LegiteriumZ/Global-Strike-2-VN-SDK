using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class HomeGunGridItem : MonoBehaviour
{
	private int _backId;

	private int _listID;

	private int _gridid;

	private int _type;

	public int listID => _listID;

	public int gridid => _gridid;

	public int backid => _backId;

	public int type => _type;

	public void Init(int listID, int gridid, int backid, int type)
	{
		_listID = listID;
		_gridid = gridid;
		_backId = backid;
		_type = type;
	}
}
