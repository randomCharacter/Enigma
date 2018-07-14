using System;
using System.Linq;
using Enigma;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    private void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
	
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
    private static Reflector AssignReflector(string code)
    {
        switch (code)
        {
            case "-B-":
                return _reflectorB;
            case "-C-":
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
    private static int[] BuildPlugboardCipher(string code)
    {
        var cipher = new int[code.Length];
        for (var i = 0; i < code.Length; i++)
        {
            cipher[i] = code[i] - 'A';
        }

        return cipher;
    }
   
    protected void SelectPlugboard(object sender, EventArgs e)
    {

        var value = ((ComboBox)sender).Name;
        var key = ((ComboBox)sender).ActiveText;
        foreach (var box in plugboard)
        {
            if (box is ComboBox combo)
            {
                if (combo.Name == key)
                {
                    combo.Active = value[0] - 'A';
                }

            }
        }
    }

    protected string GetPlugboardString()
    {
        ComboBox[] boxes = { A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z };
        return boxes.Aggregate("", (current, box) => current + (box.ActiveText ?? box.Name));
    }

    protected void ButtonClick(object sender, EventArgs e)
    {
        BuildRotors();
        var left = AssignRotor(rotorLeftType.ActiveText);
        var center = AssignRotor(rotorCenterType.ActiveText);
        var right = AssignRotor(rotorRightType.ActiveText);

        BuildReflectors();
        var reflector = AssignReflector(reflectorType.ActiveText);

        var plugboardCipher = BuildPlugboardCipher(GetPlugboardString());
        BuildPlugboard(plugboardCipher);
        
        var posRef = reflectorPosition.Active;
        var startLeft = rotorLeftStartPosition.Active;
        var startCenter = rotorCenterStartPosition.Active;
        var startRight = rotorRightStartPosition.Active;

        var ringLeft = rotorLeftRingPosition.Active;
        var ringCenter = rotorCenterRingPosition.Active;
        var ringRight = rotorRightRingPosition.Active;
        
        var machine = new Enigma.Enigma(_plugboard, left, center, right, reflector);
        machine.SetRingPositions(posRef, ringLeft, ringCenter, ringRight);
        machine.SetPositions(startLeft, startCenter, startRight);

        var message = inputText.Buffer.Text;
        var messageLetters = "";

        foreach (var ch in message)
        {
            if (char.IsUpper(ch))
            {
                messageLetters += ch;
            }
            else if (char.IsLower(ch))
            {
                messageLetters += char.ToUpper(ch);
            }
        }

        var res = messageLetters.Aggregate("", (current, t) => current + (char) (machine.Convert(t - 'A') + 'A'));
        outputText.Buffer.Text = res;
    }
}
