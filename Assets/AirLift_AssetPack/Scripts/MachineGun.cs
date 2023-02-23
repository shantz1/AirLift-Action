using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MachineGun : MonoBehaviour
{
    public GameObject bulletPrefab; // the prefab for the bullet
    public Transform firePoint; // the point from which the bullet is fired
    public float fireRate = 0.1f; // the rate of fire in seconds
    public float reloadTime = 1.5f; // the time it takes to reload in seconds
    public int maxAmmo = 50; // the maximum ammo count
    private int currentAmmo; // the current ammo count
    private float nextFireTime = 0f; // the next time the gun can fire
    private bool isReloading = false; // whether the gun is currently reloading
    private bool isFiring = false; // whether the fire button is being held down
    public Button fireButton; // the UI button for firing
    //public AudioSource shootingSound;
    public AudioSource reloadingingSound;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo; // set the current ammo count to the maximum
        // add an event listener to the fire button to detect when it is pressed and released
        fireButton.onClick.AddListener(FireButtonDown);
        fireButton.onClick.AddListener(FireButtonUp);
    }

    // Update is called once per frame
    void Update()
    {
        // if the gun is not currently reloading and the fire button is being held down and the ammo count is greater than 0
        if (!isReloading && isFiring && currentAmmo > 0)
        {
            // check if the gun can fire again
            if (Time.time >= nextFireTime)
            {
                // fire the gun
                Shoot();
                // set the next fire time based on the fire rate
                nextFireTime = Time.time + fireRate;
                // decrease the ammo count
                currentAmmo--;
            }
        }

        Reload();
    
    }

    public void Shoot()
    {
        // create a new bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("shooting");
        // add force to the bullet to make it move
        //bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * 1000f);
        //shootingSound.pitch = UnityEngine.Random.Range(1f, 1.2f);
        //shootingSound.Play();
        AudioManager.instance.Play("MechineGunSfx");
    }

   public void FireButtonDown()
    {
        // set the firing flag to true
        isFiring = true;
    }

    public void FireButtonUp()
    {
        // set the firing flag to false
        isFiring = false;
    }

    public void Reload()
    {
        // start the reloading coroutine if the ammo count is 0 and the gun is not already reloading
        if (currentAmmo == 0 && !isReloading)
        {
           
            StartCoroutine(ReloadCoroutine());
            

        }
    }

    IEnumerator ReloadCoroutine()
    {
        // set the reloading flag to true
        isReloading = true;

       
        // disable the fire button during the reload
        fireButton.interactable = false;
        // wait for the reload time
        AudioManager.instance.Play("ReloadSfx");

        yield return new WaitForSeconds(reloadTime);
        // set the reloading flag to false
        isReloading = false;
        // set the current ammo count to the maximum
        currentAmmo = maxAmmo;
        // enable the fire button after the reload
        fireButton.interactable = true;
        
    }
}
