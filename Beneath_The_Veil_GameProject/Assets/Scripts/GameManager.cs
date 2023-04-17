using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string currentWeapon;
    public GameObject Axe;
    public GameObject Sword;
    public GameObject Staff;
    
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnWeapon()
    {
        switch (currentWeapon)
        {
            case "Axe":
                Axe.SetActive(true);
                break;
            case "Sword":
                Sword.SetActive(true);
                break;
            case "Staff":
                Staff.SetActive(true);
                break;
        }
    }
}
