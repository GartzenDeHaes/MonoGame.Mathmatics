#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Text;

using Portland.Mathmatics;

namespace Microsoft.Xna.Framework
{
	[Serializable]
	public struct Vector4 : IEquatable<Vector4>
	{
		#region Private Fields

		private static Vector4 zeroVector = new Vector4();
		private static Vector4 unitVector = new Vector4(1f, 1f, 1f, 1f);
		private static Vector4 unitXVector = new Vector4(1f, 0f, 0f, 0f);
		private static Vector4 unitYVector = new Vector4(0f, 1f, 0f, 0f);
		private static Vector4 unitZVector = new Vector4(0f, 0f, 1f, 0f);
		private static Vector4 unitWVector = new Vector4(0f, 0f, 0f, 1f);

		#endregion Private Fields

		#region Public Fields

		public float X;
		public float Y;
		public float Z;
		public float W;

		#endregion Public Fields

		#region Properties

		public static Vector4 Zero
		{
			get { return zeroVector; }
		}

		public static Vector4 One
		{
			get { return unitVector; }
		}

		public static Vector4 UnitX
		{
			get { return unitXVector; }
		}

		public static Vector4 UnitY
		{
			get { return unitYVector; }
		}

		public static Vector4 UnitZ
		{
			get { return unitZVector; }
		}

		public static Vector4 UnitW
		{
			get { return unitWVector; }
		}

		#endregion Properties

		#region Constructors

		public Vector4(float x, float y, float z, float w)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
			this.W = w;
		}

		public Vector4(Vector2 value, float z, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = z;
			this.W = w;
		}

		//public Vector4(Vector3d value, float w)
		//{
		//	this.X = (float)value.X;
		//	this.Y = (float)value.Y;
		//	this.Z = (float)value.Z;
		//	this.W = w;
		//}

		public Vector4(Vector3 value, float w)
		{
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
			this.W = w;
		}

		public Vector4(float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
			this.W = value;
		}

		#endregion

		#region Public Methods

