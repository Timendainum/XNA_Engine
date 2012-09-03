using System;

namespace EngineGameLibrary.Maths
{
	public static class RandomManager
	{
		public static Random TheRandom { get; private set; }

		public static void Init()
		{
			TheRandom = new Random();
		}
	}
}
