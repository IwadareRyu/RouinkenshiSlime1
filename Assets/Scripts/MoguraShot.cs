using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraShot : MonoBehaviour
{
    [SerializeField] float m_interval = 2.5f;
    float m_timer;
    [SerializeField] GameObject m_prehab;
    bool _timerStop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timerStop)
        {
            m_timer += Time.deltaTime;
        }
        if (m_timer > m_interval)
        {
            m_timer = 0;
            Instantiate(m_prehab, this.transform.position, this.transform.rotation);
            _timerStop = true;
            StartCoroutine(StopTime());
        }
    }
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.5f);
        _timerStop = false;
    }
}
