using System.Net;
using UnityEngine;

public class PLayerAttack : MonoBehaviour
{
    public Weapon weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon != null && Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Attack();
        }
    }

    public void LoadWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public void UnloadWeapon()
    {
        weapon = null;
    }
}
