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
			world = new World(collision);
			world.Gravity = new JVector(0, -981, 0);
			
			////Set up some entities
			RigidBodyEntity ground = new RigidBodyEntity("ground", new Vector3(0f, -20f, 0f), Vector3.Zero, Vector3.One, new BoxShape(new JVector(200, 20, 200)));
			ground.Body.IsStatic = true;
			ground.Body.Material.KineticFriction = 0.0f;

			AddEntity(ground);

			RigidBodyEntity ship = new RigidBodyEntity("ship", new Vector3(0f, 500f, 0f), Vector3.Zero, Vector3.One, new BoxShape(new JVector(250,250,250)));
			ship.Body.Material.Restitution = 0.999f;
			ship.Body.Mass = 5000f;
			AddEntity(ship);

			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(0f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(250f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["ship"], , Vector3.Zero, Vector3.One, graphics));
		}

		public override void Update(GameTime gameTime)
		{
			//Update jitter world
			float step = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (step > 1.0f / 100.0f) step = 1.0f / 100.0f;
			world.Step(step, true);

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
				world.AddBody(rbe.Body);
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
