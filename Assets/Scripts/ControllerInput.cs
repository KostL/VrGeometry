using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRController))]
public class ControllerInput : MonoBehaviour
{
  private XRController m_xrController;
  private Func<InputHelpers.Button, bool> m_GetButtonPressed = null;

  public bool GetButton(InputHelpers.Button button)
  {
    switch (button)
    {
      case InputHelpers.Button.Trigger:
        return m_trigger.active;
      case InputHelpers.Button.Grip:
        return m_grip.active;
      default:
        return false;
    }
  }

  public bool GetButtonDown(InputHelpers.Button button)
  {
    switch (button)
    {
      case InputHelpers.Button.Trigger:
        return m_trigger.activatedThisFrame;
      case InputHelpers.Button.Grip:
        return m_grip.activatedThisFrame;
      default:
        return false;
    }
  }

  public bool GetButtonUp(InputHelpers.Button button)
  {
    switch (button)
    {
      case InputHelpers.Button.Trigger:
        return m_trigger.deactivatedThisFrame;
      case InputHelpers.Button.Grip:
        return m_grip.deactivatedThisFrame;
      default:
        return false;
    }
  }

  public void SetButtonPressProvider(Func<InputHelpers.Button, bool> GetButtonPressed)
  {
    m_GetButtonPressed = GetButtonPressed == null ? GetButtonPressedFromInputDevice : GetButtonPressed;
  }

  private class State
  {
    public bool active;
    public bool activatedThisFrame;
    public bool deactivatedThisFrame;
   
    public void Update(bool activeThisFrame)
    {
      activatedThisFrame = false;
      deactivatedThisFrame = false;

      if (activeThisFrame)
      {
        if (!active)
        {
          // Became active this frame
          activatedThisFrame = true;
        }
      }
      else
      {
        if (active)
        {
          // Became inactive this frame
          deactivatedThisFrame = true;
        }
      }

      active = activeThisFrame;
    }

    public State(bool active, bool activatedThisFrame, bool deactivatedThisFrame)
    {
      this.active = active;
      this.activatedThisFrame = activatedThisFrame;
      this.deactivatedThisFrame = deactivatedThisFrame;
    }
  }

  private State m_trigger = new State(false, false, false);
  private State m_grip = new State(false, false, false);

  private bool GetButtonPressedFromInputDevice(InputHelpers.Button button)
  {
    bool pressed = false;
    m_xrController.inputDevice.IsPressed(button, out pressed);
    return pressed;
  }

  private void Update()
  {
    if (m_GetButtonPressed == null)
    {
      m_GetButtonPressed = GetButtonPressedFromInputDevice;
    }

    m_trigger.Update(m_GetButtonPressed(InputHelpers.Button.Trigger));
    m_grip.Update(m_GetButtonPressed(InputHelpers.Button.Grip));
  }

  private void Awake()
  {
    m_xrController = GetComponent<XRController>();
  }
}
