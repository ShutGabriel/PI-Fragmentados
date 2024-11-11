using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Ui;

public class OptionsController : MonoBehaviour
{
    public Button BT_Options;
    public GameObject OptionsMenu;
    public Slider VolumeSlider;
    public AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        OptionsMenu.SetActive(false);

        Bt_Options.onClick.AddListener(ToggleOptionsMenu);

        VolumeSlider.onValueChanged.AddListener(AdjustVolume);

        VolumeSlider.value = audioSource.volume;

    }
    private void ToggleOptionsMenu()
    {
        bool isActive = OptionsMenu.activeSelf;
        options.Menu.SetActive(!isActive);

    }

    private void AdjustVolume(float volume)
    {
        audioSource.volume = volume;

    }
}
