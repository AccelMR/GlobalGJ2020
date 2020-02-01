using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  private float m_orbit;
  public float Orbit
  {
    get
    {
      return m_orbit;
    }
  }

  private float m_mass = 3;
  public float Mass
  {
    get
    {
      return m_mass;
    }
    set
    {
      m_mass = value;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    transform.localScale *= Mass;
    m_orbit = Mass * 0.5f;
  }

  // Update is called once per frame
  void Update()
  {

  }
}
