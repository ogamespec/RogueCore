using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RogueCore
{
    public class Tracer
    {
        public delegate int TraceDelegate(Point point, object context);

        // https://rosettacode.org/wiki/Bitmap/Bresenham%27s_line_algorithm#C.2B.2B

        public static void TraceLine(Point start, Point end, TraceDelegate cb, object ctx = null)
        {
            Point prevPoint = new Point(int.MaxValue, int.MaxValue);

            int x0 = start.X;
            int x1 = end.X;
            int y0 = start.Y;
            int y1 = end.Y;

            if (x0 == x1 && y0 == y1)
            {
                cb(new Point(x0, y0), ctx);
                return;
            }

            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            for (;;)
            {
                Point point = new Point(x0, y0);

                if (!(point.X == prevPoint.X && point.Y == prevPoint.Y))
                {
                    int res = cb(point, ctx);
                    if (res < 0)
                        break;
                }

                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }

                prevPoint.X = point.X;
                prevPoint.Y = point.Y;
            }
        }

        public static void TraceCircle(Point center, int radius, TraceDelegate cb, object ctx = null)
        {
            List<Point> visited = new List<Point>();

            if (radius <= 0)
                return;

            int n = radius * 12;
            double dtheta = 2.0 * Math.PI / n;

            for (int t = 0; t < n; t++)
            {
                double theta = t * dtheta;
                int x = (int)Math.Round((radius * Math.Cos(theta)));
                int y = (int)Math.Round((radius * Math.Sin(theta)));

                Point point = new Point(center.X + x, center.Y + y);

                bool skip = false;

                foreach (Point p in visited)
                {
                    if ( p.X == point.X && p.Y == point.Y )
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip)
                {
                    continue;
                }

                int res = cb(point, ctx);
                if (res < 0)
                    break;
            }
        }

        internal class FovState
        {
            public List<Point> visited;
            public TraceDelegate originalCb;
            public object originalContext;
        }

        private static int FovCallback(Point point, object ctx)
        {
            FovState state = (FovState)ctx;

            foreach ( Point p in state.visited)
            {
                if ( p.X == point.X && p.Y == point.Y)
                {
                    return 0;
                }
            }

            return state.originalCb(point, state.originalContext);
        }

        public static void TraceFov(Point point, int radius, TraceDelegate cb, object ctx = null)
        {
            FovState state = new FovState();

            List<Point> visited = new List<Point>();

            state.visited = visited;
            state.originalCb = cb;
            state.originalContext = ctx;

            int res = cb(point, ctx);
            if (res < 0)
                return;

            visited.Add(point);

            int n = radius * 24;
            double dtheta = 2.0 * Math.PI / n;

            for (int t = 0; t < n; t++)
            {
                double theta = t * dtheta;
                int x = (int)Math.Round((radius * Math.Cos(theta)));
                int y = (int)Math.Round((radius * Math.Sin(theta)));

                Point end = new Point(point.X + x, point.Y + y);

                Tracer.TraceLine(point, end, FovCallback, state);
            }
        }

        public static void TracePath (Dungeon map, Point from, Point to, TraceDelegate cb, object ctx = null)
        {
            List<Point> points = FindPath(map, from, to);

            if (points == null)
                return;
            
            foreach (var point in points)
            {
                int res = cb(point, ctx);
                if (res < 0)
                    break;
            }
        }

        // https://lsreg.ru/realizaciya-algoritma-poiska-a-na-c/

        #region "A-Star"

        private class PathNode
        {
            public Point Position { get; set; }
            public int PathLengthFromStart { get; set; }
            public PathNode CameFrom { get; set; }
            public int HeuristicEstimatePathLength { get; set; }
            public int EstimateFullPathLength
            {
                get
                {
                    return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
                }
            }
        }

        private static List<Point> FindPath(Dungeon field, Point start, Point goal)
        {
            var closedSet = new List<PathNode>();
            var openSet = new List<PathNode>();

            PathNode startNode = new PathNode()
            {
                Position = start,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, goal)
            };

            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                var currentNode = openSet.OrderBy(node =>
                  node.EstimateFullPathLength).First();

                if (currentNode.Position == goal)
                    return GetPathForNode(currentNode);

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                foreach (var neighbourNode in GetNeighbours(currentNode, goal, field))
                {
                    if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                        continue;
                    var openNode = openSet.FirstOrDefault(node =>
                      node.Position == neighbourNode.Position);

                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                      if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }

            return null;
        }

        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }

        private static int GetHeuristicPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        private static List<PathNode> GetNeighbours(PathNode pathNode,
          Point goal, Dungeon field)
        {
            var result = new List<PathNode>();

            Point[] neighbourPoints = new Point[4];
            neighbourPoints[0] = new Point(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[1] = new Point(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[2] = new Point(pathNode.Position.X, pathNode.Position.Y + 1);
            neighbourPoints[3] = new Point(pathNode.Position.X, pathNode.Position.Y - 1);

            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.X >= field.Width)
                    continue;
                if (point.Y < 0 || point.Y >= field.Height)
                    continue;
                if ( field.GetCell(point.X, point.Y).solid )
                    continue;
                var neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart +
                    GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }

        private static List<Point> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Point>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }

        #endregion


    }
}
