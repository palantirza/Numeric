namespace Palantir.Numeric.Statistics
{
    /// <summary>
    /// Adapted from http://www.codeproject.com/Articles/25172/Simple-Random-Number-Generation.
    /// </summary>
    public class MarsagliaMwcGenerator : IRandomGenerator
    {
        private uint m_w;
        private uint m_z;

        public MarsagliaMwcGenerator()
        {
            System.DateTime dt = System.DateTime.Now;
            long x = dt.ToFileTime();
            m_w = (uint)(x >> 16);
            m_z = (uint)(x % 4294967296);
        }

        public MarsagliaMwcGenerator(uint u)
            : this()
        {
            m_w = u;
        }

        public MarsagliaMwcGenerator(uint u, uint v)
        {
            m_w = u;
            m_z = v;
        }

        public uint GetNext()
        {
            m_z = 36969 * (m_z & 65535) + (m_z >> 16);
            m_w = 18000 * (m_w & 65535) + (m_w >> 16);
            return (m_z << 16) + m_w;
        }
           
    } 
}