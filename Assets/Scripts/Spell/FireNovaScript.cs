using UnityEngine;
using System.Collections;

public class FireNovaScript : MonoBehaviour
{
    public float MinRadius;
    public float MaxRadius;
    public float Speed;
    public float WaitTime;

    CapsuleCollider Collider;
    float Radius;
    bool SwitchDirection;
    bool IsWaiting;
    public float WaitTimeCount;

    void Start ()
    {
        Collider = GetComponent<CapsuleCollider>();
        SwitchDirection = true;
        IsWaiting = true;
        WaitTime = 1;
    }
	
	void Update ()
    {
        Radius = Collider.radius;

        float newRadius = 0;

        if (Collider.radius <= 0.5f)
        {
            if(SwitchDirection == false)
            {
                SwitchDirection = true;
                IsWaiting = true;
                WaitTimeCount = WaitTime;
            }
        }
       
        if(Collider.radius >= 7)
        {
            SwitchDirection = false;
        }     
        
        if(IsWaiting == false)
        {
            if (SwitchDirection)
                newRadius = Mathf.Lerp(Radius, MaxRadius, Time.deltaTime * Speed);
            else
                newRadius = Mathf.Lerp(Radius, MinRadius, Time.deltaTime * Speed);
        }
        else
        {
            if (WaitTimeCount >= 0f)
                WaitTimeCount -= Time.deltaTime;
            else
                IsWaiting = false;
        }
        
        Collider.radius = newRadius;
	}
}
