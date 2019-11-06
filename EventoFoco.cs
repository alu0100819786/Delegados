using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoFoco : MonoBehaviour
{
   /* public Light luz;

    void Start()
    {
        luz = GameObject.FindGameObjectWithTag("Foco").GetComponent<Light>() as Light;
        luz.enabled = false;
    }

    void Update()
    {

    }

    void LightOrNot()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
       
            luz.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            luz.enabled = false;
        }
    }*/
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
