using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CopyBase : MonoBehaviour
{
    [Tooltip("�p���B�����Ƃ��ɉ���炷")]
    [SerializeField] AudioClip _sound = default;
    [Tooltip("�A�C�e�����R�s�[��")]
    [SerializeField] Item _whatitem = Item.Copy;
    [SerializeField] GameObject _player;
    [Tooltip("�z�[�~���O���鋅�̍ہA�Ώە����z�[�~���O���邩���Ȃ���")]
    public bool notHoming = false;
    [SerializeField] GameObject _hit;
    private GameManager GM;
    public abstract void CopyTech();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //�����蔻��ɂ������
        if(collision.gameObject.tag.Equals("Atari"))
        {
            //�T�E���h���Ăяo����
            if(_sound)
            {
                AudioSource.PlayClipAtPoint(_sound, Camera.main.transform.position);
            }
            //�񋓌^��item���ƁA���̏��Copytech���Ăяo���B
            if(_whatitem == Item.Copy)
            {
                CopyTech();
                Destroy(this.gameObject);
            }
        }
        //�z�[�~���O�ɑΉ����Ă��Ȃ��ǂ�n�ʂɓ�����Ɣj�󂷂�B
        else if(collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        //�z�[�~���O����߂�u���b�N
        if(collision.gameObject.tag == "HomingBlock")
        {
            notHoming = true;
        }
        //�v���C���[�ɓ����邩���G���Ԃ���Ȃ��ƃ_���[�W���󂯂āA�z�[�~���O���~�߁A���G���Ԃ̊J�n�B
        if(collision.gameObject.tag == "Player" && !GM.star)
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
            GM.StartCoroutine("StarTime");
            notHoming = true;
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
