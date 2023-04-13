using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjActive : MonoBehaviour
{

    public GameObject objtoactive;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objtoactive.SetActive(true);
            Destroy(gameObject);
        }
    }

  


}
