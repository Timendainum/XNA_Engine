using System;

namespace ThreeDCameraTestGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ThreeDCameraTestGame game = new ThreeDCameraTestGame())
            {
                game.Run();
            }
        }
    }
#endif
}

