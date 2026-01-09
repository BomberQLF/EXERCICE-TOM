using UnityEngine;

public class PlayerRespawnController : MonoBehaviour
{
    private int yThreshold = -5;
    private CharacterController _characterController;

    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        if (_characterController == null)
        {
            Debug.LogError("CharacterController component is required for RespawnPlayer script!");
        }
    }

    void Update()
    {
        if (transform.position.y <= yThreshold )
        {
            Respawn();
        }
    }

    public void Respawn()
    {

        if (_characterController != null)
        {
            _characterController.enabled = false;

            transform.position = new Vector3(0,0,0);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            _characterController.enabled = true;
        }

    }

}