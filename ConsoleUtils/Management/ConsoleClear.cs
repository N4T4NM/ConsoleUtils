using System;

namespace ConsoleUtils.Management
{
    public static class ConsoleClear
    {
        public static void ClearLine(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                string clear = new string(' ', Console.BufferWidth - 5);
                Console.CursorLeft = 0;
                Console.Write(clear);
                Console.CursorLeft = 0;

                if (i != count - 1)
                    Console.CursorTop--;
            }
        }

        public static void ClearLineFrom(int pos)
        {
            string clear = new string(' ', Console.BufferWidth-5-pos);
            Console.CursorLeft = pos;
            Console.Write(clear);
            Console.CursorLeft = pos;
        }
    }
}
