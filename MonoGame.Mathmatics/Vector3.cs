// MIT License - Copyright (C) The Mono.Xna Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

#if !UNITY_5_3_OR_NEWER

using System;
using System.Diagnostics;
using System.Text;
using System.Runtime.Serialization;
using Portland.Mathmatics;

namespace Microsoft.Xna.Framework
{
	/// <summary>
	/// Describes a 3D-vector.
	/// </summary>
	[DataContract]
	[DebuggerDisplay("{DebugDisplayString,nq}")]
	public struct Vector3 //: IEquatable<Vector3>
	{
		#region Static Fields

		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);
		public static Vector3 zero { get {return Zero;} }
		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);
		public static readonly Vector3 UnitX = new Vector3(1f, 0f, 0f);
		public static readonly Vector3 UnitY = new Vector3(0f, 1f, 0f);
		public static readonly Vector3 UnitZ = new Vector3(0f, 0f, 1f);
		public static readonly Vector3 Up = new Vector3(0f, 1f, 0f);
		public static readonly Vector3 Down = new Vector3(0f, -1f, 0f);
		public static readonly Vector3 Right = new Vector3(1f, 0f, 0f);
		public static readonly Vector3 Left = new Vector3(-1f, 0f, 0f);
		public static readonly Vector3 Forward = new Vector3(0f, 0f, 1f);
		public static readonly Vector3 Backward = new Vector3(0f, 0f, -1f);
		public static readonly Vector3 East = new Vector3(1, 0, 0);
		public static readonly Vector3 West = new Vector3(-1, 0, 0);
		public static readonly Vector3 North = new Vector3(0, 0, -1);
		public static readonly Vector3 South = new Vector3(0, 0, 1);

		#endregion

		#region Public Fields

		/// <summary>
		/// The x coordinate of this <see cref="Vector3 />.
		/// </summary>
		[DataMember]
		public float X;

		/// <summary>
		/// The y coordinate of this <see cref="Vector3 />.
		/// </summary>
		[DataMember]
		public float Y;

		/// <summary>
		/// The z coordinate of this <see cref="Vector3 />.
		/// </summary>
		[DataMember]
		public float Z;

		public float x { get { return X; } }
		public float y { get { return Y; } }
		public float z { get { return Z; } }

		#endregion

		#region Internal Properties

		internal string DebugDisplayString
		{
			get
			{
				return string.Concat(
					 this.X.ToString(), "  ",
					 this.Y.ToString(), "  ",
					 this.Z.ToString()
				);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Constructs a 3d vector with X, Y and Z from three values.
		/// </summary>
		/// <param name="x">The x coordinate in 3d-space.</param>
		/// <param name="y">The y coordinate in 3d-space.</param>
		/// <param name="z">The z coordinate in 3d-space.</param>
		public Vector3 (float x, float y, float z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		/// <summary>
		/// Constructs a 3d vector with X, Y and Z set to the same value.
		/// </summary>
		/// <param name="value">The x, y and z coordinates in 3d-space.</param>
		public Vector3 (float value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		/// <summary>
		/// Constructs a 3d vector with X, Y from <see cref="Vector2f"/> and Z from a scalar.
		/// </summary>
		/// <param name="value">The x and y coordinates in 3d-space.</param>
		/// <param name="z">The z coordinate in 3d-space.</param>
		public Vector3 (in Vector2 value, float z)
		{
			this.X = (float)value.X;
			this.Y = (float)value.Y;
			this.Z = z;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Performs vector addition on <paramref name="value1"/> and <paramref name="value2"/>.
		/// </summary>
		/// <param name="value1">The first vector to add.</param>
		/// <param name="value2">The second vector to add.</param>
		/// <returns>The result of the vector addition.</returns>
		public static Vector3 Add(in Vector3 value1, in Vector3 value2)
		{
			Vector3 ret = value1;
			ret.X += value2.X;
			ret.Y += value2.Y;
			ret.Z += value2.Z;
			return ret;
		}

		/// <summary>
		/// Performs vector addition on <paramref name="value1"/> and
		/// <paramref name="value2"/>, storing the result of the
		/// addition in <paramref name="result"/>.
		/// </summary>
		/// <param name="value1">The first vector to add.</param>
		/// <param name="value2">The second vector to add.</param>
		/// <param name="result">The result of the vector addition.</param>
		public static void Add(in Vector3 value1, in Vector3 value2, out Vector3 result)
		{
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains the cartesian coordinates of a vector specified in barycentric coordinates and relative to 3d-triangle.
		/// </summary>
		/// <param name="value1">The first vector of 3d-triangle.</param>
		/// <param name="value2">The second vector of 3d-triangle.</param>
		/// <param name="value3">The third vector of 3d-triangle.</param>
		/// <param name="amount1">Barycentric scalar <c>b2</c> which represents a weighting factor towards second vector of 3d-triangle.</param>
		/// <param name="amount2">Barycentric scalar <c>b3</c> which represents a weighting factor towards third vector of 3d-triangle.</param>
		/// <returns>The cartesian translation of barycentric coordinates.</returns>
		public static Vector3 Barycentric(in Vector3 value1, in Vector3 value2, in Vector3 value3, float amount1, float amount2)
		{
			return new Vector3(
				 MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2),
				 MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2),
				 MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains the cartesian coordinates of a vector specified in barycentric coordinates and relative to 3d-triangle.
		/// </summary>
		/// <param name="value1">The first vector of 3d-triangle.</param>
		/// <param name="value2">The second vector of 3d-triangle.</param>
		/// <param name="value3">The third vector of 3d-triangle.</param>
		/// <param name="amount1">Barycentric scalar <c>b2</c> which represents a weighting factor towards second vector of 3d-triangle.</param>
		/// <param name="amount2">Barycentric scalar <c>b3</c> which represents a weighting factor towards third vector of 3d-triangle.</param>
		/// <param name="result">The cartesian translation of barycentric coordinates as an output parameter.</param>
		public static void Barycentric(in Vector3 value1, in Vector3 value2, in Vector3 value3, float amount1, float amount2, out Vector3 result)
		{
			result.X = MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2);
			result.Y = MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2);
			result.Z = MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains CatmullRom interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">The first vector in interpolation.</param>
		/// <param name="value2">The second vector in interpolation.</param>
		/// <param name="value3">The third vector in interpolation.</param>
		/// <param name="value4">The fourth vector in interpolation.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <returns>The result of CatmullRom interpolation.</returns>
		public static Vector3 CatmullRom(in Vector3 value1, in Vector3 value2, in Vector3 value3, in Vector3 value4, float amount)
		{
			return new Vector3(
				 MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount),
				 MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount),
				 MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains CatmullRom interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">The first vector in interpolation.</param>
		/// <param name="value2">The second vector in interpolation.</param>
		/// <param name="value3">The third vector in interpolation.</param>
		/// <param name="value4">The fourth vector in interpolation.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <param name="result">The result of CatmullRom interpolation as an output parameter.</param>
		public static void CatmullRom(in Vector3 value1, in Vector3 value2, in Vector3 value3, in Vector3 value4, float amount, out Vector3 result)
		{
			result.X = MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount);
			result.Y = MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount);
			result.Z = MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount);
		}

		/// <summary>
		/// Round the members of this <see cref="Vector3 /> towards positive infinity.
		/// </summary>
		public void Ceiling()
		{
			X = MathF.Ceiling(X);
			Y = MathF.Ceiling(Y);
			Z = MathF.Ceiling(Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded towards positive infinity.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <returns>The rounded <see cref="Vector3 />.</returns>
		public static Vector3 Ceiling(in Vector3 value)
		{
			return new Vector3(MathF.Ceiling(value.X), MathF.Ceiling(value.Y), MathF.Ceiling(value.Z));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded towards positive infinity.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="result">The rounded <see cref="Vector3 />.</param>
		public static void Ceiling(in Vector3 value, out Vector3 result)
		{
			result.X = MathF.Ceiling(value.X);
			result.Y = MathF.Ceiling(value.Y);
			result.Z = MathF.Ceiling(value.Z);
		}

		/// <summary>
		/// Clamps the specified value within a range.
		/// </summary>
		/// <param name="value1">The value to clamp.</param>
		/// <param name="min">The min value.</param>
		/// <param name="max">The max value.</param>
		/// <returns>The clamped value.</returns>
		public static Vector3 Clamp(in Vector3 value1, in Vector3 min, in Vector3 max)
		{
			return new Vector3(
				 MathHelper.Clamp(value1.X, min.X, max.X),
				 MathHelper.Clamp(value1.Y, min.Y, max.Y),
				 MathHelper.Clamp(value1.Z, min.Z, max.Z));
		}

		public void Clamp(float value)
		{
			if (MathF.Abs(X) > value)
				X = (float)(value * (X < 0 ? -1 : 1));
			if (MathF.Abs(Y) > value)
				Y = (float)(value * (Y < 0 ? -1 : 1));
			if (MathF.Abs(Z) > value)
				Z = (float)(value * (Z < 0 ? -1 : 1));
		}

		/// <summary>
		/// Clamps the specified value within a range.
		/// </summary>
		/// <param name="value1">The value to clamp.</param>
		/// <param name="min">The min value.</param>
		/// <param name="max">The max value.</param>
		/// <param name="result">The clamped value as an output parameter.</param>
		public static void Clamp(in Vector3 value1, in Vector3 min, in Vector3 max, out Vector3 result)
		{
			result.X = MathHelper.Clamp(value1.X, min.X, max.X);
			result.Y = MathHelper.Clamp(value1.Y, min.Y, max.Y);
			result.Z = MathHelper.Clamp(value1.Z, min.Z, max.Z);
		}

		/// <summary>
		/// Computes the cross product of two vectors.
		/// </summary>
		/// <param name="vector1">The first vector.</param>
		/// <param name="vector2">The second vector.</param>
		/// <returns>The cross product of two vectors.</returns>
		public static Vector3 Cross(in Vector3 vector1, in Vector3 vector2)
		{
			Cross(vector1, vector2, out var vr);
			return vr;
		}

		/// <summary>
		/// Computes the cross product of two vectors.
		/// </summary>
		/// <param name="vector1">The first vector.</param>
		/// <param name="vector2">The second vector.</param>
		/// <param name="result">The cross product of two vectors as an output parameter.</param>
		public static void Cross(in Vector3 vector1, in Vector3 vector2, out Vector3 result)
		{
			var x = vector1.Y * (double)vector2.Z - vector2.Y * (double)vector1.Z;
			var y = -(vector1.X * (double)vector2.Z - vector2.X * (double)vector1.Z);
			var z = vector1.X * (double)vector2.Y - vector2.X * (double)vector1.Y;
			result.X = (float)x;
			result.Y = (float)y;
			result.Z = (float)z;
		}

		public float DistanceTo(in Vector3 other)
		{
			return (float)Math.Sqrt((other.X - X) * (other.X - X) +
								  (other.Y - Y) * (other.Y - Y) +
								  (other.Z - Z) * (other.Z - Z));
		}

		/// <summary>
		/// Returns the distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The distance between two vectors.</returns>
		public static float Distance(in Vector3 value1, in Vector3 value2)
		{
			float result;
			DistanceSquared(value1, value2, out result);
			return MathF.Sqrt(result);
		}

		/// <summary>
		/// Returns the distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="result">The distance between two vectors as an output parameter.</param>
		public static void Distance(in Vector3 value1, in Vector3 value2, out float result)
		{
			DistanceSquared(value1, value2, out result);
			result = MathF.Sqrt(result);
		}

		/// <summary>
		/// Returns the squared distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The squared distance between two vectors.</returns>
		public static float DistanceSquared(in Vector3 value1, in Vector3 value2)
		{
			return (value1.X - value2.X) * (value1.X - value2.X) +
					  (value1.Y - value2.Y) * (value1.Y - value2.Y) +
					  (value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		/// <summary>
		/// Returns the squared distance between two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="result">The squared distance between two vectors as an output parameter.</param>
		public static void DistanceSquared(in Vector3 value1, in Vector3 value2, out float result)
		{
			result = (value1.X - value2.X) * (value1.X - value2.X) +
						(value1.Y - value2.Y) * (value1.Y - value2.Y) +
						(value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by the components of another <see cref="Vector3 />.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Divisor <see cref="Vector3 />.</param>
		/// <returns>The result of dividing the vectors.</returns>
		public static Vector3 Divide(in Vector3 value1, in Vector3 value2)
		{
			Vector3 ret = value1;
			ret.X /= value2.X;
			ret.Y /= value2.Y;
			ret.Z /= value2.Z;
			return ret;
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by a scalar.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="divider">Divisor scalar.</param>
		/// <returns>The result of dividing a vector by a scalar.</returns>
		public static Vector3 Divide(Vector3 value1, float divider)
		{
			float factor = 1 / divider;
			value1.X *= factor;
			value1.Y *= factor;
			value1.Z *= factor;
			return value1;
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by a scalar.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="divider">Divisor scalar.</param>
		/// <param name="result">The result of dividing a vector by a scalar as an output parameter.</param>
		public static void Divide(in Vector3 value1, float divider, out Vector3 result)
		{
			float factor = 1 / divider;
			result.X = value1.X * factor;
			result.Y = value1.Y * factor;
			result.Z = value1.Z * factor;
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by the components of another <see cref="Vector3 />.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Divisor <see cref="Vector3 />.</param>
		/// <param name="result">The result of dividing the vectors as an output parameter.</param>
		public static void Divide(in Vector3 value1, in Vector3 value2, out Vector3 result)
		{
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}

		/// <summary>
		/// Returns a dot product of two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The dot product of two vectors.</returns>
		public static float Dot(in Vector3 value1, in Vector3 value2)
		{
			return (float)(value1.X * (double)value2.X + value1.Y * (double)value2.Y + value1.Z * (double)value2.Z);
		}

		/// <summary>
		/// Returns a dot product of two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="result">The dot product of two vectors as an output parameter.</param>
		public static void Dot(in Vector3 value1, in Vector3 value2, out float result)
		{
			result = (float)(value1.X * (double)value2.X + value1.Y * (double)value2.Y + value1.Z * (double)value2.Z);
		}

		/// <summary>
		/// Compares whether current instance is equal to specified <see cref="Object"/>.
		/// </summary>
		/// <param name="obj">The <see cref="Object"/> to compare.</param>
		/// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (!(obj is Vector3))
				return false;

			var other = (Vector3) obj;
			return X == other.X &&
					  Y == other.Y &&
					  Z == other.Z;
		}

		/// <summary>
		/// Compares whether current instance is equal to specified <see cref="Vector3 />.
		/// </summary>
		/// <param name="other">The <see cref="Vector3 /> to compare.</param>
		/// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
		public bool Equals(Vector3 other)
		{
			return X == other.X &&
					  Y == other.Y &&
					  Z == other.Z;
		}

		/// <summary>
		/// Round the members of this <see cref="Vector3 /> towards negative infinity.
		/// </summary>
		public void Floor()
		{
			X = MathF.Floor(X);
			Y = MathF.Floor(Y);
			Z = MathF.Floor(Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded towards negative infinity.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <returns>The rounded <see cref="Vector3 />.</returns>
		public static Vector3 Floor(Vector3 value)
		{
			value.X = MathF.Floor(value.X);
			value.Y = MathF.Floor(value.Y);
			value.Z = MathF.Floor(value.Z);
			return value;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded towards negative infinity.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="result">The rounded <see cref="Vector3 />.</param>
		public static void Floor(in Vector3 value, out Vector3 result)
		{
			result.X = MathF.Floor(value.X);
			result.Y = MathF.Floor(value.Y);
			result.Z = MathF.Floor(value.Z);
		}

		/// <summary>
		/// Gets the hash code of this <see cref="Vector3 />.
		/// </summary>
		/// <returns>Hash code of this <see cref="Vector3 />.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = X.GetHashCode();
				hashCode = (hashCode * 397) ^ Y.GetHashCode();
				hashCode = (hashCode * 397) ^ Z.GetHashCode();
				return hashCode;
			}
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains hermite spline interpolation.
		/// </summary>
		/// <param name="value1">The first position vector.</param>
		/// <param name="tangent1">The first tangent vector.</param>
		/// <param name="value2">The second position vector.</param>
		/// <param name="tangent2">The second tangent vector.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <returns>The hermite spline interpolation vector.</returns>
		public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float amount)
		{
			return new Vector3(MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount),
									 MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount),
									 MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains hermite spline interpolation.
		/// </summary>
		/// <param name="value1">The first position vector.</param>
		/// <param name="tangent1">The first tangent vector.</param>
		/// <param name="value2">The second position vector.</param>
		/// <param name="tangent2">The second tangent vector.</param>
		/// <param name="amount">Weighting factor.</param>
		/// <param name="result">The hermite spline interpolation vector as an output parameter.</param>
		public static void Hermite(in Vector3 value1, in Vector3 tangent1, in Vector3 value2, in Vector3 tangent2, float amount, out Vector3 result)
		{
			result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
		}

		/// <summary>
		/// Returns the length of this <see cref="Vector3 />.
		/// </summary>
		/// <returns>The length of this <see cref="Vector3 />.</returns>
		public float Magnitude
		{
			get { return MathF.Sqrt((X * X) + (Y * Y) + (Z * Z)); }
		}

		/// <summary>
		/// Returns the squared length of this <see cref="Vector3 />.
		/// </summary>
		/// <returns>The squared length of this <see cref="Vector3 />.</returns>
		public float SqrMagnitude
		{
			get { return (X * X) + (Y * Y) + (Z * Z); }
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains linear interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
		/// <returns>The result of linear interpolation of the specified vectors.</returns>
		public static Vector3 Lerp(in Vector3 value1, in Vector3 value2, float amount)
		{
			return new Vector3(
				 MathHelper.Lerp(value1.X, value2.X, amount),
				 MathHelper.Lerp(value1.Y, value2.Y, amount),
				 MathHelper.Lerp(value1.Z, value2.Z, amount));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains linear interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
		/// <param name="result">The result of linear interpolation of the specified vectors as an output parameter.</param>
		public static void Lerp(in Vector3 value1, in Vector3 value2, float amount, out Vector3 result)
		{
			result.X = MathHelper.Lerp(value1.X, value2.X, amount);
			result.Y = MathHelper.Lerp(value1.Y, value2.Y, amount);
			result.Z = MathHelper.Lerp(value1.Z, value2.Z, amount);
		}

		///// <summary>
		///// Creates a new <see cref="Vector3"/> that contains linear interpolation of the specified vectors.
		///// Uses <see cref="MathHelper.LerpPrecise"/> on MathHelper for the interpolation.
		///// Less efficient but more precise compared to <see cref="Vector3.Lerp(Vector3, Vector3, float)"/>.
		///// See remarks section of <see cref="MathHelper.LerpPrecise"/> on MathHelper for more info.
		///// </summary>
		///// <param name="value1">The first vector.</param>
		///// <param name="value2">The second vector.</param>
		///// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
		///// <returns>The result of linear interpolation of the specified vectors.</returns>
		//public static Vector3 LerpPrecise(Vector3 value1, Vector3 value2, float amount)
		//{
		//	return new Vector3(
		//		 MathHelper.LerpPrecise(value1.X, value2.X, amount),
		//		 MathHelper.LerpPrecise(value1.Y, value2.Y, amount),
		//		 MathHelper.LerpPrecise(value1.Z, value2.Z, amount));
		//}

		///// <summary>
		///// Creates a new <see cref="Vector3"/> that contains linear interpolation of the specified vectors.
		///// Uses <see cref="MathHelper.LerpPrecise"/> on MathHelper for the interpolation.
		///// Less efficient but more precise compared to <see cref="Vector3.Lerp(ref Vector3, ref Vector3, float, out Vector3)"/>.
		///// See remarks section of <see cref="MathHelper.LerpPrecise"/> on MathHelper for more info.
		///// </summary>
		///// <param name="value1">The first vector.</param>
		///// <param name="value2">The second vector.</param>
		///// <param name="amount">Weighting value(between 0.0 and 1.0).</param>
		///// <param name="result">The result of linear interpolation of the specified vectors as an output parameter.</param>
		//public static void LerpPrecise(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		//{
		//	result.X = MathHelper.LerpPrecise(value1.X, value2.X, amount);
		//	result.Y = MathHelper.LerpPrecise(value1.Y, value2.Y, amount);
		//	result.Z = MathHelper.LerpPrecise(value1.Z, value2.Z, amount);
		//}

		/// <summary>
		/// Creates a new <see cref="Vector3"/> that contains a maximal values from the two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The <see cref="Vector3"/> with maximal values from the two vectors.</returns>
		public static Vector3 Max(in Vector3 value1, in Vector3 value2)
		{
			return new Vector3(
				 MathHelper.Max(value1.X, value2.X),
				 MathHelper.Max(value1.Y, value2.Y),
				 MathHelper.Max(value1.Z, value2.Z));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a maximal values from the two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="result">The <see cref="Vector3 /> with maximal values from the two vectors as an output parameter.</param>
		public static void Max(in Vector3 value1, in Vector3 value2, out Vector3 result)
		{
			result.X = MathHelper.Max(value1.X, value2.X);
			result.Y = MathHelper.Max(value1.Y, value2.Y);
			result.Z = MathHelper.Max(value1.Z, value2.Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a minimal values from the two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <returns>The <see cref="Vector3 /> with minimal values from the two vectors.</returns>
		public static Vector3 Min(in Vector3 value1, in Vector3 value2)
		{
			return new Vector3(
				 MathHelper.Min(value1.X, value2.X),
				 MathHelper.Min(value1.Y, value2.Y),
				 MathHelper.Min(value1.Z, value2.Z));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a minimal values from the two vectors.
		/// </summary>
		/// <param name="value1">The first vector.</param>
		/// <param name="value2">The second vector.</param>
		/// <param name="result">The <see cref="Vector3 /> with minimal values from the two vectors as an output parameter.</param>
		public static void Min(in Vector3 value1, in Vector3 value2, out Vector3 result)
		{
			result.X = MathHelper.Min(value1.X, value2.X);
			result.Y = MathHelper.Min(value1.Y, value2.Y);
			result.Z = MathHelper.Min(value1.Z, value2.Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a multiplication of two vectors.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <returns>The result of the vector multiplication.</returns>
		public static Vector3 Multiply(in Vector3 value1, in Vector3 value2)
		{
			Vector3 ret = value1;
			ret.X *= value2.X;
			ret.Y *= value2.Y;
			ret.Z *= value2.Z;
			return ret;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a multiplication of <see cref="Vector3 /> and a scalar.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="scaleFactor">Scalar value.</param>
		/// <returns>The result of the vector multiplication with a scalar.</returns>
		public static Vector3 Multiply(in Vector3 value1, float scaleFactor)
		{
			Vector3 ret = value1;
			ret.X *= scaleFactor;
			ret.Y *= scaleFactor;
			ret.Z *= scaleFactor;
			return ret;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a multiplication of <see cref="Vector3 /> and a scalar.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="scaleFactor">Scalar value.</param>
		/// <param name="result">The result of the multiplication with a scalar as an output parameter.</param>
		public static void Multiply(in Vector3 value1, float scaleFactor, out Vector3 result)
		{
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a multiplication of two vectors.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <param name="result">The result of the vector multiplication as an output parameter.</param>
		public static void Multiply(in Vector3 value1, in Vector3 value2, out Vector3 result)
		{
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains the specified vector inversion.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <returns>The result of the vector inversion.</returns>
		public static Vector3 Negate(in Vector3 value)
		{
			return new Vector3(-value.X, -value.Y, -value.Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains the specified vector inversion.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="result">The result of the vector inversion as an output parameter.</param>
		public static void Negate(in Vector3 value, out Vector3 result)
		{
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
		}

		public Vector3 Normalized
		{
			get { return Normalize(this); }
		}

		/// <summary>
		/// Turns this <see cref="Vector3 /> to a unit vector with the same direction.
		/// </summary>
		public void Normalize()
		{
			float factor = MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));
			if (factor == 0f)
			{
				return;
			}
			factor = 1f / factor;
			X *= factor;
			Y *= factor;
			Z *= factor;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a normalized values from another vector.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <returns>Unit vector.</returns>
		public static Vector3 Normalize(in Vector3 value)
		{
			float factor = MathF.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
			if (factor == 0f)
			{
				return Vector3.Zero;
			}
			factor = 1f / factor;
			return new Vector3(value.X * factor, value.Y * factor, value.Z * factor);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a normalized values from another vector.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="result">Unit vector as an output parameter.</param>
		public static void Normalize(in Vector3 value, out Vector3 result)
		{
			float factor = MathF.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
			if (factor == 0f)
			{
				result = Vector3.Zero;
				return;
			}
			factor = 1f / factor;
			result.X = value.X * factor;
			result.Y = value.Y * factor;
			result.Z = value.Z * factor;
		}

		public static void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent) 
		{ 
			normal.Normalize(); 
			tangent.Normalize(); 
			tangent = Cross(tangent, normal); 
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains reflect vector of the given vector and normal.
		/// </summary>
		/// <param name="vector">Source <see cref="Vector3 />.</param>
		/// <param name="normal">Reflection normal.</param>
		/// <returns>Reflected vector.</returns>
		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			// I is the original array
			// N is the normal of the incident plane
			// R = I - (2 * N * ( DotProduct[ I,N] ))
			Vector3 reflectedVector;
			// inline the dotProduct here instead of calling method
			float dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
			reflectedVector.X = vector.X - (2.0f * normal.X) * dotProduct;
			reflectedVector.Y = vector.Y - (2.0f * normal.Y) * dotProduct;
			reflectedVector.Z = vector.Z - (2.0f * normal.Z) * dotProduct;

			return reflectedVector;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains reflect vector of the given vector and normal.
		/// </summary>
		/// <param name="vector">Source <see cref="Vector3 />.</param>
		/// <param name="normal">Reflection normal.</param>
		/// <param name="result">Reflected vector as an output parameter.</param>
		public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
			// I is the original array
			// N is the normal of the incident plane
			// R = I - (2 * N * ( DotProduct[ I,N] ))

			// inline the dotProduct here instead of calling method
			float dotProduct = ((vector.X * normal.X) + (vector.Y * normal.Y)) + (vector.Z * normal.Z);
			result.X = vector.X - (2.0f * normal.X) * dotProduct;
			result.Y = vector.Y - (2.0f * normal.Y) * dotProduct;
			result.Z = vector.Z - (2.0f * normal.Z) * dotProduct;
		}

		/// <summary>
		/// Round the members of this <see cref="Vector3 /> towards the nearest integer value.
		/// </summary>
		public void Round()
		{
			X = MathF.Round(X);
			Y = MathF.Round(Y);
			Z = MathF.Round(Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded to the nearest integer value.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <returns>The rounded <see cref="Vector3 />.</returns>
		public static Vector3 Round(Vector3 value)
		{
			value.X = MathF.Round(value.X);
			value.Y = MathF.Round(value.Y);
			value.Z = MathF.Round(value.Z);
			return value;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains members from another vector rounded to the nearest integer value.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="result">The rounded <see cref="Vector3 />.</param>
		public static void Round(ref Vector3 value, out Vector3 result)
		{
			result.X = MathF.Round(value.X);
			result.Y = MathF.Round(value.Y);
			result.Z = MathF.Round(value.Z);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains cubic interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <param name="amount">Weighting value.</param>
		/// <returns>Cubic interpolation of the specified vectors.</returns>
		public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, float amount)
		{
			return new Vector3(
				 MathHelper.SmoothStep(value1.X, value2.X, amount),
				 MathHelper.SmoothStep(value1.Y, value2.Y, amount),
				 MathHelper.SmoothStep(value1.Z, value2.Z, amount));
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains cubic interpolation of the specified vectors.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <param name="amount">Weighting value.</param>
		/// <param name="result">Cubic interpolation of the specified vectors as an output parameter.</param>
		public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, float amount, out Vector3 result)
		{
			result.X = MathHelper.SmoothStep(value1.X, value2.X, amount);
			result.Y = MathHelper.SmoothStep(value1.Y, value2.Y, amount);
			result.Z = MathHelper.SmoothStep(value1.Z, value2.Z, amount);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains subtraction of on <see cref="Vector3 /> from a another.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <returns>The result of the vector subtraction.</returns>
		public static Vector3 Subtract(Vector3 value1, Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains subtraction of on <see cref="Vector3 /> from a another.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 />.</param>
		/// <param name="value2">Source <see cref="Vector3 />.</param>
		/// <param name="result">The result of the vector subtraction as an output parameter.</param>
		public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}

		/// <summary>
		/// Returns a <see cref="String"/> representation of this <see cref="Vector3 /> in the format:
		/// {X:[<see cref="X"/>] Y:[<see cref="Y"/>] Z:[<see cref="Z"/>]}
		/// </summary>
		/// <returns>A <see cref="String"/> representation of this <see cref="Vector3 />.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(32);
			sb.Append("{X:");
			sb.Append(this.X);
			sb.Append(" Y:");
			sb.Append(this.Y);
			sb.Append(" Z:");
			sb.Append(this.Z);
			sb.Append("}");
			return sb.ToString();
		}

		#region Transform

		public Vector3 Transform(in Matrix matrix)
		{
			return Transform(this, matrix);
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of 3d-vector by the specified <see cref="Matrix"/>.
		/// </summary>
		/// <param name="position">Source <see cref="Vector3 />.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <returns>Transformed <see cref="Vector3 />.</returns>
		public static Vector3 Transform(in Vector3 position, in Matrix matrix)
		{
			Transform(position, matrix, out var ret);
			return ret;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of 3d-vector by the specified <see cref="Matrix"/>.
		/// </summary>
		/// <param name="position">Source <see cref="Vector3 />.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="result">Transformed <see cref="Vector3 /> as an output parameter.</param>
		public static void Transform(in Vector3 position, in Matrix matrix, out Vector3 result)
		{
			var x = (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41;
			var y = (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42;
			var z = (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43;
			result.X = x;
			result.Y = y;
			result.Z = z;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of 3d-vector by the specified <see cref="Quaternion"/>, representing the rotation.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="rotation">The <see cref="Quaternion"/> which contains rotation transformation.</param>
		/// <returns>Transformed <see cref="Vector3 />.</returns>
		public static Vector3 Transform(in Vector3 value, in Quaternion rotation)
		{
			Vector3 result;
			Transform(value, rotation, out result);
			return result;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of 3d-vector by the specified <see cref="Quaternion"/>, representing the rotation.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 />.</param>
		/// <param name="rotation">The <see cref="Quaternion"/> which contains rotation transformation.</param>
		/// <param name="result">Transformed <see cref="Vector3 /> as an output parameter.</param>
		public static void Transform(in Vector3 value, in Quaternion rotation, out Vector3 result)
		{
			float x = 2 * (rotation.Y * value.Z - rotation.Z * value.Y);
			float y = 2 * (rotation.Z * value.X - rotation.X * value.Z);
			float z = 2 * (rotation.X * value.Y - rotation.Y * value.X);

			result.X = value.X + x * rotation.W + (rotation.Y * z - rotation.Z * y);
			result.Y = value.Y + y * rotation.W + (rotation.Z * x - rotation.X * z);
			result.Z = value.Z + z * rotation.W + (rotation.X * y - rotation.Y * x);
		}

		/// <summary>
		/// Apply transformation on vectors within array of <see cref="Vector3 /> by the specified <see cref="Matrix"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="sourceIndex">The starting index of transformation in the source array.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="destinationArray">Destination array.</param>
		/// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="Vector3 /> should be written.</param>
		/// <param name="length">The number of vectors to be transformed.</param>
		public static void Transform(Vector3[] sourceArray, int sourceIndex, in Matrix matrix, Vector3[] destinationArray, int destinationIndex, int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (sourceArray.Length < sourceIndex + length)
				throw new ArgumentException("Source array length is lesser than sourceIndex + length");
			if (destinationArray.Length < destinationIndex + length)
				throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

			// TODO: Are there options on some platforms to implement a vectorized version of this?

			for (var i = 0; i < length; i++)
			{
				var position = sourceArray[sourceIndex + i];
				destinationArray[destinationIndex + i] =
					 new Vector3(
						  (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
						  (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
						  (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
			}
		}

		/// <summary>
		/// Apply transformation on vectors within array of <see cref="Vector3 /> by the specified <see cref="Quaternion"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="sourceIndex">The starting index of transformation in the source array.</param>
		/// <param name="rotation">The <see cref="Quaternion"/> which contains rotation transformation.</param>
		/// <param name="destinationArray">Destination array.</param>
		/// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="Vector3 /> should be written.</param>
		/// <param name="length">The number of vectors to be transformed.</param>
		public static void Transform(Vector3[] sourceArray, int sourceIndex, in Quaternion rotation, Vector3[] destinationArray, int destinationIndex, int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (sourceArray.Length < sourceIndex + length)
				throw new ArgumentException("Source array length is lesser than sourceIndex + length");
			if (destinationArray.Length < destinationIndex + length)
				throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

			// TODO: Are there options on some platforms to implement a vectorized version of this?

			for (var i = 0; i < length; i++)
			{
				var position = sourceArray[sourceIndex + i];

				float x = 2 * (rotation.Y * position.Z - rotation.Z * position.Y);
				float y = 2 * (rotation.Z * position.X - rotation.X * position.Z);
				float z = 2 * (rotation.X * position.Y - rotation.Y * position.X);

				destinationArray[destinationIndex + i] =
					 new Vector3(
						  position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
						  position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
						  position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
			}
		}

		/// <summary>
		/// Apply transformation on all vectors within array of <see cref="Vector3 /> by the specified <see cref="Matrix"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="destinationArray">Destination array.</param>
		public static void Transform(Vector3[] sourceArray, in Matrix matrix, Vector3[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException("Destination array length is lesser than source array length");

			// TODO: Are there options on some platforms to implement a vectorized version of this?

			for (var i = 0; i < sourceArray.Length; i++)
			{
				var position = sourceArray[i];
				destinationArray[i] =
					 new Vector3(
						  (position.X * matrix.M11) + (position.Y * matrix.M21) + (position.Z * matrix.M31) + matrix.M41,
						  (position.X * matrix.M12) + (position.Y * matrix.M22) + (position.Z * matrix.M32) + matrix.M42,
						  (position.X * matrix.M13) + (position.Y * matrix.M23) + (position.Z * matrix.M33) + matrix.M43);
			}
		}

		/// <summary>
		/// Apply transformation on all vectors within array of <see cref="Vector3 /> by the specified <see cref="Quaternion"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="rotation">The <see cref="Quaternion"/> which contains rotation transformation.</param>
		/// <param name="destinationArray">Destination array.</param>
		public static void Transform(Vector3[] sourceArray, in Quaternion rotation, Vector3[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException("Destination array length is lesser than source array length");

			// TODO: Are there options on some platforms to implement a vectorized version of this?

			for (var i = 0; i < sourceArray.Length; i++)
			{
				var position = sourceArray[i];

				float x = 2 * (rotation.Y * position.Z - rotation.Z * position.Y);
				float y = 2 * (rotation.Z * position.X - rotation.X * position.Z);
				float z = 2 * (rotation.X * position.Y - rotation.Y * position.X);

				destinationArray[i] =
					 new Vector3(
						  position.X + x * rotation.W + (rotation.Y * z - rotation.Z * y),
						  position.Y + y * rotation.W + (rotation.Z * x - rotation.X * z),
						  position.Z + z * rotation.W + (rotation.X * y - rotation.Y * x));
			}
		}

		#endregion

		#region TransformNormal

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of the specified normal by the specified <see cref="Matrix"/>.
		/// </summary>
		/// <param name="normal">Source <see cref="Vector3 /> which represents a normal vector.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <returns>Transformed normal.</returns>
		public static Vector3 TransformNormal(Vector3 normal, in Matrix matrix)
		{
			TransformNormal(normal, matrix, out normal);
			return normal;
		}

		/// <summary>
		/// Creates a new <see cref="Vector3 /> that contains a transformation of the specified normal by the specified <see cref="Matrix"/>.
		/// </summary>
		/// <param name="normal">Source <see cref="Vector3 /> which represents a normal vector.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="result">Transformed normal as an output parameter.</param>
		public static void TransformNormal(in Vector3 normal, in Matrix matrix, out Vector3 result)
		{
			var x = (normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31);
			var y = (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32);
			var z = (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33);
			result.X = x;
			result.Y = y;
			result.Z = z;
		}

		/// <summary>
		/// Apply transformation on normals within array of <see cref="Vector3 /> by the specified <see cref="Matrix"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="sourceIndex">The starting index of transformation in the source array.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="destinationArray">Destination array.</param>
		/// <param name="destinationIndex">The starting index in the destination array, where the first <see cref="Vector3 /> should be written.</param>
		/// <param name="length">The number of normals to be transformed.</param>
		public static void TransformNormal(Vector3[] sourceArray,
		 int sourceIndex,
		 in Matrix matrix,
		 Vector3[] destinationArray,
		 int destinationIndex,
		 int length)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (sourceArray.Length < sourceIndex + length)
				throw new ArgumentException("Source array length is lesser than sourceIndex + length");
			if (destinationArray.Length < destinationIndex + length)
				throw new ArgumentException("Destination array length is lesser than destinationIndex + length");

			for (int x = 0; x < length; x++)
			{
				var normal = sourceArray[sourceIndex + x];

				destinationArray[destinationIndex + x] =
					  new Vector3(
						  (normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31),
						  (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32),
						  (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33));
			}
		}

		/// <summary>
		/// Apply transformation on all normals within array of <see cref="Vector3 /> by the specified <see cref="Matrix"/> and places the results in an another array.
		/// </summary>
		/// <param name="sourceArray">Source array.</param>
		/// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
		/// <param name="destinationArray">Destination array.</param>
		public static void TransformNormal(Vector3[] sourceArray, in Matrix matrix, Vector3[] destinationArray)
		{
			if (sourceArray == null)
				throw new ArgumentNullException("sourceArray");
			if (destinationArray == null)
				throw new ArgumentNullException("destinationArray");
			if (destinationArray.Length < sourceArray.Length)
				throw new ArgumentException("Destination array length is lesser than source array length");

			for (var i = 0; i < sourceArray.Length; i++)
			{
				var normal = sourceArray[i];

				destinationArray[i] =
					 new Vector3(
						  (normal.X * matrix.M11) + (normal.Y * matrix.M21) + (normal.Z * matrix.M31),
						  (normal.X * matrix.M12) + (normal.Y * matrix.M22) + (normal.Z * matrix.M32),
						  (normal.X * matrix.M13) + (normal.Y * matrix.M23) + (normal.Z * matrix.M33));
			}
		}

		#endregion

		/// <summary>
		/// Deconstruction method for <see cref="Vector3 />.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		public void Deconstruct(out float x, out float y, out float z)
		{
			x = this.X;
			y = this.Y;
			z = this.Z;
		}

		/// <summary>
		/// Returns a <see cref="System.Numerics.Vector3"/>.
		/// </summary>
		//public System.Numerics.Vector3 ToNumerics()
		//{
		//	return new System.Numerics.Vector3(this.X, this.Y, this.Z);
		//}

		#endregion

		#region Operators

		///// <summary>
		///// Converts a <see cref="System.Numerics.Vector3"/> to a <see cref="Vector3 />.
		///// </summary>
		///// <param name="value">The converted value.</param>
		//public static implicit operator Vector3 System.Numerics.Vector3 value)
		//{
		//	return new Vector3 value.X, value.Y, value.Z);
		//}

		/// <summary>
		/// Compares whether two <see cref="Vector3 /> instances are equal.
		/// </summary>
		/// <param name="value1"><see cref="Vector3 /> instance on the left of the equal sign.</param>
		/// <param name="value2"><see cref="Vector3 /> instance on the right of the equal sign.</param>
		/// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
		public static bool operator ==(in Vector3 value1, in Vector3 value2)
		{
			return value1.X == value2.X
				 && value1.Y == value2.Y
				 && value1.Z == value2.Z;
		}

		/// <summary>
		/// Compares whether two <see cref="Vector3 /> instances are not equal.
		/// </summary>
		/// <param name="value1"><see cref="Vector3 /> instance on the left of the not equal sign.</param>
		/// <param name="value2"><see cref="Vector3 /> instance on the right of the not equal sign.</param>
		/// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>	
		public static bool operator !=(in Vector3 value1, in Vector3 value2)
		{
			return !(value1 == value2);
		}

		/// <summary>
		/// Adds two vectors.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 /> on the left of the add sign.</param>
		/// <param name="value2">Source <see cref="Vector3 /> on the right of the add sign.</param>
		/// <returns>Sum of the vectors.</returns>
		public static Vector3 operator +(Vector3 value1, in Vector3 value2)
		{
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static Vector3 operator +(in Vector3 a, in Size b)
		{
			return new Vector3 (
				 (float)(a.X + b.Width),
				 (float)(a.Y + b.Height),
				 (float)(a.Z + b.Depth));
		}

		public static Vector3 operator +(in Vector3 a, float b)
		{
			return new Vector3(
				 a.X + b,
				 a.Y + b,
				 a.Z + b);
		}

		public static Vector3 operator -(in Vector3 a, in Size b)
		{
			return new Vector3(
				 a.X - b.Width,
				 a.Y - b.Height,
				 a.Z - b.Depth);
		}

		public static Vector3 operator -(in Vector3 a, float b)
		{
			return new Vector3(
				 a.X - b,
				 a.Y - b,
				 a.Z - b);
		}

		/// <summary>
		/// Inverts values in the specified <see cref="Vector3 />.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 /> on the right of the sub sign.</param>
		/// <returns>Result of the inversion.</returns>
		public static Vector3 operator -(in Vector3 value)
		{
			var ret = new Vector3(-value.X, -value.Y, -value.Z);
			return ret;
		}

		/// <summary>
		/// Subtracts a <see cref="Vector3 /> from a <see cref="Vector3 />.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 /> on the left of the sub sign.</param>
		/// <param name="value2">Source <see cref="Vector3 /> on the right of the sub sign.</param>
		/// <returns>Result of the vector subtraction.</returns>
		public static Vector3 operator -(Vector3 value1, in Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		/// <summary>
		/// Multiplies the components of two vectors by each other.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 /> on the left of the mul sign.</param>
		/// <param name="value2">Source <see cref="Vector3 /> on the right of the mul sign.</param>
		/// <returns>Result of the vector multiplication.</returns>
		public static Vector3 operator *(Vector3 value1, in Vector3 value2)
		{
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		/// <summary>
		/// Multiplies the components of vector by a scalar.
		/// </summary>
		/// <param name="value">Source <see cref="Vector3 /> on the left of the mul sign.</param>
		/// <param name="scaleFactor">Scalar value on the right of the mul sign.</param>
		/// <returns>Result of the vector multiplication with a scalar.</returns>
		public static Vector3 operator *(Vector3 value, float scaleFactor)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		/// <summary>
		/// Multiplies the components of vector by a scalar.
		/// </summary>
		/// <param name="scaleFactor">Scalar value on the left of the mul sign.</param>
		/// <param name="value">Source <see cref="Vector3 /> on the right of the mul sign.</param>
		/// <returns>Result of the vector multiplication with a scalar.</returns>
		public static Vector3 operator *(float scaleFactor, Vector3 value)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by the components of another <see cref="Vector3 />.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 /> on the left of the div sign.</param>
		/// <param name="value2">Divisor <see cref="Vector3 /> on the right of the div sign.</param>
		/// <returns>The result of dividing the vectors.</returns>
		public static Vector3 operator /(Vector3 value1, in Vector3 value2)
		{
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		/// <summary>
		/// Divides the components of a <see cref="Vector3 /> by a scalar.
		/// </summary>
		/// <param name="value1">Source <see cref="Vector3 /> on the left of the div sign.</param>
		/// <param name="divider">Divisor scalar on the right of the div sign.</param>
		/// <returns>The result of dividing a vector by a scalar.</returns>
		public static Vector3 operator /(Vector3 value1, float divider)
		{
			float factor = 1 / divider;
			value1.X *= factor;
			value1.Y *= factor;
			value1.Z *= factor;
			return value1;
		}

		#endregion

		#region Procedural Toolkit

		// Access the x, y, z components using [0], [1], [2] respectively.
		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0: return X;
					case 1: return Y;
					case 2: return Z;
					default:
						throw new IndexOutOfRangeException("Invalid Vector3 index!");
				}
			}

			set
			{
				switch (index)
				{
					case 0: X = value; break;
					case 1: Y = value; break;
					case 2: Z = value; break;
					default:
						throw new IndexOutOfRangeException("Invalid Vector3 index!");
				}
			}
		}

		/// <summary>
		/// Convert two linearly distributed numbers between 0 and 1 to a point on a unit sphere (radius = 1)
		/// </summary>
		/// <param name="random1">Linearly distributed random number between 0 and 1</param>
		/// <param name="random2">Linearly distributed random number between 0 and 1</param>
		/// <returns>A cartesian point on the unit sphere</returns>
		public static Vector3 OnUnitSphere(float random1, float random2)
		{
			var theta = random1 * 2 * MathF.PI;
			var phi = MathF.Acos((2 * random2) - 1);

			// Convert from spherical coordinates to Cartesian
			var sinPhi = MathF.Sin(phi);

			var x = sinPhi * MathF.Cos(theta);
			var y = sinPhi * MathF.Sin(theta);
			var z = MathF.Cos(phi);

			return new Vector3(x, y, z);
		}

		public static Vector3 InsideUnitSphere()
		{
			float theta = 2f * MathF.PI * MathHelper.RandomNextFloat();
			float phi = MathF.Acos(1f - 2f * MathHelper.RandomNextFloat());
			Vector3 v;
			v.X = MathF.Sin(phi) * MathF.Cos(theta);
			v.Y = MathF.Sin(phi) * MathF.Sin(theta);
			v.Z = MathF.Cos(phi);

			return v;
		}

		public Vector2 ToVector2()
		{
			Vector2 v2;
			v2.X = X;
			v2.Y = Y;
			return v2;
		}

		public static Vector3 LerpUnclamped(in Vector3 value1, in Vector3 value2, float amount)
		{
			return new Vector3(
				 MathHelper.LerpUnclamped(value1.X, value2.X, amount),
				 MathHelper.LerpUnclamped(value1.Y, value2.Y, amount),
				 MathHelper.LerpUnclamped(value1.Z, value2.Z, amount));
		}

		#endregion
	}
}

#endif
