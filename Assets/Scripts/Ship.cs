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

  private Vector3 m_movingDirection;

  private bool isSoundPlaying;

  private List<Vector3> m_forces;
  //Raycast for detect targets
  private Ray m_ray;

  private Vector3 m_finalForce;

  private RaycastHit hit;

  public float Radius
  {
    get
    {
      return 0.8f;
    }
  }

  private void Start()
  {
    m_viewDirection = Vector3.zero;
    m_ray = new Ray(transform.position, m_viewDirection);
  }

  // Update is called once per frame
  void Update()
  {
    rotateShip();
    if(Input.GetButtonDown("attractionButton"))
    {
      m_ray.direction = m_viewDirection;
      Debug.DrawRay(transform.position, m_ray.direction);
      if(Physics.Raycast(m_ray, out hit, m_shootRange))
      {
        var target = hit.collider.gameObject;
        Asteroid asteroid = target.GetComponent<Asteroid>();
        attraction(asteroid);
      }
    }
    move();
  }

  private void FixedUpdate()
  {
    Vector3 finalForce = new Vector3(0, 0, 0);
    if (null != m_forces)
    {
      foreach (var forces in m_forces)
      {
        finalForce += forces;
      }
    }
    transform.position += finalForce * Time.fixedDeltaTime;

    if(m_velocity != 0 && !isSoundPlaying)
    {
      AudioManager.playSound(AudioStuff.Sounds.ShipMovement);
      isSoundPlaying = true;
      AudioManager.changeEffectsVolume(.8f*m_velocity);
      Debug.Log(m_velocity);
    }
  }

  void
  receiveDamage(int _damage)
  {
    m_health -= _damage;
  
      AudioManager.playSound(AudioStuff.Sounds.ShipDamage);
    if(m_health == 0)
    {
      AudioManager.playSound(AudioStuff.Sounds.Explosion);
    }
  }

  void
  addHealth(int _healt)
  {
    m_health += _healt;
    System.Random rand = new System.Random();
    int randomNumber = rand.Next(0, 1);
    //   Debug.Log(randomNumber);
    if (randomNumber == 0)
    {
      AudioManager.playSound(AudioStuff.Sounds.Repair1);
    }
    if (randomNumber == 1)
    {
      AudioManager.playSound(AudioStuff.Sounds.Repair2);
    }
   
  }

#if UNITY_EDITOR
  void 
  OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, 
                    transform.position + m_viewDirection * m_shootRange);
    //Gizmos.DrawLine(transform.position, 
    //                transform.position + m_viewDirection * m_shootRange);
  }
#endif

  void
  rotateShip()
  {
    var xAxis = Input.GetAxis("leftStickX");
    var yAxis = -Input.GetAxis("leftStickY");
    if (xAxis > 0.5f || yAxis > 0.5f ||
      xAxis < -0.5f || yAxis < -0.5f)
    {
      Vector3 newViewDirection = new Vector3(xAxis, yAxis, 0);
      m_viewDirection += newViewDirection * Time.fixedDeltaTime * m_rotationSpeed;
      m_viewDirection.Normalize();

      var a = Mathf.Atan2(yAxis, xAxis) * Mathf.Rad2Deg;
      var q = Quaternion.AngleAxis(a, new Vector3(0, 0, 1));
      var r = Quaternion.Lerp(transform.rotation, q, m_rotationSpeed * Time.fixedDeltaTime);
      transform.rotation = r;

    }
    //transform.forward = m_viewDirection;
    float rot = Mathf.Atan2(Input.GetAxis("leftStickY"), Input.GetAxis("leftStickX"));
    transform.Rotate(new Vector3(0, 0, 1), rot);
  }

  void
  attraction(Asteroid _target)
  {
    Vector3 force;

    if (_target.Mass < m_attractionMassLimit)
    {
       force = seek(_target.transform);
      _target.addForce(force);
    }
    else
    {
      m_finalForce = seek(_target.transform);
    }
  }

  void
  repulsion(Asteroid _target)
  {
    if(_target.Mass < m_repulsionLimit)
    {
      Vector3 force = m_viewDirection * m_repulsionForce;
      _target.addForce(force);
    }
    else
    {

    }
  }

  public void
  addForces(List<Vector3> _forces)
  {
    m_forces = _forces;
  }

  private void OnTriggerEnter(Collider other)
  {
    System.Random rand = new System.Random();
    int randomNumber = rand.Next(0, 1);
    //   Debug.Log(randomNumber);
    if (randomNumber == 0)
    {
      AudioManager.playSound(AudioStuff.Sounds.Hit1);
    }
    if (randomNumber == 1)
    {
      AudioManager.playSound(AudioStuff.Sounds.Hit2);
    }
       Debug.Log("choco wey");
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
  move()
  {
    transform.position += m_finalForce * m_velocity * Time.fixedDeltaTime;
  }

}
