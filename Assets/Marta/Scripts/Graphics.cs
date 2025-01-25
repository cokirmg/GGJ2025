using UnityEngine;
using TMPro;

public class Graphics : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("Quality", 3);
        dropdown.value = quality;
        ajustQuality();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ajustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("Quality", dropdown.value);
        quality = dropdown.value;
    }
}
