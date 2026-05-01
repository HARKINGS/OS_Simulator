using UnityEngine;
using System.Collections.Generic;

namespace OS.Scheduling.Input
{
    public interface IInputSource
    {
        int ReadProcessCount();
        ProcessDto ReadProcess(int pid);
    }
}