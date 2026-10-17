using UnityEngine;

public class UnitCreator : MonoBehaviour
{

    public static GameObject Instanciate(GameObject prefab)
    {
        return GameObject.Instantiate(prefab);
    }
}
