using UnityEngine;

public class DarkDrain : MonoBehaviour
{
	private float speed = 0.25f;

	private GameObject moveObject;

	private GameObject cameraObject;

	private GameObject ballObject;

	private void Start()
	{
		moveObject = base.gameObject.FindForeachByName("heianxiqu");
		if ((bool)moveObject)
		{
			moveObject = moveObject.transform.GetChild(0).gameObject;
		}
		cameraObject = base.gameObject.FindForeachByName("heianxiqu_camera");
		if ((bool)cameraObject)
		{
			cameraObject = cameraObject.transform.GetChild(0).gameObject;
		}
		ballObject = base.gameObject.FindForeachByName("ball");
		if ((bool)ballObject)
		{
			ballObject = ballObject.transform.GetChild(0).gameObject;
		}
	}

	private void Update()
	{
		UpdateRotation();
	}

	private void UpdateRotation()
	{
		moveObject.transform.Rotate(new Vector3(0f, -360f * Time.deltaTime * speed, 0f));
		cameraObject.transform.Rotate(new Vector3(0f, 0f, -360f * Time.deltaTime * speed));
		ballObject.transform.Rotate(new Vector3(0f, -360f * Time.deltaTime * speed, 0f));
	}
}
