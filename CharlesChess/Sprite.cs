using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CharlesChess
{
    class Sprite
    {
        public Vector2 spritePosition { get; set; }
        public Vector2 spriteSize { get; set; }
        public Texture2D spriteTexture { get; set; }

        public Color spriteColor = Color.White;

        public Sprite()
        {

        }

        public Sprite(Texture2D tex, Vector2 pos, Vector2 size,Color color)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
            this.spriteColor = color;
        }




        public void DrawSprite(SpriteBatch s)
        {
            
            s.Begin();

            s.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColor);

            s.End();


        }




    }
}
