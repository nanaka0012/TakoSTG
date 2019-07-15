using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STG
{
    class CollidableObject : asd.TextureObject2D
    {
        public float radius;

        protected void SetRadius()
        {
            radius = Texture.Size.X / 2.0f;
        }

        protected bool OutOfWindow()
        {
            var ws = asd.Engine.WindowSize.To2DF();
            var size = Texture.Size.To2DF();

            var outX = (Position.X < size.X / 2.0f) || (ws.X - size.X / 2.0f < Position.X);
            var outY = (Position.Y < size.Y / 2.0f) || (ws.Y - size.Y / 2.0f < Position.Y);

            return (outX || outY);
        }

        protected bool IsCollide(CollidableObject o)
        {
            var distance = (Position - o.Position).SquaredLength;
            
            return ((radius + o.radius) * (radius + o.radius) > distance);
        }
    }
}
