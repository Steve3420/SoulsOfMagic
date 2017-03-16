using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    //Public Variables
    public float m_Speed = 1;
    public GameObject m_VerticalLookPivot;
    public GameObject m_Camera;
    
    public Animator m_Animator;
    public PlayerSpells m_SpellScript;
	public CameraDetection m_CamDetectionScript;
	public HealthBar m_HealthBarScript;

	public bool m_FinishedCast;
	public string m_HandCastedfrom;

    //Private Variables
    PlayerInputScript m_Input;
    Rigidbody m_Body;
    Vector3 m_InputVelocity;
    bool m_IsCasting;
    float m_CastingTime;

    bool m_OnGround = true;
    int m_GroundMask;
    Vector3 m_TempPosition;
    Quaternion m_LastRotation;
    
	public bool FinishedCast
	{
		get { return m_FinishedCast; }
		set { m_FinishedCast = value; }
	}

    public bool IsCasting
    {
        get { return m_IsCasting; }
        set { m_IsCasting = value; }
    }
    
    void Start ()
    {
        //Gets the script form the player
        m_Input = GetComponent<PlayerInputScript>();
        //Gets the rigid body form the player
        m_Body = GetComponent<Rigidbody>();
        //Sets up the layer mask so we dont collide with things from the ignore raycast layer
        m_GroundMask = ~LayerMask.GetMask("Player", "Ignore Raycast");

       // Cursor.visible = false;
       // Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update ()
    {
        //print(m_IsCasting);
        if (m_IsCasting == false)
        {   
            //Updates the player detecting the ground
            UpdateOnGround();
            //Update the player position with the input
            UpdatePositionInput();
        }
        else
            //Update the player while casting
            UpdateWhileCasting();
    }
    
    void UpdateOnGround()
    {
		//Create ray to cast in the direction of the groud
        RaycastHit RayHit;
        Ray ray = new Ray();
		//Since we crated the ray first we have to set the position and direction
        ray.origin = transform.position;
        ray.direction = -transform.up;
		//Cast the ray to the ground to see if there is ground
        Physics.Raycast(transform.position, Vector3.down, out RayHit, 1.5f, m_GroundMask);
        
		//If there is ground there then set bool for OnGround
        if(RayHit.collider != null)
        {
            m_OnGround = true;
        }
        else
            m_OnGround = false;
        
		//Setting the last rotation to prevent it from interfering with the movement
        m_LastRotation = transform.rotation;

		//This is to detect where the ground is and move the player if he/she is not on the ground
        if(m_OnGround)
        {
            Vector3 StepUp = new Vector3(0, 0.05f, 0);

            //find out how much we need to step the player up
            if (RayHit.distance <= 0.05f)
            {
                m_Body.position = Vector3.Lerp(transform.position, transform.position + StepUp, Time.deltaTime * m_Speed);
            }
        }
    }
    
    void UpdatePositionInput()
    {
        if (m_OnGround)
        {
            //Gets the input Axsis from the input script
            m_InputVelocity = new Vector3(m_Input.GetInputAxis().x, 0, m_Input.GetInputAxis().y);

            if(m_IsCasting != true)
            {
                if (m_InputVelocity.x != 0 || m_InputVelocity.z != 0)
                {
                    m_Animator.SetBool("IsWalking", true);
                }
                else
                    m_Animator.SetBool("IsWalking", false);
            }
            else
                m_Animator.SetBool("IsWalking", false);

            //Normalize input restricts the input to 1 - 1
            m_InputVelocity.Normalize();

            Vector3 newInput = m_InputVelocity + new Vector3(m_Camera.transform.eulerAngles.y, 0, 0);

            //Gets the input relative to the camera
            newInput = m_Camera.transform.TransformDirection(m_InputVelocity);
            newInput.y = 0;
            newInput.Normalize();

            //Update the player position using the rigidbody attached
            m_Body.position = Vector3.Lerp(transform.position, transform.position + newInput, Time.deltaTime * m_Speed);
            transform.LookAt(transform.position + newInput);
            m_LastRotation = transform.rotation;

            //Set and store last rotation
            m_Body.rotation = m_LastRotation;
        }
    }

	public void UpdateCastingTime(string castedHand, float castTime)
    {
		float timeAmount = castTime;

		//Check witch rank ability it is and check mana with the mana consumtion of
		//that rank because if the player doesnt have enough mana then they can use
		//that ability

		//Create local variable to store the name of the spell so we only have to
		//check it once in the function
		string SpellName;

		//Change the local based on the parameter if the function
		if (castedHand == "Main")
			SpellName = m_SpellScript.MainSpellFunc.Method.Name;
		else
			SpellName = m_SpellScript.SecondSpellFunc.Method.Name;
		
		//Check the spell name for which rank it is and check the mana according
		//to its rank

		bool CheckResult = false;

		if (SpellName.EndsWith("3"))
		{
			CheckResult = m_HealthBarScript.CheckMana(m_HealthBarScript.Rank3ManaCost);
		}
		if (SpellName.EndsWith("2"))
		{
			CheckResult = m_HealthBarScript.CheckMana(m_HealthBarScript.Rank2ManaCost);
		}
		if (SpellName.EndsWith("1"))
		{
			CheckResult = m_HealthBarScript.CheckMana(m_HealthBarScript.Rank1ManaCost);
		}

        //Check to make sure we are not allready casting
		if (m_CastingTime == 0 && m_IsCasting == false && CheckResult == true)
        {
            //Set the member to the time amount for the casting
			m_CastingTime = timeAmount;

            m_IsCasting = true;

			//Pass the parameter to to the member varaible so we can check
			//it later in the script
			m_HandCastedfrom = castedHand;
        }
    }

    public void UpdateWhileCasting()
    {
        //Stop players movement if not allready stopped
        m_Body.velocity = Vector3.zero;

        //Check casting time
        if (m_CastingTime >= 0)
        {
            //Reduce the casting time by the time between frames
            m_CastingTime -= Time.deltaTime;
            //Set the member to true so the player is casting while the time
            //Reduces
            //Debug.Log("Casting!");
            m_IsCasting = true;
			m_CamDetectionScript.HoldTarget = true;
        }
        else
        {
            //Set the casting time to 0 so that it is not anyother small number
            m_CastingTime = 0;
            //Make it so the player can continue
            m_IsCasting = false;

			if (m_HandCastedfrom == "Main") 
			{
				//Debug.Log ("Main Hand Spell Casted");
				m_SpellScript.m_MainSpellFunc ();
			}
			if (m_HandCastedfrom == "Off") 
			{
				//Debug.Log ("Off Hand Spell Casted");
				m_SpellScript.m_SecondSpellFunc();
			}
			m_CamDetectionScript.HoldTarget = false;

        }
    }

    public void Death()
    {

    }
    
}
