using System.Collections;
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
    transform.localScale *= Mass;
    m_orbit = Mass * 0.7f;
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, Orbit);
  }
}
