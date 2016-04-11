namespace Palantir.Calculation
{
    using System;
    
    /// <summary>
    /// An exception that is thrown when an operation is done on two <see cref="Measure" />s
    /// which have different and incompatible <see cref="Unit" />s.
    /// </summary>
    public class IncompatibleUnitException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IncompatibleUnitException" />.
        /// </summary>
        public IncompatibleUnitException()
        {            
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="IncompatibleUnitException" />.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public IncompatibleUnitException(string message)
            : base(message)
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="IncompatibleUnitException" />.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public IncompatibleUnitException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}