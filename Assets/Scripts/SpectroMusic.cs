using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectroMusic : MonoBehaviour
{
    private const int SAMPLE_SIZE = 1024;

    public float rmsValue;
    public float dbValue;
    public float pitch;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[1024];
        spectrum = new float[1024];
        sampleRate = AudioSettings.outputSampleRate;
    }

    private void Update()
    {
        AnalyzeSound();

    }

    private void AnalyzeSound()
    {
        source.GetOutputData(samples, 0);

        //Pega o som (rms)
        int i = 0;
        float sum = 0;
        for(; 1 < SAMPLE_SIZE; i++)
        {
            sum = samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //Pega o valor do banco(msc?)

        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        //pega o spectrum

        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        float maxV = 0;
        var MaxN = 0;
        for (i = 0; i < SAMPLE_SIZE; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                {
                continue;

                maxV = spectrum[i];
                MaxN = 1;
            }

            float freqN = MaxN;
            if(MaxN > 0 && MaxN < SAMPLE_SIZE - 1)
            {
                var dL = spectrum[MaxN - 1] / spectrum[MaxN];
                var dR = spectrum[MaxN - 1] / spectrum[MaxN];
                freqN += 0.5f * (dR * dR - dL * dL);
            }
            pitch = freqN = freqN * (sampleRate / 2) / SAMPLE_SIZE;
            }
                
        }

    }

