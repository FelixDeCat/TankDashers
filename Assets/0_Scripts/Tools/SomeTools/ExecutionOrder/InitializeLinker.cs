using UnityEngine;
using System.Linq;
public class InitializeLinker : MonoBehaviour
{
    [SerializeField] GameObject[] initializables;
    public void Initialize() 
    {
        var objs = initializables.Select(x => x.GetComponent<IInitializable>());
    }
}
