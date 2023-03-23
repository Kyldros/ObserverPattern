using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerEvent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextmesh;

    private void  SetScore(int currentScore)
    {
       scoreTextmesh.text = currentScore.ToString();
    }

    private void Start()
    {
        PlayerEvent.Instance.OnScoreChanged += SetScore;
    }

}
