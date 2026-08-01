using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndgameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _descText;
    [SerializeField] private TMP_Text _totalText;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private Button _resultButton;
    [SerializeField] private TMP_Text _resultButtonText;
    [SerializeField] private Image _dragonImage;

    [SerializeField] private int _rentCoins = 20;
    private int _partyThreshold = 10;

    [SerializeField] private Sprite _win;
    [SerializeField] private Sprite _lose;
    
    public void Initialize(LevelManager levelManager, List<TableView> tables)
    {
        StartCoroutine(AnimateEndgame(levelManager, tables));
    }
    
    private IEnumerator AnimateEndgame(LevelManager levelManager, List<TableView> tables)
    {
        _descText.gameObject.SetActive(false);
        _totalText.gameObject.SetActive(false);
        _resultText.gameObject.SetActive(false);
        _resultButton.gameObject.SetActive(false);
        
        int totalScore = 0;
        yield return new WaitForSeconds(2f);
        _descText.gameObject.SetActive(true);
        foreach (TableView table in tables)
        {
            int characterCount = table.GetAdventurers().Count;
            if (characterCount <= 0)
            {
                continue;
            }
            int tableScore = table.CalculateScore();
            bool passedThreshold = tableScore >= _partyThreshold;
            totalScore += tableScore;
            _descText.text = $"{table.GetAdventurerNames()} fought a dragon " + (passedThreshold ? "and won!" : "and lost...");
            switch (passedThreshold)
            {
                case true:
                    _dragonImage.sprite = _win;
                    break;
                case false:
                    _dragonImage.sprite = _lose;
                    break;
            }
            yield return new WaitForSeconds(3f);
        }
        _totalText.gameObject.SetActive(true);

        int coinsTotal = Mathf.Max(0, totalScore * 10);
        int coinsAfterRent = Mathf.Max(0, coinsTotal - _rentCoins);
        _totalText.text = $"TOTAL COMMISSION EARNINGS: {coinsTotal}";
        yield return new WaitForSeconds(1f);
        _totalText.text = _totalText.text.ToString() + $"\nAFTER RENT: {coinsAfterRent}";
        yield return new WaitForSeconds(2f);
        bool passedLevel = coinsAfterRent < 0;
        _resultText.gameObject.SetActive(true);
        _resultText.text = passedLevel ? "You're broke..." : "Level Won!";
        _resultButton.gameObject.SetActive(true);
        _resultButtonText.text = passedLevel ? "Retry" : "Next Level";
        _resultButton.onClick.RemoveAllListeners();
        _resultButton.onClick.AddListener(() => {
            if (passedLevel)
                levelManager.LoadNextLevel();
            else
                levelManager.RestartLevel();
        });
    }
}
