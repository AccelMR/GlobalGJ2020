﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
  [SerializeField]
  public int m_health;

  [SerializeField]
  float m_shootRange;

  [SerializeField]
  int m_shootAngle;

  [SerializeField]
  int m_ammo;

  [SerializeField]
  float m_rotationSpeed;

  [SerializeField]
  float m_velocity;

  [SerializeField]
  float m_repulsionForce;

  //The limit of the mass of the target that can be attracted 
  [SerializeField]
  float m_attractionMassLimit;

  //The limit of the mass of the target that can be repulsed
  [SerializeField]
  float m_repulsionLimit;

  private Vector3 m_viewDirection;
  private List<Vector3> m_forces;
  //Raycast for detect targets
  private Ray m_ray;

  private Vector3 m_finalForce;

  private RaycastHit hit;

  public float Radius
  {
    get
    {
      return 0.86f;
    }
  }

  private void Start()
  {
    m_viewDirection = transform.forward;
    m_ray = new Ray(transform.position, m_viewDirection);
  }

  // Update is called once per frame
  void Update()
  {
    rotateShip();
    if(Input.GetButtonDown("attractionButton"))
    {
      m_ray.direction = m_viewDirection;
      
      Debug.DrawRay(transform.position, m_ray.direction * m_shootRange);

      if(Physics.Raycast(m_ray, out hit, m_shootRange))
      {
        var target = hit.transform;
        m_finalForce = attraction(target);
      }
    }
    if(m_finalForce != Vector3.zero)
    {
      move(m_finalForce);
    }
    //m_finalForce = Vector3.zero;
  }

  void
  receiveDamage(int _damage)
  {
    m_health -= _damage;
  }

  void
  addHealth(int _healt)
  {
    m_health += _healt;
  }

#if UNITY_EDITOR
  void 
  OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, 
                    transform.position + m_viewDirection * m_shootRange);
  }
#endif

  void
  rotateShip()
  {
    Vector3 newViewDirection =
      new Vector3(Input.GetAxis("leftStickX"), Input.GetAxis("leftStickY"), 0 );
    m_viewDirection += newViewDirection * Time.fixedDeltaTime * m_rotationSpeed;
    m_viewDirection.Normalize();
    transform.forward = m_viewDirection;
  }

  Vector3
  attraction(Transform _target)
  {
    Vector3 force;
/*
    if (_target.Mass < m_attractionMassLimit)
    {
       force = seek(_target.transform);
      //_target.addForce(force);
    }*/
    //else
    //{
      return force = seek(_target);
    //}
  }

  void
  repulsion(Asteroid _target)
  {
    if(_target.Mass < m_repulsionLimit)
    {
      Vector3 force = m_viewDirection * m_repulsionForce;
      //_target.addForce(force);
    }
    else
    {
      
    }
  }

  public void
  addForces(List<Vector3> _forces)
  {

  }

  Vector3
  seek(Transform _target)
  {
    Vector3 forceV = _target.position - transform.position;
    forceV.Normalize();
    forceV *= m_velocity;
    return forceV;
  }

  void
  move(Vector3 finalForce)
  {
    float distance = (transform.position - hit.transform.position).magnitude;
    if(distance < 0.1f)
    {
      m_finalForce = Vector3.zero;
    }
    transform.position += finalForce * m_velocity * Time.fixedDeltaTime;
    
  }

}
