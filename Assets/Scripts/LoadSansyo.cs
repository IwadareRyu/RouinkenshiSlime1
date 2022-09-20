using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSansyo : MonoBehaviour
{
    private SceneLoader _load;
    // Start is called before the first frame update
    public void Load(string load)
    {
        _load = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
        _load.ResultSceneLoad(load);
    }
}
