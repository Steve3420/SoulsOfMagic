using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour 
{
	public int m_Deaths;
	public int m_Kills;
	public GameObject m_ScoreBoard;

	public void IncreaseKills()
	{
		m_Kills += 1;
	}

	public void IncreaseDeaths()
	{
		m_Deaths += 1;
	}
}
