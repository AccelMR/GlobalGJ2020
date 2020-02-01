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

    foreach (var asteroid in asteroidList)
    {
      var distance = player.transform.position - asteroid.transform.position;
      Debug.Log(distance.magnitude);
    }

  }

  private void OnDrawGizmos()
  {
    var player = GameManager.GameMngr.Player;

    Gizmos.color = Color.black;
    Gizmos.DrawWireSphere(player.transform.position, m_range);

  }
}
