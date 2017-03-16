using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ElementalSlot : MonoBehaviour
{
    

    public PlayerScript Player;

	public Image FireImage;
	public Image WaterImage;
	public Image EarthImage;
	public Sprite EmtyImage;

	public Image Slot1;
	public Image Slot2;
	public Image Slot3;

    private PlayerCharges.Element Slot1State = PlayerCharges.Element.Emty;
    private PlayerCharges.Element Slot2State = PlayerCharges.Element.Emty;
    private PlayerCharges.Element Slot3State = PlayerCharges.Element.Emty;

    void Start ()
    {
		Slot1.sprite = FireImage.sprite;
		Slot2.sprite = FireImage.sprite;
		Slot3.sprite = FireImage.sprite;
	}
	
	void Update ()
    {

    }
    

    public void ChangeState(PlayerCharges.Element ele)
    {
        Slot3State = Slot2State;
		Slot3.sprite = Slot2.sprite;

        Slot2State = Slot1State;
		Slot2.sprite = Slot1.sprite;

		Slot1State = ele;

        switch (ele)
        {
			case PlayerCharges.Element.Fire:
			Slot1.sprite = FireImage.sprite;
                break;
            case PlayerCharges.Element.Water:
			Slot1.sprite = WaterImage.sprite;
                break;
            case PlayerCharges.Element.Earth:
			Slot1.sprite = EarthImage.sprite;
                break;
            case PlayerCharges.Element.Emty:
                break;
            default:
                break;
        }
    }
}
