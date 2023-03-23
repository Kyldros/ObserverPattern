using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerEvent : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    public static PlayerEvent _instance;
    public static PlayerEvent Instance 
    {
        get
        {
            if (Instance == null)
            {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                _instance = playerObject.GetComponent<PlayerEvent>();
            }
            return _instance;
        }
    }

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        { 
            _score = value;
            OnScoreChanged.Invoke(_score);
        }
    }


    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0f, vertical);
    }

    public delegate void OnScoreChangeFunction(int newScore);
    public event OnScoreChangeFunction OnScoreChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) Score++;
    }

}
