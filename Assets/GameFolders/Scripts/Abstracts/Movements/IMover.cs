using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts.Movements
{
    public interface IMover
    {
        void Tick(float horizontal);
    }
}
