using System;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public event Action<EGameState> OnGameStateChanged;

    [SerializeField]
    private EGameState m_startingState;

    private EGameState m_currentState;

    public EGameState CurrentState {  get { return m_currentState; } }
    public EGameState CurrentSceneState { get; set; }

    protected override void Awake()
    {
        base.Awake();
        ChangeState(m_startingState);
    }

    public void ChangeState(EGameState newState)
    {
        m_currentState = newState;
        OnGameStateChanged?.Invoke(m_currentState);
    }

    public void ReturnToSceneState()
    {
        m_currentState = CurrentSceneState;
        OnGameStateChanged?.Invoke(m_currentState);
    }
}

public enum EGameState
{
    Menu,
    Field, 
    Town,
    Combat,
    Dialoque,
    Cinematic
}
