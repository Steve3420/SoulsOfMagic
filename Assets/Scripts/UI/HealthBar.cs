using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Image HealthImage;
    public Text HealthText;
    public float Health;
    public int HealthCap;
    public float HotAmount;

    public Image ManaImage;
    public Text ManaText;
    public float Mana;
    public int ManaCap;
    public float ManaRegenAmount;

    public int Rank1ManaCost;
    public int Rank2ManaCost;
    public int Rank3ManaCost;

    //Buff Stuff
    public Image Buff1HotImage;
    public Image Buff1BarrierImage;
    public Image Buff2HotImage;
    public Image Buff2BarrierImage;

    public bool DamageReduced = false;
    public bool HealOverTime = false;
	public bool DmgImmunity = false;
	private bool Dead = false;

    float DmgReductionAmount = 2;

	void Update ()
    {
        //
        HealthImage.rectTransform.localScale = new Vector3(Health / 100, HealthImage.rectTransform.localScale.y, HealthImage.rectTransform.localScale.z);
        ManaImage.rectTransform.localScale = new Vector3(Mana / 100, ManaImage.rectTransform.localScale.y, ManaImage.rectTransform.localScale.z);
        
        //Checks whether or not there is a heal over time and activates the UI indicator
        if(HealOverTime == true)
            Buff1HotImage.gameObject.SetActive(true);
        else
            Buff1HotImage.gameObject.SetActive(false);

        //Checks whether or not there is a damage reduction and activates the UI indicator
        if (DamageReduced)
            Buff2BarrierImage.gameObject.SetActive(true);
        else
            Buff2BarrierImage.gameObject.SetActive(false);
        
		if (Health <= 0) 
		{
			Death ();
		}


        //Checks the F Keys and increase/decrease Mana and Health
        DebugButtons();
    }
    
	public void ResetBars()
	{
		Health = HealthCap;
		int newHealth = (int)Health;
		HealthText.text = newHealth.ToString();

		Mana = ManaCap;
		int newMana = (int)Mana;
		ManaText.text = newMana.ToString();
	}

	public bool CheckMana(float amount)
	{
		if (Mana >= amount)
			return true;
		else
			return false;
	}

    public float DamageReduction(float amount)
    {
        if(DamageReduced)
        {
            amount /= 2;
            return amount;
        }
        else
            return amount;
    }
    
    public void DecreaseHealth(float amount)
    {
		if (DmgImmunity != true) 
		{
			Health -= DamageReduction(amount);
			int newHealth = (int)Health;
			HealthText.text = newHealth.ToString();
		}
    }

    public void IncreaseHealth(float amount)
    {
        if(Health < HealthCap)
        {
            Health += amount;
            int newHealth = (int)Health;
			HealthText.text = newHealth.ToString();
        }
    }

    public void DecreaseMana(float amount)
    {
        Mana -= amount;
        ManaText.text = Mana.ToString();
    }

    public void IncreaseMana(float amount)
    {
        if(Mana < 100)
        {
            Mana += amount;
            ManaText.text = Mana.ToString();
        }
        else
            Mana = 100;
    }

	void Death()
	{
		if (Dead != true) 
		{
			GameObject Canvas = transform.parent.GetChild (3).gameObject;
			GameObject Splash = transform.parent.GetChild (0).gameObject;

			Canvas.SetActive (false);
			Splash.SetActive (true);
			Splash.GetComponent<PlayerDeath>().Afterlife();
			Dead = true;
			transform.gameObject.SetActive (false);
		}
	}

    void DebugButtons()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            DecreaseHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            IncreaseHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            DecreaseMana(10);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            IncreaseMana(10);
        }
    }
}
