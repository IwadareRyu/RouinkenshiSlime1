using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnamy : MonoBehaviour
{
    [SerializeField] int _score = 100;
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
        if(collision.gameObject.tag == ("Atari"))
        {
            FindObjectOfType<GameManager>().AddScore(_score);
            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
