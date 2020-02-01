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

  private Vector3 m_viewDirection;
  private List<Vector2> m_forces;


  // Start is called before the first frame update
  void Awake()
  {
    m_viewDirection = Vector3.up;
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetAxis("Horizontal") < 0)
    {
      rotateShip();
    }
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

  void 
  OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, m_viewDirection);
  }

  void
  rotateShip()
  {
    Debug.Log("rotando xddxdd");
  }

}
