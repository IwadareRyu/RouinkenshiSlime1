using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    // ///////////////////////
    /* �G�t�F�N�g�̎������� */
    // ///////////////////////

    [SerializeField] int lifeTime;
    int count;

    void Start()
    {
        
    }

    void Update()
    {
        count++;
        if (count > lifeTime) Destroy(gameObject);
    }
}
