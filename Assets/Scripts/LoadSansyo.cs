using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSansyo : MonoBehaviour
{
    private SceneLoader _load;
    /// <summary>別のシーンに飛んで、ボタンを押したとき、GMのSceneLoaderに接続する用のスクリプト</summary>
    /// <param name="load"></param>
    public void Load(string load)
    {
        _load = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
        _load.ResultSceneLoad(load);
    }
}
