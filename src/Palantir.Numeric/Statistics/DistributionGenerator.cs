namespace Palantir.Numeric.Statistics
{
    using System;

    public class DistributionGenerator
    {
        private IRandomGenerator generator;
        
        public DistributionGenerator()
            : this(new MarsagliaMwcGenerator())
        {
        }

        public DistributionGenerator(IRandomGenerator generator)
        {
            this.generator = generator;
        }
        
        public double GetUniform()
        {
            // 0 <= u < 2^32
            uint u = generator.GetNext();
            // The magic number below is 1/(2^32 + 2).
            // The result is strictly between 0 and 1.
            return (u + 1.0) * 2.328306435454494e-10;
        }
        
        
        // Get normal (Gaussian) random sample with mean 0 and standard deviation 1
        private double GetNormal()
        {
            // Use Box-Muller algorithm
            double u1 = GetUniform();
            double u2 = GetUniform();
            double r = Math.Sqrt( -2.0*Math.Log(u1) );
            double theta = 2.0*Math.PI*u2;
            return r*Math.Sin(theta);
        }
        
        /// <summary>
        /// Get normal (Gaussian) random sample with specified mean and standard deviation
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation.</param>
        /// <returns>The value.</returns>
        public double GetNormal(double mean = 0, double standardDeviation = 1)
        {
            if (standardDeviation <= 0.0)
            {
                string msg = string.Format("Shape must be positive. Received {0}.", standardDeviation);
                throw new ArgumentOutOfRangeException(msg);
            }
            return mean + standardDeviation*GetNormal();
        }
        
        private double GetExponential()
        {
            return -Math.Log( GetUniform() );
        }

        /// <summary>
        /// Get exponential random sample with specified mean
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <returns>The value.</returns>
        public double GetExponential(double mean = 1)
        {
            if (mean <= 0.0)
            {
                string msg = string.Format("Mean must be positive. Received {0}.", mean);
                throw new ArgumentOutOfRangeException(msg);
            }
            return mean*GetExponential();
        }

        /// <summary>
        /// Generates a gamma distribution.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>The value.</returns>
        public double GetGamma(double shape, double scale)
        {
            // Implementation based on "A Simple Method for Generating Gamma Variables"
            // by George Marsaglia and Wai Wan Tsang.  ACM Transactions on Mathematical Software
            // Vol 26, No 3, September 2000, pages 363-372.

            double d, c, x, xsquared, v, u;

            if (shape >= 1.0)
            {
                d = shape - 1.0/3.0;
                c = 1.0/Math.Sqrt(9.0*d);
                for (;;)
                {
                    do
                    {
                        x = GetNormal();
                        v = 1.0 + c*x;
                    }
                    while (v <= 0.0);
                    v = v*v*v;
                    u = GetUniform();
                    xsquared = x*x;
                    if (u < 1.0 -.0331*xsquared*xsquared || Math.Log(u) < 0.5*xsquared + d*(1.0 - v + Math.Log(v)))
                        return scale*d*v;
                }
            }
            else if (shape <= 0.0)
            {
                string msg = string.Format("Shape must be positive. Received {0}.", shape);
                throw new ArgumentOutOfRangeException(msg);
            }
            else
            {
                double g = GetGamma(shape+1.0, 1.0);
                double w = GetUniform();
                return scale*g*Math.Pow(w, 1.0/shape);
            }
        }
        
        /// <summary>
        /// Gets a chi-square distribution.
        /// </summary>
        /// <param name="degreesOfFreedom">The degrees of freedom.</param>
        /// <returns>The value.</returns>
        public double GetChiSquare(double degreesOfFreedom)
        {
            // A chi squared distribution with n degrees of freedom
            // is a gamma distribution with shape n/2 and scale 2.
            return GetGamma(0.5 * degreesOfFreedom, 2.0);
        }

        /// <summary>
        /// Gets an inverse gamme distribution.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>The value.</returns>
        public double GetInverseGamma(double shape, double scale)
        {
            // If X is gamma(shape, scale) then
            // 1/Y is inverse gamma(shape, 1/scale)
            return 1.0 / GetGamma(shape, 1.0 / scale);
        }

        /// <summary>
        /// Gets a Weibull distribution.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>The value.</returns>
        public double GetWeibull(double shape, double scale)
        {
            if (shape <= 0.0 || scale <= 0.0)
            {
                string msg = string.Format("Shape and scale parameters must be positive. Recieved shape {0} and scale{1}.", shape, scale);
                throw new ArgumentOutOfRangeException(msg);
            }
            return scale * Math.Pow(-Math.Log(GetUniform()), 1.0 / shape);
        }

        /// <summary>
        /// Gets a Cauchy distribution.
        /// </summary>
        /// <param name="mediam">The median.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>The value.</returns>
        public double GetCauchy(double median, double scale)
        {
            if (scale <= 0)
            {
                string msg = string.Format("Scale must be positive. Received {0}.", scale);
                throw new ArgumentException(msg);
            }

            double p = GetUniform();

            // Apply inverse of the Cauchy distribution function to a uniform
            return median + scale*Math.Tan(Math.PI*(p - 0.5));
        }

        /// <summary>
        /// Gets a StudentT distribution.
        /// </summary>
        /// <param name="degreesOfFreedom">The degrees of freedom.</param>
        /// <returns>The value.</returns>
        public double GetStudentT(double degreesOfFreedom)
        {
            if (degreesOfFreedom <= 0)
            {
                string msg = string.Format("Degrees of freedom must be positive. Received {0}.", degreesOfFreedom);
                throw new ArgumentException(msg);
            }

            // See Seminumerical Algorithms by Knuth
            double y1 = GetNormal();
            double y2 = GetChiSquare(degreesOfFreedom);
            return y1 / Math.Sqrt(y2 / degreesOfFreedom);
        }

        /// <summary>
        /// The Laplace distribution is also known as the double exponential distribution.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="scale">The scale.</param>
        /// <returns>The value.</returns>
        public double GetLaplace(double mean, double scale)
        {
            double u = GetUniform();
            return (u < 0.5) ?
                mean + scale*Math.Log(2.0*u) :
                mean - scale*Math.Log(2*(1-u));
        }

        /// <summary>
        /// Gets a Log normal distribution.
        /// </summary>
        /// <param name="mu">The mean.</param>
        /// <param name="sigma">The sigma.</param>
        /// <returns>The value.</returns>
        public double GetLogNormal(double mu, double sigma)
        {
            return Math.Exp(GetNormal(mu, sigma));
        }

        /// <summary>
        /// Gets a Beta distribution.
        /// </summary>
        /// <param name="a">The a value.</param>
        /// <param name="b">The b value.</param>
        /// <returns>The value.</returns>
        public double GetBeta(double a, double b)
        {
            if (a <= 0.0 || b <= 0.0)
            {
                string msg = string.Format("Beta parameters must be positive. Received {0} and {1}.", a, b);
                throw new ArgumentOutOfRangeException(msg);
            }

            // There are more efficient methods for generating beta samples.
            // However such methods are a little more efficient and much more complicated.
            // For an explanation of why the following method works, see
            // http://www.johndcook.com/distribution_chart.html#gamma_beta

            double u = GetGamma(a, 1.0);
            double v = GetGamma(b, 1.0);
            return u / (u + v);
        }
    }
}