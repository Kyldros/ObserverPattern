using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, iObservable
{

    [SerializeField] private float speed = 10f;

    private int _score;
    private List<iObserver> observers = new List<iObserver>();

    private int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            foreach (iObserver observer in observers)
            {
                observer.OnPlayerScoreChanged(_score);
            }
        }

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0f, vertical);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Score = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Score++;
            //UIManager.Instance.SetScore(score);
            

            Destroy(other.gameObject);
        }
    }

    public void AddObserver(iObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(iObserver observer)
    {
        observers.Remove(observer);
    }
}
