using UnityEngine;

public class Building : MonoBehaviour {

    public static Building instance;//static, so shared by all instances of the class

    private void Awake() //Awake method called when the program starts
    { 
        instance = this; //Every time the game is run, the building script
    }
    public GameObject turretPrefab; //Public variable which will store the turret game object
    public GameObject turretPrefab2;
    private turrets turretToMake;

    //Property which checks to see if turret to build != null, if not, return true, which means can build.
    public bool canBuild {
        get {
            return turretToMake != null;
        }
    }

    public void BuildTurretLocation (node node)
    {
        if (Player.money < turretToMake.costOfTurret)
        {
            return; //if the player hasn't enough money to build the turret, does nothing
        }
        Player.money = Player.money - turretToMake.costOfTurret; //After condition check, player must therefore have enough for turret, so deduct money from wallet.


        //Placing of turret onto the passed node
        GameObject turret = (GameObject)Instantiate(turretToMake.prefab, node.transform.position + node.position, node.transform.rotation);
        node.turret = turret;

        Debug.Log("Money left" + Player.money);
    }
    public void ChooseTurretToMake (turrets turret)
    {
        turretToMake = turret;
    }
}
