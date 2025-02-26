using UnityEngine;

namespace Thronefall.Infrastructure
{
    public interface IAssetProvider
    {
        GameObject LoadAsset(string path);
        T LoadAsset<T>(string path) where T : Object;
    }
}