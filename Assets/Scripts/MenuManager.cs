using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEvent startEvent; 
    private void Start()
    {
        startEvent.Invoke();
    }
    public void LoadSceneAdditive()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    public void LeaveSceneOnTimer()
    {
        StartCoroutine(LeaveSceneCoroutine());
    }

    public void WinGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    private IEnumerator LeaveSceneCoroutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.UnloadSceneAsync(1);
    }
}
