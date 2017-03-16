using UnityEngine;
using System.Collections;

public class FireSpell2 : MonoBehaviour
{
    public float MinRadius;
    public float MaxRadius;
    public float Speed;
    public float WaitTime;
    public float Damage;
    public GameObject ExcludedPlayer;

    CapsuleCollider Collider;
    float Radius;
    bool IsWaiting;
    public float WaitTimeCount;

    void Start()
    {
        Collider = GetComponent<CapsuleCollider>();
        IsWaiting = true;
        //WaitTime = 1;
		Collider.radius = MinRadius;
		WaitTimeCount = WaitTime;
    }

    void Update()
    {
        Radius = Collider.radius;

        float newRadius = 0;

        if (IsWaiting == true)
        {
			if (WaitTimeCount >= 0f)
				WaitTimeCount -= Time.deltaTime;
			else
			{
				IsWaiting = false;
			}
        }
        else
        {
			newRadius = Mathf.Lerp(Radius, MaxRadius, Time.deltaTime * Speed);
        }

        Collider.radius = newRadius;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject != ExcludedPlayer && col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HealthBar>().DecreaseHealth(Damage);
        }
    }
}
