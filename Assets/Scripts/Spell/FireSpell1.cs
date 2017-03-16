using UnityEngine;
using System.Collections;

public class FireSpell1 : MonoBehaviour
{
    public float Lifetime;
	bool InHand;
    public int Damage;
    public Vector3 Force;
    public GameObject ExcludedPlayer;
	public GameObject TargetedPlayer;

	void Start ()
    {
//		GameObject Parent = ExcludedPlayer.transform.parent.gameObject;
//		GameObject CameraPos = Parent.transform.GetChild(2).gameObject;
//		GameObject FollowPos = CameraPos.transform.GetChild(0).gameObject;
//
//		//Get the Vector between the follow position and 2 units infront of it
//
//		Vector3 FollowPosition = FollowPos.transform.position;
//		Vector3 InfrontPosition = FollowPosition + FollowPos.transform.forward * 2;
//
//		Vector3 ResultVec = FollowPosition - InfrontPosition;
//
//		float Angle = Mathf.Atan2(ResultVec.y, ResultVec.x) * Mathf.Rad2Deg;
//
//		transform.eulerAngles += new Vector3(0,0,Angle);

	}
	
	void Update ()
    {
		MonitorLife();

		if (TargetedPlayer != null)
		{
			UpdateWithTarget();
		}
		else
		{
			UpdateWithOutTarget();
		}
	}

	void UpdateWithOutTarget()
	{
		

		GetComponent<Rigidbody>().AddRelativeForce(Force/10);
	}

	void UpdateWithTarget()
	{
		Vector3 targetPosition = TargetedPlayer.transform.position;

		Vector3 currentPosition = transform.position;

		targetPosition.y = currentPosition.y;

		Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * Force.z /2);

		transform.position = newPosition;
	}

	void MonitorLife()
	{
		if(Lifetime >= 0)
		{
			Lifetime -= Time.deltaTime;
		}
		else
		{
			Lifetime = 0;
			ExcludedPlayer.GetComponent<PlayerSpells>().FireballDistroyed = true;
			Destroy(this.gameObject);
		}
	}

    void OnCollisionEnter(Collision col)
    {
		GameObject collidedObject = col.gameObject;

		if (collidedObject.transform.parent != null && collidedObject.tag == "Player") 
		{
			string player = collidedObject.transform.parent.name;
			string exPlayer = ExcludedPlayer.name;

			if (player != exPlayer) 
			{
				collidedObject.GetComponent<HealthBar>().DecreaseHealth(Damage);
				Debug.Log (" ! ");
			}
		}

		ExcludedPlayer.GetComponent<PlayerSpells>().FireballDistroyed = true;
		Destroy(this.gameObject);
    }
    
}
