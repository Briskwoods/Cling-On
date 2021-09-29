using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject m_bloodSplat;

    private void OnTriggerEnter(Collider col)
    {
        switch (col.tag == "Jumper")
        {
            case true:
                col.gameObject.GetComponentInParent<GrabNearestBone>().enabled = false;
                col.gameObject.GetComponent<Animator>().enabled = false;
                col.gameObject.transform.parent.parent = null;
                //Instantiate(m_bloodSplat, this.transform);
                //col.gameObject.SetActive(false);
                break;
            case false: break;
        }


        switch(col.tag == "Player")
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
                other.gameObject.GetComponentInParent<GrabNearestBone>().enabled = false;
                other.gameObject.GetComponent<Animator>().enabled = false;
                other.gameObject.transform.parent.parent = null;
                //other.transform.position = this.transform.position;
                //other.gameObject.SetActive(false);
                break;
            case false: break;
        }
    }
}
