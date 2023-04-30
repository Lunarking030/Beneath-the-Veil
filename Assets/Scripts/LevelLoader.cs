using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject MainCanvas;
    public GameObject LoadingScreen;
    public Slider slider;
    public Text ProgressText;


    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        LoadingScreen.SetActive(true);
        MainCanvas.SetActive(false);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }


}
