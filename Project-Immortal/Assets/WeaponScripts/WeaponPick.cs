using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour {

    public GameObject playerGun;
    public GameObject groundGun;
    public GameObject UI;

    public int num = 1;

	// Use this for initialization
	void Start () {
        playerGun.SetActive(false);
        UI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray;
        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            if (hit.collider.tag == "Skorpion VZ")
            {
                UI.SetActive(true);
                if (Input.GetKeyDown (KeyCode.F))
                {
                    groundGun.SetActive(false);
                    playerGun.SetActive(true);
                    playerGun.GetComponent<Weapon>().pickedUp = true;
                    playerGun.GetComponent<Weapon>().weaponNum = num;
                    num++;
                }
            }
            else
            {
                UI.SetActive(false);
            }
        }
	}
}
