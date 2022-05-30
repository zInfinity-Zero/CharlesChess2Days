using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CharlesChess
{
    class Pieces : Sprite
    {
        public bool clickedon { get; set; } = false;
        private bool tempbool = false;
        private int whitedeath = 0;
        private int blackdeath = 0;
        
        public Pieces(Texture2D tex, Vector2 pos, Vector2 size,Color color) : base(tex,pos,size,color)
        {

        }

        public void CheckMouse(Pieces whiteking, Pieces whitequeen, Pieces whitebishop1, Pieces whitebishop2, Pieces whiteknight1, Pieces whiteknight2, Pieces whiterook1, Pieces whiterook2, Pieces whitepawn1, Pieces whitepawn2, Pieces whitepawn3, Pieces whitepawn4, Pieces whitepawn5, Pieces whitepawn6, Pieces whitepawn7, Pieces whitepawn8, Pieces blackking, Pieces blackqueen, Pieces blackrook1, Pieces blackrook2, Pieces blackbishop1, Pieces blackbishop2, Pieces blackknight1, Pieces blackknight2, Pieces blackpawn1, Pieces blackpawn2, Pieces blackpawn3, Pieces blackpawn4, Pieces blackpawn5, Pieces blackpawn6, Pieces blackpawn7, Pieces blackpawn8,   List<Pieces> allpiece)
        {
            Rectangle mouserec = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            Rectangle thisrec = new Rectangle((int)this.spritePosition.X, (int)this.spritePosition.Y, (int)this.spriteSize.X, (int)this.spriteSize.Y);
            if (mouserec.Intersects(thisrec))
            {
                //if (!whitebishop1.clickedon && !whitebishop2.clickedon && !whiteknight1.clickedon && !whiteknight2.clickedon && !whiterook2.clickedon && !whiterook1.clickedon && !whiteking.clickedon && !whitequeen.clickedon && !whitepawn1.clickedon && !whitepawn2.clickedon && !whitepawn3.clickedon && !whitepawn4.clickedon && !whitepawn5.clickedon && !whitepawn6.clickedon && !whitepawn7.clickedon && !whitepawn8.clickedon && !blackbishop2.clickedon && !blackbishop1.clickedon && !blackrook2.clickedon && blackrook1.clickedon&& !blackknight1.clickedon && !blackknight2.clickedon && !blackking.clickedon && !blackqueen.clickedon && !blackpawn1.clickedon && !blackpawn2.clickedon && !blackpawn3.clickedon && !blackpawn4.clickedon && !blackpawn5.clickedon && !blackpawn6.clickedon && !blackpawn7.clickedon && !blackpawn8.clickedon)
                //{
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    foreach (Pieces p in allpiece)
                    {
                        if (p.clickedon)
                        {
                            tempbool = true;
                        }
                    }
                    if (!tempbool)
                        clickedon = true;
                }
                        
                //}

            }
            if (clickedon == true)
            {
                float tempx = Mouse.GetState().X - this.spriteSize.X/2;
                float tempy = Mouse.GetState().Y -this.spriteSize.Y/2;
                this.spritePosition = new Vector2(tempx,tempy);
                if (Mouse.GetState().LeftButton == ButtonState.Released)
                {
                    foreach (Pieces p in allpiece)
                    {
                        Rectangle temprec = new Rectangle((int)p.spritePosition.X, (int)p.spritePosition.Y, (int)p.spriteSize.X, (int)p.spriteSize.Y);
                        if (mouserec.Intersects(temprec))
                        {
                            if (!p.clickedon)
                            {
                                p.spritePosition = new Vector2(0, 0);
                            }
                        }
                        this.spritePosition = new Vector2(tempx, tempy);
                        clickedon = false;
                        tempbool = false;
                    }
                }
            
            }
        }
       
        
    }
}
