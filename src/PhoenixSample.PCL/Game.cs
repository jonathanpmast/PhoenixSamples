using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PhoenixSample.PCL.Monogame.Aspects;
using PhoenixSample.PCL.Monogame.Components;
using PhoenixSample.PCL.Systems;
using PhoenixSystem.Engine.Channel;
using PhoenixSystem.Engine.Collections;
using PhoenixSystem.Engine.Entity;

namespace PhoenixSample.PCL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SampleGameManager _gameManager;
        SpriteFont font;
        IChannelManager _channelManager;
        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _channelManager = new ChannelManager();
            var entityManager = new EntityManager(_channelManager, new EntityPool());
            _gameManager = new SampleGameManager(new DefaultEntityAspectManager(_channelManager, entityManager), entityManager, _channelManager);
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

            font = Content.Load<SpriteFont>("Status");

            MovementSystem movementSystem = new MovementSystem(_channelManager, 25, new string[] { "default" });
            TextRenderSystem textRenderSystem = new TextRenderSystem(spriteBatch, _channelManager, 100, "default");
            _gameManager.AddSystem(textRenderSystem);
            _gameManager.AddSystem(movementSystem);

            var te = _gameManager.EntityManager.Get("text", new string[] { "default" });
            te.CreateTextRenderEntity("Some Text", Color.Black, new Vector2(100, 100), 5, 1.0f, font);
            var teMove = _gameManager.EntityManager.Get("text2", new string[] { "default" });
            teMove.CreateTextRenderEntity("I'm Moving!", Color.Black, new Vector2(1, 1), 5, 1.0f, font).AddComponent(new VelocityComponent() { Direction = new Vector2(1, 1), Speed = new Vector2(15, 15) });
            _gameManager.AddEntity(te);
            _gameManager.AddEntity(teMove);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameManager.Update(new MonogameTickEvent(gameTime));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred);
            _gameManager.Draw(new MonogameTickEvent(gameTime));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
