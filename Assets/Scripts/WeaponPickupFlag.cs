using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickupFlag : MonoBehaviour
{
    public string Weapon;
    public GameObject AxePickup;
    public GameObject SwordPickup;
    public GameObject StaffPickup;
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickupCyl"))
        {
            other.gameObject.SetActive(false);

            switch (Weapon)
            {
                case "Axe":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "Axe";
                    AxePickup.gameObject.SetActive(false);
                    SwordPickup.gameObject.SetActive(false);
                    StaffPickup.gameObject.SetActive(false);
                    break;
                case "Sword":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "Sword";
                    AxePickup.gameObject.SetActive(false);
                    SwordPickup.gameObject.SetActive(false);
                    StaffPickup.gameObject.SetActive(false);
                    break;
                case "Staff":
                    gm.gameObject.GetComponent<GameManager>().currentWeapon = "Staff";
                    AxePickup.gameObject.SetActive(false);
                    SwordPickup.gameObject.SetActive(false);
                    StaffPickup.gameObject.SetActive(false);
                    break;
            }

            gm.gameObject.GetComponent<GameManager>().spawnWeapon();
        }
    }

}