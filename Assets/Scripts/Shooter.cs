using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class Shooter : MonoBehaviour
{

    // Reference to projectile prefab to shoot
    public GameObject projectile1;
    public GameObject projectile2;
    public float power = 10.0f;
    public GameObject gm;
    public int damageAmount = 10; // Amount of damage dealt to enemy

    // Reference to AudioClip to play
    public AudioClip shootSFX;

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(5);
    }

    // Update is called once per frame
    void Update()
    {
        // Detect if fire button is pressed
        if (Input.GetButtonDown("Fire1") && gm.gameObject.GetComponent<GameManager>().currentWeapon == "Staff")
        {
            // if projectile is specified
            if (projectile1)
            {
                // Instantiate projectile at the camera + 1 meter forward with camera rotation
                StartCoroutine(Cooldown());
                GameObject newProjectile = Instantiate(projectile1, transform.position + transform.forward, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }

        if (Input.GetButtonDown("Fire2") && gm.gameObject.GetComponent<GameManager>().currentWeapon == "Staff")
        {
            // if projectile is specified
            if (projectile2)
            {
                // Instantiate projectile at the camera + 1 meter forward with camera rotation
                StartCoroutine(Cooldown());
                GameObject newProjectile = Instantiate(projectile2, transform.position + transform.forward, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);


                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                      // play the sound clip through the AudioSource component on the gameobject.
                      // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                    }
                }
            }
        }
    }
}