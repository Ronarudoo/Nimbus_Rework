using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    private PlayerInput playerInput;
    private Animator anim;
    private InputAction attackAction;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        attackAction = playerInput.actions["Attack"];
    }

    private void Update()
    {
        
        if (attackAction.triggered)
        {
            anim.SetTrigger("Attack");
        }
    }
}
