﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		public KeyboardController(Game1 g)
		{
			myGame = g;
			this.center = center;
		}

		public void handleInput() {
			KeyboardState kstate = Keyboard.GetState();

			if (kstate.IsKeyDown(Keys.D0) || kstate.IsKeyDown(Keys.NumPad0)) {
				//return val of 0, exit the game
				myGame.Exit();
			}
			


		}
	}
}