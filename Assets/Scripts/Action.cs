using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Action : MonoBehaviour
{
    [SerializeField] UnityEvent _action;
    // Start is called before the first frame update
    void Start()
    {
        //���߂ɃC�x���g���s�B
        _action.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
