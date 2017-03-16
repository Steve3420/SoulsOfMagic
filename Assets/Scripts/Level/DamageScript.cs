using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour
{
    public float DamageAmount;
    public bool Activate;


	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter");
        if(col.tag == "Player")
        col.gameObject.GetComponent<HealthBar>().DecreaseHealth(DamageAmount);
    }
}
