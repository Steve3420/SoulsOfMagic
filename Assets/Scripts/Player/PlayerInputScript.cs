using UnityEngine;
using System.Collections;

public class PlayerInputScript : MonoBehaviour
{
    //Public variables
	public bool m_UseJoyStick;
    public string m_PlayerLabel;
    public Vector2 m_InputAxis;
    public Vector2 m_MousePosition;

	//Public access to private variables
	public string PlayerLabel
	{
		get { return m_PlayerLabel; }
		set { m_PlayerLabel = value; }
	}

	public bool JoyStickDetected
	{
		get { return m_JoystickDetected; }
		set { m_JoystickDetected = value; }
	}

	public string JoystickNum
	{
		get { return m_JoystickNum; }
		set { m_JoystickNum = value; }
	}

	public string JoystickNumButton
	{
		get { return m_JoystickNumButton; }
		set { m_JoystickNumButton = value; }
	}

	//Private Variables
	private bool m_JoystickDetected;
	private string m_JoystickNum = "";
	private string m_JoystickNumButton = "";

	void Start()
	{
		//Check the Input class for joysticks
		if (Input.GetJoystickNames().GetLength(0) == 0)
		{
			m_JoystickDetected = false;
		}
		else
		{
			//Set the bool for the joystickDetect
			m_JoystickDetected = true;

			//Grab the set string and split it up
			string Label = m_PlayerLabel;
			char[] CharArray = Label.ToCharArray();

			//Grab the number from after the P
			int Parse = Label.IndexOf('P');
			string newLabel = CharArray[Parse + 1].ToString();

			//Combine all the results to make the string for geting input
			m_JoystickNumButton = "joystick " + newLabel + " button";
			m_JoystickNum = newLabel;
		}
	}

	void Update ()
    {
		if(m_JoystickDetected)
        {
            //Joystick Input
            m_InputAxis = new Vector2(Input.GetAxis(m_PlayerLabel + "LJoystickHorizontal"), Input.GetAxis(m_PlayerLabel + "LJoystickVertical"));
        }
        else
        {
            //Keyboard Input
            m_InputAxis = new Vector2(Input.GetAxis(m_PlayerLabel + "Horizontal"), Input.GetAxis(m_PlayerLabel + "Vertical"));

            //Gets the mousposition
            m_MousePosition = Input.mousePosition;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Break();
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Debug.Break();
        }
	}
    //Two functions that return the input
    public Vector2 GetInputAxis()
    {
        return m_InputAxis;
    }
    public Vector2 GetMousPosition()
    {
        return m_MousePosition;
    }

    public void GetInputinfo()
    {
        
    }
}
