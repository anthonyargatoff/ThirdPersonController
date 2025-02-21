using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI textMeshPro;
  private int score = 0;
  private Coin[] coins;

  void Start()
  {
    textMeshPro.text = "Score: " + score;
    coins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
    foreach (Coin coin in coins)
    {
      coin.CollectCoin.AddListener(updateScore);
    }
  }

  void updateScore()
  {
    score++;
    textMeshPro.text = $"Score: " + score;
  }
}
