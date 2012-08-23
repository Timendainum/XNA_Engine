using System;

namespace SpriteTestGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpriteTest game = new SpriteTest())
            {
                game.Run();
            }
        }
    }
#endif
}

