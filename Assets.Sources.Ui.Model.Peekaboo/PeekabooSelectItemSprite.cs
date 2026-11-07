using System;
using System.Collections.Generic;
using Assets.Sources.Modules.Ui;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Peekaboo;

internal class PeekabooSelectItemSprite
{
	public static readonly int STOP = 0;

	public static readonly int RUN = 1;

	public static readonly int FINISH = 2;

	public static readonly int END = 3;

	public static UiResourcesLoader Loader;

	private GameObject image1;

	private GameObject image2;

	private string targetUrl;

	private int state = STOP;

	private float speed;

	private float fraction;

	private List<string> baseTextureUrlList;

	private List<string> randomTextureUrlList;

	private int legalWidth;

	private int legalHeight;

	private string img1Url = "";

	public PeekabooSelectItemSprite(List<string> textureUrlList, GameObject tmpImage1, GameObject tmpImage2, int width, int height)
	{
		baseTextureUrlList = new List<string>();
		copyTextureUrlList(textureUrlList, baseTextureUrlList);
		legalWidth = width;
		legalHeight = height;
		image1 = tmpImage1;
		image2 = tmpImage2;
		updateImageSprite(image1, baseTextureUrlList[0]);
		updateImageSprite(image2, baseTextureUrlList[1]);
	}

	private void copyTextureUrlList(List<string> a, List<string> b)
	{
		int count = a.Count;
		for (int i = 0; i < count; i++)
		{
			b.Add(a[i]);
		}
	}

	public void start(string testureUrl)
	{
		targetUrl = testureUrl;
		speed = 0.04f;
		fraction = 0f;
		randomTextureUrlList = new List<string>();
		copyTextureUrlList(baseTextureUrlList, randomTextureUrlList);
		state = RUN;
	}

	public int getState()
	{
		return state;
	}

	public bool isStop()
	{
		return state == STOP;
	}

	public void run(int frameTime)
	{
		if (STOP != state)
		{
			updateFraction(frameTime);
			updateSpeed(frameTime);
			updateImage1();
			updateImage2();
		}
	}

	private void updateSpeed(int frameTime)
	{
		if (speed > 0.001f)
		{
			speed -= (float)frameTime * 2E-05f;
			if ((double)speed <= 0.001)
			{
				speed = 0.001f;
				state = FINISH;
			}
		}
	}

	private void updateImage1()
	{
		if (fraction > 1f)
		{
			Debug.Log("fraction > 1," + fraction);
		}
		float num = (float)legalHeight - (float)legalHeight * fraction;
		RectTransform component = image1.GetComponent<RectTransform>();
		Vector3 localPosition = component.localPosition;
		localPosition.y = num + (float)(legalHeight / 2);
		component.localPosition = localPosition;
	}

	private void updateImage2()
	{
		float num = (float)(-legalHeight) * fraction;
		RectTransform component = image2.GetComponent<RectTransform>();
		Vector3 localPosition = component.localPosition;
		localPosition.y = num + (float)(legalHeight / 2);
		component.localPosition = localPosition;
	}

	private void updateImageSprite(GameObject obj, string url)
	{
		Image image = obj.GetComponent<Image>();
		if (image != null && Loader != null)
		{
			if (obj == image1)
			{
				img1Url = url;
			}
			AssetInfo assetInfo = new AssetInfo("ui/peekabooModel", url);
			Loader.RetriveSprite(assetInfo, delegate(Sprite sprite)
			{
				image.sprite = sprite;
			});
		}
	}

	private void updateFraction(int frameTime)
	{
		fraction += speed * (float)frameTime;
		if (!(fraction > 1f))
		{
			return;
		}
		fraction -= (float)Math.Floor(fraction);
		if (END == state)
		{
			state = STOP;
			fraction = 1f;
			return;
		}
		if (FINISH == state)
		{
			state = END;
			updateImageSprite(image2, img1Url);
			updateImageSprite(image1, targetUrl);
			return;
		}
		updateImageSprite(image2, img1Url);
		int index = UnityEngine.Random.Range(0, randomTextureUrlList.Count);
		updateImageSprite(image1, randomTextureUrlList[index]);
		randomTextureUrlList.RemoveAt(index);
		if (randomTextureUrlList.Count == 0)
		{
			copyTextureUrlList(baseTextureUrlList, randomTextureUrlList);
		}
	}
}
