using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour 
{
	public GameObject LimitObject;

	public GameObject RockV1;
	public GameObject RockV2;
	public GameObject RockV3;

	public int RockV1ArrayMax;
	public int RockV2ArrayMax;
	public int RockV3ArrayMax;

	private float LimitX;
	private float LimitZ;

	private int[] RockV1Array;
	private int[] RockV2Array;
	private int[] RockV3Array;

	// Use this for initialization
	void Start () 
	{
		//Create the Array in memory with the desired amount set by the editor
		RockV1Array = new int[RockV1ArrayMax];
		RockV2Array = new int[RockV2ArrayMax];
		RockV3Array = new int[RockV3ArrayMax];

		//Get limits from gameobjects collider
		LimitX = LimitObject.GetComponent<BoxCollider>().bounds.extents.x;
		LimitZ = LimitObject.GetComponent<BoxCollider>().bounds.extents.z;

		SpawnRocks();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void SpawnRocks()
	{
		Vector3 MiddlePosition = LimitObject.transform.position;
		float LimitXMin = MiddlePosition.x - LimitX;
		float LimitXMax = MiddlePosition.x + LimitX;

		float LimitZMin = MiddlePosition.z - LimitZ;
		float LimitZMax = MiddlePosition.z + LimitZ;

		for (int i = 0; i < RockV1Array.Length; i++)
		{
			Vector3 RanPosition = new Vector3(Random.Range(LimitXMin,LimitXMax), LimitObject.transform.position.y, Random.Range(LimitZMin,LimitZMax));
			Quaternion RanRotation = new Quaternion(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360), 0);

			GameObject Rock = (GameObject)Instantiate(RockV1, RanPosition,RanRotation);

			Rock.transform.SetParent(transform);
		}

		for (int i = 0; i < RockV2Array.Length; i++)
		{
			Vector3 RanPosition = new Vector3(Random.Range(LimitXMin,LimitXMax), LimitObject.transform.position.y, Random.Range(LimitZMin,LimitZMax));
			Quaternion RanRotation = new Quaternion(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360), 0);

			GameObject Rock = (GameObject)Instantiate(RockV1, RanPosition,RanRotation);

			Rock.transform.SetParent(transform);
		}

		for (int i = 0; i < RockV3Array.Length; i++)
		{
			Vector3 RanPosition = new Vector3(Random.Range(LimitXMin,LimitXMax), LimitObject.transform.position.y, Random.Range(LimitZMin,LimitZMax));
			Quaternion RanRotation = new Quaternion(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360), 0);

			GameObject Rock = (GameObject)Instantiate(RockV1, RanPosition,RanRotation);

			Rock.transform.SetParent(transform);
		}
	}
}
