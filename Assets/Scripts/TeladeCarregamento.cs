using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TeladeCarregamento : MonoBehaviour
{
    public string CenaACarregar;
    public float TempoFixoSeg = 5;
    public enum TipoCarreg {Carregamento, TempoFixo};
    public TipoCarreg TipodeCarregamento;
    public Image barradeCarregamento;
    public Text TextoProgresso;
    private int progresso = 0;
    private string textoOriginal;

    void Start()
    {
        switch (TipodeCarregamento)
        {
            case TipoCarreg.Carregamento:
                StartCoroutine(Cenacarregamento(CenaACarregar));
                break;
            case TipoCarreg.TempoFixo:
               StartCoroutine(TempoFixo (CenaACarregar)); //Tempo fixo
                break;

        }
        if(TextoProgresso != null) { 
        textoOriginal = TextoProgresso.text;
        }
        if(barradeCarregamento != null) { 
        barradeCarregamento.type = Image.Type.Filled;
        barradeCarregamento.fillMethod = Image.FillMethod.Horizontal;
        barradeCarregamento.fillOrigin = (int) Image.OriginHorizontal.Left;
        }
    }
   IEnumerator Cenacarregamento(string cena)
    {
        AsyncOperation carregamento = SceneManager.LoadSceneAsync(cena);
        while (!carregamento.isDone)
        {
            progresso = (int) (carregamento.progress * 100.0f);
            yield return null;
           
        }

    }
    
    IEnumerator TempoFixo(string cena)
    {
        yield return new WaitForSeconds(TempoFixoSeg);
        SceneManager.LoadScene(cena);
    }
    void Update()
    {
        switch (TipodeCarregamento)
        {
            case TipoCarreg.Carregamento:
                break;
            case TipoCarreg.TempoFixo:
                progresso = (int)(Mathf.Clamp((Time.time / TempoFixoSeg),0.0f,1.0f) * 100.0f); 
                break;

                if (TextoProgresso != null)
                {
                    TextoProgresso.text = textoOriginal + " " + progresso + "%";
                }
                if (barradeCarregamento != null)
                {
                    barradeCarregamento.fillAmount = (progresso / 100.0f);
                }
        }
    }
}
