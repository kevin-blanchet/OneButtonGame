using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    private List<string> _scenes = new List<string>();

    private void Awake()
    {
        if (_scenes.Count <= 0) return;
        AddScene();
    }

    void AddScene()
    {
        foreach(string scene in _scenes)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
    }
}
