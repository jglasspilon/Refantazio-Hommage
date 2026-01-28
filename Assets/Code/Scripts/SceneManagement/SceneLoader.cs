using System.Collections;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Scenes m_sceneName;

    [SerializeField]
    private EGameState m_sceneState;

    private void Awake()
    {
        SceneManager.Instance.RegisterSceneLoader(m_sceneName, this);
        Load();
    }

    public virtual void Load()
    {
        GameStateManager.Instance.CurrentSceneState = m_sceneState;
    }
    public virtual IEnumerator Unload()
    {
        yield break;
    }
}
