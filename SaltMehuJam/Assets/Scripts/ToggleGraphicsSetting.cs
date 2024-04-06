using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingToggle : MonoBehaviour
{
    public Toggle graphicsToggle;

    public void ToggleGraphicsSetting()
    {
        int graphicsSetting = graphicsToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("GraphicsSetting", graphicsSetting);
        Debug.Log(PlayerPrefs.GetInt("GraphicsSetting"));
    }
}