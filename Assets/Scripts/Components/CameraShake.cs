using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    private float _delayShake = 0.2f;

    [SerializeField]
    private float _amplitudeShake = 0.55f;

    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;

    void Start()
    {

    }

    void Shake()
    {
        StartCoroutine("CoroutineShake");
    }

    IEnumerator CoroutineShake()
    {
        _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = _amplitudeShake;
        _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_PivotOffset = new Vector3(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1));
        yield return new WaitForSeconds(_delayShake);
        _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }

    private void OnEnable()
    {
        Target._onTargetHit += Shake;
    }

    private void OnDisable()
    {
        Target._onTargetHit -= Shake;
    }
}
