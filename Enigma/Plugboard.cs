namespace Enigma
{
    /// <summary>
    /// Enigma plugboard.
    /// </summary>
    public class Plugboard
    {
        public const int Letters = 26;

        // Position (for elements that are rotatable
        protected int _position;
        protected int _ringPosition;

        // Ciphers
        private readonly int[] _cipher;
        private readonly int[] _invCipher;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="cipher">Cipher to be used.</param>
        public Plugboard(int[] cipher)
        {
            _position = 0;
            _ringPosition = 0;
            _cipher = cipher;
            _invCipher = CreateInvCipher(cipher);
        }

        /// <summary>
        /// Converts given value.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <returns>Converted value.</returns>
        public int Convert(int value)
        {
            return ((((_cipher[((((value - _ringPosition) % 26 + 26) % 26 + _position) % 26 + 26) % 26] - _position) % 26 + 26) % 26 + _ringPosition) % 26 + 26) % 26;
        }

        /// <summary>
        /// Inverse converts given value.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <returns>Converted value.</returns>
        public int ConvertInv(int value)
        {
            return ((((_invCipher[((((value - _ringPosition) % 26 + 26) % 26 + _position) % 26 + 26) % 26] - _position) % 26 + 26) % 26 + _ringPosition) % 26 + 26) % 26;
        }

        /// <summary>
        /// Creates inverse cipher for given cipher.
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Inverse cipher.</returns>
        private static int[] CreateInvCipher(int[] cipher)
        {
            var invCipher = new int[Letters];
            for (var i = 0; i < Letters; i++)
            {
                invCipher[cipher[i]] = i;
            }

            return invCipher;
        }
    }
}
