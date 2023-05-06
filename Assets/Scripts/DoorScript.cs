using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float openCost;
    public GameObject statKeeper;
    public TextMeshPro costDisplay;

    // Start is called before the first frame update
    void Start()
    {
        statKeeper = GameObject.Find("Stats Cube");
        costDisplay.SetText("cost\n" + openCost);
        //openCost = 100; //how many Bone Coins it costs in order to open this door
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon") && statKeeper.gameObject.GetComponent<Stats>().coins >= openCost) //if a weapon collides with a Door, and the player has enough Bone Coins
        {
            print("door hit detected");
            statKeeper.gameObject.GetComponent<Stats>().coins -= openCost; //reduce Bone Coins by how much the Door costed
            this.gameObject.SetActive(false); // then the Door will disappear
        }
    }
}