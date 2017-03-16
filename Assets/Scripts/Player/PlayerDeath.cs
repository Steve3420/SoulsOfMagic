using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDeath : MonoBehaviour 
{
	//Public Variables 
	public CameraScript m_CamScript;
	public PlayerScore m_ScoreScript;
	public GameObject m_SpawnPoint;
	public GameObject m_MiddleArea;
	public float m_RespawnTimerBackup;
	public float m_RespawnTimer;
	public Text m_RespawnText;
	public bool m_ActivateRes = false;

	//Private Variables
	GameObject m_Parent;
	bool m_Rotate = false;

	void Start () 
	{
		//Get the object parent and store the reference in a member variable
		m_Parent = transform.parent.gameObject;

		//Set the Timer to the member variable that was set by Unity
		m_RespawnTimer = m_RespawnTimerBackup;
	}

	void Update () 
	{
		//Adds a rotation onto the object, which updates every frame
		if (m_Rotate == true) 
			m_Parent.transform.eulerAngles += new Vector3 (0, 2, 0);

		//Prevents the timer and functions from running when we dont want it to
		if (m_ActivateRes == true) 
		{
			//As long as the timer is above zero the first thing will happen
			if (m_RespawnTimer > 0) 
			{
				//Takes the variable that holds the timer limit and takes away
				//the time between frames. This is the easiest way to count down
				m_RespawnTimer -= Time.deltaTime;

				//Create a local variable so we can convert the float number to int
				int TimerDisplay = (int)m_RespawnTimer;

				//Convert the number into a string and send it to the ui to display it
				m_RespawnText.text = TimerDisplay.ToString ();
			}
			else 
				//When the timer is down it will run this function and Respawn
				//the player to their respawn location
				Respawn ();
		}
	}

	public void Afterlife()
	{
		//Set the parent object to this objects parent
		m_Parent = transform.parent.gameObject;
		//Send the player Camera to the middles area for it to show the map
		m_Parent.transform.position = m_MiddleArea.transform.position;

		//This makes the camera lock so we dont have input on camera
		m_CamScript.m_IsDead = true;
		//Activate the Rotate bool which will spin the camera
		m_Rotate = true;
		//Activate the timer
		m_ActivateRes = true;
		//Set the Timer to the member variable
		m_RespawnTimer = m_RespawnTimerBackup;
	}

	void Respawn()
	{
		//This makes the camera lock so we dont have input on camera
		m_CamScript.m_IsDead = false;
		//Stop the rotation
		m_Rotate = false;
		//Stop the timer from doing anything else
		m_ActivateRes = false;
		//Reset the timer for the next time its activated
		m_RespawnTimer = 0;

		//Move the Player back to spawn with the right orientation
		m_Parent.transform.position = m_SpawnPoint.transform.position;
		m_Parent.transform.rotation = m_SpawnPoint.transform.rotation;

		GameObject Canvas = transform.parent.GetChild(3).gameObject;
		GameObject Mage = transform.parent.GetChild(1).gameObject;
		GameObject Splash = transform.parent.GetChild(0).gameObject;

		//Reset the Health/Mana bar
		Mage.GetComponent<HealthBar>().ResetBars();

		m_ScoreScript.IncreaseDeaths();

		//Re-Activate the UI and Character
		Canvas.gameObject.SetActive(true);
		Mage.gameObject.SetActive (true);

		//De-Activate the Death Splash Screen
		Splash.SetActive (false);
	}
}
