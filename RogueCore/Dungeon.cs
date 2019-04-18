using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RogueCore
{
    public class Cell
    {
        public bool visible = false;
        public bool solid = false;
        public Char character = new Char();
        public int debugCounter = 0;
    }

    public class Dungeon
    {
        private readonly Cell[] cells;
        public int Width;
        public int Height;
        private readonly Char invisibleTile = new Char();

        public Dungeon (int w, int h)
        {
            this.Width = w;
            this.Height = h;
            cells = new Cell[w * h];
            Clear();
        }

        public void Clear()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    cells[y * Width + x] = new Cell();
                }
            }
        }

        public Cell GetCell (int x, int y)
        {
            if (x < 0 || x >= Width)
                return new Cell();
            if (y < 0 || y >= Height)
                return new Cell();

            return cells[y * Width + x];
        }

        public void SetCell (int x, int y, Cell tile)
        {
            if (x < 0 || x >= Width)
                return;
            if (y < 0 || y >= Height)
                return;

            Cell copyTile = new Cell();

            copyTile.character = new Char();

            copyTile.character.backColor = tile.character.backColor;
            copyTile.character.frontColor = tile.character.frontColor;
            copyTile.character.character = tile.character.character;

            copyTile.solid = tile.solid;
            copyTile.visible = tile.visible;

            cells[y * Width + x] = copyTile;
        }

        public void Display(Screen screen, int lineStart)
        {
            for (int y=0; y<Height; y++)
            {
                for(int x=0; x<Width; x++)
                {
                    Cell cell = GetCell(x, y);

                    screen.SetChar(x, lineStart + y, cell.visible ? cell.character : invisibleTile);
                }
            }

            screen.Invalidate();
        }

        private int FillCallback (Point point, object ctx)
        {
            SetCell(point.X, point.Y, ctx as Cell);
            return 0;
        }

        public void FillLine(Point start, Point end, Cell tile)
        {
            Tracer.TraceLine(start, end, FillCallback, tile);
        }

        public void FillRect(Rectangle rect, Cell tile)
        {
            for (int y=0; y<rect.Height;y++)
            {
                for(int x=0; x<rect.Width; x++)
                {
                    SetCell(rect.X + x, rect.Y + y, tile);
                }
            }
        }

        public void FillCircle(Point center, int radius, Cell tile)
        {
            Tracer.TraceCircle(center, radius, FillCallback, tile);
        }

        public void ShowAll ()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GetCell(x, y).visible = true;
                }
            }
        }

        public void HideAll()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    GetCell(x, y).visible = false;
                }
            }
        }

        private int DungeonFovCallback(Point point, object ctx)
        {
            Cell cell = GetCell(point.X, point.Y);

            cell.visible = true;

            if (cell.solid)
                return -1;

            return 0;
        }

        public void UpdateFov (Point point, int radius)
        {
            Tracer.TraceFov(point, radius, DungeonFovCallback);
        }

    }

}
