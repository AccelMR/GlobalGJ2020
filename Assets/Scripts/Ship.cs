using System.Collections;
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

  public float Radius
  {
    get
    {
      return 0.86f;
    }
  }

  // Update is called once per frame
  void Update()
  {
    rotateShip();
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
      new Vector3(Input.GetAxis("leftStickX"), 0, Input.GetAxis("leftStickY") * -1);
    m_viewDirection += newViewDirection * Time.fixedDeltaTime * m_rotationSpeed;
    m_viewDirection.Normalize();
    transform.forward = m_viewDirection;
  }

  void
  attraction(Asteroid _target)
  {
    Vector3 force;
    if (_target.Mass < m_attractionMassLimit)
    {
       force = seek(_target.transform);
      //_target.addForce(force);
    }
    else
    {
      force = seek(transform);
      transform.position += force * Time.fixedDeltaTime;
    }
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
    Vector3 forceV = transform.position - _target.position;
    forceV.Normalize();
    forceV *= m_velocity;
    return forceV;
  }

}
