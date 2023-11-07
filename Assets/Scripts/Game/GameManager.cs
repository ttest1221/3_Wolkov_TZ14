using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _nicknamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _acceptNicknameButton;
    [SerializeField] private InputField _nicknameInput;
    [SerializeField] private Dragon _dragon;
    public bool gameStarted;
    public LeaderBoard leaderBoard;
    public SaveManager saveManager;
    public float ballsSpeed;
    public bool isLight = false;
    public string nickname;
    public int score;
    public int bestScore;
    
    private void Start()
    {
        _menu.SetActive(false); 
        _game.SetActive(false);
        _gameOverPanel.SetActive(false);
        _acceptNicknameButton.onClick.AddListener(() => AcceptNicknameClick());
    }
    private void AcceptNicknameClick()
    {
        nickname = _nicknameInput.text;
        _game.SetActive(true);
        _menu.SetActive(true);
        _nicknamePanel.SetActive(false);
        gameStarted = true;
        _dragon.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        TextsUpdate();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void TextsUpdate()
    {
        _scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        _menu.SetActive(false);
        _game.SetActive(false);
        _gameOverPanel.SetActive(true);
        if (score > bestScore)
            bestScore = score;
        Save();
        gameStarted = false;
        score = 0;
        TextsUpdate();
    }
    public void Save()
    {
        saveManager.SaveLeader(leaderBoard.GetLeaders());
        saveManager.SavePlayer();
    }
}
