using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //sets 2 sec for death time
    const int time = 1;
    Timer DeathTime;

    // Start is called before the first frame update
    void Start()
    {
        //creates a new timer
        DeathTime = gameObject.AddComponent<Timer>();
        //sets the timer duration
        DeathTime.Duration = time;
        //runs the timer
        DeathTime.Run();
        
    }

    //it aplies force to the bullet
    public void ApplyForce(Vector2 thrustForce)
    {
        float magnitude = 5f;
        GetComponent<Rigidbody2D>().AddForce( magnitude * thrustForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //if the time has finished destroy the bullet
        if (DeathTime.Finished)
        {
            Destroy(this.gameObject);
        }
    }
}
