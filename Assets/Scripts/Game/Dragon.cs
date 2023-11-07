using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Check")
        {
            Destroy(collision.gameObject);
            _gameManager.score++;
            _gameManager.TextsUpdate();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
            _gameManager.GameOver();
        if(collision.transform.tag == "Finish")
        {
            _gameManager.Save();
            _gameManager.ToMenu();
        }
            
    }
}
