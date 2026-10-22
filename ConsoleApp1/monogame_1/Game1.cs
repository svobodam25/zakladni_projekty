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

        int nepritel_rychlost = 3;

        float nepritel_x = 200;
        float nepritel_y = 100;

        int nepratele = 50;
        float[] nepratele_x;
        float[] nepratele_y;
        float[] nepratele_rychlosti;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            nepratele_x = new float[nepratele];
            nepratele_y = new float[nepratele];
            nepratele_rychlosti = new float[nepratele];

            for (int i = 0; i < nepratele; i++)
            {
                nepratele_x[i] = new Random().Next(-velikost_ctverce, 800 - velikost_ctverce);
                nepratele_y[i] = new Random().Next(-velikost_ctverce, 600 - velikost_ctverce);
                nepratele_rychlosti[i] = new Random().Next(150, nepritel_rychlost * 100) / 100.0f;
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

            for (int i = 0; i < nepratele; i++)
            {
                float vzd_x = System.Math.Abs(x - nepratele_x[i]);
                float vzd_y = System.Math.Abs(y - nepratele_y[i]);
                float total_vzd = vzd_x + vzd_y;
                float rychlost_x = vzd_x / total_vzd * nepratele_rychlosti[i];
                float rychlost_y = vzd_y / total_vzd * nepratele_rychlosti[i];
                if (x >= nepratele_x[i])
                {
                    nepratele_x[i] += rychlost_x;
                    if (!(x >= nepratele_x[i]))
                    {
                        nepratele_x[i] = x;
                    }
                }
                else
                {
                    nepratele_x[i] -= rychlost_x;
                    if (x >= nepratele_x[i])
                    {
                        nepratele_x[i] = x;
                    }
                }
                if (y >= nepratele_y[i])
                {
                    nepratele_y[i] += rychlost_y;
                    if (!(y >= nepratele_y[i]))
                    {
                        nepratele_y[i] = y;
                    }
                }
                else
                {
                    nepratele_y[i] -= rychlost_y;
                    if (y >= nepratele_y[i])
                    {
                        nepratele_y[i] = y;
                    }
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            for (int i = 0; i < nepratele; i++)
            {
                _spriteBatch.Draw(mojeTextura2, new Vector2(nepratele_x[i], nepratele_y[i]), Color.Red);
            }

            _spriteBatch.Draw(mojeTextura, new Vector2(x, y), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
