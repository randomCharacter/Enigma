namespace Enigma
{
    /// <inheritdoc />
    /// <summary>
    /// Enigma reflector.
    /// </summary>
    public class Reflector : Plugboard
    {
        /// <inheritdoc />
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="cipher">Cipher to be used.</param>
        public Reflector(int[] cipher) : base(cipher) { }

        /// <summary>
        /// Position of the rotor.
        /// </summary>
        public int Position
        {
            set { _position = value; }
        }
    }
}
