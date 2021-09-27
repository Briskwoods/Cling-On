using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyChangeAnimationSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.5f , 1.5f);
    }
}
