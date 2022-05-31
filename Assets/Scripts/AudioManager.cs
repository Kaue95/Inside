using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;

    public const string MUSICA_CHAVE = "musicaVolume";
    public const string NARRACAO_CHAVE = "narracaoVolume"
;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        carregaVolume();
    }

    void carregaVolume()
    {
        float musicaPref = PlayerPrefs.GetFloat(MUSICA_CHAVE, 1f);
        Sound.volume = PlayerPrefs.GetFloat(NARRACAO_CHAVE, 1f);

        mixer.SetFloat(OptionsMenu.MIXER_MUSICA, Mathf.Log10(musicaPref) * 10);
        mixer.SetFloat(OptionsMenu.MIXER_NARRACAO, Mathf.Log10(Sound.volume) * 10);
    }
}