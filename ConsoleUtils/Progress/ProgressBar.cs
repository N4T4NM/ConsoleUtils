using ConsoleUtils.Management;
using System;

namespace ConsoleUtils.Progress
{
    public class ProgressBar : ProgressObject<ProgressBar>
    {
        char _begin;
        char _end;
        char _progressChar;
        int _space;
        bool _decimal;
        public ProgressBar(bool showDecimal = false, char begin = '[', char end = ']', char progressChar = '=', int spacing = 5)
        {
            _decimal = showDecimal;
            _begin = begin;
            _end = end;
            _progressChar = progressChar;
            _space = spacing;
        }

        int GetShowNumber()
            => (int)((_space * 2) * (Progress / 100)) + 1;
        string BuildPercentageNumber()
        {
            string number = _decimal ? Progress.ToString("0.0") : Progress.ToString("0");
            return $" {number}% ";
        }

        protected override void Redraw()
        {
            ConsoleClear.ClearLine();
            Console.Write(_begin);
            int toShow = GetShowNumber();

            int cShown = 0;
            for (int i = 0; i < _space; i++)
            {
                if (cShown + 1 < toShow)
                {
                    Console.Write(_progressChar);
                    cShown++;
                }
                else Console.Write(' ');
            }

            Console.Write(BuildPercentageNumber());

            for (int i = _space; i < _space * 2; i++)
            {
                if (cShown + 1 < toShow)
                {
                    Console.Write(_progressChar);
                    cShown++;
                }
                else Console.Write(' ');
            }

            Console.Write(_end);
        }

        float _progress;
        public bool Finished => !_exec;
        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                Redraw();

                if (_progress >= 100)
                {
                    _progress = 100;
                    Redraw();
                    Stop(false);
                }
            }
        }

        public override void Show(Executor task)
        {
            RunTask(task, this);
            Progress = 0;
            base.Show(task);
        }
    }
}
