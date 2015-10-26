using System;

// -- -- \\

// There is no need to make any modifications within this class for the purpose of the workshop.
// This code has been 'given' to you.

// -- -- \\

namespace ParticleBasic
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Main game = new Main())
            {
                game.Run();
            }
        }
    }
#endif
}

