using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMonster : MonoBehaviour
{
    private GameObject monster;
    private const string monster_path= "Monster";

    public void BuildMonster()
    {
        monster = Resources.Load(monster_path) as GameObject;
        Instantiate(monster, new Vector3(0,0,0), Quaternion.identity);
    }
}
