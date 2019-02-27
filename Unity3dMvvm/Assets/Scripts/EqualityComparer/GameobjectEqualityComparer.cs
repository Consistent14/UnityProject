using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EqualityComparer
{
    class GameobjectEqualityComparer : IEqualityComparer<GameObject>
    {
        public bool Equals(GameObject x, GameObject y)
        {
            return x.name.Equals(y.name);
        }

        public int GetHashCode(GameObject obj)
        {
            return 0;
        }
    }
}
