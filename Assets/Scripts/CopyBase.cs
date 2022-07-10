using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CopyBase : MonoBehaviour
{
    [Tooltip("�p���B�����Ƃ��ɉ���炷")]
    [SerializeField] AudioClip _sound = default;
    /// <summary>�A�C�e�����R�s�[��</summary>
    [SerializeField] Item _whatitem = Item.Copy;
    [SerializeField] GameObject _player;
    public abstract void CopyTech();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�����蔻��ɂ������
        if(collision.gameObject.tag.Equals("Atari"))
        {
            //�T�E���h���Ăяo����
            if(_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }

            //�񋓌^���R�s�[���ƁA���X�g�ɕۑ������B
            if(_whatitem == Item.Copy)
            {
                //Debug.Log("�Ă�");
                this.transform.position = Camera.main.transform.position;
                GetComponent<Collider2D>().enabled = false;
                _player.gameObject.GetComponent<BoundController>().GetCopy(this);
                //Destroy(this.gameObject);
            }
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
        /// <summary>�R�s�[������ </summary>
        Copy,
        /// <summary>�A�C�e�����E�����Ƃ�(���̂Ƃ���Ȃ�) </summary>
        item,
    }
}
