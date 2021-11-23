using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject m_splatter;
    [SerializeField] private List<Transform> m_splatterPoint;
    
    private void OnTriggerEnter(Collider col)
    {
        switch (col.tag == "Jumper")
        {
            case true:
                Destroy(col.gameObject);
                int randomIndex = Random.Range(0, m_splatterPoint.Count);
                GameObject Obj  = Instantiate(m_splatter,m_splatterPoint[randomIndex].transform);
                Obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                break;
            case false: break;
        }


        switch (col.tag == "Player")
        {
            case true:
                col.gameObject.GetComponent<PlayerMovement>().m_speed = col.gameObject.GetComponent<PlayerMovement>().m_initialSpeed;
                break;
            case false: break;
        }


        switch (col.tag == "Runner")
        {
            case true:
                col.gameObject.GetComponent<RunnerController>().m_speed = col.gameObject.GetComponent<RunnerController>().m_initialSpeed;
                break;
            case false: break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag == "Jumper")
        {
            case true:
                Destroy(other.gameObject);
                Instantiate(m_splatter, transform);
                break;
            case false: break;
        }
    }
}
