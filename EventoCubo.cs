using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoCubo : MonoBehaviour
{
    public delegate void _OnChangeColor(GameObject go);
    public static event _OnChangeColor OnChangeColor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Esfera")
        {
            if(OnChangeColor != null)
            {
                OnChangeColor(gameObject);
            }
        }
    }
}
