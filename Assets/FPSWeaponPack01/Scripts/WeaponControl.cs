using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

	//All the weapons in the inventory
	public WeaponScript primaryWeapon;
    public WeaponScript secondaryWeapon;

    public WeaponScript selectedWeapon;

	public static WeaponControl instance;


	private void Awake() 
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != null)
		{
			Destroy(this);
		}
	}

	void Start () 
	{
		//At the start we enable the primary weapon and disable the secondary
        primaryWeapon.ActivateWeapon(true);
        secondaryWeapon.ActivateWeapon(false);
        selectedWeapon = primaryWeapon;
        primaryWeapon.manager = this;
        secondaryWeapon.manager = this;
	}
	
	// Update is called once per frame
	void Update () {
		//Switch weapon on TAB
		if (Input.GetKeyDown (KeyCode.Tab)) {
			StartCoroutine ("SwitchWeapon");
		}
	}

	IEnumerator SwitchWeapon () {
		
		if(selectedWeapon == primaryWeapon)
		{
		//Play ther current weapon's Lower animation
		primaryWeapon.GetComponent<Animator> ().CrossFade ("Lower",0.15f);
		
		//Give it time to finish
		yield return new WaitForSeconds (0.5f);

		primaryWeapon.ActivateWeapon(false);
		secondaryWeapon.ActivateWeapon(true);

		//Play ther current weapon's Raise animation
		secondaryWeapon.GetComponent<Animator> ().CrossFade ("Raise",0f);

		selectedWeapon = secondaryWeapon;
		}
		else if(selectedWeapon == secondaryWeapon)
		{
			//Play ther current weapon's Lower animation
		secondaryWeapon.GetComponent<Animator> ().CrossFade ("Lower",0.15f);
		
		//Give it time to finish
		yield return new WaitForSeconds (0.5f);

		primaryWeapon.ActivateWeapon(true);
		secondaryWeapon.ActivateWeapon(false);

		//Play ther current weapon's Raise animation
		primaryWeapon.GetComponent<Animator> ().CrossFade ("Raise",0f);

		selectedWeapon = primaryWeapon;
		}
		
	}

	public void PickUpGun(WeaponControl gun)
	{

	}
}
