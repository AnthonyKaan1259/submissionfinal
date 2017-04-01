using UnityEngine;

public class shop : MonoBehaviour {

    public turrets turret1; //will pass in the turret prefabs in unity ui
    public turrets turret2;
    Building building;

    private void Start()
    {
        building = Building.instance;
    }

	public void ChooseStandardTurret()
    {
        building.ChooseTurretToMake(turret1); //Sets the turret to be built as turret1, passing the prefab as a parameter.
        return;
    }

    public void ChooseStandardTurret2()
    {
        building.ChooseTurretToMake(turret2); //Sets the turret to be built as turret2, passing the prefab as a parameter.
        return;
    }
}
