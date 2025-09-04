using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Thronefall.Infrastructure;

public class LoadProgressState : IState
{
    private readonly IGameStateMachine _stateMachine;

    public LoadProgressState(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public async UniTask Enter()
    {
        const int secondSceneIndex = 1;
        string sceneName = SceneManager.GetSceneByBuildIndex(secondSceneIndex).name;
            
#if UNITY_EDITOR
        string key = SwitchToEntrySceneInEditor.CURRENT_SCENE_NAME_KEY;
            
        if (PlayerPrefs.HasKey(key))
        {
            sceneName = PlayerPrefs.GetString(key);

            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();
        }
#endif
        await _stateMachine.Enter<LoadLocalState, string>(sceneName);
    }

    public UniTask Exit() =>
        UniTask.CompletedTask;
}