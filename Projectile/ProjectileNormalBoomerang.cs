﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class ProjectileNormalBoomerang : IProjectile
    {
        private Vector2 position;
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;

        private int frame;
        private float rotation;
        // Used by the Player class to know if the projectile is still in animation
        private Boolean isRunning;

        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public ProjectileNormalBoomerang(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;
            
            sourceRect = new Rectangle(95, 280, 12, 19);
            
            isRunning = true;
            rotation = 0f;
            frame = 0;
        }

        public void GetRotation(Vector2 direction)
        {
            if (direction.X == 0 && direction.Y > 0)
            {
                rotation = (float)Math.PI  / 2f;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (direction.X > 0 && direction.Y == 0)
            {
                rotation = 0f;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                rotation = (float)Math.PI;
            }
        }

        public void Update()
        {
            destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 38);
            GetRotation(direction);
            frame++;

            if (frame < 10)
            {
                IsRunning = true;
                position.X += direction.X * 5f;
                position.Y += direction.Y * 5f;
            }
            else if (frame >= 10 && frame < 20)
            {
                position.X += direction.X * 5f;
                position.Y += direction.Y * 5f;
                sourceRect = new Rectangle(107, 280, 12, 19);
            }
            else if (frame >= 20 && frame < 30)
            {
                position.X += direction.X * 3f;
                position.Y += direction.Y * 3f;
                sourceRect = new Rectangle(122, 280, 17, 19);
            }
            else if (frame >= 30 && frame < 35)
            {
                position.X += direction.X * 0f;
                position.Y += direction.Y * 0f;
                sourceRect = new Rectangle(95, 280, 12, 19);
            }
            else if (frame >= 35 && frame < 45)
            {
                position.X += direction.X * -3f;
                position.Y += direction.Y * -3f;
                sourceRect = new Rectangle(107, 280, 12, 19);
            }
            else if (frame >= 45 && frame < 55)
            {
                position.X += direction.X * -5f;
                position.Y += direction.Y * -5f;
                sourceRect = new Rectangle(122, 280, 12, 19);
            }
            else if (frame >= 55 && frame < 65)
            {
                position.X += direction.X * -5f;
                position.Y += direction.Y * -5f;
                sourceRect = new Rectangle(95, 280, 12, 19);
            }
            else
            {
                IsRunning = false;
                sourceRect = new Rectangle(400, 400, 0, 0);
            }
        }

        public void Draw()
        {
            batch.Begin();
            batch.Draw(
                 texture,
                 destinationRect,
                 sourceRect,
                Color.White,
                rotation,
                new Vector2(sourceRect.Width / 2 , sourceRect.Height/ 2),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }

        
    }



}


