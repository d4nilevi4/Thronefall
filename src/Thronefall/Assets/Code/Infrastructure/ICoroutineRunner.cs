using System.Collections;
using UnityEngine;

namespace Thronefall.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator load);
    }
}