using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    void Enter(Rigidbody rb);
    void Exit(Rigidbody rb);
    void DoState(Rigidbody rb);
    void DoStateLateUpdate(Rigidbody rb);
    void DoStateFixedUpdate(Rigidbody rb);
}


public class PlayerStateController : MonoBehaviour
{
    public static PlayerStateController Instance;
    public PlayerState playerState { get; private set; }

    private Rigidbody _rb;

    private void EnterState(PlayerState newState)
    {
        if (playerState != null)
            playerState.Exit(_rb);
        playerState = newState;
        playerState.Enter(_rb);
    }
    private void Awake()
    {
        Instance = this;
        //Debug.Log(UnityEngine.Localization.Settings.LocalizationSettings.SelectedLocale.name);
        _rb = GetComponent<Rigidbody>();
        EnterState(new Movement());
    }

    void Update()
    {
        playerState.DoState(_rb);
    }
    void LateUpdate()
    {
        playerState.DoStateLateUpdate(_rb);
    }
    void FixedUpdate()
    {
        playerState.DoStateFixedUpdate(_rb);
    }
}

public class Movement : PlayerState
{
    public void Enter(Rigidbody rb)
    {
        
    }
    public void Exit(Rigidbody rb)
    {
        rb.velocity = Vector3.zero;
    }
    public void DoState(Rigidbody rb)
    {
        rb.GetComponent<PlayerMovement>().Move(rb);
        CameraController.instance.LookAround();
    }

    public void DoStateFixedUpdate(Rigidbody rb)
    {
        
    }

    public void DoStateLateUpdate(Rigidbody rb)
    {
        
    }
}

public class Interact : PlayerState
{
    Interactables interactable;

    public Interact(Interactables interactable)
    {
        this.interactable = interactable;
    }

    public void Enter(Rigidbody rb)
    {
        interactable.Interact();
    }
    public void Exit(Rigidbody rb)
    {
        interactable.CloseInteract();
    }
    public void DoState(Rigidbody rb)
    {

    }

    public void DoStateFixedUpdate(Rigidbody rb)
    {

    }

    public void DoStateLateUpdate(Rigidbody rb)
    {

    }
}