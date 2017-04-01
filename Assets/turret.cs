using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    private Transform target;

    [Header("Characteristcs")]
    public float rateoffire = 1f; //Fire once each second
    private float attackcountdown = 0f;//Start at 0, fire straight away.
    public float range = 15f; // Range of turret
    public Vector3 positionTurret;

    [Header("Construction fields")]
    public string enemyTag = "Enemy";
    public Transform rotation;
    public GameObject bulletfab;
    public Transform Pointoffire;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //Invoke function at 0 seconds and then every 0.5 secs
	}

    void UpdateTarget() //Renewed search for a target
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //Creates an array storing all the enemies, which will be identified with a string called 'Enemy'.
        float shortestDistance = Mathf.Infinity; //Store shortest distance to an enemy. When no enemy, there's an infinite distance to enemy.
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            //Direction vector
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Distance between turrent position and enemy position
            if (distanceToEnemy < shortestDistance)//Finds enemy closer than any found previously, if less than infinity
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; //Nearest enemy set to the enemy object
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)//If the enemy is in the range and not equal to default null THEN
        {
            target = nearestEnemy.transform; //Target var stores the position of the nearest enemy
        }
        else
        {
            target = null; //If not, then target is set to null
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)//if the target equals null, do nothing
            return;
        transform.LookAt(target); //Unity method, look at target

        if (attackcountdown <= 0f)
        {
            Attack();
            attackcountdown = 1f / rateoffire;
        }

        attackcountdown -= Time.deltaTime; //Every second the attack countdown will be reduced by one
    }

    void Attack()
    {
        GameObject bulletSpawn = (GameObject)Instantiate(bulletfab, Pointoffire.position, Pointoffire.rotation); //Creates an instance of the bullet fab on the position of the 'point of fire'
        bullet bullet = bulletSpawn.GetComponent<bullet>();

        if (bullet != null)
            bullet.chase(target);
    }

    private void OnDrawGizmos() //just used to debug the range of the turrets
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
