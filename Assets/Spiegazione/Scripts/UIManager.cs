using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour, iObserver
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static UIManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        Player player = playerObject.GetComponent<Player>();

        player.AddObserver(this);
    }

    public void OnPlayerScoreChanged(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
