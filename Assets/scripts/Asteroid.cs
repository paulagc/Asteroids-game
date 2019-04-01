using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // apply impulse force to get game object moving
    const float MinImpulseForce = 0.5f;
    const float MaxImpulseForce = 1f;

    //fields for asteroid sprites
    [SerializeField]
    Sprite asteroid1;
    [SerializeField]
    Sprite asteroid2;
    [SerializeField]
    Sprite asteroid3;


    // Start is called before the first frame update
    void Start()
    {



        //selects the asteroid sprite randomly from 3 possibilities
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            GetComponent<SpriteRenderer>().sprite = asteroid1;

        }
        else if (spriteNumber == 1)
        {
            GetComponent<SpriteRenderer>().sprite = asteroid2;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = asteroid3;

        }
    }

    //gives the asteroid a direction and angle to move
    public void Initialize(Direction direction)
    {
      

        if(direction == Direction.Up)
        {
            float angle = Random.Range(75 * Mathf.Deg2Rad, 105 * Mathf.Deg2Rad);
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else if ( direction == Direction.Down)
        {
            float angle = Random.Range(255 * Mathf.Deg2Rad, 295 * Mathf.Deg2Rad);
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else if( direction == Direction.Left)
        {
            float angle = Random.Range(165 * Mathf.Deg2Rad, 205 * Mathf.Deg2Rad);
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }
        else
        {
            float angle = Random.Range(335 * Mathf.Deg2Rad, 360 * Mathf.Deg2Rad);
            float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
            Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
        }

       

    }

    public void StartMoving(float angle)
    {
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);

    }

    //destroy the asteroid on collision with a bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //makes sound when hiting the asteroid by a bullet
            AudioManager.Play(AudioClipName.AsteroidHit);

            if (transform.localScale.x >= 0.5)
            {
                //transforms size of the asteroid in half
                Vector3 originalSize = gameObject.transform.localScale;
                originalSize.x = originalSize.x / 2;
                originalSize.y = originalSize.y / 2;
                originalSize.z = originalSize.z / 2;

                //transforms size of the collider of the asteroid in half
                Vector3 originalCollider = gameObject.GetComponent<CircleCollider2D>().transform.localScale;
                originalCollider.x = originalCollider.x / 2;
                originalCollider.y = originalCollider.y / 2;
                originalCollider.z = originalCollider.z / 2;

                //copies new sizes
                gameObject.transform.localScale = originalSize;
                gameObject.GetComponent<CircleCollider2D>().transform.localScale = originalCollider;

                //creates 2 new smaller asteroids
                GameObject asteroid1 = Instantiate(this.gameObject);
                GameObject asteroid2 = Instantiate(this.gameObject);

                //makes the new asteroids moving randomly
                float angle1 = Random.Range(0, 2 * Mathf.PI);
                asteroid1.GetComponent<Asteroid>().StartMoving(angle1);
                float angle2 = Random.Range(0, 2 * Mathf.PI);
                asteroid2.GetComponent<Asteroid>().StartMoving(angle2);

                //destroys the original big asteroid-
                Destroy(gameObject);
            }
            else
            {   //if the asteroid is too small it gets destroyed
                Destroy(gameObject);
            }





        }

    }



}
