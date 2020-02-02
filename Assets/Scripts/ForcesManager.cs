using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcesManager : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    if(GameManager.GameMngr.GameState != GAME_STATE.gamePlay)
    {
      return;
    }
    var asteroidList = GameManager.GameMngr.AsteroidGenerator.ListaEstrella;
    var player = GameManager.GameMngr.Player;

    List<Vector3> forcesAppliable = new List<Vector3>();

    foreach (var asteroid in asteroidList)
    {
      var Distance = (player.transform.position - asteroid.transform.position).magnitude;
      var real = asteroid.GetComponent<Asteroid>();
      if (real != null)
      {
        var minDistance = real.Orbit;
        if (Distance - player.Radius < minDistance)
        {
          forcesAppliable.Add(asteroid.GetComponent<Asteroid>().AtractionForce);
        }
      }
    }

    player.addForces(forcesAppliable);
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
      var real = asteroid.GetComponent<Asteroid>();
      if(real == null)
      {
        continue;
      }
      if (sqrDistance - player.Radius < real.Orbit)
      {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(asteroid.transform.position, player.transform.position);
      }
    }

  }
#endif
}
