using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RogueDemo
{
    public partial class Form1 : Form
    {
        RogueCore.Message msg;
        string inputText = "";
        RogueCore.Input input = new RogueCore.Input();
        RogueCore.Dungeon currentDungeon = null;

        public Form1()
        {
            InitializeComponent();

            msg = new RogueCore.Message(0, 2);

            input.RegisterHandler(DefaultInputHandler);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        Random rnd = new Random();

        private Color RandomColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        public char RandomCharacter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            int num = rnd.Next(0, chars.Length - 1);
            return chars[num];
        }

        private void FillRandomChars()
        {
            for (int y = 0; y < rogueScreen1.ScreenHeight; y++)
            {
                for (int x = 0; x < rogueScreen1.ScreenWidth; x++)
                {
                    RogueCore.Char character = new RogueCore.Char();

                    character.backColor = Color.Black;
                    character.frontColor = RandomColor();
                    character.character = RandomCharacter();

                    rogueScreen1.SetChar(x, y, character);
                }
            }

            rogueScreen1.Invalidate();
        }

        private void fillScreenByRandomCharsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillRandomChars();
        }

        private void clearScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rogueScreen1.ClearScreen();
        }

        private void setCursorAtRandomPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = rnd.Next(0, rogueScreen1.ScreenWidth - 1);
            int y = rnd.Next(0, rogueScreen1.ScreenHeight - 1);

            rogueScreen1.SetCursor (new Point(x, y));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void rogueScreen1_KeyDown(object sender, KeyEventArgs e)
        {
            input.SendKey(input.Translate(e));
        }

        private void setScreenToRandomSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w = rnd.Next(10, 100);
            int h = rnd.Next(10, 60);

            rogueScreen1.ScreenWidth = w;
            rogueScreen1.ScreenHeight = h;
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(openFileDialog1.FileName);

                rogueScreen1.ScreenWidth = bitmap.Width;
                rogueScreen1.ScreenHeight = bitmap.Height;

                for (int y=0; y<bitmap.Height; y++)
                {
                    for(int x=0; x<bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        float yval = 0.299f * color.R + 0.587f * color.G + 0.114f * color.B;

                        RogueCore.Char character = new RogueCore.Char();

                        character.frontColor = color;
                        character.character = getGrayShade((int)yval);

                        rogueScreen1.SetChar(x, y, character);
                    }
                }
            }
        }

        private char getGrayShade(int value)
        {
            char asciival = ' ';
            const char BLACK = '@';
            const char CHARCOAL = '#';
            const char DARKGRAY = '8';
            const char MEDIUMGRAY = '&';
            const char MEDIUM = 'o';
            const char GRAY = ':';
            const char SLATEGRAY = '*';
            const char LIGHTGRAY = '.';
            const char WHITE = ' ';

            if (value >= 230)
            {
                asciival = WHITE;
            }
            else if (value >= 200)
            {
                asciival = LIGHTGRAY;
            }
            else if (value >= 180)
            {
                asciival = SLATEGRAY;
            }
            else if (value >= 160)
            {
                asciival = GRAY;
            }
            else if (value >= 130)
            {
                asciival = MEDIUM;
            }
            else if (value >= 100)
            {
                asciival = MEDIUMGRAY;
            }
            else if (value >= 70)
            {
                asciival = DARKGRAY;
            }
            else if (value >= 50)
            {
                asciival = CHARCOAL;
            }
            else
            {
                asciival = BLACK;
            }

            return asciival;
        }

        private void addMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg.Add("The quick brown fox jumps over the lazy dog.");
        }

        private void showMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg.ShowMore(rogueScreen1);
        }

        private void printHelloAtCursorPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point pos = rogueScreen1.GetCursor();

            rogueScreen1.Print(pos.X, pos.Y, "Hello!");
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            //FillRandomChars();
        }

        private void addPoemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msg.Add(Properties.Resources.Poem);
        }

        private void generateRandomDungeonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomDungeon randomDungeon = new RandomDungeon();

            currentDungeon = randomDungeon.Generate(
                rogueScreen1.ScreenWidth,
                rogueScreen1.ScreenHeight - 4 );

            currentDungeon.Display(rogueScreen1, 2);
        }

        private int TraceCb(Point point, object ctx)
        {
            RogueCore.Char dot = new RogueCore.Char();

            dot.character = '.';

            rogueScreen1.SetChar(point.X, point.Y, dot);

            return 0;
        }

        private void traceRandomLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point start = new Point(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1));
            Point end = new Point(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1));

            msg.Add("Trace line: (" + start.X.ToString() + ", " + start.Y.ToString() + ") - (" +
                end.X.ToString() + ", " + end.Y.ToString() + ")");

            RogueCore.Tracer.TraceLine(start, end, TraceCb);

            rogueScreen1.Invalidate();
        }

        private void traceRandomCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point center = new Point(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1));
            int radius = rnd.Next(1, 10);

            msg.Add("Trace circle: (" + center.X.ToString() + ", " + center.Y.ToString() + "), " + radius.ToString());

            RogueCore.Tracer.TraceCircle(center, radius, TraceCb);

            rogueScreen1.Invalidate();
        }

        private int RedExplosionCb(Point point, object ctx)
        {
            Color[] explosionColors = new Color[]
            {
                Color.Red,
                Color.OrangeRed,
                Color.Firebrick,
                Color.Tomato
            };

            RogueCore.Char fire = new RogueCore.Char();

            fire.character = '#';

            int colorIndex = rnd.Next(0, explosionColors.Length);
            fire.frontColor = explosionColors[colorIndex];

            rogueScreen1.SetChar(point.X, point.Y, fire);

            return 0;
        }

        private int GreenExplosionCb(Point point, object ctx)
        {
            Color[] explosionColors = new Color[]
            {
                Color.Green,
                Color.Lime,
                Color.ForestGreen,
                Color.Chartreuse
            };

            RogueCore.Char fire = new RogueCore.Char();

            fire.character = '#';

            int colorIndex = rnd.Next(0, explosionColors.Length);
            fire.frontColor = explosionColors[colorIndex];

            rogueScreen1.SetChar(point.X, point.Y, fire);

            return 0;
        }

        private int BlueExplosionCb(Point point, object ctx)
        {
            Color[] explosionColors = new Color[]
            {
                Color.Blue,
                Color.RoyalBlue,
                Color.MediumBlue,
                Color.Cyan
            };

            RogueCore.Char fire = new RogueCore.Char();

            fire.character = '#';

            int colorIndex = rnd.Next(0, explosionColors.Length);
            fire.frontColor = explosionColors[colorIndex];

            rogueScreen1.SetChar(point.X, point.Y, fire);

            return 0;
        }

        private void RandomExplosion(RogueCore.Tracer.TraceDelegate cb)
        {
            Point center = new Point(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1));
            int radiusMin = 2;
            int radiusMax = rnd.Next(3, 12);

            msg.Add("Trace explosion: (" + center.X.ToString() + ", " + center.Y.ToString() + "), " + radiusMax.ToString());

            int r = radiusMin;
            while (r < radiusMax)
            {
                RogueCore.Tracer.TraceCircle(center, r, cb);
                r++;
            }

            rogueScreen1.Invalidate();
        }

        private void traceRandomExplosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomExplosion(RedExplosionCb);
        }

        private void traceSaluteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RogueCore.Tracer.TraceDelegate[] cbs = new RogueCore.Tracer.TraceDelegate[]
            {
                RedExplosionCb,
                GreenExplosionCb,
                BlueExplosionCb
            };

            int numExplosions = rnd.Next(5, 10);

            for(int i=0; i< numExplosions; i++)
            {
                int explosionCbIndex = rnd.Next(0, cbs.Length);

                RandomExplosion(cbs[explosionCbIndex]);
            }
        }

        private void inputStringAtCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputText = "";
            input.RegisterHandler(InputTextHandler);
        }

        private void DefaultInputHandler (RogueCore.KeyInfo key)
        {
            Point pos = rogueScreen1.GetCursor();

            switch (key.KeyCode)
            {
                case RogueCore.Key.Up:
                    pos.Y--;
                    rogueScreen1.Invalidate();
                    break;
                case RogueCore.Key.Down:
                    pos.Y++;
                    rogueScreen1.Invalidate();
                    break;
                case RogueCore.Key.Left:
                    pos.X--;
                    rogueScreen1.Invalidate();
                    break;
                case RogueCore.Key.Right:
                    pos.X++;
                    rogueScreen1.Invalidate();
                    break;
                case RogueCore.Key.Esc:
                    pos = new Point();
                    break;
                case RogueCore.Key.Backspace:
                    rogueScreen1.ClearScreen();
                    break;

                case RogueCore.Key.Space:
                    msg.ShowMore(rogueScreen1);
                    return;
            }

            rogueScreen1.SetCursor(pos);
        }

        private void InputTextHandler(RogueCore.KeyInfo key)
        {
            switch (key.KeyCode)
            {
                case RogueCore.Key.Enter:
                    MessageBox.Show("Input: " + inputText);
                    input.RegisterHandler(DefaultInputHandler);
                    break;
                case RogueCore.Key.Backspace:
                    if (inputText.Length != 0)
                    {
                        rogueScreen1.PutChar(' ', true);
                        inputText = inputText.Substring(0, inputText.Length - 1);
                    }
                    break;
                default:
                    string text = key.ToString();
                    if (text.Length == 1)
                    {
                        inputText += text[0];
                        rogueScreen1.PutChar(text[0]);
                    }
                    break;
            }
        }

        private RogueCore.Cell GetFloor()
        {
            RogueCore.Cell floor = new RogueCore.Cell();

            floor.character = new RogueCore.Char();
            floor.character.character = '.';
            floor.character.frontColor = Color.FromArgb(0xaa, 0xaa, 0xaa);

            floor.visible = true;
            floor.solid = false;

            return floor;
        }

        private RogueCore.Cell GetWall()
        {
            RogueCore.Cell wall = new RogueCore.Cell();

            wall.character = new RogueCore.Char();
            wall.character.character = '#';
            wall.character.frontColor = Color.FromArgb(0x55, 0x55, 0x55);

            wall.visible = true;
            wall.solid = true;

            return wall;
        }

        private void fillByWallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                currentDungeon = new RogueCore.Dungeon(rogueScreen1.ScreenWidth, rogueScreen1.ScreenHeight - 4);
            }

            currentDungeon.FillRect(new Rectangle(0, 0, currentDungeon.Width, currentDungeon.Height), GetWall());
            currentDungeon.Display(rogueScreen1, 2);
        }

        private void digRandomRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                currentDungeon = new RogueCore.Dungeon(rogueScreen1.ScreenWidth, rogueScreen1.ScreenHeight - 4);
            }

            Rectangle rect = new Rectangle(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1),
                rnd.Next(3, 8), rnd.Next(3, 8));

            currentDungeon.FillRect(rect, GetFloor());
            currentDungeon.Display(rogueScreen1, 2);
        }

        private void digRandomTunnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                currentDungeon = new RogueCore.Dungeon(rogueScreen1.ScreenWidth, rogueScreen1.ScreenHeight - 4);
            }

            int vertical = rnd.Next(0, 2);

            int width = rnd.Next(5, 15);
            Point start = new Point(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1));
            Point end = new Point(
                start.X + width * ((vertical != 0) ? 0 : 1),
                start.Y + width * ((vertical != 0) ? 1 : 0) );

            currentDungeon.FillLine(start, end, GetFloor() );
            currentDungeon.Display(rogueScreen1, 2);
        }

        private void fillByFloorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                currentDungeon = new RogueCore.Dungeon(rogueScreen1.ScreenWidth, rogueScreen1.ScreenHeight - 4);
            }

            currentDungeon.FillRect(new Rectangle(0, 0, currentDungeon.Width, currentDungeon.Height), GetFloor());
            currentDungeon.Display(rogueScreen1, 2);
        }

        private void putWallSlabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                currentDungeon = new RogueCore.Dungeon(rogueScreen1.ScreenWidth, rogueScreen1.ScreenHeight - 4);
            }

            Rectangle rect = new Rectangle(
                rnd.Next(0, rogueScreen1.ScreenWidth - 1),
                rnd.Next(0, rogueScreen1.ScreenHeight - 1),
                rnd.Next(3, 8), rnd.Next(3, 8));

            currentDungeon.FillRect(rect, GetWall());
            currentDungeon.Display(rogueScreen1, 2);
        }

        private int TracePathCb(Point point, object ctx)
        {
            RogueCore.Char character = new RogueCore.Char();

            character.character = 'x';
            character.frontColor = Color.Yellow;

            rogueScreen1.SetChar(point.X, point.Y + 2, character);

            return 0;
        }

        private void traceRandomPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                return;
            }

            Point start = new Point(
                rnd.Next(0, currentDungeon.Width / 2),
                rnd.Next(0, currentDungeon.Height - 1));
            Point end = new Point(
                rnd.Next(currentDungeon.Width / 2 + 1, currentDungeon.Width - 1),
                rnd.Next(0, currentDungeon.Height - 1));

            currentDungeon.Display(rogueScreen1, 2);

            RogueCore.Tracer.TracePath(currentDungeon, start, end, TracePathCb);

            rogueScreen1.Invalidate();

            msg.Clear();
            msg.Add("Trace path: (" + start.X.ToString() + ", " + start.Y.ToString() + ") - (" +
                end.X.ToString() + ", " + end.Y.ToString() + ")");
            msg.ShowMore(rogueScreen1);            
        }

        private void traceTopbottomPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon == null)
            {
                return;
            }

            Point start = new Point(0, 0);
            Point end = new Point(currentDungeon.Width - 1, currentDungeon.Height - 1);

            currentDungeon.Display(rogueScreen1, 2);

            RogueCore.Tracer.TracePath(currentDungeon, start, end, TracePathCb);

            rogueScreen1.Invalidate();

            msg.Clear();
            msg.Add("Trace path: (" + start.X.ToString() + ", " + start.Y.ToString() + ") - (" +
                end.X.ToString() + ", " + end.Y.ToString() + ")");
            msg.ShowMore(rogueScreen1);
        }

        private void makeDungeonInvisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon != null)
            {
                currentDungeon.HideAll();
                currentDungeon.Display(rogueScreen1, 2);
            }
        }

        private void makeDungeonVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon != null)
            {
                currentDungeon.ShowAll();
                currentDungeon.Display(rogueScreen1, 2);
            }
        }

        private void randomFOVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon != null)
            {
                Point point = new Point(
                    rnd.Next(0, currentDungeon.Width - 1),
                    rnd.Next(0, currentDungeon.Height - 1));
                int radius = rnd.Next(5, 10);

                currentDungeon.UpdateFov(point, radius);
                currentDungeon.Display(rogueScreen1, 2);
            }
        }

        private void randomFOVAtCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentDungeon != null)
            {
                Point cursorPos = rogueScreen1.GetCursor();

                Point point = new Point(cursorPos.X, cursorPos.Y - 2);
                int radius = rnd.Next(5, 10);

                currentDungeon.UpdateFov(point, radius);
                currentDungeon.Display(rogueScreen1, 2);
            }
        }
    }
}
