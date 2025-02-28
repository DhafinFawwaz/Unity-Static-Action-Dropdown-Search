using System;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public static Action OnChicken1Sound;
    public static Action OnChicken2Sound;

    void Start() {
        Invoke(nameof(PlaySound1), 1);
        Invoke(nameof(PlaySound2), 2);
    }

    void PlaySound1() {
        Debug.Log("Chicken 1 sound");
        OnChicken1Sound?.Invoke();
    }

    void PlaySound2() {
        Debug.Log("Chicken 2 sound");
        OnChicken2Sound?.Invoke();
    }

}
