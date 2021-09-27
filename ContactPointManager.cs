using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPointManager : MonoBehaviour
{
    public List<GrabNearestBone> bones;
    public List<ContactPoint> points;

    void Update()
    {
        foreach(ContactPoint point in points)
        {
            switch (point.isTaken)
            {
                case true:
                    foreach(GrabNearestBone bone in bones)
                    {
                        bone.AvailableBones.Remove(point.transform);
                    }
                    break;
                case false:
                    break;
            }

            foreach (GrabNearestBone bone in bones)
            {
                    switch (!point.isTaken && !bone.AvailableBones.Contains(point.transform))
                    {
                        case true:
                                bone.AvailableBones.Add(point.transform);
                            break;
                        case false:
                            break;
                    }
            }
        }
    }

}
