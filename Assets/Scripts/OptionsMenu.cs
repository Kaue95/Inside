using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider Musica;
    [SerializeField] Slider Narracao;

    public const string MIXER_MUSICA = "Musica";
    public const string MIXER_NARRACAO = "Narracao";

    void Awake()
    {
        Musica.onValueChanged.AddListener(SetVolume);
        Narracao.onValueChanged.AddListener(SetNarracao);
        Musica.value = PlayerPrefs.GetFloat("sliderMusica");
        Narracao.value = PlayerPrefs.GetFloat("sliderNarracao");
    }

    void Start()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSICA_CHAVE, Musica.value);
        PlayerPrefs.SetFloat(AudioManager.NARRACAO_CHAVE, Narracao.value);
        PlayerPrefs.SetFloat("sliderMusica", Musica.value);
        PlayerPrefs.SetFloat("sliderNarracao", Narracao.value);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MUSICA_CHAVE, Musica.value);
        PlayerPrefs.SetFloat(AudioManager.NARRACAO_CHAVE, Narracao.value);
        PlayerPrefs.SetFloat("sliderMusica", Musica.value);
        PlayerPrefs.SetFloat("sliderNarracao", Narracao.value);
        PlayerPrefs.Save();
    }

    void SetVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSICA, Mathf.Log10(value) * 20);
    }

    void SetNarracao(float value)
    {
        mixer.SetFloat(MIXER_NARRACAO, Mathf.Log10(value) * 20);
        Sound.volume = value;
    }
}