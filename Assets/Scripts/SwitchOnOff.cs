using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{
    [Tooltip("�^�C�����C���̍ۏ��������I�u�W�F�N�g")]
    [SerializeField] GameObject _title;
    [Tooltip("�^�C�����C���̍ہA�\�����������I�u�W�F�N�g")]
    [SerializeField] GameObject _timelime;
    [Tooltip("�^�C�����C���̌�V�[���ړ��������Ƃ��̃I�u�W�F�N�g")]
    [SerializeField] GameObject _sceneLoad;

    private void Start()
    {
        
    }

    /// <summary>�^�C�����C�����X�^�[�g�������Ăяo�����֐��B</summary>
    public void TimeLineStart()
    {
        _title.gameObject.SetActive(false);
        _timelime.gameObject.SetActive(true);
    }

    /// <summary>�^�C�����C�����I�������Ƃ��Ăяo�����֐��B</summary>
    public void TimeLineEnd()
    {
        _title.gameObject.SetActive(true);
        StartCoroutine("TimeLineTime");
    }
    /// <summary>�^�C�����C���̌�A�Ăяo�������Ƃ��Ɏg���֐��B</summary>
    public void TimeSceneLoad()
    {
        _sceneLoad.gameObject.SetActive(true);
    }

    /// <summary>�^�C�����C�����X�L�b�v�������Ƃ��̊֐��B</summary>
    public void Skip()
    {
        _title.gameObject.SetActive(true);
        _timelime.gameObject.SetActive(false);
    }

    /// <summary>���������I�u�W�F�N�g�������܂ł̃^�C�����O�B</summary>
    /// <returns></returns>
    IEnumerator TimeLineTime()
    {
        yield return new WaitForSeconds(0.5f);
        _timelime.gameObject.SetActive(false);
    }
}
