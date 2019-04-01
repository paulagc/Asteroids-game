using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        //spawns 4 asteroids coming from middle of all screen edges
        GameObject asteroidRight = Instantiate(prefabAsteroid, new Vector3(ScreenUtils.ScreenRight, 1, 0), Quaternion.identity) as GameObject;
        asteroidRight.GetComponent<Asteroid>().Initialize(Direction.Left);

        GameObject asteroidLeft = Instantiate(prefabAsteroid, new Vector3(ScreenUtils.ScreenLeft, 1, 0), Quaternion.identity) as GameObject;
        asteroidLeft.GetComponent<Asteroid>().Initialize(Direction.Right);

        GameObject asteroidBottom = Instantiate(prefabAsteroid, new Vector3(1, ScreenUtils.ScreenBottom, 0), Quaternion.identity) as GameObject;
        asteroidBottom.GetComponent<Asteroid>().Initialize(Direction.Up);

        GameObject asteroidTop = Instantiate(prefabAsteroid, new Vector3( 1, ScreenUtils.ScreenTop, 0), Quaternion.identity) as GameObject;
        asteroidTop.GetComponent<Asteroid>().Initialize(Direction.Down);

    }

}
