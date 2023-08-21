using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeDefense
{
    /// <summary>
    /// Stores Turret definitions on TurretCollection
    /// </summary>
    [CreateAssetMenu(fileName = "TurretCollection", menuName = "Collections/Turrets")]
    public class TurretCollection : ScriptableObject
    {
        public List<TurretDescription> turrets;
    }

}