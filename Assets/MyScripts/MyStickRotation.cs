using UnityEngine;

namespace MyScripts
{
    public class MyStickRotation : MonoBehaviour
    {
        [Header("Configuração de Rotação")]
        [Tooltip("Velocidade de rotação em graus por segundo (X, Y, Z)")]
        
        public Vector3 rotation = new Vector3(0, 0, 15f);
        
        [Tooltip("Ativa/desativa rotação")]
        
        public bool enableRotation = true;
        
        void Update()
        {
            if (enableRotation)
            {
                transform.Rotate(rotation * Time.deltaTime);
            }
        }
    }
}



// using System;
// using UnityEngine;
// using Random = UnityEngine.Random;
//
// /*  This script will rotate MyStick 2.
//     Based upon Rotate.cs */
//
// namespace MyScripts
// {
//     public class MyStickRotation : MonoBehaviour
//     {
//         public Vector3 rotation = new Vector3(0, 0, 50f); // inicializa vector3 com valores padrão de rotação (manipulável externamente, pois é public)
//         public bool enableRotation = true;  // caixinha de true/false, manipulável externamente
//         public bool randomizeOnStart = false;  // separa lógica da randomização
//         
//         /* void OnEnable()  // evento substituído por Start()... ele era chamado quando componente é habilitado (aqui, iria ocorrer apenas uma vez) */
//         
//         void Start()
//         {
//             if (randomizeOnStart && enableRotation)  
//             {
//                 Vector3 newRotation = new Vector3 (         // Randomiza entre -rotation e rotation em XYZ
//                     Random.Range(-rotation.x, rotation.x), 
//                     Random.Range(-rotation.y, rotation.y), 
//                     Random.Range(-rotation.z, rotation.z)
//                 );  
//                 
//                 rotation = newRotation;  // aplica seu valor ao valor original de rotation.
//             }
//         }
//         
//         /* float Randomizer(float range)  // amplifica e retorna valor situado entre -1 e 1
//         {
//             return Random.Range(-1f, 1f) * range;  // uso de float em vez de int
//         }*/
//         
//         void Update()  // Atualiza rotação aqui...
//         {
//             if (enableRotation)  // ... mas somente se a caixinha estiver marcada como true.
//             {
//                 gameObject.transform.Rotate(rotation * Time.deltaTime);    // rotação fluida
//             }
//         }
//     }
// }
//
