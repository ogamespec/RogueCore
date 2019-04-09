using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Threading;

namespace RogueCore
{
    public class Char
    {
        public Color backColor;
        public Color frontColor;
        public char character;

        public Char()
        {
            backColor = Color.Black;
            frontColor = Color.LightGray;
            character = ' ';
        }
    }

    public class Screen : Control
    {
        private Char[] _screen;
        private int _screenWidth;
        private int _screenHeight;

        public int ScreenWidth
        {
            get
            {
                return _screenWidth;
            }
            set
            {
                _screenWidth = value;
                _screen = new Char[_screenWidth * _screenHeight];
                ClearScreen();
            }
        }
        public int ScreenHeight
        {
            get
            {
                return _screenHeight;
            }
            set
            {
                _screenHeight = value;
                _screen = new Char[_screenWidth * _screenHeight];
                ClearScreen();
            }
        }

        private BufferedGraphics gfx = null;
        private BufferedGraphicsContext context;

        private Point CursorPos = new Point();
        private bool cursorShowToggle = true;
        private bool cursorVisible = true;

        public Screen()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            ScreenWidth = 80;
            ScreenHeight = 25;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 400);    // ms
            dt.Tick += new EventHandler(CursorTick);
            dt.Start();
        }

        private void CursorTick(object sender, EventArgs e)
        {
            cursorShowToggle = !cursorShowToggle;
            Invalidate();
        }

        public void ClearScreen()
        {
            for(int y=0; y<ScreenHeight; y++)
            {
                for(int x=0; x<ScreenWidth; x++)
                {
                    SetChar(x, y, new Char());
                }
            }
            Invalidate();
        }

        public void SetChar (int x, int y, Char character)
        {
            if (x < 0 || x >= ScreenWidth)
                return;
            if (y < 0 || y >= ScreenHeight)
                return;

            Char copyChar = new Char();

            copyChar.backColor = character.backColor;
            copyChar.frontColor = character.frontColor;
            copyChar.character = character.character;

            _screen[y * ScreenWidth + x] = copyChar;
        }

        public Char GetChar (int x, int y)
        {
            if (x < 0 || x >= ScreenWidth)
                return new Char();
            if (y < 0 || y >= ScreenHeight)
                return new Char();

            return _screen[y * ScreenWidth + x];
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (gfx == null)
            {
                ReallocateGraphics();
            }

            Draw(gfx.Graphics);

            gfx.Render(e.Graphics);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (gfx != null)
            {
                gfx.Dispose();
                ReallocateGraphics();
            }

            Invalidate();
            base.OnSizeChanged(e);
        }

        private void ReallocateGraphics()
        {
            context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(Width + 1, Height + 1);

            gfx = context.Allocate(CreateGraphics(),
                 new Rectangle(0, 0, Width, Height));
        }

        private void Draw(Graphics gr)
        {
            if (Width == 0 || Height == 0)
                return;

            gr.Clear(BackColor);

            var textSize = gr.MeasureString("X", this.Font);

            float charWidth = textSize.Width - 3;
            float charHeight = textSize.Height - 1;

            for (int y = 0; y < ScreenHeight; y++)
            {
                for (int x = 0; x < ScreenWidth; x++)
                {
                    Char character = _screen[y * ScreenWidth + x];

                    DrawChar(x, y, charWidth, charHeight, gr, character);
                }
            }

            DrawCursor(charWidth, charHeight, gr);
        }

        private void DrawChar(int x, int y, float charWidth, float charHeight, Graphics gr, Char character)
        {
            string text = new string(character.character, 1);

            gr.FillRectangle(new SolidBrush(character.backColor),
                    x * charWidth, y * charHeight,
                    charWidth, charHeight);

            gr.DrawString(text, this.Font, new SolidBrush(character.frontColor),
                x * charWidth, y * charHeight);
        }

        private void DrawCursor (float charWidth, float charHeight, Graphics gr)
        {
            if (CursorPos.X < 0 || CursorPos.X >= ScreenWidth)
                return;
            if (CursorPos.Y < 0 || CursorPos.Y >= ScreenHeight)
                return;

            Char cursorChar = new Char();
            cursorChar.character = '_';

            string text = new string(cursorChar.character, 1);

            if (cursorShowToggle && cursorVisible)
            {
                gr.DrawString(text, this.Font, new SolidBrush(cursorChar.frontColor),
                    CursorPos.X * charWidth, CursorPos.Y * charHeight + 2);
                gr.DrawString(text, this.Font, new SolidBrush(cursorChar.frontColor),
                    CursorPos.X * charWidth, CursorPos.Y * charHeight + 3);
            }
            else
            {
                gr.DrawString(text, this.Font, new SolidBrush(cursorChar.backColor),
                    CursorPos.X * charWidth, CursorPos.Y * charHeight + 2);
                gr.DrawString(text, this.Font, new SolidBrush(cursorChar.backColor),
                    CursorPos.X * charWidth, CursorPos.Y * charHeight + 3);
            }
        }

        public void SetCursor (Point point)
        {
            CursorPos = point;
            Invalidate();
        }

        public Point GetCursor ()
        {
            return CursorPos;
        }

        public void ShowCursor ()
        {
            cursorVisible = true;
            Invalidate();
        }

        public void HideCursor()
        {
            cursorVisible = false;
            Invalidate();
        }

        public bool IsCursorVisible ()
        {
            return cursorVisible;
        }

        public void ClearLine (int n)
        {
            if (n < 0 || n >= ScreenHeight)
                return;
            for (int x = 0; x < ScreenWidth; x++)
                SetChar(x, n, new Char());
            Invalidate();
        }

        public void Print (int x, int y, string text)
        {
            int i = 0;

            while ( i < text.Length)
            {
                Char character = GetChar(x, y);
                character.character = text[i];
                SetChar(x, y, character);
                x++; i++;
            }

            Invalidate();
        }

        public void PutChar(char charValue, bool backward = false)
        {
            Point pos = GetCursor();

            if (backward)
                pos.X--;

            RogueCore.Char character = GetChar(pos.X, pos.Y);
            character.character = charValue;
            SetChar(pos.X, pos.Y, character);

            if (!backward)
                pos.X++;

            SetCursor(pos);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            return true;
        }

    }

}
