using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform enemyPrefab; //prefab of the enemy to spawn

    public float wavetimer = 5f; //Time between enemy spawns
    private float countdowntimer = 5f;
    private int waveNumber = 0; //

    void Update()
    {
        if (countdowntimer <= 0f)
        {
            StartCoroutine(Wave()); //Calls the wave method defined below
            countdowntimer = wavetimer; //Resets to 5 each time
        }
        //Decrease the countdown timer so the waves of enemies are called, decrease by one each frame
        countdowntimer -= Time.deltaTime; //Amount of time passed since last frame. 

    }

    //Wavemethod, calls the spawn enemy method 
    IEnumerator Wave()
    {
        waveNumber++; //Increase the wave number each time
        for (int i = 0; i < waveNumber; i++) //For integer i = 0 and i less than waveNumber, increase the value of i by one
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }


    //Spawn enemy method
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); //Create an instance of the enemy prefab at spawnpoint
    }

}
