using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    private TextMeshProUGUI _txtScore;
    // Start is called before the first frame update
    void Start()
    {
        _txtScore = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _txtScore.text = Math.Floor(GameManager.GameManagerInstance.score).ToString("000000000000");
    }
}
