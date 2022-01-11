using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattlefield : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("BattleField");
    }
}
