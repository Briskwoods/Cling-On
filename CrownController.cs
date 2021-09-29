using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownController : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_playerCrown;
    [SerializeField] private GameObject m_Runner;
    [SerializeField] private GameObject m_RunnerCrown;
    [SerializeField] private Transform finishLine;


    private float playerdistance;
    private float runnerdistance;

    // Update is called once per frame
    void Update()
    {
        playerdistance = Vector3.Distance(m_player.transform.position, finishLine.position);
        runnerdistance = Vector3.Distance(m_Runner.transform.position, finishLine.position);


        switch (playerdistance < runnerdistance)
        {
            case true:
                m_playerCrown.SetActive(true);
                m_RunnerCrown.SetActive(false);
                break;
            case false:
                m_playerCrown.SetActive(false);
                m_RunnerCrown.SetActive(true);
                break;
        }
    }
}
