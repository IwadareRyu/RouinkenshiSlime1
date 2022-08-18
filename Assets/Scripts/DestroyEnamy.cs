using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnamy : MonoBehaviour
{
    [SerializeField] int _score = 100;
    [SerializeField] int _enemyHP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Atari"))
        {
            FindObjectOfType<GameManager>().AddScore(_score);

            _enemyHP -= 2;
        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score);
            Destroy(collision.gameObject);
            _enemyHP--;
        }
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddLife(-5);
        }
    }
}
