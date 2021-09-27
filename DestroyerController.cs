using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Jumper")
        {
            case true:
                //other.transform.parent.parent.GetComponentInParent<RangeDetector>().enemies.Remove(other.gameObject);
                Destroy(other.gameObject.transform.parent.gameObject);
                break;
            case false: break;
        }
    }
}
