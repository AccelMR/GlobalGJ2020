﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_reparar : MonoBehaviour
{
    public GameObject m_scrap;
    public int vida = 10;
    public int m_cantidadScrap=3;
    Vector3 m_randPosVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            for (int i = 0; i < m_cantidadScrap; i++)
            {
                Instantiate(m_scrap);
                m_randPosVector.x = (UnityEngine.Random.Range(-30, 30));
                m_randPosVector.z = (Random.Range(-30, 30));
                m_scrap.GetComponent<Transform>().position = gameObject.transform.position;
                m_scrap.transform.position += m_randPosVector;
            }
            Destroy(gameObject);
        }
    }
}
