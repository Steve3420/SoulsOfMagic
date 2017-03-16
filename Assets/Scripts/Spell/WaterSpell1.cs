using UnityEngine;
using System.Collections;

public class WaterSpell1 : MonoBehaviour
{
    
    public float m_LifeTime;
    public ParticleSystem m_PartSystem;

    //BU mean Back up
    public float m_BULifeTime; 

	void Start ()
    {
        m_BULifeTime = m_LifeTime;
    }
	
	void Update ()
    {
	    if(m_LifeTime >= 0)
        {
            m_LifeTime -= Time.deltaTime;
        }
        else
        {
            m_LifeTime = 0;
            gameObject.SetActive(false);

            if(this != null)
                Destroy(this.gameObject);
        }
	}
}
