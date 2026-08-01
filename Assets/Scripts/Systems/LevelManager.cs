using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using Random = UnityEngine.Random;

public class SelectionManager
{
    ISelectableView _selectedView;
    
    public void Clicked(ISelectableView selectable)
    {
        Debug.Log("Clicked: " + selectable.ToString());
        ISelectableView previousSelectedView = _selectedView;
        _selectedView = selectable;
        selectable.Select(previousSelectedView);
        previousSelectedView?.Deselect();
    }
}

public class LevelManager : MonoBehaviour
{
    private const string SCENE_NAME = "Level";
    [SerializeField] private LevelData[] _levels;
    [SerializeField] private TableView[] _tables;
    [SerializeField] private AdventurerView _adventurerPrefab;
    [SerializeField] private AudioClip _musicIntro;
    [SerializeField] private AudioClip _musicLoop;
    [SerializeField] private AudioClip _ambienceLoop;
    
    private SelectionManager _selectionManager = new SelectionManager();
    
    private static int _currentLevelIndex;

    private void Start()
    {
        InitializeLevel();
    }

    public void InitializeLevel()
    {
        LevelData currentLevelData = _levels[_currentLevelIndex];
        InitializeTables();
        List<AdventurerView> adventurerViews = GetLevelAdventurers(currentLevelData);
        RandomlyPlaceAdventurersOnTables(adventurerViews);
        StartCoroutine(PlayMusic());
    }

    private void InitializeTables()
    {
        foreach (TableView table in _tables)
        {
            table.Initialize(_selectionManager);
        }
    }

    private IEnumerator PlayMusic()
    {
        AudioManager.Instance.StopAllAudio();
        AudioManager.Instance.PlayMusic(_musicIntro, loop: false);
        AudioManager.Instance.PlayMusic(_ambienceLoop, fadeIn: true);
        yield return new WaitForSeconds(_musicIntro.length);
        AudioManager.Instance.PlayMusic(_musicLoop, loop: true);
    }

    private void RandomlyPlaceAdventurersOnTables(List<AdventurerView> adventurerViews)
    {
        adventurerViews.Shuffle();
        for (int i = adventurerViews.Count - 1; i >= 0; i--)
        {
            List<TableView> availableTables = GetAvailableTables();
            if (availableTables.Count <= 0)
            {
                Debug.LogError("Not enough available tables to seat all adventurers.");
                return;
            }
            TableView table = availableTables[Random.Range(0, availableTables.Count)];
            table.Seat(adventurerViews[i]);
        }
    }

    private List<TableView> GetAvailableTables()
    {
        List<TableView> availableTables = new List<TableView>();
        foreach (TableView table in _tables)
        {
            if (table != null && !table.IsFull())
            {
                availableTables.Add(table);
            }
        }
        return availableTables;
    }

    private List<AdventurerView> GetLevelAdventurers(LevelData currentLevelData)
    {
        List<AdventurerView> adventurerViews = new List<AdventurerView>();
        for (int i =0;i<currentLevelData.Adventurers.Length;i++)
        {
            AdventurerView adventurerView = Instantiate(_adventurerPrefab);
            adventurerView.Initialize(currentLevelData.Adventurers[i], _selectionManager);
            adventurerViews.Add(adventurerView);
        }
        return adventurerViews;
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SCENE_NAME);
    }
    
    public void LoadNextLevel()
    {
        _currentLevelIndex++;
        SceneManager.LoadScene(SCENE_NAME);
    }
}
