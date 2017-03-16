using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoardManager : MonoBehaviour 
{
	int NumberofPlayer;
	public ScoreBoard ScoreBoardP1;
	public ScoreBoard ScoreBoardP2;
	public ScoreBoard ScoreBoardP3;
	public ScoreBoard ScoreBoardP4;

	PlayerScore PlayerOne;
	PlayerScore PlayerTwo;
	PlayerScore PlayerThree;
	PlayerScore PlayerFour;

	int[] PlayerOneKD = new int[2];
	int[] PlayerTwoKD = new int[2];
	int[] PlayerThreeKD = new int[2];
	int[] PlayerFourKD = new int[2];



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetPlayerScore();

		UpdateScoreBoards();
	}

	void UpdateScoreBoards()
	{
		//Tell all the other scoreboards to update theirs
		switch (NumberofPlayer)
		{
			case 1:
				{
					ScoreBoardP1.UpdateScores(PlayerOneKD);
				}
				break;

			case 2:
				{
					ScoreBoardP1.UpdateScores(PlayerOneKD,PlayerTwoKD);
					ScoreBoardP2.UpdateScores(PlayerOneKD,PlayerTwoKD);
				}
				break;

			case 3:
				{
					ScoreBoardP1.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD);
					ScoreBoardP2.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD);
					ScoreBoardP3.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD);
				}
				break;

			case 4:
				{
					ScoreBoardP1.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD,PlayerFourKD);
					ScoreBoardP2.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD,PlayerFourKD);
					ScoreBoardP3.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD,PlayerFourKD);
					ScoreBoardP4.UpdateScores(PlayerOneKD,PlayerTwoKD,PlayerThreeKD,PlayerFourKD);
				}
				break;

			default:
				Debug.Log("Error Updating Player's Scoreboard");
				break;
		}
	}

	void GetPlayerScore()
	{
		//Grab the cores form each player
		switch (NumberofPlayer)
		{
			case 1:
				{
					PlayerOneKD[0] = PlayerOne.m_Kills;
					PlayerOneKD[1] = PlayerOne.m_Deaths;
				}
				break;

			case 2:
				{
					PlayerOneKD[0] = PlayerOne.m_Kills;
					PlayerOneKD[1] = PlayerOne.m_Deaths;

					PlayerTwoKD[0] = PlayerTwo.m_Kills;
					PlayerTwoKD[1] = PlayerTwo.m_Deaths;
				}
				break;

			case 3:
				{
					PlayerOneKD[0] = PlayerOne.m_Kills;
					PlayerOneKD[1] = PlayerOne.m_Deaths;

					PlayerTwoKD[0] = PlayerTwo.m_Kills;
					PlayerTwoKD[1] = PlayerTwo.m_Deaths;

					PlayerThreeKD[0] = PlayerThree.m_Kills;
					PlayerThreeKD[1] = PlayerThree.m_Deaths;

				}
				break;

			case 4:
				{
					PlayerOneKD[0] = PlayerOne.m_Kills;
					PlayerOneKD[1] = PlayerOne.m_Deaths;

					PlayerTwoKD[0] = PlayerTwo.m_Kills;
					PlayerTwoKD[1] = PlayerTwo.m_Deaths;

					PlayerThreeKD[0] = PlayerThree.m_Kills;
					PlayerThreeKD[1] = PlayerThree.m_Deaths;

					PlayerFourKD[0] = PlayerFour.m_Kills;
					PlayerFourKD[1] = PlayerFour.m_Deaths;
				}
				break;

			default:
				Debug.Log("Error Getting Scores");
				break;
		}
	}
		
	public void SetPlayers(int numberOfPlayers, GameObject playerOne, GameObject playerTwo, GameObject playerThree, GameObject playerFour)
	{
		NumberofPlayer = numberOfPlayers;

		switch (numberOfPlayers)
		{
			case 1:
				{
					PlayerOne = playerOne.GetComponent<PlayerScore>();
					ScoreBoardP1 = PlayerOne.m_ScoreBoard.GetComponent<ScoreBoard>();
				}
				break;

			case 2:
				{
					PlayerOne = playerOne.GetComponent<PlayerScore>();
					ScoreBoardP1 = PlayerOne.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerTwo = playerTwo.GetComponent<PlayerScore>();
					ScoreBoardP2 = PlayerTwo.m_ScoreBoard.GetComponent<ScoreBoard>();
				}
				break;

			case 3:
				{
					PlayerOne = playerOne.GetComponent<PlayerScore>();
					ScoreBoardP1 = PlayerOne.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerTwo = playerTwo.GetComponent<PlayerScore>();
					ScoreBoardP2 = PlayerTwo.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerThree = playerThree.GetComponent<PlayerScore>();
					ScoreBoardP3 = PlayerThree.m_ScoreBoard.GetComponent<ScoreBoard>();
				}
				break;

			case 4:
				{
					PlayerOne = playerOne.GetComponent<PlayerScore>();
					ScoreBoardP1 = PlayerOne.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerTwo = playerTwo.GetComponent<PlayerScore>();
					ScoreBoardP2 = PlayerTwo.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerThree = playerThree.GetComponent<PlayerScore>();
					ScoreBoardP3 = PlayerThree.m_ScoreBoard.GetComponent<ScoreBoard>();

					PlayerFour = playerFour.GetComponent<PlayerScore>();
					ScoreBoardP4 = PlayerFour.m_ScoreBoard.GetComponent<ScoreBoard>();
				}
				break;

			default:
				Debug.Log("Error Setting players");
				break;
		}
	}

}
