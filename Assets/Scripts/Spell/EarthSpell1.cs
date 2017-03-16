using UnityEngine;
using System.Collections;

public class EarthSpell1 : MonoBehaviour
{
    public Animator Anima;
    bool AbilityCasted = false;
    bool StateofSheild = false;
    
	void Start ()
    {
       Anima = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (StateofSheild == true)
        {
            //Check if the shield is active
            if (AbilityCasted == false)
            {
                //Activate the game object so we can do what ever
                //transform.gameObject.SetActive(true);
                //its not active so set bool sto start animation
                AbilityCasted = true;
                //this will make it assemble and then idle
                Anima.SetBool("Cast", true);
            }
            //Else do nothing
        }
        else
        {
            if (AbilityCasted == true)
            {
                Anima.SetBool("Casted", true);
                Anima.SetBool("Cast", false);
                AbilityCasted = false;
            }
        }
    }

    public void ActivateEarthSheild(bool state)
    {
        StateofSheild = state;

        if(state)
            transform.gameObject.SetActive(true);
        else
            transform.gameObject.SetActive(false);
    }

    public void DisableSheild()
    {
        transform.gameObject.SetActive(false);
    }
}
