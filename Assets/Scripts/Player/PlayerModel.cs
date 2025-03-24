using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerModel", order = 1)]
public class PlayerModel : ScriptableObject
{
    public float speed = 15f;
    public float gravity = 9.8f;
    public float jumpGravity = 1f;
    public LayerMask layerMask;
}
