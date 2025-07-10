using UnityEngine;

public static class ApplicationHandler 
{
    public static  void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
