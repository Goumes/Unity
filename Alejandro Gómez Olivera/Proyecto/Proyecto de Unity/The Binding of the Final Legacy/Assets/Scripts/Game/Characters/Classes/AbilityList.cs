using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityList
{
    //No tiene getters y setters porque el binaryformatter the unity no lo puede manejar y lo tuve que quitar.
    public List<Ability> abilities;
}
