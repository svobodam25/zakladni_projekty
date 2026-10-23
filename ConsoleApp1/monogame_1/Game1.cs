using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace monogame_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D mojeTextura;
        Texture2D mojeTextura2;
        int x = 100;
        int y = 100;

        int velikost_ctverce = 100;

        int rychlost = 5;

        int nastaveni_nepritel_rychlost = 3;


        int pocet_nepratel = 50;

        Nepritel_trida[] nepratele;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            nepratele = new Nepritel_trida[pocet_nepratel];



            for (int i = 0; i < pocet_nepratel; i++)
            {
                float x = new Random().Next(-velikost_ctverce, 800 - velikost_ctverce);
                float y = new Random().Next(-velikost_ctverce, 600 - velikost_ctverce);
                float nepritel_rychlost = new Random().Next(150, nastaveni_nepritel_rychlost * 100) / 100.0f;

                nepratele[i] = new Nepritel_trida();
                nepratele[i].Nepritel(x, y, nepritel_rychlost);
            }

            base.Initialize();
        }




        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            mojeTextura = new Texture2D(GraphicsDevice, velikost_ctverce, velikost_ctverce);
            mojeTextura2 = new Texture2D(GraphicsDevice, velikost_ctverce, velikost_ctverce);

            Color[] pixely = new Color[velikost_ctverce * velikost_ctverce];

            for (int i = 0; i < pixely.Length; i++)
            {
                pixely[i] = Color.Black;
            }

            Color[] pixely2 = new Color[velikost_ctverce * velikost_ctverce];

            for (int i = 0; i < pixely2.Length; i++)
            {
                pixely2[i] = Color.Red;
            }

            mojeTextura.SetData(pixely);
            mojeTextura2.SetData(pixely2);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                x += rychlost;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                x -= rychlost;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                y -= rychlost;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                y += rychlost;
            }

            for (int i = 0; i < pocet_nepratel; i++)
            {
                Nepritel_trida nepritel = nepratele[i];
                nepritel.pohnise(x, y);
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            for (int i = 0; i < pocet_nepratel; i++)
            {
                Nepritel_trida nepritel = nepratele[i];
                _spriteBatch.Draw(mojeTextura2, new Vector2(nepritel.x, nepritel.y), Color.Red);
            }

            _spriteBatch.Draw(mojeTextura, new Vector2(x, y), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
