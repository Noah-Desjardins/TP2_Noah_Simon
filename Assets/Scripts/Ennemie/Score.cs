using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    int score = 0;

    // Update is called once per frame
    public void Agmenter()
    {
        score++;
        textMeshProUGUI.text = score.ToString();
    }
}
