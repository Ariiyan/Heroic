using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText;
    public GameObject congratMenu;

    private int enemyCount = 0;

    private void Start()
    {
        UpdateEnemyCountText();
    }

    public void EnemyHit()
    {
        enemyCount++;

        if (enemyCount >= 5)
        {
            congratMenu.SetActive(true);
            Time.timeScale = 0f; // Pause the game

        }

        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemies Hit: " + enemyCount;
    }
}
