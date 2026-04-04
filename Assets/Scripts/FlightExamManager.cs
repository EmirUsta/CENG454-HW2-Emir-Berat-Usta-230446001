using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private AudioSource missionCompleteAudioSource;

    bool hasTakenOff;
    bool threatCleared;
    bool missionComplete;

    public bool ThreatCleared => threatCleared;

    void Start()
    {
        statusText.text = "Status: On Ground";
        missionText.text = "Mission: Take off and clear the danger zone.";
    }

    public void EnterDangerZone()
    {
        hasTakenOff = true;
        threatCleared = false;
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        if (!hasTakenOff) return;
        threatCleared = true;
        statusText.text = "Status: Danger Zone Cleared";
    }

    public void MissionComplete()
    {
        missionComplete = true;
        missionText.text = "Mission: Complete!";
        missionCompleteAudioSource?.Play();
    }

    public void MissionFailed()
    {
        hasTakenOff = false;
        threatCleared = false;
        missionComplete = false;
        statusText.text = "Status: On Ground";
        missionText.text = "Mission: Take off and clear the danger zone.";
    }
}
