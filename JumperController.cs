using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    private Rigidbody m_rigidbody;

    [SerializeField] private Outline m_myOutline;

    public Animator m_selfAnim;

    [SerializeField] private int m_diveSpreed = 1;
    [SerializeField] private int m_moveSpreed = 10;

    [SerializeField] private int maxRange;
    [SerializeField] private int minRange;

    [SerializeField] private Transform m_target;

    public bool isCollided = false;
    public bool isStuck = false;
    
    // Start is called before the first frame update
    void Start()
    {
        m_selfAnim = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity = (Vector3.zero);
        

        switch ((Vector3.Distance(transform.position, m_target.transform.position) < maxRange) && !(Vector3.Distance(transform.position, m_target.transform.position) > minRange) && !isStuck)
        {
            case true:
                transform.LookAt(m_target);
                transform.Translate(Vector3.forward * m_moveSpreed * Time.deltaTime);
                m_selfAnim.SetBool("Run", true); 
                break;
            case false:
                m_selfAnim.SetBool("Run", false);
                break;
        }

        switch ((Vector3.Distance(transform.position, m_target.transform.position) < minRange) && !isStuck)
        {
            case true:
                m_selfAnim.SetTrigger("Dive");
                break;
            case false: break;


        }


        switch (m_selfAnim.enabled == false && !isStuck)
        {
            case true:
                m_rigidbody.AddForce(Vector3.forward * m_diveSpreed * Time.deltaTime, ForceMode.Impulse);
                this.enabled = false;
                break;
            case false: break;
        }


        switch (isStuck || isCollided)
        {
            case true:
                transform.localPosition = new Vector3(0,0,0);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                m_rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                m_rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                this.enabled = false;
                break;
            case false:
                break;
        }
    }


    public void onDive()
    {
        if (!isStuck)
        transform.Translate(Vector3.forward * m_diveSpreed * Time.deltaTime);
        m_selfAnim.enabled = false;
        //m_myOutline.enabled = true;
    }

    
}
