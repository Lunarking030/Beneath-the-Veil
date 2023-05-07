using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float speed;
    public float damage;
    public float secDamage;

    public float coins;

    public bool frostEnable;
    public float freezeTime;

    public GameObject shieldAbility;
    public bool shieldActiveFlag = false;

    public Text healthCounter;
    public TextMeshProUGUI boneCounter;
    public GameObject shopMenu;
    private bool shopOpen = false;
    public GameObject hp;
    
    // Start is called before the first frame update
    void Start()
    {   
        health = 100f;
        maxHealth = health;
        speed = 2f;
        damage = 5f;
        secDamage = 10f;

        coins = 0f;

        frostEnable = false;
        freezeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        healthCounter.text = health + " / " + maxHealth;
        boneCounter.SetText(coins + "");

        if (Input.GetKeyDown("2"))
        {
            if (shieldActiveFlag == false)
            {
                shieldAbility.gameObject.SetActive(true);
                shieldActiveFlag = true;
            }
            else
            {
                shieldAbility.gameObject.SetActive(false);
                shieldActiveFlag = false;
            }
        }

        if (Input.GetKeyDown("tab"))
        {
            if (shopOpen==true)
            {
                shopMenu.gameObject.SetActive(false);
                shopOpen = false;
            }

            else
            if (shopOpen== false)
            {
                shopMenu.gameObject.SetActive(true);
                shopOpen = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crowbar"))
        {
            print("Old damage: " + damage);
            damage += 5f;
            print("New damage: " + damage);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("FreezePotion"))
        {
            frostEnable = true;
            freezeTime += 0.25f;
            print("Freeze is now active.");
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("blackCrowbar"))
        {
            this.secDamage += 10f;
            other.gameObject.SetActive(false);
            //print("Debug: secDamage=" + secDamage);
        }

        if (other.gameObject.CompareTag("HealthPotion"))
        {
            health += 100;
            maxHealth += 100;
            other.gameObject.SetActive(false);
        }
    }
}
