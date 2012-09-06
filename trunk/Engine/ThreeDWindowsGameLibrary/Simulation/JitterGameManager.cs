using System.Collections.Generic;
using EngineGameLibrary.Simulation;
using Jitter;
using Jitter.Collision;
using Microsoft.Xna.Framework;
using Jitter.Collision.Shapes;
using Jitter.LinearMath;

namespace ThreeDWindowsGameLibrary.Simulation
{
	public class JitterGameManager : GameManager
	{
		CollisionSystem collision;
		World world;

		private List<Entity> _entities = new List<Entity>();

		public World World
		{
			get
			{
				return world;
			}
			set
			{
				world = value;
			}
		}
		public List<Entity> Entities
		{
			get
			{
				return _entities;
			}
		}


		public JitterGameManager()
		{
			collision = new CollisionSystemSAP();
			World = new World(collision);

			////Set up some entities
			RigidBodyEntity ground = new RigidBodyEntity("ground", new Vector3(0f, -1f, 0f), VectorHelper.CreateOrientationMatrix(Vector3.Zero), Vector3.One * 0.05f, new BoxShape(new JVector(1000, 1, 1000)));
			ground.Body.IsStatic = true;
			ground.Body.Material.KineticFriction = 0.5f;
			ground.Body.EnableDebugDraw = false;

			AddEntity(ground);


			for (int i = 0; i < 2; i++)
			{
				for (int y = 0; y < 10; y++)
				{
					float offset;
					if (y % 2 == 1)
						offset = 0f;
					else
						offset = 5f;


					RigidBodyEntity ship = new RigidBodyEntity("ship", new Vector3((i * 15), 500f + (y * 15f), offset), VectorHelper.CreateOrientationMatrix(Vector3.Zero), Vector3.One * 0.005f, new BoxShape(new JVector(10, 5, 10)));
					ship.Body.Material.Restitution = 0.9f;
					ship.Body.Mass = 2500f;
					ship.Body.EnableDebugDraw = true;
					AddEntity(ship);
				}
				
			}

			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(0f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(250f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["ship"], , Vector3.Zero, Vector3.One, graphics));
		}

		public override void Update(GameTime gameTime)
		{
			//Update jitter world
			float step = (float)gameTime.ElapsedGameTime.TotalSeconds;
			//if (step > 1.0f / 100.0f) step = 1.0f / 100.0f;
			World.Step(step, true);

			//Update entities
			//foreach (Entity e in Entities)
			//{
			//	e.Update(gameTime);
			//}
		}

		public void AddEntity(Entity entity)
		{
			_entities.Add(entity);

			if (entity is RigidBodyEntity)
			{
				RigidBodyEntity rbe = (RigidBodyEntity)entity;
				World.AddBody(rbe.Body);
			}

			//ground = new RigidBody(new BoxShape(new JVector(200, 20, 200)));
			//ground.Position = new JVector(0, -10, 0);
			//ground.Tag = BodyTag.DontDrawMe;
			//ground.IsStatic = true; Demo.World.AddBody(ground);
			////ground.Restitution = 1.0f;
			//ground.Material.KineticFriction = 0.0f;


			//Shape shape = new BoxShape(1.0f, 2.0f, 3.0f);
			//RigidBody body = new RigidBody(shape);

			//world.AddBody(body);
		}

		public void RemoveEntity(Entity entity)
		{
			if (Entities.Contains(entity))
				Entities.Remove(entity);
		}

	}
}
