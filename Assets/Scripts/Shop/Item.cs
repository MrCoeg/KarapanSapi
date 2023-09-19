using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public bool isOwned;
    public int id;

    public virtual void Use()
    {
        
    }
}
