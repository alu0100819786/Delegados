using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoCilindro : MonoBehaviour
{
    public delegate void _OnIncreasePower(GameObject go);
    public static event _OnIncreasePower OnIncreasePower;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Esfera")
        {
            if (OnIncreasePower != null)
            {
                OnIncreasePower(gameObject);
            }
        }
    }
}
