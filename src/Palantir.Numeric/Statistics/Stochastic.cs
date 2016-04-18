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
        #endregion
        
    }
}