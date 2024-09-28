using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using UnityEngine;
using TMPro;

public class Attributes : MonoBehaviour
{
    public int Health;
    public int Attack;

    public void TakeDamage(int amount)
    {
        Health -= amount;
        DamagePopUpGenerator.current.CreatePopUp(transform.position, amount.ToString(), Color.yellow);
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<Attributes>();
        if(atm != null)
        {
            atm.TakeDamage(Attack);
        }
    }
}
