using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueCore
{
    public enum Key
    {
        None = 0,
        Esc, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, F11, F12,
        Tilda, Key1, Key2, Key3, Key4, Key5, Key6, Key7, Key8, Key9, Key0, KeyMinus, KeyPlus,
        Backspace, Enter, Space,
        Up, Down, Left, Right,
        NumSlash, NumAsterisk, NumMinus, NumPlus,
        Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num0,
        Q, W, E, R, T, Y, U, I, O, P, 
        A, S, D, F, G, H, J, K, L, 
        Z, X, C, V, B, N, M, 
        LSquare, RSquare, Colon, Quotes, BackSlash, LAngle, RAngle, Slash,
    }

    public class KeyInfo
    {
        public Key KeyCode = Key.None;
        public bool Shift = false;
        public bool Ctrl = false;
        public bool Alt = false;

        public override string ToString()
        {
            switch (KeyCode)
            {
                case Key.Tilda: return Shift ? "~" : "`";

                case Key.Key1: return Shift ? "!" : "1";
                case Key.Key2: return Shift ? "@" : "2";
                case Key.Key3: return Shift ? "#" : "3";
                case Key.Key4: return Shift ? "$" : "4";
                case Key.Key5: return Shift ? "%" : "5";
                case Key.Key6: return Shift ? "^" : "6";
                case Key.Key7: return Shift ? "&" : "7";
                case Key.Key8: return Shift ? "*" : "8";
                case Key.Key9: return Shift ? "(" : "9";
                case Key.Key0: return Shift ? ")" : "0";
                case Key.KeyMinus: return Shift ? "_" : "-";
                case Key.KeyPlus: return Shift ? "+" : "=";

                case Key.Q: return Shift ? "Q" : "q";
                case Key.W: return Shift ? "W" : "w";
                case Key.E: return Shift ? "E" : "e";
                case Key.R: return Shift ? "R" : "r";
                case Key.T: return Shift ? "T" : "t";
                case Key.Y: return Shift ? "Y" : "y";
                case Key.U: return Shift ? "U" : "u";
                case Key.I: return Shift ? "I" : "i";
                case Key.O: return Shift ? "O" : "o";
                case Key.P: return Shift ? "P" : "p";

                case Key.A: return Shift ? "A" : "a";
                case Key.S: return Shift ? "S" : "s";
                case Key.D: return Shift ? "D" : "d";
                case Key.F: return Shift ? "F" : "f";
                case Key.G: return Shift ? "G" : "g";
                case Key.H: return Shift ? "H" : "h";
                case Key.J: return Shift ? "J" : "j";
                case Key.K: return Shift ? "K" : "k";
                case Key.L: return Shift ? "L" : "l";

                case Key.Z: return Shift ? "Z" : "z";
                case Key.X: return Shift ? "X" : "x";
                case Key.C: return Shift ? "C" : "c";
                case Key.V: return Shift ? "V" : "v";
                case Key.B: return Shift ? "B" : "b";
                case Key.N: return Shift ? "N" : "n";
                case Key.M: return Shift ? "M" : "m";

                case Key.Space: return " ";

                case Key.NumSlash: return "/";
                case Key.NumAsterisk: return "*";
                case Key.NumMinus: return "-";
                case Key.NumPlus: return "+";
                case Key.Num0: return "0";
                case Key.Num1: return "1";
                case Key.Num2: return "2";
                case Key.Num3: return "3";
                case Key.Num4: return "4";
                case Key.Num5: return "5";
                case Key.Num6: return "6";
                case Key.Num7: return "7";
                case Key.Num8: return "8";
                case Key.Num9: return "9";

                case Key.LSquare: return Shift ? "{" : "[";
                case Key.RSquare: return Shift ? "}" : "]";
                case Key.Colon: return Shift ? ":" : ";";
                case Key.Quotes: return Shift ? "\"" : "'";
                case Key.BackSlash: return Shift ? "|" : "\\";
                case Key.LAngle: return Shift ? "<" : ",";
                case Key.RAngle: return Shift ? ">" : ".";
                case Key.Slash: return Shift ? "?" : "/";
            }

            return "";
        }
    }

    public delegate void InputHandler(KeyInfo key);

    public class Input
    {
        private InputHandler inputHandler = null;

        public void SendKey (KeyInfo key)
        {
            inputHandler?.Invoke(key);
        }

        public void RegisterHandler (InputHandler handler)
        {
            inputHandler = handler;
        }

        public KeyInfo Translate (KeyEventArgs e)
        {
            KeyInfo key = new KeyInfo();

            key.Shift = e.Shift;
            key.Ctrl = e.Control;
            key.Alt = e.Alt;

            if (e.KeyCode == Keys.Enter)
            {
                key.KeyCode = Key.Enter;
                return key;
            }

            switch (e.KeyCode)
            {
                case Keys.Escape: key.KeyCode = Key.Esc; break;
                case Keys.Back: key.KeyCode = Key.Backspace; break;
                case Keys.Space: key.KeyCode = Key.Space; break;

                case Keys.F1: key.KeyCode = Key.F1; break;
                case Keys.F2: key.KeyCode = Key.F2; break;
                case Keys.F3: key.KeyCode = Key.F3; break;
                case Keys.F4: key.KeyCode = Key.F4; break;
                case Keys.F5: key.KeyCode = Key.F5; break;
                case Keys.F6: key.KeyCode = Key.F6; break;
                case Keys.F7: key.KeyCode = Key.F7; break;
                case Keys.F8: key.KeyCode = Key.F8; break;
                case Keys.F9: key.KeyCode = Key.F9; break;
                case Keys.F10: key.KeyCode = Key.F10; break;
                case Keys.F11: key.KeyCode = Key.F11; break;
                case Keys.F12: key.KeyCode = Key.F12; break;

                case Keys.D1: key.KeyCode = Key.Key1; break;
                case Keys.D2: key.KeyCode = Key.Key2; break;
                case Keys.D3: key.KeyCode = Key.Key3; break;
                case Keys.D4: key.KeyCode = Key.Key4; break;
                case Keys.D5: key.KeyCode = Key.Key5; break;
                case Keys.D6: key.KeyCode = Key.Key6; break;
                case Keys.D7: key.KeyCode = Key.Key7; break;
                case Keys.D8: key.KeyCode = Key.Key8; break;
                case Keys.D9: key.KeyCode = Key.Key9; break;
                case Keys.D0: key.KeyCode = Key.Key0; break;

                case Keys.Oem3: key.KeyCode = Key.Tilda; break;
                case Keys.OemMinus: key.KeyCode = Key.KeyMinus; break;
                case Keys.Oemplus: key.KeyCode = Key.KeyPlus; break;

                case Keys.Q: key.KeyCode = Key.Q; break;
                case Keys.W: key.KeyCode = Key.W; break;
                case Keys.E: key.KeyCode = Key.E; break;
                case Keys.R: key.KeyCode = Key.R; break;
                case Keys.T: key.KeyCode = Key.T; break;
                case Keys.Y: key.KeyCode = Key.Y; break;
                case Keys.U: key.KeyCode = Key.U; break;
                case Keys.I: key.KeyCode = Key.I; break;
                case Keys.O: key.KeyCode = Key.O; break;
                case Keys.P: key.KeyCode = Key.P; break;

                case Keys.A: key.KeyCode = Key.A; break;
                case Keys.S: key.KeyCode = Key.S; break;
                case Keys.D: key.KeyCode = Key.D; break;
                case Keys.F: key.KeyCode = Key.F; break;
                case Keys.G: key.KeyCode = Key.G; break;
                case Keys.H: key.KeyCode = Key.H; break;
                case Keys.J: key.KeyCode = Key.J; break;
                case Keys.K: key.KeyCode = Key.K; break;
                case Keys.L: key.KeyCode = Key.L; break;

                case Keys.Z: key.KeyCode = Key.Z; break;
                case Keys.X: key.KeyCode = Key.X; break;
                case Keys.C: key.KeyCode = Key.C; break;
                case Keys.V: key.KeyCode = Key.V; break;
                case Keys.B: key.KeyCode = Key.B; break;
                case Keys.N: key.KeyCode = Key.N; break;
                case Keys.M: key.KeyCode = Key.M; break;

                case Keys.NumPad0: key.KeyCode = Key.Num0; break;
                case Keys.NumPad1: key.KeyCode = Key.Num1; break;
                case Keys.NumPad2: key.KeyCode = Key.Num2; break;
                case Keys.NumPad3: key.KeyCode = Key.Num3; break;
                case Keys.NumPad4: key.KeyCode = Key.Num4; break;
                case Keys.NumPad5: key.KeyCode = Key.Num5; break;
                case Keys.NumPad6: key.KeyCode = Key.Num6; break;
                case Keys.NumPad7: key.KeyCode = Key.Num7; break;
                case Keys.NumPad8: key.KeyCode = Key.Num8; break;
                case Keys.NumPad9: key.KeyCode = Key.Num9; break;

                case Keys.Divide: key.KeyCode = Key.NumSlash; break;
                case Keys.Multiply: key.KeyCode = Key.NumAsterisk; break;
                case Keys.Subtract: key.KeyCode = Key.NumMinus; break;
                case Keys.Add: key.KeyCode = Key.NumPlus; break;

                case Keys.Up: key.KeyCode = Key.Up; break;
                case Keys.Down: key.KeyCode = Key.Down; break;
                case Keys.Left: key.KeyCode = Key.Left; break;
                case Keys.Right: key.KeyCode = Key.Right; break;

                case Keys.Oem4: key.KeyCode = Key.LSquare; break;
                case Keys.Oem6: key.KeyCode = Key.RSquare; break;
                case Keys.Oem1: key.KeyCode = Key.Colon; break;
                case Keys.Oem7: key.KeyCode = Key.Quotes; break;
                case Keys.Oem5: key.KeyCode = Key.BackSlash; break;
                case Keys.Oemcomma: key.KeyCode = Key.LAngle; break;
                case Keys.OemPeriod: key.KeyCode = Key.RAngle; break;
                case Keys.Oem2: key.KeyCode = Key.Slash; break;

                default:
                    key.KeyCode = Key.None;
                    break;
            }

            return key;
        }

    }

}
