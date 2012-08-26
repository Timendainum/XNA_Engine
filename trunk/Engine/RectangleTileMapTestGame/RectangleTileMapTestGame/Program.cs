using System;

namespace RectangleTileMapTestGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (RectangleTileMapTestGame game = new RectangleTileMapTestGame())
            {
                game.Run();
            }
        }
    }
#endif
}

