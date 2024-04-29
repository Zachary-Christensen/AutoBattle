using UnityEngine;

public static class BGUtils
{
    public static (float height, float width) GetScreenSize()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Camera.main.aspect; // aspect = width/height
        return (height, width);
    }

    public static void SetFrameRate()
    {
        Application.targetFrameRate = Mathf.Clamp(30, 60, PlayerPrefs.GetInt("FPS", 60));
    }

    public static void SetFrameRate(int frameRate)
    {
        PlayerPrefs.SetInt("FPS", Mathf.Clamp(30, 60, frameRate));
        SetFrameRate();
    }
}
