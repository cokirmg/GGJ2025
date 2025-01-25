using UnityEngine;
using UnityEngine.UI;


public class Brightness : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image BrightnessPanel;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        BrightnessPanel.color = new Color(BrightnessPanel.color.r, BrightnessPanel.color.g, BrightnessPanel.color.b, slider.value);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeBrightness(float brightValue)
    {
        sliderValue = brightValue;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
        BrightnessPanel.color = new Color(BrightnessPanel.color.r, BrightnessPanel.color.g, BrightnessPanel.color.b, slider.value);
    }
}
