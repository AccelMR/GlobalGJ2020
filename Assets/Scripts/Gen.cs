using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    /// <summary>
    /// TAMAÑO MAX BOLAS
    /// </summary>
    public int m_rangoMax=3;
    /// <summary>
    /// TAMAÑO MIN BOLAS
    /// </summary>
    public int m_rangoMin=1;
    Asteroid objetoInstaciado;
    int m_randSize;
    Vector3 m_randSizeVector;
    Vector3 m_randPosVector;


    // Start is called before the first frame update
    void Start()
    {
        m_listaEstrella = new List<Asteroid>();
        
        generar_bolas(m_objeto);
        
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void generar_bolas(Asteroid m_objeto)
    {
        for (int i = 0; i < m_numObjetos; i++)
        {
            m_randSize = UnityEngine.Random.Range(m_rangoMin, m_rangoMax);
            m_randPosVector.x = (UnityEngine.Random.Range(-38, 38));
            m_randPosVector.z = (Random.Range(-38, 38));
            //instanciado
            objetoInstaciado = Instantiate<Asteroid>(m_objeto);
            objetoInstaciado.transform.position = m_randPosVector;
            objetoInstaciado.Mass = m_randSize;
        //  lo meto a la lista

            objetoInstaciado.transform.parent = transform;
            m_listaEstrella.Add(objetoInstaciado);

        }
      
      
    }

}
