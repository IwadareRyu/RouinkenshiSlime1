using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    [SerializeField]float m_deadtime;
    // Start is called before the first frame update
    void Start()
    {
        //���̎��Ԃ��o�����玩�g��j��B
        Destroy(this.gameObject, m_deadtime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
