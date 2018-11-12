using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    public bool pickedUp;

    public int weaponNum;

    public float range = 100f;
    public int bulletsPer = 20;
    public int bulletsRemaining;

    public Transform shootPoint;

    public float coolDown = 0.1f;
    float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        if (timer < coolDown)
        {
            timer += Time.deltaTime;
        }

	}

    void Fire()
    {
        if (timer >= coolDown)
        {
            timer = 0.0f;
            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name + " found!");
                bulletsRemaining--;
            }
        }
    }
}
