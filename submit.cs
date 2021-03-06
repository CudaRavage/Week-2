using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // STUDENTS: declare variables for three sprites

        Texture2D ghost0;  // green ghost
       // Rectangle drawRectangle0;

        Texture2D ghost1;  // red ghost
      //  Rectangle drawRectangle1;

        Texture2D ghost2;  // blue ghost
      //  Rectangle drawRectangle2;



        // STUDENTS: declare variables for x and y speeds

        int speedX;
        int speedY;


        // used to handle generating random values
        Random rand = new Random();
        const int CHANGE_DELAY_TIME = 1000;
        int elapsedTime = 0;

        // used to keep track of current sprite and location
        Texture2D currentSprite;
        Rectangle drawRectangle = new Rectangle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT; ;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // STUDENTS: load the sprite images here

            ghost0 = Content.Load<Texture2D>("ghost0");

            ghost1 = Content.Load<Texture2D>("ghost1");
  
            ghost2 = Content.Load<Texture2D>("ghost2");
            


            // STUDENTS: set the currentSprite variable to one of your sprite variables 

            currentSprite = ghost0;



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > CHANGE_DELAY_TIME)
            {
                elapsedTime = 0;

                // STUDENTS: uncomment the code below and make it generate a random number 
                // between 0 and 2 inclusive using the rand field I provided
                int spriteNumber = rand.Next(0,3) ;

                // sets current sprite
                // STUDENTS: uncomment the lines below and change sprite0, sprite1, and sprite2
                //      to the three different names of your sprite variables
                if (spriteNumber == 0)
                {
                    currentSprite = ghost0;
                }
                else if (spriteNumber == 1)
                {
                    currentSprite = ghost1;
                }
                else if (spriteNumber == 2)
                {
                    currentSprite = ghost2;
                }

                // STUDENTS: set the drawRectangle.Width and drawRectangle.Height to match the width and height of currentSprite

                drawRectangle = new Rectangle(98, 100, currentSprite.Width, currentSprite.Height); // x, y, width, height

                // STUDENTS: center the draw rectangle in the window. Note that the X and Y properties of the rectangle
                // are for the upper left corner of the rectangle, not the center of the rectangle
                //sprite is 98x100 pixels

                drawRectangle.X = 350;
                drawRectangle.Y = 249;

                // STUDENTS: write code below to generate random numbers  between -4 and 4 inclusive for the x and y speed 
				// using the rand field I provided
                // CAUTION: Don't redeclare the x speed and y speed variables here!

                speedX = rand.Next(-4, 5);
                speedY = rand.Next(-4, 5);
            }

            // STUDENTS: move the drawRectangle by the x speed and the y speed


            drawRectangle.X += speedX;
            drawRectangle.Y += speedY;


            //drawRectangle.X = speedX;
            //drawRectangle.Y = speedY;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // STUDENTS: draw current sprite here

            spriteBatch.Begin();
            spriteBatch.Draw(currentSprite, drawRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
