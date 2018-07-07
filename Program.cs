﻿using System;
using System.Linq;

namespace Enigma
{
    /// <summary>
    /// Main class
    /// </summary>
    internal static class Program
    {
        // Error codes
        private const int InvalidArguments = 1;
        private const int InvalidReflectorCode = 2;
        private const int InvalidRotorCode = 3;
        private const int RotorAttachedTwice = 4;
        private const int InvalidPositions = 5;
        private const int InvalidCipher = 6;
        private const int MultipleConnections = 7;
        private const int InvalidInput = 8;

        private static Rotor _rotor1;
        private static Rotor _rotor2;
        private static Rotor _rotor3;
        private static Rotor _rotor4;
        private static Rotor _rotor5;
        private static Rotor _rotor6;
        private static Rotor _rotor7;
        private static Rotor _rotor8;

        private static Reflector _reflectorB;
        private static Reflector _reflectorC;

        private static Plugboard _plugboard;

        /// <summary>
        /// Creates Enigma motors
        /// </summary>
        private static void BuildRotors()
        {
            // Rotor 1
            int[] rotor1Cipher = { 4, 10, 12, 5, 11, 6, 3, 16, 21, 25, 13, 19, 14, 22, 24, 7, 23, 20, 18, 15, 0, 8, 1, 17, 2, 9 };
            int[] rotor1Notches = { 16 };
            _rotor1 = new Rotor(rotor1Cipher, rotor1Notches);
            // Rotor 2
            int[] rotor2Cipher = { 0, 9, 3, 10, 18, 8, 17, 20, 23, 1, 11, 7, 22, 19, 12, 2, 16, 6, 25, 13, 15, 24, 5, 21, 14, 4 };
            int[] rotor2Notches = { 4 };
            _rotor2 = new Rotor(rotor2Cipher, rotor2Notches);
            // Rotor 3
            int[] rotor3Cipher = { 1, 3, 5, 7, 9, 11, 2, 15, 17, 19, 23, 21, 25, 13, 24, 4, 8, 22, 6, 0, 10, 12, 20, 18, 16, 14 };
            int[] rotor3Notches = { 21 };
            _rotor3 = new Rotor(rotor3Cipher, rotor3Notches);
            // Rotor 4
            int[] rotor4Cipher = { 4, 18, 14, 21, 15, 25, 9, 0, 24, 16, 20, 8, 17, 7, 23, 11, 13, 5, 19, 6, 10, 3, 2, 12, 22, 1 };
            int[] rotor4Notches = { 9 };
            _rotor4 = new Rotor(rotor4Cipher, rotor4Notches);
            // Rotor 5
            int[] rotor5Cipher = { 21, 25, 1, 17, 6, 8, 19, 24, 20, 15, 18, 3, 13, 7, 11, 23, 0, 22, 12, 9, 16, 14, 5, 4, 2, 10 };
            int[] rotor5Notches = { 12, 25 };
            _rotor5 = new Rotor(rotor5Cipher, rotor5Notches);
            // Rotor 6
            int[] rotor6Cipher = { 9, 15, 6, 21, 14, 20, 12, 5, 24, 16, 1, 4, 13, 7, 25, 17, 3, 10, 0, 18, 23, 11, 8, 2, 19, 22 };
            int[] rotor6Notches = { 12, 25 };
            _rotor6 = new Rotor(rotor6Cipher, rotor6Notches);
            // Rotor 7
            int[] rotor7Cipher = { 13, 25, 9, 7, 6, 17, 2, 23, 12, 24, 18, 22, 1, 14, 20, 5, 0, 8, 21, 11, 15, 4, 10, 16, 3, 19 };
            int[] rotor7Notches = { 12, 25 };
            _rotor7 = new Rotor(rotor7Cipher, rotor7Notches);
            // Rotor 8
            int[] rotor8Cipher = { 5, 10, 16, 7, 19, 11, 23, 14, 2, 1, 9, 18, 15, 3, 25, 17, 0, 12, 4, 22, 13, 8, 20, 24, 6, 21 };
            int[] rotor8Notches = { 12, 25 };
            _rotor8 = new Rotor(rotor8Cipher, rotor8Notches);
        }

        /// <summary>
        /// Creates enigma Reflectors
        /// </summary>
        private static void BuildReflectors()
        {
            int[] cipherB = { 24, 17, 20, 7, 16, 18, 11, 3, 15, 23, 13, 6, 14, 10, 12, 8, 4, 1, 5, 25, 2, 22, 21, 9, 0, 19 };
            _reflectorB = new Reflector(cipherB);
            int[] cipherC = { 5, 21, 15, 9, 8, 0, 14, 24, 4, 3, 17, 25, 23, 22, 6, 2, 19, 10, 20, 16, 18, 1, 13, 12, 7, 11 };
            _reflectorC = new Reflector(cipherC);
        }

        /// <summary>
        /// Creates Engima plugboard from cipher.
        /// </summary>
        /// <param name="cipher">Cipher that defines plugboard connections.</param>
        private static void BuildPlugboard(int[] cipher = null)
        {
            int[] defaultCipher = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };
            _plugboard = new Plugboard(cipher ?? defaultCipher);
        }

