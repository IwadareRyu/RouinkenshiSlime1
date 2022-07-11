using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    [SerializeField] GameObject Button;
    [SerializeField] GameObject Goaltext;
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
        if (collision.gameObject.tag == "Player")
        {
            Button.gameObject.SetActive(true);
            Goaltext.gameObject.SetActive(true);
        }
    }
}
