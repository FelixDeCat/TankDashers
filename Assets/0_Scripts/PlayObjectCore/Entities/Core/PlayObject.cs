﻿using UnityEngine;

public abstract class PlayObject : MonoBehaviour
{
    protected bool canupdate;
    public void On() { canupdate = true; OnTurnOn(); }
    public void Off() { canupdate = false; OnTurnOff(); }
    public void Pause() { canupdate = false; OnPause(); }
    public void Resume() { canupdate = true; OnResume(); }
    private void Update() { if (canupdate) OnUpdate(); }
    private void FixedUpdate() { if (canupdate) OnFixedUpdate(); }

    /////////////////////////////////////////////////////////////
    /// ABSTRACTS QUE SE IMPLEMENTAN EN LOS CHILDS
    /////////////////////////////////////////////////////////////
    protected abstract void OnTurnOn();
    protected abstract void OnTurnOff();
    protected abstract void OnUpdate();
    protected abstract void OnFixedUpdate();
    protected abstract void OnPause();
    protected abstract void OnResume();

}
