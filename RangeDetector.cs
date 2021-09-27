using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetector : MonoBehaviour
{

    [SerializeField] private int maxRange;
    public List<GameObject> enemies;

    [SerializeField] private Transform m_target;

    void Start()
    {
        GrabNearestBone[] transforms = gameObject.GetComponentsInChildren<GrabNearestBone>();

        foreach (GrabNearestBone t in transforms)
        {
            enemies.Add(t.gameObject);
        }
    }


    void Update()
    {
        switch ((Vector3.Distance(transform.position, m_target.transform.position) < maxRange))
        {
            case true:
                for(int i = 0; i < enemies.Count; i++)
                {
                    switch(enemies[i] != null)
                    {
                        case true:
                            enemies[i].SetActive(true);
                            break;
                        case false:
                            enemies.RemoveAt(i);
                            break;
                    }
                }

                //foreach(GameObject enemy in enemies)
                //{
                //    switch (enemy != null)
                //    {
                //        case true:
                //            enemy.SetActive(true);  
                //            break;
                //        case false:
                //            enemies.Remove(enemy);
                //            break;
                //    }
                //}
                break;
            case false:
                break;
        }

        //switch ((Vector3.Distance(transform.position, m_target.transform.position) > maxRange))
        //{
        //    case true:
        //        foreach (GameObject enemy in enemies)
        //        {
        //            enemy.SetActive(false);
        //        }
        //        break;
        //    case false:
        //        break;
        //}
    }
}
