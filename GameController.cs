﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    GameObject[] Cilindro;
    GameObject[] Cubo;
    GameObject Foco;
    public static GameController controlador;
    float x = 1;
    float y = 1;
    float z = 1;
    int score = 0;

    private Color[] colors = new Color[] { Color.green, Color.red, Color.blue };

  
    void Awake()
    {
      if (controlador == null)
        {
            controlador = this;
            DontDestroyOnLoad(this);
        }  
      else if(controlador != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Foco = GameObject.FindGameObjectWithTag("Foco");
    }
    private void Update()
    {
        LightOrNot(Foco);
    }

    void OnEnable()
    {
        EventoCubo.OnChangeColor += ChangeColor;
        EventoCilindro.OnIncreasePower += IncreasePower;
        EventoFoco.OnLightOrNot += LightOrNot;
    }

    void OnDisable()
    {
        EventoCubo.OnChangeColor -= ChangeColor;
        EventoCilindro.OnIncreasePower -= IncreasePower;
        EventoFoco.OnLightOrNot += LightOrNot;
    }
    
    void ChangeColor(GameObject go)
    {
        Cubo = GameObject.FindGameObjectsWithTag("Cubo");
        x += 1;
        y += 1;
        z += 1;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cubo").Length; i++)
        {
            Cubo[i].transform.localScale = new Vector3(x, y, z);
            Cubo[i].GetComponent<Renderer>().material.color = colors[1];
        }
        score -= 1;
    }

    void IncreasePower(GameObject go)
    {
        score += 10;
        
    }

    void LightOrNot(GameObject go)
    {

        if (Input.GetKey(KeyCode.L))
        {
            Foco.SetActive(true);
            //go.GetComponent<Light>() as Light;
           Debug.Log("hola");
        }
        if (Input.GetKey(KeyCode.N))
        {
            Foco.SetActive(false);
           Debug.Log("Adios");
        }


    }
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 10, 10), "Score = " + score);
        GUILayout.EndArea();
    }


}
