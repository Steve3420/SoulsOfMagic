using UnityEngine;
using System.Collections;

public class CameraDetection : MonoBehaviour 
{
	public PlayerSpells m_PlayerSpellScript;
	public GameObject m_PlayerHitbox;
	public GameObject m_Target;

	private bool m_HoldTarget;

	public bool HoldTarget
	{
		get {return m_HoldTarget;}
		set {m_HoldTarget = value;}
	}

	void Start () 
	{
	}

	void Update () 
	{
		Ray LookRay = new Ray();
		LookRay.origin = transform.position;
		LookRay.direction = transform.forward;

		RaycastHit HitMark;

		Physics.Raycast(LookRay, out HitMark);

		if (HitMark.collider != null && m_HoldTarget == false)
		{
			GameObject HitObject = HitMark.collider.gameObject;

			if (HitObject.name != m_PlayerHitbox.name && HitObject.tag == "Hitbox")
			{
				if (HitObject.tag == "Hitbox")
				{
					GameObject NewTarget = HitMark.collider.gameObject;

					m_Target = NewTarget.transform.parent.gameObject;

					m_PlayerSpellScript.m_TargetPlayer = m_Target;
				}
				else
				{
					m_Target = null;
					m_PlayerSpellScript.m_TargetPlayer = null;
					m_HoldTarget = false;
				}
			}
			else
			{
				m_Target = null;
				m_PlayerSpellScript.m_TargetPlayer = null;
				m_HoldTarget = false;
			}
		}
	}
}
