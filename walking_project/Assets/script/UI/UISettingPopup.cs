using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISettingPopup : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider masterSFXSlider;

    protected float m_MasterVolume;
    protected float m_MusicVolume;
    protected float m_MasterSFXVolume;

    protected const float k_MinVolume = -80f;
    protected const string k_MasterVolumeFloatName = "MasterVolume";
    protected const string k_MusicVolumeFloatName = "MusicVolume";
    protected const string k_MasterSFXVolumeFloatName = "MasterSFXVolume";

    public void Open()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public void Close()
    {
        GameManager.Instance.SaveData();
        gameObject.SetActive(false);
    }

    void UpdateUI()
    {
        m_MasterVolume = GameManager.Instance.I_gameInfo.GetWorKData().masterVolume;
        m_MusicVolume = GameManager.Instance.I_gameInfo.GetWorKData().musicVolume;
        m_MasterSFXVolume = GameManager.Instance.I_gameInfo.GetWorKData().masterSFXVolume;

        masterSlider.value = 1.0f - (m_MasterVolume / k_MinVolume);
        musicSlider.value = 1.0f - (m_MusicVolume / k_MinVolume);
        masterSFXSlider.value = 1.0f - (m_MasterSFXVolume / k_MinVolume);
    }

    public void MasterVolumeChangeValue(float value)
    {
        m_MasterVolume = k_MinVolume * (1.0f - value);
        mixer.SetFloat(k_MasterVolumeFloatName, m_MasterVolume);
        GameManager.Instance.I_gameInfo.GetWorKData().masterVolume = m_MasterVolume;
    }

    public void MusicVolumeChangeValue(float value)
    {
        m_MusicVolume = k_MinVolume * (1.0f - value);
        mixer.SetFloat(k_MusicVolumeFloatName, m_MusicVolume);
        GameManager.Instance.I_gameInfo.GetWorKData().musicVolume = m_MusicVolume;
    }

    public void MasterSFXVolumeChangeValue(float value)
    {
        m_MasterSFXVolume = k_MinVolume * (1.0f - value);
        mixer.SetFloat(k_MasterSFXVolumeFloatName, m_MasterSFXVolume);
        GameManager.Instance.I_gameInfo.GetWorKData().masterSFXVolume = m_MasterSFXVolume;
    }

}
