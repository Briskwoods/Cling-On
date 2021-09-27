using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GrabNearestBone : MonoBehaviour
{
    public List<Transform> AvailableBones = new List<Transform>();
    
    public void Start()
    {
        var nClosest = AvailableBones.OrderBy(t => (t.position - transform.position).sqrMagnitude).Take(1).ToArray();
        transform.SetParent(nClosest[0].GetChild(0));
        transform.localPosition = new Vector3(0,0,0f);
        transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));

    }
}
