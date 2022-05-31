using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSave : MonoBehaviour
{
    private Historia jogo;
    private SaveController saveGame;
    private DateTime date;
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _title2;

    void Start()
    {
        saveGame = GetComponent<SaveController>();
        _title.text = PlayerPrefs.GetString("save1");
        _title2.text = PlayerPrefs.GetString("save2");
    }

    void OnDisable()
    {
        PlayerPrefs.SetString("save1", _title.text);
        PlayerPrefs.SetString("save2", _title2.text);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void save()
    {
        _title.text = "Save 1: dia " + DateTime.UtcNow;
    }
    public void save2()
    {
        _title2.text = "Save 2: dia " + DateTime.UtcNow;
    }
    public void delete()
    {
        _title.text = "Novo jogo";
        _title2.text = "Novo jogo";
        PlayerPrefs.SetString("save1", _title.text);
        PlayerPrefs.SetString("save2", _title2.text);
        saveGame = GetComponentInChildren<SaveController>();
        saveGame.Delete();
    }
}