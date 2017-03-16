using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour 
{
	public Image PlayerRow1;
	public Image PlayerRow2;
	public Image PlayerRow3;
	public Image PlayerRow4;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void ShowScoreBoard()
	{

	}

	void HideScoreBoard()
	{
		
	}

	public void UpdateScores(int[] playerOneKD)
	{
		UpdatePlayerScore(PlayerRow1, playerOneKD[0], playerOneKD[1]);
	}

	public void UpdateScores(int[] playerOneKD,int[] playerTwoKD)
	{
		UpdatePlayerScore(PlayerRow1, playerOneKD[0], playerOneKD[1]);

		UpdatePlayerScore(PlayerRow2, playerTwoKD[0], playerTwoKD[1]);
	}

	public void UpdateScores(int[] playerOneKD,int[] playerTwoKD,int[] playerThreeKD)
	{
		UpdatePlayerScore(PlayerRow1, playerOneKD[0], playerOneKD[1]);

		UpdatePlayerScore(PlayerRow2, playerTwoKD[0], playerTwoKD[1]);

		UpdatePlayerScore(PlayerRow3, playerTwoKD[0], playerTwoKD[1]);
	}

	public void UpdateScores(int[] playerOneKD,int[] playerTwoKD,int[] playerThreeKD,int[] playerFourKD)
	{
		UpdatePlayerScore(PlayerRow1, playerOneKD[0], playerOneKD[1]);

		UpdatePlayerScore(PlayerRow2, playerTwoKD[0], playerTwoKD[1]);

		UpdatePlayerScore(PlayerRow3, playerTwoKD[0], playerTwoKD[1]);

		UpdatePlayerScore(PlayerRow4, playerTwoKD[0], playerTwoKD[1]);
	}

	void UpdatePlayerScore(Image ScoreRow, int kills, int deaths)
	{
		Text KillCount = ScoreRow.transform.GetChild(1).GetComponent<Text>();
		Text DeathCount = ScoreRow.transform.GetChild(2).GetComponent<Text>();

		KillCount.text = kills.ToString();
		DeathCount.text = deaths.ToString();
	}
}
