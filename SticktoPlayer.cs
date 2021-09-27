using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SticktoPlayer : MonoBehaviour
{
    public int counter = 0;

    [SerializeField] private float m_speedReduction = 2.5f;
    
    [SerializeField] private GrabNearestBone m_boneScript;
    
    [SerializeField] private RandomlyChangeAnimationSpeed m_randomSpeedScript;
    
    [SerializeField] private JumperController m_myController;
    
    [SerializeField] private PlayerMovement m_player;
    
    [SerializeField] private Animator m_myAnimator;
    
    [SerializeField] private Outline m_myOutline;

    [SerializeField] private SkinnedMeshRenderer m_myRenderer;

    [SerializeField] private Material m_changeMaterial;

    void Start()
    {
        m_myRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }


    void Update()
    {
        switch (counter == 1)
        {
            case true:
                transform.localPosition = new Vector3(0, 0, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                break;
            case false:
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag == "Player" && counter == 0 && m_myAnimator.enabled == true)
        {
            case true:
                counter = 1;
                transform.localPosition = new Vector3(0, 0, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                m_player.m_speed -= m_speedReduction;
                m_myController.isCollided = true;
                m_myAnimator.SetBool("Cling", true);
                m_boneScript.enabled = true;
                m_randomSpeedScript.enabled = true;
                m_myOutline.enabled = true;
                transform.localScale = new Vector3(5f, 5f, 5f);
                transform.localPosition = new Vector3(0f, 0f, 0f);
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                m_myRenderer.material = m_changeMaterial;
                break;
            case false:
                break;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        switch(collision.collider.tag == "Player" && counter == 1)
        {
            case true:
                m_myController.isStuck = true;
                transform.localPosition = new Vector3(0, 0, 0);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                break;
            case false:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Wall")
        {
            case true:
                m_boneScript.enabled = false;
                m_randomSpeedScript.enabled = false;
                transform.parent = other.transform;
                m_myOutline.enabled = false;
                break;
            case false:
                break;
        }
    }

}
