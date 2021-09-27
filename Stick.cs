using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private PlayerMovement m_playerMovement;
    [SerializeField] public float speedReduction = 1f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Jumper")
        {
            ChangeLayersRecursively(collision.gameObject.transform.parent.parent.parent.parent.parent.parent.parent.parent, "AttachedToPlayer");
            m_playerMovement.m_speed -= speedReduction;            
            collision.collider.enabled = false;           
            collision.gameObject.GetComponentInParent<GrabNearestBone>().enabled = true;
            collision.gameObject.GetComponentInParent<Animator>().SetBool("Cling",true);
            collision.gameObject.GetComponentInParent<RandomlyChangeAnimationSpeed>().enabled = true;
            collision.gameObject.GetComponentInParent<JumperController>().isStuck = true;
            


            //collision.gameObject.GetComponentInParent<JumperController>().enabled = false;
            //collision.gameObject.GetComponentInParent<JumperController>().m_selfAnim.SetBool("Cling", true);
            //collision.gameObject.GetComponentInParent<JumperController>().m_selfAnim.SetBool("Run", false);

            //collision.gameObject.transform.parent = this.transform;
            //collision.transform.position = this.transform.position;
            //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //collision.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            //collision.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jumper")
        {
            other.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Jumper" )
        {
            //collision.gameObject.transform.parent = this.transform;
            //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //collision.rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            //collision.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    public void ChangeLayersRecursively(Transform trans, string name)
    {
        Debug.Log(""+trans.gameObject.name);
        trans.gameObject.layer = LayerMask.NameToLayer(name);
        foreach (Transform child in trans.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer(name);
            
        }
    }
}
