using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Itens;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ItemCollatableBase i = other.transform.GetComponent<ItemCollatableBase>();
        if(i != null)
        {
            i.gameObject.AddComponent<Magnetic>();
        }
    }
}
