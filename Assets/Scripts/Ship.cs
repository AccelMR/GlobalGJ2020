using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
  [SerializeField]
  public int m_health;

  [SerializeField]
  float m_shootDistance;

  [SerializeField]
  int m_shootAngle;

  [SerializeField]
  int m_ammo;

  [SerializeField]
  float m_rotationSpeed;

  [SerializeField]
  float m_velocity;

  //The limit of the mass of the target that can be attracted 
  [SerializeField]
  float m_attractionMassLimit;

  //The limit of the mass of the target that can be repulsed
  [SerializeField]
  float m_repulsionLimit;

  private Vector2 m_viewDirection;
  private List<Vector3> m_forces;

  public float Radius
  {
    get
    {
      return 0.8f;
    }
  }


  // Start is called before the first frame update
  void Awake()
  {
    m_viewDirection = Vector2.up;
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
    Gizmos.DrawLine(transform.position, m_viewDirection);
  }
#endif

  void
  rotateShip()
  {
   // Vector2 newViewDirection =
   //   new Vector2(Input.GetAxis("leftStickX"), -Input.GetAxis("leftStickY"));
   // m_viewDirection += newViewDirection * Time.fixedDeltaTime * m_rotationSpeed;
   // m_viewDirection.Normalize();
  }

  void
  attraction(Asteroid _target)
  {
    if (_target.Mass < m_attractionMassLimit)
    {
    
    }
  }

  void
  repulsion(Asteroid _target)
  {
    if(_target.Mass < m_repulsionLimit)
    {

    }
  }

  public void
  addForces(List<Vector3> _forces)
  {

  }

}
