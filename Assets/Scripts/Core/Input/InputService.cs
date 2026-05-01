using System.Collections.Generic;

namespace OS.Scheduling.Input
{
    public class InputService
    {
        private readonly IInputSource _inputSource;

        public InputService(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        public List<ProcessDto> GetProcesses()
        {
            int count = _inputSource.ReadProcessCount();
            var dtos = new List<ProcessDto>(count);

            for (int i = 0; i < count; ++i)
                dtos.Add(_inputSource.ReadProcess(i + 1));

            return dtos;
        }
    }
}