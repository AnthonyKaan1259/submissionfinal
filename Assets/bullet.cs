using UnityEngine;

public class bullet : MonoBehaviour {
    private Transform target;

    public float speed = 70f;
    public GUIText Balance;

    public void chase (Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject); //Destroys the bullet so it doesn't stay on the screen
            return;
        }

        Vector3 direction = target.position - transform.position; //Find the direction that the bullet needs to point in, to look at target
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame) //Length of directiom, distance from bullet to target. If it's less than or equal to the distance from the frame then target is hit.
        {
            TargetHit(); //Call the targethit function if 
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World); //normalise it so moves at constant speed, not dependant on frame rate. Move relative to world space

	}

    void TargetHit()
    {
        Destroy(gameObject);

    }
}
