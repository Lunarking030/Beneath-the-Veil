using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string currentWeapon;
    public GameObject Axe;
    public GameObject Sword;
    public GameObject Staff;
    public GameObject statKeeper;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

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
                statKeeper.gameObject.GetComponent<Stats>().damage = 15f;
                statKeeper.gameObject.GetComponent<Stats>().secDamage = 25f;
                break;
            case "Sword":
                Sword.SetActive(true);
                statKeeper.gameObject.GetComponent<Stats>().damage = 10f;
                statKeeper.gameObject.GetComponent<Stats>().secDamage = 15f;
                break;
            case "Staff":
                Staff.SetActive(true);
                statKeeper.gameObject.GetComponent<Stats>().damage = 5f;
                statKeeper.gameObject.GetComponent<Stats>().secDamage = 20f;
                break;
        }
    }
}
