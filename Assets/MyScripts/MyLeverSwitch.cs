using UnityEngine;

public class MyLeverSwitch : MonoBehaviour
{
    [Header("Configuração de Alavanca")]
    [Tooltip("Permite escolher direção de inclinação da alavanca")]

    public Vector3 rotationX = new Vector3(0f, 0f, 0f);  
    
    [Tooltip("Ativa/desativa movimentação de alavanca")]
    public bool canMove = true;
    
    // void Start()
    // {
    //     rotationX = new Vector3(0f, 0f, 0f);                       
    // }

    void Update()
    {
        if (canMove)
        {
            if (transform.rotation.eulerAngles.x < 120)
            {
                transform.Rotate(rotationX * Time.deltaTime);
                // float value = transform.rotation.eulerAngles.x > 180 ? transform.rotation.eulerAngles.x - 360 : transform.rotation.eulerAngles.x;
            }
            else // if (rotationX.x > 5f)
            {
                transform.Rotate(-rotationX * Time.deltaTime);
            }
        }
    }
}
