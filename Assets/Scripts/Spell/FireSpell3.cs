using UnityEngine;
using System.Collections;

public class FireSpell3 : MonoBehaviour
{
    public float Lifetime;
    public int Damage;
    public Vector3 Force;
    public GameObject ExcludedPlayer;
    public GameObject GroundEffectPrefab;
    public bool UseCollision;
    public bool UseLifeTime;
    public bool UseScaleDown;

    void Start()
    {
    }

    void Update()
    {
        if(UseLifeTime)
        {
            if (Lifetime >= 0)
            {
                Lifetime -= Time.deltaTime;

                if(UseScaleDown)
                {
					if(transform.localScale.x >= 0)
                    transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
                }
            }
            else
            {
                Lifetime = 0;
                Destroy(this.gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(UseCollision)
        {
            if (col.gameObject != ExcludedPlayer && col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<HealthBar>().DecreaseHealth(Damage);
                Destroy(this.gameObject);
            }
            else if (col.gameObject.tag == "Ground")
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y -0.6f, transform.position.z);
                Quaternion Rotation = new Quaternion(0,0,0,0);
                Instantiate(GroundEffectPrefab, position, Rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
