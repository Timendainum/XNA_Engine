using System;

namespace HexTileMapTestGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (HexTileTestGame game = new HexTileTestGame())
            {
                game.Run();
            }
        }
    }
#endif
}

