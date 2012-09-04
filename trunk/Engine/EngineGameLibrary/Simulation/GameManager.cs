using Microsoft.Xna.Framework;

namespace EngineGameLibrary.Simulation
{
	public abstract class GameManager
	{

		#region Update
		/// <summary>
		/// Allows the screen to run logic, such as updating the transition position.
		/// Unlike HandleInput, this method is called regardless of whether the screen
		/// is active, hidden, or in the middle of a transition.
		/// </summary>
		public abstract void Update(GameTime gameTime);
		#endregion

	}
}
