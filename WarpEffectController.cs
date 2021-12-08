using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpEffectController : MonoBehaviour
{
    [SerializeField] private PlayerMovement m_playerMovement;

    private ParticleSystem m_ps;
    void Start()
    {
        m_ps = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //var main = m_ps.main;

        //float speed = 10f;
        m_ps.emissionRate = Mathf.Clamp(m_playerMovement.m_speed, 10f, 100f);
        
        //main.startSpeed = m_playerMovement.m_speed;
        //switch (m_playerMovement.m_speed < 150)
        //{
        //    case true:
        //        main.startSpeed = 20f;
        //        main.startSize = 0.1f;
        //        break;
        //    case false:
        //        main.startSpeed = 69.42f;
        //        main.startSize = 0.5f;
        //        break;
        //}
    }

    //public void IncreaseSpeed()
    //{
    //    float speed = 10f;
    //    m_ps.emissionRate = Mathf.Clamp(speed, 10f, 100f);
    //}
}
