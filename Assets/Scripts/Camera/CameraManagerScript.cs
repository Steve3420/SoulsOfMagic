using UnityEngine;
using System.Collections;

public class CameraManagerScript : MonoBehaviour
{

    public Rect m_SmallRectangle;
	public Rect m_HalfRectangle;
	public Rect m_FullRectangle;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void UpdatePlayers(int Number, Camera Cam1, Camera Cam2, Camera Cam3, Camera Cam4)
    {
        switch (Number)
        {
            case 1:
                {
                    //Full Screen
					Cam1.rect = m_FullRectangle;
                }
                break;

            case 2:
                {
                    // Half Screen
					m_HalfRectangle.y = 0.5f;
					Cam1.rect = m_HalfRectangle;
					m_HalfRectangle.y = 0;
					Cam2.rect = m_HalfRectangle;
					Cam2.rect = m_HalfRectangle;
                }
                break;

            case 3:
                {
                    // Quarter screen with bottom left blank
                }
                break;

            case 4:
                {

                    // Quarter screen
                }
                break;


            default:
                break;
        }
    }
}
