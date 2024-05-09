// we have the libraries here
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour // this is for managing the asteroids placement
{
    [SerializeField] Asteroid asteroid;
    [SerializeField] int numberOfAsteroidsOnAxis  = 5;
    [SerializeField] int gridSpacing = 50;
    

    void Start() // we have start method here
    {
        PlaceAsteroids();   // we call placeasteroids method    
    }


    void PlaceAsteroids()
    { // to place asteroids in grid pattern
        for (int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for (int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for (int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z); // instatiate asteroid at the specified grid posiiton

                }
            }
        }
        }

    void InstantiateAsteroid(int x, int y, int z)
    { // calculate the position for the new asteroid
        Instantiate(asteroid, new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
            transform.position.y + (y * gridSpacing) + AsteroidOffset(),
            transform.position.z + (z * gridSpacing) + AsteroidOffset()),Quaternion.identity, transform);
    }

    
    float AsteroidOffset() // generating a random offset within haf of the grid spacing
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
        
    }
}
