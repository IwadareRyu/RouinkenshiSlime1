using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CopyBase : MonoBehaviour
{
    [Tooltip("パリィしたときに音を鳴らす")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>アイテムかコピーか</summary>
    [SerializeField] Item _whatitem = Item.Copy;
    [SerializeField] GameObject _player;
    public abstract void CopyTech();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //当たり判定にあたると
        if(collision.gameObject.tag.Equals("Atari"))
        {
            //サウンドが呼び出され
            if(_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            //列挙型がコピーだと、リストに保存される。
            if(_whatitem == Item.Copy)
            {
                //Debug.Log("呼ぶ");
                this.transform.position = Camera.main.transform.position;
                GetComponent<Collider2D>().enabled = false;
                _player.gameObject.GetComponent<BoundController>().GetCopy(this);
                //Destroy(this.gameObject);
            }
            //列挙型がitemだと、その場でCopytechを呼び出す。
            else
            {
                CopyTech();
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag.Equals("Wall"))
        {
            Destroy(this.gameObject);
        }
        //if(collision.gameObject.tag.Equals("Player"))
        //{
        //    if (_whatitem == Item.item)
        //    {
        //        CopyTech();
        //        Destroy(this.gameObject);
        //    }
        //}
    }

    enum Item
    {
        /// <summary>コピーした時 </summary>
        Copy,
        /// <summary>アイテムを拾ったとき(BoundControllerでリストが使えないので今のところこれを使う。) </summary>
        item,
    }
}
