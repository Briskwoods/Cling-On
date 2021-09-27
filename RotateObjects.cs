using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public Transform Target;
    public List<Transform> All_Cling_Points = new List<Transform>();

    [ContextMenu("Execute")]
    public void Execute()
    {
        foreach (Transform Obj in All_Cling_Points)
        {
            Vector3 Pos = Target.position;
            Pos.y = Obj.transform.position.y;

            Obj.transform.LookAt(Pos);
        }
    }
}
