namespace Enigma
{
    /// <summary>
    /// Enigma machine
    /// </summary>
    public class Enigma
    {
        // Components
        private readonly Plugboard _plugboard;
        private readonly Rotor _left;
        private readonly Rotor _right;
        private readonly Rotor _center;
        private readonly Reflector _reflector;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="plugboard">Plugboard.</param>
        /// <param name="left">Left rotor.</param>
        /// <param name="center">Center rotor.</param>
        /// <param name="right">Right rotor.</param>
        /// <param name="reflector">Reflector.</param>
        public Enigma(Plugboard plugboard, Rotor left, Rotor center, Rotor right, Reflector reflector)
        {
            _plugboard = plugboard;
            _left = left;
            _right = right;
            _center = center;
            _reflector = reflector;
        }

        /// <summary>
        /// Sets position of the rotors.
        /// </summary>
        /// <param name="reflectorPos">Position of the reflector.</param>
        /// <param name="leftPos">Position of the left rotor.</param>
        /// <param name="centerPos">Position of the center rotor.</param>
        /// <param name="rightPos">Position of the right rotor.</param>
        public void SetPositions(int leftPos, int centerPos, int rightPos)
        {
            _left.Position = leftPos;
            _center.Position = centerPos;
            _right.Position = rightPos;
        }
        
        /// <summary>
        /// Sets position of the rotors.
        /// </summary>
        /// <param name="reflectorPos">Position of the reflector.</param>
        /// <param name="leftPos">Position of the left rotor.</param>
        /// <param name="centerPos">Position of the center rotor.</param>
        /// <param name="rightPos">Position of the right rotor.</param>
        public void SetRingPositions(int reflectorPos, int leftPos, int centerPos, int rightPos)
        {
            _reflector.RingPosition = reflectorPos;
            _left.RingPosition = leftPos;
            _center.RingPosition = centerPos;
            _right.RingPosition = rightPos;
        }

        /// <summary>
        /// Simulates key press.
        /// </summary>
        /// <param name="value">Decimal value of pressed key.</param>
        /// <returns>Converted value in decimal mode.</returns>
        public int Convert(int value)
        {
            AdvanceRotors();
            var res = value;
            res = _plugboard.Convert(res);
            res = _right.Convert(res);
            res = _center.Convert(res);
            res = _left.Convert(res);
            res = _reflector.Convert(res);
            res = _left.ConvertInv(res);
            res = _center.ConvertInv(res);
            res = _right.ConvertInv(res);
            res = _plugboard.Convert(res);
            return res;
        }

        /// <summary>
        /// Rotates rotors that need to be rotated.
        /// </summary>
        private void AdvanceRotors()
        {
            bool rotL = false, rotC = false;
            if (_center.IsAtNotch())
            {
                rotC = true;
                rotL = true;
            }

            if (_right.IsAtNotch())
            {
                rotC = true;
            }

            if (rotL)
            {
                _left.Rotate();
            }

            if (rotC)
            {
                _center.Rotate();
            }

            _right.Rotate();
        }
    }
}
