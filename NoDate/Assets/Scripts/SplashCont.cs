using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class SplashCont : MonoBehaviour
{
    AsyncOperation async;
    void Start()
    {

        //在这里开启一个异步任务，
        StartCoroutine(StartLoading());
    }

    private void Update()
    {

        if (AddForce.isend == true)
        {
            StartCoroutine(Load());
        }
    }
    private IEnumerator StartLoading()
    {

        yield return new WaitForSeconds(0.1f);
        async = SceneManager.LoadSceneAsync("game");
        async.allowSceneActivation = false;//禁止Unity加载完毕后自动切换场景

    }
    private IEnumerator Load()
    {

        yield return new WaitForSeconds(0.5f);
        async.allowSceneActivation = true;
        AddForce.isend = false;

    }


}
