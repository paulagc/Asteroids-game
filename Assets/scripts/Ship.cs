using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour

{

    Rigidbody2D shipRigidBody;

    [SerializeField]
    GameObject prefabBullet;

    [SerializeField]
    GameObject hud;

    //movement direction
    Vector2 thrustDirection = new Vector2(1, 0);
    //force applied
    const float ThrustForce = 6f;
    //amount of rotation
    const float RotateDegreesPerSecond = 40;


    // Start is called before the first frame update
    void Start()
    {
        //gets the rigid body component of the ship
        shipRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //gets the input for rotation
        float rotationInput = Input.GetAxis("Rotate");

        //if there's rotation input
        if(rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            //rotate the ship 
            transform.Rotate(Vector3.forward, rotationAmount);

            float direction = transform.eulerAngles.z;
            direction *= Mathf.Deg2Rad;

            thrustDirection.x = Mathf.Cos(direction);
            thrustDirection.y = Mathf.Sin(direction);
        }

        //when pressing this button ship shoots a bullet
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject bullet = Instantiate(prefabBullet, gameObject.transform.position, Quaternion.identity);

            bullet.GetComponent<Bullet>().ApplyForce(shipRigidBody.velocity);
            //plays the shooting audio
            AudioManager.Play(AudioClipName.PlayerShot);
        }
    }

    //reacts to the thrust input
    void FixedUpdate()
    {
        float thrustInput = Input.GetAxis("Thrust");
        if (thrustInput != 0)
        {
            //adds thrust force to the ship given a direction
            shipRigidBody.AddForce(ThrustForce * thrustDirection);
        }
    }

    //destroy the ship on collision with an asteroid
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Asteroid")
        {
            hud.GetComponent<HUD>().StropGameTimer();
            AudioManager.Play(AudioClipName.PlayerDeath);
            Destroy(this.gameObject);
        }

    }


}

