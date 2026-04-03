using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;

    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private Transform playerTransform;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        playerTransform = other.transform;
        examManager.EnterDangerZone();
        activeCountdown = StartCoroutine(MissileCountdown());
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }
        missileLauncher?.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher?.Launch(playerTransform);
    }
}
