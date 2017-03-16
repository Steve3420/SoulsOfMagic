using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellIcon : MonoBehaviour
{
    public Image MainSlot;
    public Image SecSlot;

    public Sprite FireImage1;
    public Sprite FireImage2;
    public Sprite FireImage3;

    public Sprite WaterImage1;
    public Sprite WaterImage2;
    public Sprite WaterImage3;

    public Sprite EarthImage1;
    public Sprite EarthImage2;
    public Sprite EarthImage3;

    public PlayerSpells PlayerSpell;
    public bool MainHand;

    string SpellName;
    int SpellNumber;
    
    void Start ()
    {
	    
	}
	
	void Update ()
    {
        string Spell;

        if(MainHand)
            //Get the name from the spell function
            Spell = PlayerSpell.MainSpellFunc.Method.Name;
        else
            Spell = PlayerSpell.SecondSpellFunc.Method.Name;
        
        GetSpellName(Spell);
        
        if (MainHand)
            CheckMainHand();
        else
            CheckSecondHand();
    }

    void GetSpellName(string Spell)
    {
        //Split into an array of characters
        char[] Letters = Spell.ToCharArray();

        //Read if the ltter is and f for fire which is 4 letters
        //instead of 5
        if (Letters[0] == 'F')
        {
            //Set the name using the characters from the list
            SpellName = Letters[0].ToString()
                 + Letters[1].ToString()
                 + Letters[2].ToString()
                 + Letters[3].ToString();
        }
        else
        {
            //Set the name using the characters from the list
            SpellName = Letters[0].ToString()
                 + Letters[1].ToString()
                 + Letters[2].ToString()
                 + Letters[3].ToString()
                 + Letters[4].ToString();
        }

        //Get the index using the amount in the array and minusing
        //one for the array since it starts at 0
        int index = Letters.Length - 1;

        //Gets the number from the last digit in the name
        int.TryParse(Letters[index].ToString(), out SpellNumber);

        //Debug.Log(SpellName + SpellNumber);

    }
    
    void CheckMainHand()
    {
        if(SpellName == "Fire")
        {
            switch (SpellNumber)
            {
                case 1:
                    MainSlot.sprite = FireImage1;
                    break;

                case 2:
                    MainSlot.sprite = FireImage2;
                    break;

                case 3:
                    MainSlot.sprite = FireImage3;
                    break;
            }
        }

        if(SpellName == "Water")
        {
            switch (SpellNumber)
            {
                case 1:
                    MainSlot.sprite = WaterImage1;
                    break;

                case 2:
                    MainSlot.sprite = WaterImage2;
                    break;

                case 3:
                    MainSlot.sprite = WaterImage3;
                    break;
            }
        }

        if (SpellName == "Earth")
        {
            switch (SpellNumber)
            {
                case 1:
                    MainSlot.sprite = EarthImage1;
                    break;

                case 2:
                    MainSlot.sprite = EarthImage2;
                    break;

                case 3:
                    MainSlot.sprite = EarthImage3;
                    break;
            }
        }

        if(SpellName == "Empty")
        {
            SecSlot.sprite = MainSlot.sprite;
        }
    }

    void CheckSecondHand()
    {
        if (SpellName == "Fire")
        {
            switch (SpellNumber)
            {
                case 1:
                    SecSlot.sprite = FireImage1;
                    break;

                case 2:
                    SecSlot.sprite = FireImage2;
                    break;

                case 3:
                    SecSlot.sprite = FireImage3;
                    break;
            }
        }

        if (SpellName == "Water")
        {
            switch (SpellNumber)
            {
                case 1:
                    SecSlot.sprite = WaterImage1;
                    break;

                case 2:
                    SecSlot.sprite = WaterImage2;
                    break;

                case 3:
                    SecSlot.sprite = WaterImage3;
                    break;
            }
        }

        if (SpellName == "Earth")
        {
            switch (SpellNumber)
            {
                case 1:
                    SecSlot.sprite = EarthImage1;
                    break;

                case 2:
                    SecSlot.sprite = EarthImage2;
                    break;

                case 3:
                    SecSlot.sprite = EarthImage3;
                    break;
            }
        }

        if (SpellName == "Empty")
        {
            SecSlot.sprite = MainSlot.sprite;
        }
    }
}
