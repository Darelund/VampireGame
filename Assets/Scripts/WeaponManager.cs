using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> weapons = new();

    public List<GameObject> GetWeapons => weapons;

    private static WeaponManager instance;


    public static WeaponManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }



    public void UpdateAllWeapons()
    {
        for (int i = 0; i < weapons.Count; i++)
        {

            weapons[i].GetComponent<BaseWeapon>().UpdateWeapon(); 
        }
    }
}
