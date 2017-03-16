using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject PlayersMenu;
    public GameObject StartButton;
    public GameObject ExitButton;
    public GameObject OptionsButton;
    public GameObject StartGameButton;
    public int NumberOfPlayers = 0;

    public GameObject PlayerOnePrefab;
	public GameObject PlayerTwoPrefab;
	public GameObject PlayerThreePrefab;
	public GameObject PlayerFourPrefab;

    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;

	public GameObject MiddleLocation;

    public CameraManagerScript CameraManScript;
	public ScoreBoardManager ScoreboardmanScript;

    void Start ()
    {
        
    }
	
	void Update ()
    {
        Time.timeScale = 0;


        if (NumberOfPlayers == 0)
        {
            StartGameButton.GetComponent<Button>().interactable = false;
        }
        else
            StartGameButton.GetComponent<Button>().interactable = true;
    }

    public void SetNumberPlayers(int number)
    {
        NumberOfPlayers = number;
    }
    public void OptionsFunction()
    {

    }
    public void StartFunction()
    {
        StartButton.SetActive(true);
        ExitButton.SetActive(true);
        OptionsButton.SetActive(true);
        PlayersMenu.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1;




        SpawnPlayers();

        transform.gameObject.SetActive(false);
    }

    void SpawnPlayers()
    {
        switch (NumberOfPlayers)
        {
			case 1:
				SpawnOnePlayer();
                break;

			case 2:
				SpawnTwoPlayer();
                break;

			case 3:
				SpawnThreePlayer();
                break;

			case 4:
				SpawnFourPlayer();
                break;

            default:
                    Debug.Log("Error Selecting Players");
                break;
        }
    }

	public void SpawnOnePlayer()
	{
		//Set up Player One
		GameObject PlayerOne = (GameObject)Instantiate(PlayerOnePrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
		Camera CameraOne = PlayerOne.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set the Player One's Locations
		PlayerOne.transform.GetChild(0).GetComponent<PlayerInputScript>();
		PlayerOne.transform.GetChild(0).GetComponent<PlayerDeath>().m_SpawnPoint = SpawnPoint1;
		PlayerOne.transform.GetChild(0).GetComponent<PlayerDeath>().m_MiddleArea = MiddleLocation;

		//Update the camera manager with how many players there are and pass the references to them
		CameraManScript.UpdatePlayers(1, CameraOne, null,null,null);
		ScoreboardmanScript.gameObject.SetActive(true);
		ScoreboardmanScript.SetPlayers(1, PlayerOne.transform.GetChild(1).gameObject, null, null, null);
	}

	public void SpawnTwoPlayer()
	{
		//Set up Player One
		GameObject PlayerOne = (GameObject)Instantiate(PlayerOnePrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
		Camera CameraOne = PlayerOne.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set the Player One's Locations
		PlayerOne.transform.GetChild(0).GetComponent<PlayerDeath>().m_SpawnPoint = SpawnPoint1;
		PlayerOne.transform.GetChild(0).GetComponent<PlayerDeath>().m_MiddleArea = MiddleLocation;

		//Set up Player Two
		GameObject PlayerTwo = (GameObject)Instantiate(PlayerTwoPrefab, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
		Camera CameraTwo = PlayerTwo.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set the Player Two's Locations
		PlayerTwo.transform.GetChild(0).GetComponent<PlayerDeath>().m_SpawnPoint = SpawnPoint2;
		PlayerTwo.transform.GetChild(0).GetComponent<PlayerDeath>().m_MiddleArea = MiddleLocation;

		//Update the camera manager with how many players there are and pass the references to them
		CameraManScript.UpdatePlayers(2, CameraOne, CameraTwo, null, null);
		ScoreboardmanScript.gameObject.SetActive(true);
		ScoreboardmanScript.SetPlayers(2, PlayerOne.transform.GetChild(1).gameObject, PlayerTwo.transform.GetChild(1).gameObject, null, null);
	}

	public void SpawnThreePlayer()
	{
		//Set up player one
		GameObject PlayerOne = (GameObject)Instantiate(PlayerOnePrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
		Camera CameraOne = PlayerOne.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set up player two
		GameObject PlayerTwo = (GameObject)Instantiate(PlayerTwoPrefab, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
		Camera CameraTwo = PlayerTwo.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set up player three
		GameObject PlayerThree = (GameObject)Instantiate(PlayerThreePrefab, SpawnPoint3.transform.position, SpawnPoint3.transform.rotation);
		Camera CameraThree = PlayerThree.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Update the camera manager with how many players there are and pass the references to them
		CameraManScript.UpdatePlayers(3, CameraOne, CameraTwo, CameraThree, null);
		ScoreboardmanScript.gameObject.SetActive(true);
		ScoreboardmanScript.SetPlayers(3, PlayerOne.transform.GetChild(1).gameObject, PlayerTwo.transform.GetChild(1).gameObject, PlayerThree.transform.GetChild(1).gameObject, null);
	}

	public void SpawnFourPlayer()
	{
		//Set up player one
		GameObject PlayerOne = (GameObject)Instantiate(PlayerOnePrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
		Camera CameraOne = PlayerOne.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set up player two
		GameObject PlayerTwo = (GameObject)Instantiate(PlayerTwoPrefab, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
		Camera CameraTwo = PlayerTwo.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set up player three
		GameObject PlayerThree = (GameObject)Instantiate(PlayerThreePrefab, SpawnPoint3.transform.position, SpawnPoint3.transform.rotation);
		Camera CameraThree = PlayerThree.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Set up player four
		GameObject PlayerFour = (GameObject)Instantiate(PlayerFourPrefab, SpawnPoint4.transform.position, SpawnPoint4.transform.rotation);
		Camera CameraFour = PlayerFour.transform.GetChild (2).GetChild(1).GetComponent<Camera>();

		//Update the camera manager with how many players there are and pass the references to them
		CameraManScript.UpdatePlayers(4, CameraOne, CameraTwo, CameraThree, CameraFour);
		ScoreboardmanScript.gameObject.SetActive(true);
		ScoreboardmanScript.SetPlayers(4, PlayerOne.transform.GetChild(1).gameObject, PlayerTwo.transform.GetChild(1).gameObject, 
										  PlayerThree.transform.GetChild(1).gameObject, PlayerFour.transform.GetChild(1).gameObject);
	}

    public void ExitGame()
    {

    }
}
