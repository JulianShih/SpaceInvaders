using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Bullet velocity
    public float bulletSpeed = 10;

    // Gun
    public GameObject gun;

    // bullet prefab
    public GameObject bulletPrefab;

    // Game Manager
    GameManager gm;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        audio = gun.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            
            audio.Play();
            // spawn a new bullet
            GameObject newBullet = Instantiate(bulletPrefab);

            // pass the game manager
            newBullet.GetComponent<BulletController>().gm = gm;

            // position will be that of the gun
            newBullet.transform.position = gun.transform.position;

            // get rigid body
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

            // give the bullet velocity
            bulletRb.velocity = gun.transform.forward * bulletSpeed;
        }
    }
}
