using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterModel : MonoBehaviour
{
    [SerializeField]
    private int life;
    public int Life { 
        get { return life; }
        set {
            life = value;
            if (life <= 0)
            {
                Dead();
            }
        } 
    }

    public int attack { get; set; }

    public int defense { get; set; }

    public int Attack_speed { get; set; }


    void Dead() 
    {
        Destroy(this.gameObject);
    }
}
