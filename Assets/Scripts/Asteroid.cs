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

  public float sizeOfOrbit = 0.5f;

  // Start is called before the first frame update
  void Start()
  {
    m_orbit = Mass * sizeOfOrbit;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void
   updateSize()
  {
    transform.localScale = new Vector3(1, 1, 1) * Mass;
    m_orbit = Mass * sizeOfOrbit;
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, Orbit + Mass * 0.2f);
  }
}
