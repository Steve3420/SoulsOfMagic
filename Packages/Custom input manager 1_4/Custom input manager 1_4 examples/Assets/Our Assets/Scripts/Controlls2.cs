using UnityEngine;
using System.Collections;

public class Controlls2 : MonoBehaviour {

    public custom_inputs inputManager;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    
    {
        inputhandling();
	}


    void inputhandling()
    {
        // here we put the controlls, every 'isInput[]' matches its discriptionstring number,
        // so if discription 0 is "Up" then isInput[0] should get the 'UP' code

        // inputkey 0 (for example: Up)
        //--------------------
        if (inputManager.isInput[0])
        {
            inputManager.analogFeel_up += inputManager.analogFeel_sensitivity;
            inputManager.analogFeel_up *= Time.deltaTime;
            if (inputManager.analogFeel_up >= 50f) { inputManager.analogFeel_up = 50f; }
            rigidbody.AddRelativeForce(Vector3.forward * inputManager.analogFeel_up); // 
        }
      
        // inputkey 1 (for example: Down)
        //--------------------
        if (inputManager.isInput[1])
        {
            inputManager.analogFeel_down += inputManager.analogFeel_sensitivity;
            inputManager.analogFeel_down *= Time.deltaTime;
            if (inputManager.analogFeel_down >= 50f) { inputManager.analogFeel_down = 50f; }
            rigidbody.AddRelativeForce(Vector3.back * inputManager.analogFeel_down); // 
        }
      
        // inputkey 2 (for example: Left)
        //--------------------
        if (inputManager.isInput[2])
        {
            inputManager.analogFeel_left += inputManager.analogFeel_sensitivity;
            inputManager.analogFeel_left *= Time.deltaTime;
            if (inputManager.analogFeel_left >= 50f) { inputManager.analogFeel_left = 50f; }
            rigidbody.AddRelativeForce(Vector3.left * inputManager.analogFeel_left); // 

        }
      

        // inputkey 3 (for example: Right)
        //--------------------
        if (inputManager.isInput[3])
        {
            inputManager.analogFeel_right += inputManager.analogFeel_sensitivity;
            inputManager.analogFeel_right *= Time.deltaTime;
            if (inputManager.analogFeel_right >= 50f) { inputManager.analogFeel_right = 50f; }
            rigidbody.AddRelativeForce(Vector3.right * inputManager.analogFeel_right); // 

        }
      
        // inputkey 4 (for example: Jump)
        //--------------------
        if (inputManager.isInputDown[4])
        {
            // put yr code here to make your character jump
            rigidbody.AddRelativeForce(0, 3000 * Time.deltaTime, 0);
        }

        // etc....

        // if you want to use the real analog input from a joystick then you need to use something like :
        // speed =  Input.GetAxis(inputManager.joystickString[n]) - where n is the inputkey - this will only work if a 
        // joystick is set as input, so you need to check if inputManager.joystickActive[n]==true first
        // this is in my opinion only needed for a few games,but the support is there if you need it.
    }


}
