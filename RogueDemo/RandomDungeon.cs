using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RogueDemo
{
    public class RandomDungeon
    {
        private enum CellType
        {
            Floor = 0,
            Wall,
            OpenDoor,
            ClosedDoor,
            DoorWay,

            Max,
        }

        private Random rnd = new Random();

        public RogueCore.Dungeon Generate(int w, int h)
        {
            RogueCore.Dungeon dungeon = new RogueCore.Dungeon(w, h);

            for(int y=0; y<dungeon.Height; y++)
            {
                for(int x=0; x<dungeon.Width; x++)
                {
                    RogueCore.Cell cell = dungeon.GetCell(x, y);

                    int type = rnd.Next(0, (int)CellType.Max);

                    switch (type)
                    {
                        case (int)CellType.Floor:
                            cell.character.character = '.';
                            cell.character.frontColor = Color.FromArgb(0xaa, 0xaa, 0xaa);
                            cell.solid = false;
                            break;
                        case (int)CellType.OpenDoor:
                            cell.character.character = '/';
                            cell.character.frontColor = Color.FromArgb(0xaa, 0x55, 0);
                            cell.solid = false;
                            break;
                        case (int)CellType.ClosedDoor:
                            cell.character.character = '+';
                            cell.character.frontColor = Color.FromArgb(0xaa, 0x55, 0);
                            cell.solid = false;
                            break;
                        case (int)CellType.DoorWay:
                            cell.character.character = '.';
                            cell.character.frontColor = Color.FromArgb(0xaa, 0x55, 0);
                            cell.solid = false;
                            break;
                        case (int)CellType.Wall:
                            cell.character.character = '#';
                            cell.character.frontColor = Color.FromArgb(0x55, 0x55, 0x55);
                            cell.solid = true;
                            break;
                    }

                    cell.visible = true;
                }
            }

            dungeon.GetCell(0, 0).solid = false;
            dungeon.GetCell(w-1, h-1).solid = false;

            return dungeon;
        }

    }
}
