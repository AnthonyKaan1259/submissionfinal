using UnityEngine;

public class enemyspawn : MonoBehaviour
{

    public Transform Enemy1; //prefab of the enemy to spawn

    public float wavetimer = 5f; //Time between enemy spawns
    private float countdowntimer = 5f;
    private int waveNumber = 1; //
    public Transform spawnPoint;

    void Update()
    {
        if (countdowntimer <= 0f)
        {
            Wave(); //Calls the wave method defined below
            countdowntimer = wavetimer; //Resets to 5 each time
        }
        //Decrease the countdown timer so the waves of enemies are called, decrease by one each frame
        countdowntimer -= Time.deltaTime; //Amount of time passed since last frame. 

    }

    //Wavemethod, calls the spawn enemy method 
    void Wave()
    {
        for (int i = 0; i < waveNumber; i++) //For integer i = 0 and i less than waveNumber, increase the value of i by one
        {
            SpawnEnemy();
        }
        waveNumber++; //Increase the wave number each time
    }


    //Spawn enemy method
    void SpawnEnemy()
    {
        Instantiate(Enemy1, spawnPoint.position, spawnPoint.rotation); //Create an instance of the enemy model at spawnpoint
    }

}
