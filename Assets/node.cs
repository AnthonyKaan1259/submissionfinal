using UnityEngine;
using UnityEngine.EventSystems;

public class node : MonoBehaviour {

    public Color hoverOver;
    public Color normalColour;
    public GameObject turret;
    public Vector3 position; //Vector3 var which contains offsets entered into the unity ui, will be used to ensure that the turret isn't placed inside of the nodes.
    Building building;

    private void Start()
    {
        building = Building.instance;

    }
    void OnMouseDown()
    {
        if (!building.canBuild)
            return;

        if (EventSystem.current.IsPointerOverGameObject()) //Stops the user from selecting a turrent and placing it on a node. If tis over a game object (the node), then exit.
            return;

        if (turret != null)
        {
            //error message to say that can't be built on
            return;
        }
        building.BuildTurretLocation(this);//passes in this node
    }

    void OnMouseEnter()//every time the mouse or 'touch' enters the collider of the object
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!building.canBuild)
            return;

        GetComponent<Renderer>().material.color = hoverOver; //changes the colour when the mouse hovers over
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = normalColour; //reverts colour back to original
    }
}
