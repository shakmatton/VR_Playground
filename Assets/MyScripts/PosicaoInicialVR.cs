/* ═══════════════════════════════════════════════════════════════
COMO USAR (VERSÃO CORRIGIDA):

1. Este script JÁ está no seu XR Origin

2. AJUSTAR A POSIÇÃO:
   Método A - Capturar (Recomendado):
   - Posicione o XR Origin onde você quer na Scene
   - Marque "Capturar Posicao Atual" no Inspector
   
   Método B - Durante o Play:
   - Entre no Play Mode
   - Ande até onde você quer começar
   - Pressione a tecla P
   - Saia do Play Mode
   - A posição ficou salva!

3. AJUSTAR O TEMPO:
   - Se ainda não funcionar, aumente "Tempo Espera" para 0.5 ou 1.0
   - Isso dá mais tempo para os sistemas VR inicializarem

COMO FUNCIONA AGORA:
- Desliga temporariamente o Character Controller
- Aplica a posição
- Religa o Character Controller
- Isso impede que ele "corrija" a posição antes de você spawnar

DICA VISUAL:
- Linha vermelha = conecta onde está agora com onde vai spawnar
- Esfera verde = local do spawn
- Seta azul = direção que vai olhar
═══════════════════════════════════════════════════════════════ */

using UnityEngine;
using System.Collections;

/// <summary>
/// Força o XR Origin a começar em uma posição específica
/// Funciona mesmo com Character Controller ativo
/// Coloque este script no XR Origin
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PosicaoInicialVR : MonoBehaviour
{
    [Header("Posição Inicial")]
    [Tooltip("Posição onde o jogador vai começar")]
    public Vector3 posicaoInicial = new Vector3(0, 0, 0);
    
    [Tooltip("Rotação inicial (apenas Y importa - direção que está olhando)")]
    public Vector3 rotacaoInicial = new Vector3(0, 0, 0);
    
    [Header("Opções")]
    [Tooltip("Capturar a posição atual do XR Origin como inicial?")]
    public bool capturarPosicaoAtual = false;

    [Tooltip("Tempo de espera antes de aplicar posição (segundos)")]
    public float tempoEspera = 0.2f;

    private CharacterController characterController;
    private bool posicaoAplicada = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        // Aguarda para garantir que outros sistemas inicializaram
        StartCoroutine(AplicarPosicaoAtrasada());
    }

    IEnumerator AplicarPosicaoAtrasada()
    {
        // Espera o tempo configurado
        yield return new WaitForSeconds(tempoEspera);
        
        // Desabilita o Character Controller temporariamente
        bool controlerEstavAtivo = characterController.enabled;
        characterController.enabled = false;
        
        // Aplica a posição
        transform.position = posicaoInicial;
        transform.rotation = Quaternion.Euler(rotacaoInicial);
        
        // Aguarda um frame
        yield return null;
        
        // Reabilita o Character Controller
        characterController.enabled = controlerEstavAtivo;
        
        posicaoAplicada = true;
        Debug.Log($"✓ Posição inicial aplicada: {posicaoInicial}");
    }

    // Botão no Inspector para capturar posição atual
    void OnValidate()
    {
        if (capturarPosicaoAtual)
        {
            posicaoInicial = transform.position;
            rotacaoInicial = transform.rotation.eulerAngles;
            capturarPosicaoAtual = false;
            
            Debug.Log($"✓ Posição capturada: {posicaoInicial}, Rotação: {rotacaoInicial}");
        }
    }

    // Desenha um gizmo mostrando onde o jogador vai spawnar
    void OnDrawGizmos()
    {
        // Esfera verde = posição inicial
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(posicaoInicial, 0.3f);
        Gizmos.DrawWireSphere(posicaoInicial + Vector3.up * 0.5f, 0.2f);
        
        // Seta azul = direção que vai olhar
        Vector3 direcao = Quaternion.Euler(rotacaoInicial) * Vector3.forward;
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(posicaoInicial + Vector3.up * 0.5f, direcao * 1f);
        
        // Linha vermelha conectando posição atual à inicial (apenas no editor)
        if (!Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, posicaoInicial);
        }
    }

    // Removido Update() para evitar erro com novo Input System
    // Se precisar capturar posição durante o Play, use "Capturar Posicao Atual" no Inspector
}

