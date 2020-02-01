using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Gen : MonoBehaviour
{
  private List<Asteroid> m_listaEstrella;
  public List<Asteroid> ListaEstrella
  {
    get { return m_listaEstrella; }
  }
  [SerializeField]
  Asteroid m_objeto;
  [SerializeField]
  int m_numObjetos;
  Asteroid m_objetoInstanciado;
  int m_randMass;
  [SerializeField]
  Vector3 m_rangoPosicion;
  [SerializeField]
  int m_coeficienteDispersion;
  Vector3 m_asteroidePos;
  [SerializeField]
  int m_iteracionesDispersion;



  // Start is called before the first frame update
  void Start()
  {
    m_listaEstrella = new List<Asteroid>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void generarAsteroides()
  {
    for (int i = 0; i < m_numObjetos; i++)
    {
      m_randMass = UnityEngine.Random.Range(0, 3) + 1;
      m_asteroidePos.x = (UnityEngine.Random.Range(-m_rangoPosicion.x, m_rangoPosicion.x));
      m_asteroidePos.z = (UnityEngine.Random.Range(-m_rangoPosicion.z, m_rangoPosicion.z));
      m_objetoInstanciado = Instantiate<Asteroid>(m_objeto);
      m_objetoInstanciado.transform.position = m_asteroidePos;
      m_objetoInstanciado.Mass = m_randMass;
      m_objetoInstanciado.transform.parent = transform;
      m_listaEstrella.Add(m_objetoInstanciado);
    }
    initDispersion();
  }

  void initDispersion()
  {
    float m_distanciaMinima;
    float m_distanciaActual;
    int[,] m_listaColision = new int[m_numObjetos, m_numObjetos];

    for (int z = 0; z < m_iteracionesDispersion; z++)
    {
      foreach (Asteroid i in m_listaEstrella)
      {
        foreach (Asteroid j in m_listaEstrella)
        {

          m_distanciaMinima = (i.Mass * .5f) + 5;
          m_distanciaActual = (i.transform.position - j.transform.position).magnitude;


          if (m_distanciaActual < m_distanciaMinima)
          {
            m_listaColision[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)] = m_listaEstrella.IndexOf(j);
          }
          else
          {
            m_listaColision[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)] = 0;
          }
        }
      }
      colisionDetectada(m_listaColision);
    }

  }

  void colisionDetectada(int[,] m_listaColision)
  {
    Vector3[,] m_restaDeVectores = new Vector3[m_numObjetos, m_numObjetos];
    foreach (Asteroid i in m_listaEstrella)
    {
      foreach (Asteroid j in m_listaEstrella)
      {

        if (m_listaEstrella.IndexOf(j) == m_listaColision[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)])
        {
          if (m_listaColision[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)].Equals(0))
          {

            m_restaDeVectores[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)] = new Vector3(0, 0, 0);
          }
          else
          {
            m_restaDeVectores[m_listaEstrella.IndexOf(i), m_listaEstrella.IndexOf(j)] = i.transform.position - j.transform.position;
          }
        }
      }
    }
    sumaVectores(m_restaDeVectores);

  }
  void sumaVectores(Vector3[,] m_restaDeVectores)
  {
    Vector3[] m_sumaDeVectores = new Vector3[m_numObjetos];
    for (int i = 0; i < m_numObjetos; i++)
    {
      for (int j = 0; j < m_numObjetos; j++)
      {
        if (m_restaDeVectores[i, j].Equals(0))
        {
          m_sumaDeVectores[i] = new Vector3(0, 0, 0);
        }
        else
        {

          m_sumaDeVectores[i] += m_restaDeVectores[i, j];
        }
      }
    }
    mover(m_sumaDeVectores);
  }

  void mover(Vector3[] m_sumaDeVectores)
  {
    foreach (Asteroid i in m_listaEstrella)
    {
      i.transform.position = i.transform.position + (m_sumaDeVectores[m_listaEstrella.IndexOf(i)] * Time.fixedDeltaTime * m_coeficienteDispersion);
    }
  }
}
