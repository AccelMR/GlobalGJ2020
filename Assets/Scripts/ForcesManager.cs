using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcesManager : MonoBehaviour
{
  [SerializeField]
  private float m_range;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    var asteroidList = GameManager.GameMngr.AsteroidGenerator.ListaEstrella;
    var player = GameManager.GameMngr.Player;

    List<Vector3> forcesAppliable = new List<Vector3>();

    int i = 0;
    foreach (var asteroid in asteroidList)
    {
      var Distance = (player.transform.position - asteroid.transform.position).magnitude;
      Distance -= player.Radius;
      var minDistance = asteroid.Orbit;
      if (Distance < m_range)
      {
        forcesAppliable.Add(asteroid.AtractionForce);

        i++;
      }
    }



    if (i > 0)
    {
      Debug.Log("Possibility to collide with: " + i);
    }
  }


#if UNITY_EDITOR
  private void OnDrawGizmos()
  {
    if(null == GameManager.GameMngr)
    {
      return;
    }

    var player = GameManager.GameMngr.Player;

    var asteroidList = GameManager.GameMngr.AsteroidGenerator.ListaEstrella;
    foreach (var asteroid in asteroidList)
    {
      var sqrDistance = (player.transform.position - asteroid.transform.position).magnitude;

      if (sqrDistance - 0.86f < asteroid.Orbit)
      {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(asteroid.transform.position, player.transform.position);
      }
    }

  }
#endif
}
