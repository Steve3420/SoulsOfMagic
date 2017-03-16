using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerTimers : MonoBehaviour
{
    //Scripts we will need
    PlayerSpells m_PlayerSpells;
    PlayerCharges m_PlayerCharges;
    HealthBar m_HealthBar;

    public Text m_GlobalText;
    public Text m_ChargeText;

    //Back up and public so it can be set in the editor
    public float m_GlobalCDBackup = 2;
    public float m_ChargeCDBackup = 2;
    public float m_HealOverTimeBackup = 2;
    public float m_ReductionTimeBackup = 2;

    public bool m_HealOverTimeActive = false;
    public bool m_DamageReduced = false;
	public bool m_DamageImmunity = false;

    //Internal Timers
    private float m_GlobalCooldown = 0;
    private float m_ChargeCooldown = 0;
    private float m_HealOverTimer = 2;
    private float m_ReductionTimer = 2;
	private float m_ImmunityTimer = 2;
    public float m_ManaRecoverTimer = 0.5f;

    void Start ()
    {
        m_PlayerSpells = GetComponent<PlayerSpells>();
        m_PlayerCharges = GetComponent<PlayerCharges>();
        m_HealthBar = GetComponent<HealthBar>();
    }
	 
	void Update ()
    {
        GlobalCooldown();

        ChargeCooldown();

        DamageReduction();

		DamageImmunity();

        HealOverTime();
        
        RecoverMana();
    }

    void RecoverMana()
    {
        if(m_HealthBar.Mana <= 100)
            if (m_ManaRecoverTimer > 0)
            {
                m_ManaRecoverTimer -= Time.deltaTime;
            }
            else
            {
                m_ManaRecoverTimer = m_HealthBar.Mana / m_HealthBar.ManaCap;

                m_HealthBar.IncreaseMana(m_HealthBar.ManaRegenAmount);
            }
    }

    void DamageReduction()
    {
        if (m_DamageReduced)
        {
            if (m_ReductionTimer > 0)
            {
                m_ReductionTimer -= Time.deltaTime;
                m_HealthBar.DamageReduced = true;
            }
            else
            {
                m_ReductionTimer = 2;
                m_HealthBar.DamageReduced = false;
                m_DamageReduced = false;
				m_HealthBar.DamageReduced = false;
            }
        }
    }

	void DamageImmunity()
	{
		if (m_DamageImmunity)
		{
			if (m_ImmunityTimer > 0)
			{
				m_ImmunityTimer -= Time.deltaTime;
				m_HealthBar.DmgImmunity = true;
			}
			else
			{
				m_ImmunityTimer = 2;
				m_HealthBar.DmgImmunity = false;
				m_DamageImmunity = false;
				m_HealthBar.DmgImmunity = false;
			}
		}
	}

    void HealOverTime()
    {
        if(m_HealOverTimeActive)
            if (m_HealOverTimer > 0)
            {
                if (IsOdd((int)m_HealOverTimer))
                    m_HealthBar.IncreaseHealth(m_HealthBar.HotAmount);

                m_HealOverTimer -= Time.deltaTime;
                m_HealthBar.HealOverTime = true;
            }
            else
            {
                m_HealOverTimer = 2;
                m_HealthBar.HealOverTime = false;
                m_HealOverTimeActive = false;
            }
    }

    void GlobalCooldown()
    {
        if (m_GlobalCooldown > 0)
        {
            m_GlobalCooldown -= Time.deltaTime;
            m_PlayerSpells.GlobalCooldown = false;
        }
        else
        {
            m_PlayerSpells.GlobalCooldown = true;
            m_GlobalCooldown = 0;
        }
        m_GlobalText.text = "GlobalCD: " + m_GlobalCooldown.ToString();
    }
    
    void ChargeCooldown()
    {
        if (m_ChargeCooldown > 0)
        {
            m_ChargeCooldown -= Time.deltaTime;
            m_PlayerCharges.ChargeCooldown = false;
        }
        else
        {
            m_PlayerCharges.ChargeCooldown = true;
            m_ChargeCooldown = 0;
        }
        m_ChargeText.text = "ChargeCD: " + m_ChargeCooldown.ToString();
    }
    
    public void ResetHealOverTime()
    {
        m_HealOverTimer = m_HealOverTimeBackup;
        m_HealOverTimeActive = true;
    }

    public void ResetDamageReduction()
    {
        m_ReductionTimer = m_ReductionTimeBackup;
        m_DamageReduced = true;
		m_HealthBar.DamageReduced = true;
    }

	public void ResetDamageImmunity()
	{
		m_ImmunityTimer = 2;
		m_DamageImmunity = true;
		m_HealthBar.DmgImmunity = true;
	}

    public void ResetGlobalCooldown()
    {
        m_GlobalCooldown = m_GlobalCDBackup;
    }

    public void ResetChargeCooldown()
    {
        m_ChargeCooldown = m_ChargeCDBackup;
    }

    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
}
