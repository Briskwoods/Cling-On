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
        switch (m_playerMovement.m_speed == 150f)
        {
            case true:
                m_ps.emissionRate = 100f;
                break;
            case false:
                break;
        }
        
        switch (m_playerMovement.m_speed <= 149f && m_playerMovement.m_speed <= 140f)
        {
            case true:
                m_ps.emissionRate = 80f;
                break;
            case false:
                break;
        }

        switch (m_playerMovement.m_speed <= 149f && m_playerMovement.m_speed <= 140f)
        {
            case true:
                m_ps.emissionRate = 60f;
                break;
            case false:
                break;
        }

        switch (m_playerMovement.m_speed <= 139f && m_playerMovement.m_speed <= 130f)
        {
            case true:
                m_ps.emissionRate = 40f;
                break;
            case false:
                break;
        }

        switch (m_playerMovement.m_speed <= 129f && m_playerMovement.m_speed <= 120f)
        {
            case true:
                m_ps.emissionRate = 20f;
                break;
            case false:
                break;
        }

        switch (m_playerMovement.m_speed <= 119f && m_playerMovement.m_speed <= 110f)
        {
            case true:
                m_ps.emissionRate = 10f;
                break;
            case false:
                break;
        }


        
        
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
