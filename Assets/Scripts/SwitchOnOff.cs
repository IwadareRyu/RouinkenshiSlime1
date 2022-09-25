using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{
    [SerializeField] GameObject _title;
    [SerializeField] GameObject _timelime;
    [SerializeField] GameObject _sceneLoad;

    private void Start()
    {
        
    }
    public void TimeLineStart()
    {
        _title.gameObject.SetActive(false);
        _timelime.gameObject.SetActive(true);
    }

    public void TimeLineEnd()
    {
        _title.gameObject.SetActive(true);
        StartCoroutine("TimeLineTime");
    }
    public void TimeSceneLoad()
    {
        _sceneLoad.gameObject.SetActive(true);
    }
    public void Skip()
    {
        _title.gameObject.SetActive(true);
        _timelime.gameObject.SetActive(false);
    }
    IEnumerator TimeLineTime()
    {
        yield return new WaitForSeconds(0.5f);
        _timelime.gameObject.SetActive(false);
    }
}
