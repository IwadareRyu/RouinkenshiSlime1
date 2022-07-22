using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtobi : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 playerTrams;
    float transx;
    float transy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        playerTrams = (player.transform.position - this.transform.position).normalized;
        FlipX(playerTrams);
        transx = player.transform.position.x;
        transy = player.transform.position.y;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        StartCoroutine("Dammage");
    //    }

    //}
    void FlipX(Vector2 horizontal)
    {

        if (horizontal.x < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    //IEnumerator Dammage()
    //{
    //    for (int i = 0; i < 10; i++)
    //    {
    //        yield return new WaitForSeconds(0.02f);
    //    }
    //}
}
