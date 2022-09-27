using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguraShot : MonoBehaviour
{
    [SerializeField] float m_interval = 2.5f;
    float _timer;
    [Tooltip("��������������鋅")]
    [SerializeField] GameObject _prehab1;
    [SerializeField] GameObject _bikkuri;
    [SerializeField] GameObject _bikkuriprehab;
    [Tooltip("�ђʋ�")]
    [SerializeField] GameObject _prehab2;
    bool _timerStop;
    [Tooltip("�ђʋ�����������������鋅���B")]
    [SerializeField]bool _change;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timerStop)
        {
            _timer += Time.deltaTime;
        }
        if (!_change)
        {
            /*��������������鋅�̃p�^�[��*/
            if (_timer > m_interval)
            {
                _timer = 0;
                Instantiate(_prehab1, this.transform.position, this.transform.rotation);
                _timerStop = true;
                StartCoroutine(StopTime());
            }
        }
        else
        {
            /*�ђʋ��̃p�^�[��*/
            if(_timer > m_interval - 1)
            {
                Instantiate(_bikkuriprehab, _bikkuri.transform.position, Quaternion.identity);
            }
            if (_timer > m_interval)
            {
                _timer = 0;
                Instantiate(_prehab2, this.transform.position, this.transform.rotation);
                _timerStop = true;
                StartCoroutine(StopTime());
            }
        }

    }
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.5f);
        _timerStop = false;
    }
}
