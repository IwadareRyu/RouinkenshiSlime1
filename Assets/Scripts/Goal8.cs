using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class Goal8 : MonoBehaviour
{
    private PlayableDirector _playable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���̓����蔻��ɓ������playabledirector���Đ������B
        _playable = GameObject.FindGameObjectWithTag("Director").GetComponent<PlayableDirector>();
        if (collision.gameObject.tag == "Atari")
        {
            _playable.Play();
        }
    }
}
