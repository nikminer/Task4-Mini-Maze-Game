using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float Speed = 2;
    
    private CharacterController CharacterController;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }


    private void FixedUpdate()
    {
        Vector3 vectorMovemnt = Vector3.zero;
        vectorMovemnt += Vector3.right * Input.GetAxis("Horizontal");
        vectorMovemnt += Vector3.forward * Input.GetAxis("Vertical");
        CharacterController.Move(vectorMovemnt);
    }
}
