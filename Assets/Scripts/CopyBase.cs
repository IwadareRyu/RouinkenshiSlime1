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
    public bool liftHoming = false;
    [SerializeField] GameObject _hit;
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
            //if(_whatitem == Item.Copy)
            //{
            //    //Debug.Log("�Ă�");
            //    this.transform.position = Camera.main.transform.position;
            //    GetComponent<Collider2D>().enabled = false;
            //    _player.gameObject.GetComponent<BoundController>().GetCopy(this);
            //    //Destroy(this.gameObject);
            //}
            //�񋓌^��item���ƁA���̏��Copytech���Ăяo���B
            if(_whatitem == Item.Copy)
            {
                CopyTech();
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "HomingBlock")
        {
            liftHoming = true;
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5);
        }
    }

    enum Item
    {
        /// <summary>�R�s�[������ </summary>
        Copy,
        /// <summary>�A�C�e�����E�����Ƃ�</summary>
        item,
    }
}
