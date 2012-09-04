using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThreeDWindowsGameLibrary.Actors.Materials;
using ThreeDWindowsGameLibrary.Simulation;

namespace ThreeDWindowsGameLibrary.Actors
{
	public class BasicActor
	{
		public Vector3 Position
		{
			get
			{
				return Entity.Position;
			}
		}
		public Vector3 Rotation
		{
			get
			{
				return Entity.Rotation;
			}
		}
		public Vector3 Scale
		{
			get
			{
				return Entity.Scale;
			}
		}

		public Model Model { get; private set; }
		public Entity Entity { get; private set; }

		private Matrix[] _modelTransforms;
		private BoundingSphere _boundingSphere;

		public Material Material { get; set; }

		public BoundingSphere BoundingSphere
		{
			get
			{
				// No need for rotation, as this is a sphere
				Matrix worldTransform = Matrix.CreateScale(Scale) * Matrix.CreateTranslation(Position);

				BoundingSphere transformed = _boundingSphere;
				transformed = transformed.Transform(worldTransform);

				return transformed;
			}
		}

		public BasicActor(Entity entity, Model model)
		{
			Entity = entity;
			Model = model;
			Material = new Material();

			_modelTransforms = new Matrix[Model.Bones.Count];
			Model.CopyAbsoluteBoneTransformsTo(_modelTransforms);

			buildBoundingSphere();
			generateTags();
		}

		private void buildBoundingSphere()
		{
			BoundingSphere sphere = new BoundingSphere(Vector3.Zero, 0);

			// Merge all the model's built in bounding spheres
			foreach (ModelMesh mesh in Model.Meshes)
			{
				BoundingSphere transformed = mesh.BoundingSphere.Transform(
				    _modelTransforms[mesh.ParentBone.Index]);

				sphere = BoundingSphere.CreateMerged(sphere, transformed);
			}

			_boundingSphere = sphere;
		}

		private void generateTags()
		{
			foreach (ModelMesh mesh in Model.Meshes)
			{
				foreach (ModelMeshPart part in mesh.MeshParts)
				{
					if (part.Effect is BasicEffect)
					{
						BasicEffect effect = (BasicEffect)part.Effect;
						MeshTag tag = new MeshTag(effect.DiffuseColor, effect.Texture, effect.SpecularPower);
						part.Tag = tag;
					}
				}
			}
		}

		public void CacheEffects()
		{
			foreach (ModelMesh mesh in Model.Meshes)
			{
				foreach (ModelMeshPart part in mesh.MeshParts)
				{
					((MeshTag)part.Tag).CachedEffect = part.Effect;
				}
			}
		}

		public void RestoreEffects()
		{
			foreach (ModelMesh mesh in Model.Meshes)
			{
				foreach (ModelMeshPart part in mesh.MeshParts)
				{
					if (((MeshTag)part.Tag).CachedEffect != null)
					{
						part.Effect = ((MeshTag)part.Tag).CachedEffect;
					}
				}
			}
		}

		// Sets the specified effect parameter to the given effect, if it
		// has that parameter
		void setEffectParameter(Effect effect, string paramName, object val)
		{
			if (effect.Parameters[paramName] == null)
				return;

			if (val is Vector3)
				effect.Parameters[paramName].SetValue((Vector3)val);
			else if (val is bool)
				effect.Parameters[paramName].SetValue((bool)val);
			else if (val is Matrix)
				effect.Parameters[paramName].SetValue((Matrix)val);
			else if (val is Texture2D)
				effect.Parameters[paramName].SetValue((Texture2D)val);
		}

		public void SetModelEffect(Effect effect, bool CopyEffect)
		{
			foreach (ModelMesh mesh in Model.Meshes)
				foreach (ModelMeshPart part in mesh.MeshParts)
				{
					Effect toSet = effect;

					// Copy the effect if necessary
					if (CopyEffect)
						toSet = effect.Clone();

					MeshTag tag = ((MeshTag)part.Tag);

					// If this ModelMeshPart has a texture, set it to the effect
					if (tag.Texture != null)
					{
						setEffectParameter(toSet, "BasicTexture", tag.Texture);
						setEffectParameter(toSet, "TextureEnabled", true);
					}
					else
						setEffectParameter(toSet, "TextureEnabled", false);

					// Set our remaining parameters to the effect
					setEffectParameter(toSet, "DiffuseColor", tag.Color);
					setEffectParameter(toSet, "SpecularPower", tag.SpecularPower);

					part.Effect = toSet;
				}
		}

		public void Draw(Matrix view, Matrix projection, Vector3 cameraPosition)
		{
			// Calculate the base transformation by combining
			// translation, rotation, and scaling
			Matrix baseWorld = Matrix.CreateScale(Scale)
			    * Matrix.CreateFromYawPitchRoll(
				   Rotation.Y, Rotation.X, Rotation.Z)
			    * Matrix.CreateTranslation(Position);

			foreach (ModelMesh mesh in Model.Meshes)
			{
				Matrix localWorld = _modelTransforms[mesh.ParentBone.Index] * baseWorld;

				foreach (ModelMeshPart meshPart in mesh.MeshParts)
				{
					Effect effect = meshPart.Effect;

					if (effect is BasicEffect)
					{
						((BasicEffect)effect).World = localWorld;
						((BasicEffect)effect).View = view;
						((BasicEffect)effect).Projection = projection;
						((BasicEffect)effect).EnableDefaultLighting();
					}
					else
					{
						setEffectParameter(effect, "World", localWorld);
						setEffectParameter(effect, "View", view);
						setEffectParameter(effect, "Projection", projection);
						setEffectParameter(effect, "CameraPosition", cameraPosition);

						Material.SetEffectParameters(effect);
					}
				}

				mesh.Draw();
			}
		}
	}

}
