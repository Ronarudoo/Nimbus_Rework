using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public Attributes PlayerAtm;
    public Attributes EnemyAtm;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            PlayerAtm.DealDamage(EnemyAtm.gameObject);
        } 
        if (Input.GetKeyDown(KeyCode.O))
        {
            EnemyAtm.DealDamage(PlayerAtm.gameObject);
        }
    }
}
