using System;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public static Action OnFrog1Sound;
    public static Action OnFrog2Sound;
    public static Action<int> OnFrog3SoundInt;
    public int frogValue = 120;

    void Start() {
        Invoke(nameof(PlaySound1), 1);
        Invoke(nameof(PlaySound2), 2);
        Invoke(nameof(PlaySound3), 3);
    }

    void PlaySound1() {
        Debug.Log("Frog 1 sound");
        OnFrog1Sound?.Invoke();
    }

    void PlaySound2() {
        Debug.Log("Frog 2 sound");
        OnFrog2Sound?.Invoke();
    }

    void PlaySound3() {
        Debug.Log("Frog 3 sound with value: " + frogValue);
        OnFrog3SoundInt?.Invoke(frogValue);
    }

}
