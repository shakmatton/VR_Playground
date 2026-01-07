using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;    

namespace MyScripts
{
    // ver: https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@3.3/api/UnityEngine.XR.Interaction.Toolkit.BaseInteractionEventArgs.html
    public class MyXRGrabInteractableCylinder : XRGrabInteractable  
    {
        private Color _originalColor;
        private Renderer _rend;
        
        // Usar _BaseColor para o shader "Interactable"
        private static readonly int ColorPropertyID = Shader.PropertyToID("_BaseColor");

        
        protected override void Awake()
        {
            base.Awake();
            
            // Capturar renderer e cor original do objeto logo no início
            _rend = GetComponent<Renderer>();
            if (_rend != null && _rend.material != null)
            {
                // Usar GetColor para pegar a cor da propriedade específica
                _originalColor = _rend.material.GetColor(ColorPropertyID);
            }
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (_rend != null && _rend.material != null)
            {
                // Usar SetColor para mudar apenas a cor base, não o RimColor
                _rend.material.SetColor(ColorPropertyID, Color.green);
            }
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);

            if (_rend != null && _rend.material != null)
            {
                // Restaurar a cor original (azul)
                _rend.material.SetColor(ColorPropertyID, _originalColor);
            }
        }
        /*
        // =====================================
        // ============= DEBUGGING =============
        // =====================================
        
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);
            Debug.Log("HOVER entrou no cilindro!");

            if (_rend != null && _rend.material != null)
            {
                _rend.material.SetColor("_RimColor", new Color(1, 1, 0, 1));
            }
            
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);
            Debug.Log("HOVER saiu do cilindro!");

            if (_rend != null && _rend.material != null)
            {
                _rend.material.SetColor("_RimColor", new Color(0, 0, 0, 0));
            }
        }
        
        // ====================================== */
    }
}

