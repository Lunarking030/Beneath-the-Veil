using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextScenes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NextScenes()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
