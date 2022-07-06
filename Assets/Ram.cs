using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    [SerializeField] float m_interval = 3f;
    float m_timer;
    [SerializeField] GameObject m_prehab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > m_interval)
        {
            m_timer = 0;
            Instantiate(m_prehab, this.transform.position, this.transform.rotation);
        }
    }
}
