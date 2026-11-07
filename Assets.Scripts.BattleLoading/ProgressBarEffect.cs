using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.BattleLoading;

internal class ProgressBarEffect : MonoBehaviour
{
	public Sprite[] list;

	private int indexer;

	private int nowFrame = -1;

	private int frameGap = 5;

	public void Start()
	{
		indexer = 0;
		nowFrame = -1;
	}

	public void FixedUpdate()
	{
		if (list.Length != 0)
		{
			if (nowFrame > frameGap || nowFrame == -1)
			{
				nowFrame = 0;
				changeTexture2D();
			}
			else
			{
				nowFrame++;
			}
		}
	}

	private void changeTexture2D()
	{
		base.transform.GetComponent<Image>().sprite = list[indexer];
		indexer++;
		if (indexer >= list.Length)
		{
			indexer = 0;
		}
	}
}
