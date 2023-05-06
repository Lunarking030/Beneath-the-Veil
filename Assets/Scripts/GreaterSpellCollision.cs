using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterSpellCollision : MonoBehaviour
{
    public GameObject explosionFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionFX, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }
}
