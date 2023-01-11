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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddScene()
    {
        foreach(string scene in _scenes)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
    }
}
