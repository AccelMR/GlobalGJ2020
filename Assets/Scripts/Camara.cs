using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField]
    int m_limiteMax=20;
    [SerializeField]
    int m_limiteMin = 0;
    private float m_speed =1.0f;
    public GameObject ship;
    // Start is called before the first frame update
  Vector3 offset;
    void Start()
    {
       // offset = transform.position - ship.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float mov = Input.GetAxisRaw("Vertical");
        if (mov != 0) {

        transform.position += new Vector3(0,0, mov) * m_speed *Time.fixedDeltaTime;

        }
        
        //Debug.Log("si sirve weee");
        //transform.position = ship.transform.position + offset;
    }
}
