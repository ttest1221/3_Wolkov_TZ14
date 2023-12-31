using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private string keyPlayer = "Nickname";
    private string keyScore = "Score";
    private string keyBestScore = "BestScore";


    public void SaveLeader(List<PlayerData> data)
    {
        PlayerData currentPlayer = GetCurrentPlayer();
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].score < currentPlayer.score)
            {
                PlayerPrefs.SetString(keyPlayer + (i + 1), currentPlayer.nickname);
                PlayerPrefs.SetInt(keyScore + (i + 1), currentPlayer.score);
                PlayerPrefs.SetInt(keyBestScore + (i + 1), currentPlayer.bestScore);
                break;
            }
        }
    }
    
    public void SavePlayer()
    {
        PlayerPrefs.SetString(keyPlayer, GetCurrentPlayer().nickname);
        PlayerPrefs.SetInt(keyScore, GetCurrentPlayer().score);
        if(GetCurrentPlayer().score > PlayerPrefs.GetInt(keyBestScore))
        {
            PlayerPrefs.SetInt(keyBestScore, GetCurrentPlayer().score);
        }
            

    }
    public PlayerData GetCurrentPlayer()
    {
        PlayerData data = new PlayerData() { nickname = _gameManager.nickname, score = _gameManager.score, bestScore = _gameManager.bestScore };
        return data;
    }
}
public class PlayerData
{
    public string nickname;
    public int score;
    public int bestScore;
}
