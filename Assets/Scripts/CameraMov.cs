using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
	[SerializeField]
	public GameObject m_objetivo;

	// Start is called before the first frame update

	private bool m_smooth = true;
	private float m_smoothVel = 0.125f;
	private Vector3 m_offset = new Vector3(0, 0, -32);


	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
	}

	private void FixedUpdate()
	{
    if (Input.GetKey(KeyCode.W))
    {
      m_offset += new Vector3(0, 0, -1);
    }
    if (Input.GetKey(KeyCode.S))
    {
      m_offset += new Vector3(0, 0, 1);
    }

    if (m_offset.z > -1)
    {
      m_offset.z = -1;
    }
    if (m_offset.z < -32)
    {
      m_offset.z = -32;
    }

    Vector3 desiredPosition = m_objetivo.transform.position + m_offset;
    if (m_smooth)
    {
      GetComponentInParent<Transform>().position = Vector3.Lerp(transform.position, desiredPosition, m_smoothVel);
    }
    else
    {
      GetComponentInParent<Transform>().position = desiredPosition;
    }
  }

	private void LateUpdate()
	{
	}
}
