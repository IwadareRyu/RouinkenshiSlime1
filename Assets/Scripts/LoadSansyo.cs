using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSansyo : MonoBehaviour
{
    private SceneLoader _load;
    /// <summary>�ʂ̃V�[���ɔ��ŁA�{�^�����������Ƃ��AGM��SceneLoader�ɐڑ�����p�̃X�N���v�g</summary>
    /// <param name="load"></param>
    public void Load(string load)
    {
        _load = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
        _load.ResultSceneLoad(load);
    }
}
