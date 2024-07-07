using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    public GameObject cam;
    private CinemachineVirtualCamera[] cameras;

    private void Awake() {
        cameras = cam.GetComponentsInChildren<CinemachineVirtualCamera>();
    }

    public void Shake(float amplitude, float frequency, float time) {
        StartCoroutine(ShakeRoutine(amplitude, frequency, time));
    }

    private IEnumerator ShakeRoutine(float amplitude, float frequency, float time) {
        CinemachineBasicMultiChannelPerlin perlin = cameras[0].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        perlin.m_AmplitudeGain = amplitude;
        perlin.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(time);
        perlin.m_AmplitudeGain = 0;
        perlin.m_FrequencyGain = 0;
    }
}
