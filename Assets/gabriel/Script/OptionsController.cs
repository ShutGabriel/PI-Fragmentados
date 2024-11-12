using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public Button optionsButton;
    public GameObject OptionsMenu;
    public Slider VolumeSlider;
    public AudioSource audioSource;
    public GameObject menu1;
    private bool isActive = false;
    private void Start()
    {
       // OptionsMenu.SetActive(false);

        //optionsButton.onClick.AddListener(ToggleOptionsMenu);

        VolumeSlider.onValueChanged.AddListener(AdjustVolume);

        VolumeSlider.value = audioSource.volume;

    }
    private void ToggleOptionsMenu()
    {
        bool isActive = OptionsMenu.activeSelf;
        //optionsButton.OptionsMenu.SetActive(!isActive);

    }

    public void OpenMainMenu()
    {
        isActive = false;
        OptionsMenu.SetActive(false);
        menu1.SetActive(true);
    }

    private void AdjustVolume(float volume)
    {
        audioSource.volume = volume;

    }


   
}
