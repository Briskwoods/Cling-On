using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    [SerializeField]  private Transform nextTarget;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag == "Runner")
        {
            case true:
                other.GetComponent<RunnerController>().target = nextTarget;
                break;
            case false:
                break;
        }
    }
}
