using ConsoleUtils.Management;
using System;
using System.Threading.Tasks;

namespace ConsoleUtils.Progress
{
    public abstract class ProgressObject<Source>
    {
        protected virtual void Redraw()
        {

        }

        protected bool _exec = true;
        public virtual void Stop(bool clearLine)
        {
            Console.CursorVisible = true;

            _exec = false;
            if (clearLine)
                ConsoleClear.ClearLine();
            else Console.Write('\n');
        }

        public delegate void Executor(Source source);
        protected void RunTask(Executor task, Source src)
            => new Task(() => task?.Invoke(src)).Start();
        public virtual void Show(Executor task)
        {
            Console.CursorVisible = false;
            while (_exec) ;
        }
    }
}
