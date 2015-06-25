using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {

    public Color StartTransitionColor;
    public int StartTransitionDepth;
    public float StartTransitionTime;

    public Color EndTransitionColor;
    public int EndTransitionDepth;
    public float EndTransitionTime;

    public static GameStateScript Instance {
        get;
        set;
    }

    public void EndLevelTransition() {
        FadeScreenScript.Instance.FadeInBackground(EndTransitionColor, EndTransitionDepth, EndTransitionTime, false, EndLevel);
    }

    private void EndLevel() {
        Application.LoadLevel(Application.loadedLevel + 1); 
    }

    private void StartLevel() {
        PlayerSpawnerScript.Instance.SpawnPlayer(EndTransitionColor, EndTransitionTime, EndTransitionDepth);
        FadeScreenScript.Instance.SetCurrentBackgroundColor(StartTransitionColor, StartTransitionDepth);
        FadeScreenScript.Instance.FadeOutBackground(StartTransitionTime, true, null);
    }

    public void RestartLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        StartLevel();
    }
}
