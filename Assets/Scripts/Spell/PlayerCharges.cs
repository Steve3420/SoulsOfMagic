using UnityEngine;
using System.Collections;
using System.Reflection;

public class PlayerCharges : MonoBehaviour
{
    public enum Element
    {
        Fire,
        Water,
        Earth,
        Emty
    }

    public Element m_Slot1State = Element.Emty;
    public Element m_Slot2State = Element.Emty;
    public Element m_Slot3State = Element.Emty;

    public bool ChargeCooldown = true;

    public ElementalSlot m_ElementScript;
    PlayerSpells m_PlayerSpells;
    PlayerTimers m_PlayerTimers;
    

    void Start ()
    {
        //Get the scripts we need
        m_PlayerSpells = GetComponent<PlayerSpells>();
        m_PlayerTimers = GetComponent<PlayerTimers>();
        
        //Update the UI with the changes
        m_ElementScript.ChangeState(m_Slot3State);
        m_ElementScript.ChangeState(m_Slot2State);
        m_ElementScript.ChangeState(m_Slot1State);

        //figure out the new spell from the player
        GetSpell(m_Slot1State);
    }
	
	void Update ()
    {

    }

    public void ChangeState(Element ele)
    {
        if(ChargeCooldown == true)
        {
            //This takes the new element from the player input and
            //pushes the other elements down the line in slots
            m_Slot3State = m_Slot2State;
            m_Slot2State = m_Slot1State;
            m_Slot1State = ele;

            //Update the UI so that it is aware of the changes
            m_ElementScript.ChangeState(ele);

            //figure out the new spell from the player
            GetSpell(ele);

            m_PlayerTimers.ResetChargeCooldown();
        }
    }
    
    void GetSpell(Element ele)
    {
        //Determining the main hand spell function
        
        //This int is to store the Rank of each spell and
        //the default is rank 1
        int RankNumber = 1;

        //Check the first charge slot with the other to slots
        //determining which spell rank to use for the main hand spell
        if (m_Slot1State == m_Slot2State)
        {
            if (m_Slot1State == m_Slot3State)
            {
                RankNumber = 3;
            }
            else
            {
                RankNumber = 2;
            }
        }

        //Check which element that the charge will change into and
        //set the specificly ranked spell using the integer Ranknumber
        if(ele == Element.Fire)
        {
            switch (RankNumber)
            {
                case 1:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.FireSpellRank1;
                    break;
                case 2:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.FireSpellRank2;
                    break;
                case 3:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.FireSpellRank3;
                    break;
                default:
                    break;
            }
        }
        else if (ele == Element.Earth)
        {
            switch (RankNumber)
            {
                case 1:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.EarthSpellRank1;
                    break;
                case 2:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.EarthSpellRank2;
                    break;
                case 3:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.EarthSpellRank3;
                    break;
                default:
                    break;
            }
        }
        else if (ele == Element.Water)
        {
            switch (RankNumber)
            {
                case 1:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.WaterSpellRank1;
                    break;
                case 2:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.WaterSpellRank2;
                    break;
                case 3:
                    m_PlayerSpells.MainSpellFunc = m_PlayerSpells.WaterSpellRank3;
                    break;
                default:
                    break;
            }
        }

        //Determining the secondary hand spell

        //Assuming Slot 1 is taken we are left with 2 to check for
        //the same element
        //To start, will be the last slot because it is used for the right
        //hand casting

        //Checking to make sure all the slots are not allready used.
        if(RankNumber != 3)
        {
            if (m_Slot3State == m_Slot2State)
            {
                //Since both are the same element, it makes it easy to set the spell.
                if (m_Slot3State == Element.Fire)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.FireSpellRank2;
                }
                else if (m_Slot3State == Element.Earth)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.EarthSpellRank2;
                }
                else if (m_Slot3State == Element.Water)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.WaterSpellRank2;
                }
            }
            else
            {
                //Its not he same as the third slot so it is to be ignored
                if (m_Slot3State == Element.Fire)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.FireSpellRank1;
                }
                else if (m_Slot3State == Element.Earth)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.EarthSpellRank1;
                }
                else if (m_Slot3State == Element.Water)
                {
                    m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.WaterSpellRank1;
                }
            }
        }
        else
        {
            //Set the spell function to an empty function so it does
            //not cause issues.
            m_PlayerSpells.SecondSpellFunc = m_PlayerSpells.EmptySpell;
        }
    }

}
