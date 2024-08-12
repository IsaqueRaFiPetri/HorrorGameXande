using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerModes
{
    Walking, UIing
}
public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    PlayerModes modes;
    PlayerMovement playMove;
    FirstPersonController controller;

    public UnityEvent OnPause, OnUnpause;

    public bool win;

    void Awake()
    {
        instance = this;
        playMove = GetComponent<PlayerMovement>();
        controller = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        switch (modes)
        {
            case PlayerModes.Walking:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                PlayerInteraction.Instance.enabled = true;
                PlayerInteraction.Instance.RayCast();
                playMove.enabled = true;
                controller.enabled = true;
                break;
            case PlayerModes.UIing:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                PlayerInteraction.Instance.enabled = false;
                playMove.enabled = false;
                controller.enabled = false;
                break;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                modes = PlayerModes.UIing;
                OnPause.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                modes = PlayerModes.Walking;
                OnUnpause.Invoke();
            }
        }

    }

    public void SetPause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void SetUIingMode()
    {
        modes = PlayerModes.UIing;
    }
    public void SetWalkingMode()
    {
        modes = PlayerModes.Walking;
    }
}
