using System.Linq;

namespace Enigma
{
    /// <inheritdoc />
    /// <summary>
    /// Enigma rotor.
    /// </summary>
    public class Rotor : Reflector
    {
        // Notches
        private readonly int[] _notches;

        /// <inheritdoc />
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="cipher">Cipher to be used.</param>
        /// <param name="notches">Positions that cause rotor to rotate.</param>
        public Rotor(int[] cipher, int[] notches = null) : base(cipher)
        {
            _notches = notches ?? new int[0];
        }

        /// <summary>
        /// Rotates the rotor.
        /// </summary>
        public void Rotate()
        {
            _position = (_position + 1) % Letters;
        }

        /// <summary>
        /// Checks if rotor is at notch.
        /// </summary>
        /// <returns><code>true</code> if rotor is at notch, <code>false</code> if it is not.</returns>
        public bool IsAtNotch()
        {
            return _notches.Any(t => t == _position);
        }
    }
}
