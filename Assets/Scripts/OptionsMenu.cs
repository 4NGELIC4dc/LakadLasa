using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Button onButton;
    public Button offButton;

    void Start()
    {
        bgmSlider.value = GameSettingsManager.Instance.bgmVolume * 100f;
        sfxSlider.value = GameSettingsManager.Instance.sfxVolume * 100f;

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        onButton.onClick.AddListener(() => ToggleHaptics(true));
        offButton.onClick.AddListener(() => ToggleHaptics(false));
    }

    void SetBGMVolume(float value)
    {
        GameSettingsManager.Instance.bgmVolume = value / 100f;
    }

    void SetSFXVolume(float value)
    {
        GameSettingsManager.Instance.sfxVolume = value / 100f;
    }

    void ToggleHaptics(bool enable)
    {
        GameSettingsManager.Instance.isHapticsEnabled = enable;
    }
}
