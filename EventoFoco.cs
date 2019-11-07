using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoFoco : MonoBehaviour
{
 
    public delegate void _OnLightOrNot(GameObject go);
    public static event _OnLightOrNot OnLightOrNot;

    private void LightOrNot()
    {
            if (OnLightOrNot != null)
            {
                OnLightOrNot(gameObject);
            }
    }
}
