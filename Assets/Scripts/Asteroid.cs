﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  [SerializeField]
  private float m_orbit;
  public float Orbit
  {
    get
    {
      return m_orbit;
    }
  }

  [SerializeField]
  private float m_mass;
  public float Mass
  {
    get
    {
      return m_mass;
    }
    set
    {
      m_mass = value;
      updateSize();      
    }
  }

  public float sizeOfOrbit = 0.4f;

  private Vector3 m_atractionForce;
  public Vector3 AtractionForce
  {
    get
    {
      return m_atractionForce;
    }
  }


  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  }

  private void
   updateSize()
  {
    transform.localScale = new Vector3(1, 1, 1) * Mass;
    m_orbit = Mass * 0.5f + (Mass * sizeOfOrbit);
    var playerDir = GameManager.GameMngr.Player.transform.position - transform.position;
    m_atractionForce = playerDir.normalized * (Mass * 1.0f);
   
  }

#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    Gizmos.color = Color.white;
    Gizmos.DrawWireSphere(transform.position, Orbit);

    Gizmos.color = Color.yellow;
    var playerDir = GameManager.GameMngr.Player.transform.position - transform.position;
    var from = transform.position +  (playerDir.normalized *  m_orbit);
    var to = from + m_atractionForce;
    Gizmos.DrawLine(from, to);
  }
 #endif
}
