using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace CharlesChess
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite chessboard; private Texture2D chessboardtex;


        private Pieces whiteking, whitequeen, whitebishop1, whitebishop2, whiteknight1, whiteknight2, whiterook1, whiterook2, whitepawn1, whitepawn2, whitepawn3, whitepawn4, whitepawn5, whitepawn6, whitepawn7, whitepawn8;
        private Pieces blackking, blackqueen, blackbishop1, blackbishop2, blackknight1, blackknight2, blackrook1, blackrook2, blackpawn1, blackpawn2, blackpawn3, blackpawn4, blackpawn5, blackpawn6, blackpawn7, blackpawn8;

        private List<Pieces> allpieces = new List<Pieces>();
        private List<Pieces> blackpawns = new List<Pieces>();
        private List<Pieces> whitepawns = new List<Pieces>();


        private Texture2D wki, wq, wb, wkn, wr, wp;
        private Texture2D bki, bq, bb, bkn, br, bp;

        private SpriteFont font;
        private Text whitewin;
        private Text blackwin;

        private bool gameover = false;

        private int[] row = new int []{ 95+0, 95 + 70, 95 + 140, 95 + 210, 95 + 280, 95 + 350, 95 + 420, 95 + 490 };
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //70x70 box
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 750;
            _graphics.PreferredBackBufferHeight = 750;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
   
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            chessboardtex = Content.Load<Texture2D>("chessb (2)");
            chessboard = new Sprite(chessboardtex, new Vector2(95,95), new Vector2(560, 560),Color.White);

            wki = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (5)");
            wq = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (4)");
            wkn = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (3)");
            wr = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (6)");
            wb = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (2)");
            wp = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (7)");

            bki = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (5)");
            bq = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (4)");
            bkn = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (3)");
            br = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (6)");
            bb = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (2)");
            bp = Content.Load<Texture2D>("800px-Chess_Pieces_Sprite.svg (7)");

            font = Content.Load<SpriteFont>("File");

            whitepawn1 = new Pieces(wp, new Vector2(row[0], row[6]), new Vector2(70, 70),Color.White);
            allpieces.Add(whitepawn1);
            whitepawns.Add(whitepawn1);
            whitepawn2 = new Pieces(wp, new Vector2(row[1], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn2);
            whitepawns.Add(whitepawn2);
            whitepawn3 = new Pieces(wp, new Vector2(row[2], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn3);
            whitepawns.Add(whitepawn3);
            whitepawn4 = new Pieces(wp, new Vector2(row[3], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn4);
            whitepawns.Add(whitepawn4);
            whitepawn5 = new Pieces(wp, new Vector2(row[4], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn5);
            whitepawns.Add(whitepawn5);
            whitepawn6 = new Pieces(wp, new Vector2(row[5], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn6);
            whitepawns.Add(whitepawn6);
            whitepawn7 = new Pieces(wp, new Vector2(row[6], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn7);
            whitepawns.Add(whitepawn7);
            whitepawn8 = new Pieces(wp, new Vector2(row[7], row[6]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitepawn8);
            whitepawns.Add(whitepawn8);

            whiteking = new Pieces(wki, new Vector2(row[4], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whiteking);
            whitequeen = new Pieces(wq, new Vector2(row[3], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitequeen);
            whiterook1 = new Pieces(wr, new Vector2(row[0], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whiterook1);
            whiterook2 = new Pieces(wr, new Vector2(row[7], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whiterook2);
            whiteknight1 = new Pieces(wkn, new Vector2(row[1], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whiteknight1);
            whiteknight2 = new Pieces(wkn, new Vector2(row[6], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whiteknight2);
            whitebishop1 = new Pieces(wb, new Vector2(row[2], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitebishop1);
            whitebishop2 = new Pieces(wb, new Vector2(row[5], row[7]), new Vector2(70, 70), Color.White);
            allpieces.Add(whitebishop2);


            //next do for black
            blackpawn1 = new Pieces(bp, new Vector2(row[0], row[1]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackpawn1);
            blackpawns.Add(blackpawn1);
            blackpawn2 = new Pieces(bp, new Vector2(row[1], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn2);
            allpieces.Add(blackpawn2);
            blackpawn3 = new Pieces(bp, new Vector2(row[2], row[1]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackpawn3);
            blackpawns.Add(blackpawn3);
            blackpawn4 = new Pieces(bp, new Vector2(row[3], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn4);
            allpieces.Add(blackpawn4);
            blackpawn5 = new Pieces(bp, new Vector2(row[4], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn5);
            allpieces.Add(blackpawn5);
            blackpawn6 = new Pieces(bp, new Vector2(row[5], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn6);
            allpieces.Add(blackpawn6);
            blackpawn7 = new Pieces(bp, new Vector2(row[6], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn7);
            allpieces.Add(blackpawn7);
            blackpawn8 = new Pieces(bp, new Vector2(row[7], row[1]), new Vector2(70, 70), Color.Blue);
            blackpawns.Add(blackpawn8);
            allpieces.Add(blackpawn8);
            blackking = new Pieces(bki, new Vector2(row[4], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackking);
            blackqueen = new Pieces(bq, new Vector2(row[3], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackqueen);
            blackrook1 = new Pieces(br, new Vector2(row[0], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackrook1);
            blackrook2 = new Pieces(br, new Vector2(row[7], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackrook2);
            blackknight1 = new Pieces(bkn, new Vector2(row[1], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackknight1);
            blackknight2 = new Pieces(bkn, new Vector2(row[6], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackknight2);
            blackbishop1 = new Pieces(bb, new Vector2(row[2], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackbishop1);
            blackbishop2 = new Pieces(bb, new Vector2(row[5], row[0]), new Vector2(70, 70), Color.Blue);
            allpieces.Add(blackbishop2);


            whitewin = new Text(font, "White Won", new Vector2(300, 350), Color.White);
            blackwin = new Text(font, "Black Won", new Vector2(300, 350), Color.White);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            


                foreach (Pieces p in allpieces)
                {
                    p.CheckMouse(whiteking, whitequeen, whitebishop1, whitebishop2, whiteknight1, whiteknight2, whiterook1, whiterook2, whitepawn1, whitepawn2, whitepawn3, whitepawn4, whitepawn5, whitepawn6, whitepawn7, whitepawn8, blackking, blackqueen, blackrook1, blackrook2, blackbishop1, blackbishop2, blackknight1, blackknight2, blackpawn1, blackpawn2, blackpawn3, blackpawn4, blackpawn5, blackpawn6, blackpawn7, blackpawn8, allpieces);
                }
            foreach (Pieces p in whitepawns)
            {
                if (p.spritePosition.Y <= row[0])
                {
                    p.spriteTexture = wq;
                }
            }
            foreach (Pieces p in blackpawns)
            {
                if (p.spritePosition.Y >= row[7])
                {
                    p.spriteTexture = bq;
                }
            }

            if (blackking.spritePosition == new Vector2 (0,0) || whiteking.spritePosition == new Vector2(0, 0))
            {
                gameover = true;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (!gameover)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                chessboard.DrawSprite(_spriteBatch);
                foreach (Pieces p in allpieces)
                {
                    p.DrawSprite(_spriteBatch);
                }
            }
            else
            {
                GraphicsDevice.Clear(Color.Black);
                if (whiteking.spritePosition == new Vector2(0,0))
                {
                    blackwin.DrawText(_spriteBatch);
                }
                else
                {
                    whitewin.DrawText(_spriteBatch);
                }
            }
            base.Draw(gameTime);
        }
    }
}
