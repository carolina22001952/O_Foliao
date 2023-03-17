using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "New NPC")]
public class NPC : ScriptableObject
{
    [SerializeField] private string _name;
    public string name { get { return _name; } }

    [SerializeField] private Sprite _sprite;
    public Sprite sprite { get { return _sprite; } }

    private enum friendshipLvl {Estranho = 0, Conhecido = 1, Amigo = 2, Proximo = 3, Intimo = 4, Amante = 5}

}
