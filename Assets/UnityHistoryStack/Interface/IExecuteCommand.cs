using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public interface ICommand
    {
        void Do();
        void Undo();
    }

}

