using System.Collections.Generic;
using EngineGameLibrary.Simulation;
using Jitter;
using Jitter.Collision;
using Microsoft.Xna.Framework;

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
		}

		public override void Update(GameTime gameTime)
		{
			//Update jitter world
			float step = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (step > 1.0f / 100.0f) step = 1.0f / 100.0f;
			world.Step(step, true);

			//Update entities
			foreach (Entity e in Entities)
			{
				e.Update(gameTime);
			}
		}

		public void AddEntity(Entity entity)
		{
			_entities.Add(entity);
			
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

		}

	}
}
