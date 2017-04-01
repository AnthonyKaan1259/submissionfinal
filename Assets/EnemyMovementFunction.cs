using UnityEngine;

public class EnemyMovementFunction : MonoBehaviour {
    public float speed = 10f; //float to allow decimal values

    private Transform target;
    private int navigationIndex = 0; //Current waypoint to move to

    private void Start() //local method
    {
        target = Navigation.waypoints[0]; //Target = index 0 in array made in navigation script.
    }

    private void Update()// Every frame called
    {
        //direction vector, gives length and direction
        Vector3 direction = target.position - transform.position; //To get the direction from enemy to target waypoint
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //Moves transform object in direction and distance of translation. Normalized used to keep the same speed. Delta time ensures that the movement speed of the object isn't dependent on the frame rate. Delta time is the time from the last frame, so computers with different frame rates move at same pace, not super fast or super slow. SPace to move in is relative to the world space.
        transform.LookAt(target); //Changes the enemy object to 'look' at the next waypoint. Revised from earlier version, now applies to all waypoints including first.
        if (Vector3.Distance(transform.position, target.position) <= 0.2f) //if the distance from the enemy object (transform) is less than or equal 0.2 from the target position then call the next waypoint method
        {
            NextWayPoint();
        }
    }

    void NextWayPoint()
    {
        if (navigationIndex >= Navigation.waypoints.Length) //if the index is greater than or equal to total length of waypoint array, call finish function, no more waypoints.
        {
            finish();
            return; //ensures that object is destroyed before the next code executes.
        }
        navigationIndex = navigationIndex + 1;//Increment the navigationIndex by one
        target = Navigation.waypoints[navigationIndex]; //Navigationindex value becomes the index value in the waypoints array, so the target becomes the next waypoint.
        //transform.LookAt(target); OLD, doesn't apply for the first waypoint
    }

    void finish()
    {
        Player.health = Player.health - 1; //decrease player health by one
        Destroy(gameObject); //destroy the enemy to increase performance and prevent index error from occuring
    }
}
