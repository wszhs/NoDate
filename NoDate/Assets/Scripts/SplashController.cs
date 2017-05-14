using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class SplashController : MonoBehaviour
{

    public Slider sliderBar;
    void Start()
    {
        
        //在这里开启一个异步任务，
        StartCoroutine(StartLoading());
        sliderBar.enabled = false;
    }
  
    private IEnumerator StartLoading()
    {
        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync("game");
        async.allowSceneActivation = false;//禁止Unity加载完毕后自动切换场景
    
        //while (async.progress < 0.9f)
        //{
        //    toProgress = (int)async.progress * 100;
        //    Debug.Log(toProgress);
        //    while (displayProgress <=toProgress)
        //    {
        //        ++displayProgress;
        //        sliderBar.value = displayProgress;
        //        yield return new WaitForEndOfFrame();
        //    }
        //}

        toProgress =50;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
      
            Debug.Log(async.progress);

            float value = displayProgress / 50.0f;
            sliderBar.value = value;
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;
    }


}
