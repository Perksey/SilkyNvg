﻿using SilkyNvg.Core.Paths;
using System.Numerics;

namespace SilkyNvg.Core.Instructions
{
    internal class LineToInstruction : IInstruction
    {

        private Vector2 _position;

        public bool RequiresPosition => true;

        public PathCache PathCache { private get; set; }

        public float[] Data => new float[] { _position.Y, _position.X };

        public LineToInstruction(Vector2 position)
        {
            _position = position;
        }

        public void Transform(Matrix3x2 transform)
        {
            _position = Vector2.Transform(_position, transform);
        }

        public void BuildPath()
        {
            PathCache.AddPoint(_position, PointFlags.Corner);
        }

    }
}
