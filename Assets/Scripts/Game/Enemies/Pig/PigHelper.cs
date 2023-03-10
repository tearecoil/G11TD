using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigHelper : MonoBehaviour
{
    // Start is called before the first frame update
    public void FinishAttack()
    {
        GameObject target = transform.parent.GetComponent<AIStateAttack>().GetTarget();
        if (target != null)
        {   
            int damage = transform.parent.GetComponentInChildren<AttackMelee>().damage;
            DamageTaker damageTaker = target.GetComponent<DamageTaker>();
            if (damageTaker != null)
            {
                damageTaker.TakeDamage(damage);
            }
            else if (target.CompareTag("CapturePoint") == true)
            {
                //Debug.Log("Captured");
                Destroy(transform.parent.gameObject);
                EventManager.TriggerEvent("Captured", null, null);
            }
        }
    }
}
