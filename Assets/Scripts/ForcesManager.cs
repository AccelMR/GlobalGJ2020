using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcesManager : MonoBehaviour
{
  private Gen m_asteroidGenerator;
  public Gen AsteroidGenerator
  {
    get
    {
      if (null == m_asteroidGenerator)
      {
        m_asteroidGenerator = FindObjectOfType<Gen>();
      }
      return m_asteroidGenerator;
    }
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    var asteroidList = AsteroidGenerator.ListaEstrella;
    var player = GameManager.GameMngr.Player;

    foreach (var asteroid in asteroidList)
    {
      Vector3 distance = player.transform.position - asteroid.transform.position;
      Debug.Log(distance.magnitude);
    }

  }
}
