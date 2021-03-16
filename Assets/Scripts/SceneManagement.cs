using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.Events;
using UnityEngine.Audio;
public class SceneManagement : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clipConfirm;
    public void PlayConfirm()
    {
        source.PlayOneShot(clipConfirm);
        
    }

    public void RunDemo()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}