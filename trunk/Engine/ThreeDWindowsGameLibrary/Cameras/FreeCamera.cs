﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThreeDWindowsGameLibrary.Cameras
{
    public class FreeCamera : Camera
    {
        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public Vector3 Position { get; set; }
        public Vector3 Target { get; private set; }

        private Vector3 _translation;

        public FreeCamera(Vector3 position, float yaw, float pitch, GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
            Position = position;
            Yaw = yaw;
            Pitch = pitch;

            _translation = Vector3.Zero;
        }

        public void Rotate(float yawChange, float pitchChange)
        {
            Yaw += yawChange;
            Pitch += pitchChange;
        }

        public void Move(Vector3 translation)
        {
            _translation += translation;
        }

        public override void Update()
        {
            // Calculate the rotation matrix
            Matrix rotation = Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0);

            // Offset the position and reset the translation
            _translation = Vector3.Transform(_translation, rotation);
            Position += _translation;
            _translation = Vector3.Zero;

            // Calculate the new target
            Vector3 forward = Vector3.Transform(Vector3.Forward, rotation);
            Target = Position + forward;

            // Calculate the up vector
            Vector3 up = Vector3.Transform(Vector3.Up, rotation);

            // Calculate the view matrix
            View = Matrix.CreateLookAt(Position, Target, up);
        }
    }
}
