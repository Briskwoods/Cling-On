using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger : MonoBehaviour
{
    [SerializeField] private Transform m_target;

    private void OnTriggerEnter(Collider col)
    {
        switch (col.tag == "Jumper")
        {
            case true:
                col.gameObject.GetComponentInParent<GrabNearestBone>().enabled = false;
                col.gameObject.GetComponent<Animator>().enabled = false;
                col.gameObject.GetComponent<SticktoPlayer>().enabled = false;
                col.gameObject.transform.parent.parent = null;
                col.gameObject.GetComponent<MoveToTarget>().target = m_target;
                col.gameObject.GetComponent<MoveToTarget>().enabled = true;
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
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag == "Jumper")
        {
            case true:
                other.gameObject.GetComponentInParent<GrabNearestBone>().enabled = false;
                other.gameObject.GetComponent<Animator>().enabled = false;
                other.gameObject.transform.parent.parent = null;
                other.gameObject.GetComponent<MoveToTarget>().target = m_target;
                other.gameObject.GetComponent<MoveToTarget>().enabled = true;
                break;
            case false: break;
        }
    }
}
