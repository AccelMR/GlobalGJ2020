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

  private Vector2 m_viewDirection;
  private List<Vector2> m_forces;


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
    Vector2 newViewDirection =
      new Vector2(Input.GetAxis("leftStickX"), -Input.GetAxis("leftStickY"));
    m_viewDirection += newViewDirection * Time.fixedDeltaTime * m_rotationSpeed;
    m_viewDirection.Normalize();
  }

  void
  attraction()    
  {
  }

  void
  repulsion()
  {
  }

}
