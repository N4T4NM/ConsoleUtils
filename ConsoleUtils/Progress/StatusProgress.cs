using ConsoleUtils.Management;
using System;
using System.Threading.Tasks;

namespace ConsoleUtils.Progress
{
    public class StatusProgress : ProgressObject<StatusProgress>
    {
        char[] _chars;
        int _current;
        public StatusProgress(params char[] chars)
        {
            _chars = chars;
        }

        string _status = "...";
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                lock (_status)
                {
                    ConsoleClear.ClearLineFrom(4);
                    Console.Write(_status);
                }
            }
        }

        void DrawRotator()
        {
            lock(_status)
            {
                if (_current >= _chars.Length)
                    _current = 0;
                
                Console.CursorLeft = 0;
                Console.Write($"[{_chars[_current]}] ");

                _current++;
            }
        }

        public override void Show(Executor task)
        {
            RunTask(task, this);
            new Task(async () =>
            {
                while (_exec)
                {
                    DrawRotator();
                    await Task.Delay(150);
                }
            }).Start();
            base.Show(task);
        }

        public static StatusProgress CreateDefault()
            => new StatusProgress('|', '/', '-', '\\', '|', '/', '-', '\\');
    }
}