		public static Vector4 Add(Vector4 value1, Vector4 value2)
		{
			value1.W += value2.W;
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static void Add(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W + value2.W;
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}

		public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2)
		{
#if (USE_FARSEER)
            return new Vector4(
                SilverSpriteMathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#else
			return new Vector4(
				 MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
				 MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
				 MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
				 MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#endif
		}

		public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1, float amount2, out Vector4 result)
		{
#if (USE_FARSEER)
            result = new Vector4(
                SilverSpriteMathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
                SilverSpriteMathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#else
			result = new Vector4(
				 MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
				 MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
				 MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2),
				 MathHelper.Barycentric(value1.W, value2.W, value3.W, amount1, amount2));
#endif
		}

		public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount)
		{
#if (USE_FARSEER)
            return new Vector4(
                SilverSpriteMathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                SilverSpriteMathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#else
			return new Vector4(
				 MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
				 MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
				 MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
				 MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#endif
		}

		public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float amount, out Vector4 result)
		{
#if (USE_FARSEER)
            result = new Vector4(
                SilverSpriteMathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
                SilverSpriteMathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
                SilverSpriteMathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#else
			result = new Vector4(
				 MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
				 MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
				 MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount),
				 MathHelper.CatmullRom(value1.W, value2.W, value3.W, value4.W, amount));
#endif
		}

		public static Vector4 Clamp(Vector4 value1, Vector4 min, Vector4 max)
		{
			return new Vector4(
				 MathHelper.Clamp(value1.X, min.X, max.X),
				 MathHelper.Clamp(value1.Y, min.Y, max.Y),
				 MathHelper.Clamp(value1.Z, min.Z, max.Z),
				 MathHelper.Clamp(value1.W, min.W, max.W));
		}

		public static void Clamp(ref Vector4 value1, ref Vector4 min, ref Vector4 max, out Vector4 result)
		{
			result = new Vector4(
				 MathHelper.Clamp(value1.X, min.X, max.X),
				 MathHelper.Clamp(value1.Y, min.Y, max.Y),
				 MathHelper.Clamp(value1.Z, min.Z, max.Z),
				 MathHelper.Clamp(value1.W, min.W, max.W));
		}

		public static float Distance(Vector4 value1, Vector4 value2)
		{
			return MathF.Sqrt(DistanceSquared(value1, value2));
		}

		public static void Distance(ref Vector4 value1, ref Vector4 value2, out float result)
		{
			result = MathF.Sqrt(DistanceSquared(value1, value2));
		}

		public static float DistanceSquared(in Vector4 value1, in Vector4 value2)
		{
			float result;
			DistanceSquared(value1, value2, out result);
			return result;
		}

		public static void DistanceSquared(in Vector4 value1, in Vector4 value2, out float result)
		{
			result = (value1.W - value2.W) * (value1.W - value2.W) +
						(value1.X - value2.X) * (value1.X - value2.X) +
						(value1.Y - value2.Y) * (value1.Y - value2.Y) +
						(value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		public static Vector4 Divide(Vector4 value1, Vector4 value2)
		{
			value1.W /= value2.W;
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector4 Divide(Vector4 value1, float divider)
		{
			float factor = 1f / divider;
			value1.W *= factor;
			value1.X *= factor;
			value1.Y *= factor;
			value1.Z *= factor;
			return value1;
		}

		public static void Divide(ref Vector4 value1, float divider, out Vector4 result)
		{
			float factor = 1f / divider;
			result.W = value1.W * factor;
			result.X = value1.X * factor;
			result.Y = value1.Y * factor;
			result.Z = value1.Z * factor;
		}

		public static void Divide(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W / value2.W;
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}

		public static float Dot(Vector4 vector1, Vector4 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
		}

		public static void Dot(ref Vector4 vector1, ref Vector4 vector2, out float result)
		{
			result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z + vector1.W * vector2.W;
		}

		public override bool Equals(object obj)
		{
			return (obj is Vector4) ? this == (Vector4)obj : false;
		}

		public bool Equals(Vector4 other)
		{
			return this.W == other.W
				 && this.X == other.X
				 && this.Y == other.Y
				 && this.Z == other.Z;
		}

        /// <summary>
        /// Round the members of this <see cref="Vector4"/> to the nearest integer value.
        /// </summary>
        public void Round()
        {
            X = MathF.Round(X);
            Y = MathF.Round(Y);
            Z = MathF.Round(Z);
            W = MathF.Round(W);
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded to the nearest integer value.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <returns>The rounded <see cref="Vector4"/>.</returns>
        public static Vector4 Round(Vector4 value)
        {
            value.X = MathF.Round(value.X);
            value.Y = MathF.Round(value.Y);
            value.Z = MathF.Round(value.Z);
            value.W = MathF.Round(value.W);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded to the nearest integer value.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <param name="result">The rounded <see cref="Vector4"/>.</param>
        public static void Round(in Vector4 value, out Vector4 result)
        {
            result.X = MathF.Round(value.X);
            result.Y = MathF.Round(value.Y);
            result.Z = MathF.Round(value.Z);
            result.W = MathF.Round(value.W);
        }

        /// <summary>
        /// Round the members of this <see cref="Vector4"/> towards positive infinity.
        /// </summary>
        public void Ceiling()
        {
            X = MathF.Ceiling(X);
            Y = MathF.Ceiling(Y);
            Z = MathF.Ceiling(Z);
            W = MathF.Ceiling(W);
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded towards positive infinity.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <returns>The rounded <see cref="Vector4"/>.</returns>
        public static Vector4 Ceiling(Vector4 value)
        {
            value.X = MathF.Ceiling(value.X);
            value.Y = MathF.Ceiling(value.Y);
            value.Z = MathF.Ceiling(value.Z);
            value.W = MathF.Ceiling(value.W);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded towards positive infinity.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <param name="result">The rounded <see cref="Vector4"/>.</param>
        public static void Ceiling(in Vector4 value, out Vector4 result)
        {
            result.X = MathF.Ceiling(value.X);
            result.Y = MathF.Ceiling(value.Y);
            result.Z = MathF.Ceiling(value.Z);
            result.W = MathF.Ceiling(value.W);
        }

        /// <summary>
        /// Round the members of this <see cref="Vector4"/> towards negative infinity.
        /// </summary>
        public void Floor()
        {
            X = MathF.Floor(X);
            Y = MathF.Floor(Y);
            Z = MathF.Floor(Z);
            W = MathF.Floor(W);
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded towards negative infinity.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <returns>The rounded <see cref="Vector4"/>.</returns>
        public static Vector4 Floor(Vector4 value)
        {
            value.X = MathF.Floor(value.X);
            value.Y = MathF.Floor(value.Y);
            value.Z = MathF.Floor(value.Z);
            value.W = MathF.Floor(value.W);
            return value;
        }

        /// <summary>
        /// Creates a new <see cref="Vector4"/> that contains members from another vector rounded towards negative infinity.
        /// </summary>
        /// <param name="value">Source <see cref="Vector4"/>.</param>
        /// <param name="result">The rounded <see cref="Vector4"/>.</param>
        public static void Floor(in Vector4 value, out Vector4 result)
        {
            result.X = MathF.Floor(value.X);
            result.Y = MathF.Floor(value.Y);
            result.Z = MathF.Floor(value.Z);
            result.W = MathF.Floor(value.W);
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Vector4"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Vector4"/>.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = W.GetHashCode();
                hashCode = (hashCode * 397) ^ X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

		public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount)
		{
			Vector4 result;
			Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result)
		{
#if (USE_FARSEER)
            result.W = SilverSpriteMathHelper.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
            result.X = SilverSpriteMathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
            result.Y = SilverSpriteMathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
            result.Z = SilverSpriteMathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
#else
			result.W = MathHelper.Hermite(value1.W, tangent1.W, value2.W, tangent2.W, amount);
			result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
#endif
		}

		public float Length()
		{
			float result;
			DistanceSquared(this, zeroVector, out result);
			return MathF.Sqrt(result);
		}

		public float LengthSquared()
		{
			float result;
			DistanceSquared(this, zeroVector, out result);
			return result;
		}

		public static Vector4 Lerp(in Vector4 value1, in Vector4 value2, float amount)
		{
			return new Vector4(
				 MathHelper.Lerp(value1.X, value2.X, amount),
				 MathHelper.Lerp(value1.Y, value2.Y, amount),
				 MathHelper.Lerp(value1.Z, value2.Z, amount),
				 MathHelper.Lerp(value1.W, value2.W, amount));
		}

		public static void Lerp(in Vector4 value1, in Vector4 value2, float amount, out Vector4 result)
		{
			result = new Vector4(
				 MathHelper.Lerp(value1.X, value2.X, amount),
				 MathHelper.Lerp(value1.Y, value2.Y, amount),
				 MathHelper.Lerp(value1.Z, value2.Z, amount),
				 MathHelper.Lerp(value1.W, value2.W, amount));
		}

		public static Vector4 Max(in Vector4 value1, in Vector4 value2)
		{
			return new Vector4(
				MathHelper.Max(value1.X, value2.X),
				MathHelper.Max(value1.Y, value2.Y),
				MathHelper.Max(value1.Z, value2.Z),
				MathHelper.Max(value1.W, value2.W));
		}

		public static void Max(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result = new Vector4(
				MathHelper.Max(value1.X, value2.X),
				MathHelper.Max(value1.Y, value2.Y),
				MathHelper.Max(value1.Z, value2.Z),
				MathHelper.Max(value1.W, value2.W));
		}

		public static Vector4 Min(in Vector4 value1, in Vector4 value2)
		{
			return new Vector4(
				MathHelper.Min(value1.X, value2.X),
				MathHelper.Min(value1.Y, value2.Y),
				MathHelper.Min(value1.Z, value2.Z),
				MathHelper.Min(value1.W, value2.W));
		}

		public static void Min(in Vector4 value1, in Vector4 value2, out Vector4 result)
		{
			result = new Vector4(
				MathHelper.Min(value1.X, value2.X),
				MathHelper.Min(value1.Y, value2.Y),
				MathHelper.Min(value1.Z, value2.Z),
				MathHelper.Min(value1.W, value2.W));
		}

		public static Vector4 Multiply(Vector4 value1, in Vector4 value2)
		{
			value1.W *= value2.W;
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector4 Multiply(Vector4 value1, float scaleFactor)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static void Multiply(ref Vector4 value1, float scaleFactor, out Vector4 result)
		{
			result.W = value1.W * scaleFactor;
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}

		public static void Multiply(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
		{
			result.W = value1.W * value2.W;
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}

		public static Vector4 Negate(in Vector4 value)
		{
			return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		public static void Negate(in Vector4 value, out Vector4 result)
		{
			result = new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		public void Normalize()
		{
			Normalize(this, out this);
		}

		public static Vector4 Normalize(in Vector4 vector)
		{
			Normalize(vector, out var vectoro);
			return vectoro;
		}

		public static void Normalize(in Vector4 vector, out Vector4 result)
		{
			float factor;
			DistanceSquared(vector, zeroVector, out factor);
			factor = 1f / MathF.Sqrt(factor);

			result.W = vector.W * factor;
			result.X = vector.X * factor;
			result.Y = vector.Y * factor;
			result.Z = vector.Z * factor;
		}

		public static Vector4 SmoothStep(in Vector4 value1, in Vector4 value2, float amount)
		{
#if (USE_FARSEER)
            return new Vector4(
                SilverSpriteMathHelper.SmoothStep(value1.X, value2.X, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Y, value2.Y, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Z, value2.Z, amount),
                SilverSpriteMathHelper.SmoothStep(value1.W, value2.W, amount));
#else
			return new Vector4(
				 MathHelper.SmoothStep(value1.X, value2.X, amount),
				 MathHelper.SmoothStep(value1.Y, value2.Y, amount),
				 MathHelper.SmoothStep(value1.Z, value2.Z, amount),
				 MathHelper.SmoothStep(value1.W, value2.W, amount));
#endif
		}

		public static void SmoothStep(in Vector4 value1, in Vector4 value2, float amount, out Vector4 result)
		{
#if (USE_FARSEER)
            result = new Vector4(
                SilverSpriteMathHelper.SmoothStep(value1.X, value2.X, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Y, value2.Y, amount),
                SilverSpriteMathHelper.SmoothStep(value1.Z, value2.Z, amount),
                SilverSpriteMathHelper.SmoothStep(value1.W, value2.W, amount));
#else
			result = new Vector4(
				 MathHelper.SmoothStep(value1.X, value2.X, amount),
				 MathHelper.SmoothStep(value1.Y, value2.Y, amount),
				 MathHelper.SmoothStep(value1.Z, value2.Z, amount),
				 MathHelper.SmoothStep(value1.W, value2.W, amount));
#endif
		}

		public static Vector4 Subtract(Vector4 value1, Vector4 value2)
		{
			value1.W -= value2.W;
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static void Subtract(in Vector4 value1, in Vector4 value2, out Vector4 result)
		{
			result.W = value1.W - value2.W;
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}

		public static Vector4 Transform(in Vector2 position, in Matrix matrix)
		{
			Vector4 result;
			Transform(position, matrix, out result);
			return result;
		}

		public static Vector4 Transform(in Vector3 position, in Matrix matrix)
		{
			Vector4 result;
			Transform(position, matrix, out result);
			return result;
		}

		public static Vector4 Transform(in Vector4 vector, in Matrix matrix)
		{
			Transform(vector, matrix, out var vectoro);
			return vectoro;
		}

		public static void Transform(in Vector2 position, in Matrix matrix, out Vector4 result)
		{
			result = new Vector4((position.X * matrix.M11) + (position.Y * matrix.M21) + matrix.M41,
										(position.X * matrix.M12) + (position.Y * matrix.M22) + matrix.M42,
										(position.X * matrix.M13) + (position.Y * matrix.M23) + matrix.M43,
										(position.X * matrix.M14) + (position.Y * matrix.M24) + matrix.M44);
		}

		public static void Transform(in Vector3 position, in Matrix matrix, out Vector4 result)
		{
			result = new Vector4((position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
										(position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
										(position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43,
										(position.X * matrix.M14) + (position.Y * matrix.M24) + (position.Z * matrix.M34) + matrix.M44);
		}

		public static void Transform(in Vector4 vector, in Matrix matrix, out Vector4 result)
		{
			result = new Vector4((vector.X * matrix.M11) + (vector.Y * matrix.M21) + (vector.Z * matrix.M31) + (vector.W * matrix.M41),
										(vector.X * matrix.M12) + (vector.Y * matrix.M22) + (vector.Z * matrix.M32) + (vector.W * matrix.M42),
										(vector.X * matrix.M13) + (vector.Y * matrix.M23) + (vector.Z * matrix.M33) + (vector.W * matrix.M43),
										(vector.X * matrix.M14) + (vector.Y * matrix.M24) + (vector.Z * matrix.M34) + (vector.W * matrix.M44));
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(32);
			sb.Append("{X:");
			sb.Append(this.X);
			sb.Append(" Y:");
			sb.Append(this.Y);
			sb.Append(" Z:");
			sb.Append(this.Z);
			sb.Append(" W:");
			sb.Append(this.W);
			sb.Append("}");
			return sb.ToString();
		}

		#endregion Public Methods

		#region Operators

		public static Vector4 operator -(Vector4 value)
		{
			return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
		}

		public static bool operator ==(Vector4 value1, Vector4 value2)
		{
			return value1.W == value2.W
				 && value1.X == value2.X
				 && value1.Y == value2.Y
				 && value1.Z == value2.Z;
		}

		public static bool operator !=(Vector4 value1, Vector4 value2)
		{
			return !(value1 == value2);
		}

		public static Vector4 operator +(Vector4 value1, Vector4 value2)
		{
			value1.W += value2.W;
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static Vector4 operator -(Vector4 value1, Vector4 value2)
		{
			value1.W -= value2.W;
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static Vector4 operator *(Vector4 value1, Vector4 value2)
		{
			value1.W *= value2.W;
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector4 operator *(Vector4 value1, float scaleFactor)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static Vector4 operator *(float scaleFactor, Vector4 value1)
		{
			value1.W *= scaleFactor;
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static Vector4 operator /(Vector4 value1, Vector4 value2)
		{
			value1.W /= value2.W;
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector4 operator /(Vector4 value1, float divider)
		{
			float factor = 1f / divider;
			value1.W *= factor;
			value1.X *= factor;
			value1.Y *= factor;
			value1.Z *= factor;
			return value1;
		}

		#endregion Operators
	}
}
