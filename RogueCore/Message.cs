using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueCore
{
    public class Message
    {
        private const string more = " (more)";
        private string textQueue = "";
        private int lineStart;
        private int numLines;

        public Message (int lineStart, int numLines)
        {
            this.lineStart = lineStart;
            this.numLines = numLines;
        }

        public void Add (string msg)
        {
            textQueue += msg + " ";
        }

        public void Clear()
        {
            textQueue = "";
        }

        public void ShowMore (Screen screen)
        {
            ClearMessageView(screen);

            if ( textQueue.Length == 0 )
            {
#if DEBUG
                screen.Print(0, lineStart, "<empty>");
#endif
                return;
            }

            int charsCount = 0;

            string [] words = textQueue.Split(' ');
            int y = 0;
            string text = "";

            for (int i = 0; i < words.Length; i++)
            {
                int wordSize = words[i].Length;

                bool lastLine = y == (numLines - 1);

                if ( text.Length + wordSize + (lastLine ? more.Length : 0) >= screen.ScreenWidth )
                {
                    screen.Print(0, lineStart + y, text + (lastLine ? more : "") );
                    charsCount += text.Length;
                    text = "";
                    y++;

                    if (y >= numLines)
                        break;
                }

                text += words[i] + " ";
            }

            /// Tail

            if ( text.Length != 0)
            {
                screen.Print(0, lineStart + y, text);
                charsCount += text.Length;
            }

            textQueue = textQueue.Substring(Math.Min(charsCount, textQueue.Length)).Trim();
        }

        private void ClearMessageView (Screen screen)
        {
            for(int y=0; y <numLines; y++)
                screen.ClearLine(lineStart + y);
        }

    }
}
