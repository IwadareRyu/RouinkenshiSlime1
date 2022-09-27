using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram : MonoBehaviour
{
    [SerializeField] float m_interval = 3f;
    float _timer;
    [SerializeField] GameObject _prehab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        //���̎��Ԃ���������Object����
        if (_timer > m_interval)
        {
            _timer = 0;
            Instantiate(_prehab, transform.position, transform.rotation);
        }
    }
}