        /// <summary>
        /// Assigns motor with given code.
        /// Valid values: 'I', 'II', 'III', 'IV', 'V', 'VI', 'VII', 'VIII'.
        /// </summary>
        /// <param name="code">Rotor code.</param>
        /// <returns>Rotor with given code.</returns>
        private static Rotor AssignRotor(string code)
        {
            switch (code)
            {
                case "I":
                    return _rotor1;
                case "II":
                    return _rotor2;
                case "III":
                    return _rotor3;
                case "IV":
                    return _rotor4;
                case "V":
                    return _rotor5;
                case "VI":
                    return _rotor6;
                case "VII":
                    return _rotor7;
                case "VIII":
                    return _rotor8;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Assigns reflector with given code.
        /// Valid values: 'B', 'C'
        /// </summary>
        /// <param name="code">Reflector code.</param>
        /// <returns>Reflector with given code.</returns>
        private static Reflector AssignReflector(String code)
        {
            switch (code)
            {
                case "B":
                    return _reflectorB;
                case "C":
                    return _reflectorC;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Builds plugboard cipher from given string.
        /// </summary>
        /// <param name="code">String value of cipher.</param>
        /// <returns>Array value of cipher.</returns>
        private static int[] BuildPlugboardCipher(String code)
        {
            var cipher = new int[code.Length];
            for (var i = 0; i < code.Length; i++)
            {
                cipher[i] = code[i] - 'A';
            }

            return cipher;
        }

        /// <summary>
        /// Checks if program arguments are valid.
        /// </summary>
        /// <param name="args">Program arguments</param>
        /// <returns><code>true</code> if args are valid, <code>false</code> if they are not.</returns>
        private static bool ErrorFound(string[] args)
        {
            if (args.Length != 5 && args.Length != 6)
            {
                Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName + " reflector" + " leftRotor" + " centerRotor" + " rightRotor" + " positions" + " [plugboard]");
                Console.WriteLine("reflector = { B, C }");
                Console.WriteLine("leftRotor, centerRotor, rightRotor = { I, II, III, IV, V, VI, VII, VIII }");
                Console.WriteLine("positions: start positions for reflector and all the rotors (example 'ABCD'");
                Console.WriteLine("plugboard (optional) array of chars (exp. 'ABCDEFGHIJKLMNOPQRSTUVWXZ'");
                Environment.Exit(InvalidArguments);
            }

            if (args[0] != "B" && args[0] != "C")
            {
                Console.WriteLine("Invalid reflector value (valid values: 'B' and 'C')");
                Environment.Exit(InvalidReflectorCode);
            }

            for (var i = 1; i <= 3; i++)
            {
                if (args[i] != "I" && args[i] != "II" && args[i] != "III" && args[i] != "IV" && args[i] != "V" &&
                    args[i] != "VI" && args[i] != "VII" && args[i] != "VIII")
                {
                    Console.WriteLine("Invalid rotor value (valid values: 'I', 'II', 'III', 'IV', 'V', 'VI', 'VII', 'VIII')");
                    Environment.Exit(InvalidRotorCode);
                }
            }

            if (args[1] == args[2] || args[2] == args[3] || args[3] == args[1])
            {
                Console.WriteLine("One rotor can not be attached twice");
                Environment.Exit(RotorAttachedTwice);
            }

            if (args[4].Length != 4)
            {
                Console.WriteLine("Invalid starting positions. (valid example: 'ABCD'");
                Environment.Exit(InvalidPositions);
            }

            for (var i = 0; i < args[4].Length; i++)
            {
                if (!char.IsUpper(args[4][i]))
                {
                    Console.WriteLine("Invalid character in starting positions.");
                    Console.WriteLine("starting positions must contain 4 capital letters!");
                    Environment.Exit(InvalidPositions);
                }
            }

            if (args.Length == 6)
            {
                if (args[5].Length != Plugboard.Letters)
                {
                    Console.WriteLine("Invalid plugboard cipher. (valid example: 'ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                    Environment.Exit(InvalidCipher);
                }

                for (var i = 0; i < args[5].Length; i++)
                {
                    if (!char.IsUpper(args[5][i]))
                    {
                        Console.WriteLine("Invalid character in plugboard cipher.");
                        Console.WriteLine("Plugboard cipher must contain 26 capital letters");
                        Environment.Exit(InvalidCipher);
                    }
                }

                if (args[5].Distinct().Count() != args[5].Length)
                {
                    Console.WriteLine("One character can be connected to only one other character.");
                    Environment.Exit(MultipleConnections);
                }
            }

            return false;
        }

        /// <summary>
        /// Main function.
        /// </summary>
        /// <param name="args">Program arguments.</param>
        public static void Main(string[] args)
        {
            if (ErrorFound(args))
            {
                return;
            }


            BuildRotors();
            var left = AssignRotor(args[1]);
            var center = AssignRotor(args[2]);
            var right = AssignRotor(args[3]);

            BuildReflectors();
            var reflector = AssignReflector(args[0]);

            if (args.Length == 6)
            {
                var plugboardCipher = BuildPlugboardCipher(args[6]);
                BuildPlugboard(plugboardCipher);
            }
            else
            {
                BuildPlugboard();
            }

            var posRef = args[4][0] - 'A';
            var posLeft = args[4][1] - 'A';
            var posCenter = args[4][2] - 'A';
            var posRight = args[4][3] - 'A';

            var machine = new Enigma(_plugboard, left, center, right, reflector);
            machine.SetPositions(posRef, posLeft, posCenter, posRight);

            var s = Console.ReadLine();

            if (s == null)
            {
                Console.WriteLine("Invalid input.");
                Environment.Exit(InvalidInput);
            }

            foreach (var ch in s)
            {
                if (char.IsUpper(ch))
                {
                    continue;
                }
                Console.WriteLine("Invalid character in input (only capital letters allowed).");
                Environment.Exit(InvalidInput);
            }


            var res = s.Aggregate("", (current, t) => current + (char) (machine.Convert(t - 'A') + 'A'));
            Console.WriteLine(res);
        }
    }
}
