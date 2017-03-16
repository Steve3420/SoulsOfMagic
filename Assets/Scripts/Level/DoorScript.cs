using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{

    public GameObject Door1;
    public GameObject Door2;

    public bool Door1DirectionCW;
    public bool Door2DirectionCW;

    public Vector3 EndRotation1;
    public Vector3 EndRotation2;

    void Start()
    {
    }

    void OpenDoors()
    {

    }

    void Update()
    {
        if(Door1.transform.eulerAngles.y <= EndRotation1.y)
        {
            if(Door1DirectionCW)
                Door1.transform.eulerAngles += new Vector3(0, 2, 0);
            else
                Door1.transform.eulerAngles -= new Vector3(0, 2, 0);
        }

        if (Door2.transform.eulerAngles.y >= EndRotation2.y)
        {
            if (Door2DirectionCW)
                Door2.transform.eulerAngles += new Vector3(0, 2, 0);
            else
                Door2.transform.eulerAngles -= new Vector3(0, 2, 0);
        }
    }
}
