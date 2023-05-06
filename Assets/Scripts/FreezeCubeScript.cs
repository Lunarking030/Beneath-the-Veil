using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCubeScript : MonoBehaviour
{
    public GameObject statKeeper;
    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        if (statKeeper == null)
        {
            statKeeper = GameObject.Find("Stats Cube");
        }

        if (go == null)
        {
            go = gameObject;
        }
        
        StartCoroutine(deleter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator deleter()
    {
        yield return new WaitForSeconds(/*statKeeper.gameObject.GetComponent<Stats>().freezeTime*/10);

        Destroy(go);
    }
}
