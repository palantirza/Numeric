namespace Palantir.Numeric.Statistics
{
    using System;
    
    /// <summary>
    /// Represents a stochastic value.
    /// </summary>
    public struct Stochastic
    {
        #region Declarations
        private double mean;
        private double sigma;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Stochastic" /> class.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="sigma">The standard deviation.</param>
        public Stochastic(double mean = 0, double sigma = 1) 
        {
            this.mean = mean;
            this.sigma = sigma;
        }
        #endregion
        
        #region Properties
        /// <summary>
        /// The mean value for the stochastic values.
        /// </summary>
        public double Mean => mean;
        
        /// <summary>
        /// The standard deviation for the stochastic values.
        /// </summary>
        public double StandardDeviation => sigma;
        #endregion
        
		#region Methods
		/// <summary>
		/// Compares the Stochastic for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public override bool Equals(object obj)
		{
			// STEP 1: Check for null
			if (obj == null)
				return false;

			// STEP 3: equivalent data types
			if (this.GetType() != obj.GetType())
				return false;

			return Equals((Stochastic)obj);
		}

		/// <summary>
		/// Compares the Stochastic for equality.
		/// </summary>
		/// <param name="obj">The object to compare to.</param>
		/// <returns>true if the objects are equal, false otherwise.</returns>
		public bool Equals(Stochastic obj)
		{
			// STEP 1: Check for null if nullable (e.g., a reference type)
			// STEP 2: Check for ReferenceEquals if this is a reference type

			// STEP 4: Possibly check for equivalent hash codes

			// STEP 5: Check base.Equals if base overrides Equals()

			// STEP 6: Compare identifying fields for equality.
			return (this.mean - obj.mean < 0.0000001) 
				&& (this.sigma - obj.sigma < 0.0000001);
		}

		/// <summary>
		/// Fetches the hash code for the Money.
		/// </summary>
		/// <returns>The hash code.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				var hash = 17;
				hash *= 23 + mean.GetHashCode();
				hash *= 23 + sigma.GetHashCode();

				return hash;
			}
		}
		#endregion
		
        #region Operators
		/// <summary>
		/// Adds two stochastic instances together.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator +(Stochastic lhs, Stochastic rhs)
		{
			return new Stochastic(lhs.mean + rhs.mean, Math.Sqrt(Math.Pow(lhs.sigma, 2) + Math.Pow(rhs.sigma, 2)));
		}

		/// <summary>
		/// Adds a value to a stochastic instance.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator +(Stochastic lhs, int rhs)
		{
			return new Stochastic(lhs.mean + rhs, lhs.sigma);
		}

		/// <summary>
		/// Adds a value to a stochastic instance.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator +(int lhs, Stochastic rhs)
		{
			return new Stochastic(lhs + rhs.mean, rhs.sigma);
		}

		/// <summary>
		/// Adds a value to a stochastic instance.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator +(Stochastic lhs, double rhs)
		{
			return new Stochastic(lhs.mean + rhs, lhs.sigma);
		}

		/// <summary>
		/// Adds a value to a stochastic instance.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator +(double lhs, Stochastic rhs)
		{
			return new Stochastic(lhs + rhs.mean, rhs.sigma);
		}

		/// <summary>
		/// Subtracts two stochastic instances.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator -(Stochastic lhs, Stochastic rhs)
		{
            // SQRT((StdDev s3^2)−(StdDev s1^2))
			return new Stochastic(lhs.mean - rhs.mean, Math.Sqrt(Math.Pow(lhs.sigma, 2) - Math.Pow(rhs.sigma, 2)));
		}

		/// <summary>
		/// Subtracts a value from a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator -(Stochastic lhs, int rhs)
		{
			return new Stochastic(lhs.mean - rhs, lhs.sigma);
		}

		/// <summary>
		/// Subtracts a value from a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator -(int lhs, Stochastic rhs)
		{
			return new Stochastic(lhs - rhs.mean, rhs.sigma);
		}

		/// <summary>
		/// Subtracts a value from a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator -(Stochastic lhs, double rhs)
		{
			return new Stochastic(lhs.mean - rhs, lhs.sigma);
		}

		/// <summary>
		/// Subtracts a value from a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator -(double lhs, Stochastic rhs)
		{
			return new Stochastic(lhs - rhs.mean, rhs.sigma);
		}

		/// <summary>
		/// Multiplies two stochastics.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator *(Stochastic lhs, Stochastic rhs)
		{
            var mean = lhs.mean * rhs.mean;
            
            var left = lhs.sigma / lhs.mean;
            var right = rhs.sigma / rhs.mean;
            
            return new Stochastic(mean, (left + right) * mean);
		}

		/// <summary>
		/// Multiplies a value to a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator *(Stochastic lhs, int rhs)
		{
			return new Stochastic(lhs.mean * rhs, lhs.sigma * rhs);
		}

		/// <summary>
		/// Multiplies a value to a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator *(Stochastic lhs, double rhs)
		{
			return new Stochastic(lhs.mean * rhs, lhs.sigma * rhs);
		}
        
		/// <summary>
		/// Multiplies a value to a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator *(int lhs, Stochastic rhs)
		{
			return new Stochastic(lhs * rhs.mean, lhs * rhs.sigma);
		}

		/// <summary>
		/// Multiplies a value to a stochastic.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator *(double lhs, Stochastic rhs)
		{
			return new Stochastic(lhs * rhs.mean, lhs * rhs.sigma);
		}
        
		/// <summary>
		/// Divides two stochastics.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator /(Stochastic lhs, Stochastic rhs)
		{
            var mean = lhs.mean / rhs.mean;
            
            var left = lhs.sigma / lhs.mean;
            var right = rhs.sigma / rhs.mean;
            
            return new Stochastic(mean, (left + right) * mean);
		}

		/// <summary>
		/// Divides a stochastic by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator /(Stochastic lhs, int rhs)
		{
			return new Stochastic(lhs.mean / rhs, lhs.sigma / rhs);
		}

		/// <summary>
		/// Divides a stochastic by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator /(Stochastic lhs, double rhs)
		{
			return new Stochastic(lhs.mean / rhs, lhs.sigma / rhs);
		}
		
		/// <summary>
		/// Divides a stochastic by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator /(int lhs, Stochastic rhs)
		{
			return new Stochastic(lhs / rhs.mean, lhs / rhs.sigma);
		}

		/// <summary>
		/// Divides a stochastic by a value.
		/// </summary>
		/// <param name="lhs">The left hand side of the expression.</param>
		/// <param name="rhs">The right hand side of the expression.</param>
		/// <returns>The expression result.</returns>
		public static Stochastic operator /(double lhs, Stochastic rhs)
		{
			return new Stochastic(lhs / rhs.mean, lhs / rhs.sigma);
		}
        #endregion
        
    }
}