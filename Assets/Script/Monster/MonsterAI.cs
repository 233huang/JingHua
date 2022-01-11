using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    MonsterModel thismodel;
    public float speed;
    [SerializeField]
    private float time=5;
    [SerializeField]
    private float attacktime;
    private bool onTrigger=false;

    private void Update()
    {
        if(onTrigger)
            attacktime += thismodel.Attack_speed * Time.deltaTime;

        if (time >= 5)
        {
            float direction = Random.Range(0f, 360f);//在0--360之间随机生成一个单精度小数)
            transform.rotation = Quaternion.Euler(0, 0, direction);//旋转指定度数
            time = 0;
         }
        time += Time.deltaTime;
        transform.Translate(Vector3.up*speed*Time.deltaTime);//向前移动*/
    }

    private void Awake()
    {
        thismodel = this.gameObject.GetComponent<MonsterModel>();
        modelinit();
    }

    private void modelinit()
    {
        thismodel.Life = 100;
        thismodel.attack = 5;
        thismodel.Attack_speed = 1;
        thismodel.defense = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("测试");
        if (collision.gameObject.tag == "Monster")
        {
            onTrigger = true;
            if (attacktime > 1)
            {
                Debug.Log("s");
                collision.gameObject.GetComponent<MonsterModel>().Life -= thismodel.attack;
                attacktime = 0;
            }

        }
    }


}
