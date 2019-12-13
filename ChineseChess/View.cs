using System;

namespace ChineseChess
{
    internal class View
    {
        /// <summary>
        /// Show the chessboard to the user.
        /// </summary>
        public static void DisplayBoard(Board board)
        {

            dynamic chess;
            for (int x = 0; x < board.GetRow() + 1; x++)
            {
                for (int y = 0; y < board.GetCol() + 1; y++)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //坐标提示
                    if (x == 0 && y == 0)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    if (x == 0)
                    {
                        if (y % 2 != 0)
                            Console.Write($" {y / 2}");
                        else
                            Console.Write("  ");
                        continue;
                    }
                    if (y == 0)
                    {
                        if (x % 2 != 0)
                            Console.Write($"{x / 2} ");
                        else
                            Console.Write("  ");
                        continue;
                    }

                    int row = x - 1;
                    int col = y - 1;
                    chess = Board.board[row, col];
                    Controller.SetChessForegroundColor(chess.GetColor());
                    //根据空白的位置设置形状
                    if (chess.GetDefaultColor().Equals("White"))
                    {
                        //特殊点位
                        if (row == 9)
                        {
                            switch (col)
                            {
                                case 0:
                                case 16:
                                    chess.SetName("│ ");
                                    break;

                                case 2:
                                    chess.SetName("楚");
                                    break;

                                case 4:
                                    chess.SetName("河");
                                    break;

                                case 12:
                                    chess.SetName("汉");
                                    break;

                                case 14:
                                    chess.SetName("界");
                                    break;

                                default:
                                    chess.SetName("  ");
                                    break;
                            }
                        }
                        else if (row % 2 != 0 && col % 2 != 0)
                        {
                            chess.SetName("  ");
                        }
                        else if (row % 2 == 0 && col % 2 != 0)
                        {
                            chess.SetName("──");
                        }
                        else if (row % 2 != 0 && col % 2 == 0)
                        {
                            chess.SetName("│ ");
                        }
                        else if (col == 0)
                        {
                            //第一列
                            if (row == 0)
                            {
                                chess.SetName("┌─");
                            }
                            else if (row == Board.board.GetLength(0) - 1)
                            {
                                chess.SetName(" └");
                            }
                            else if (row != Board.board.GetLength(0) / 2)
                                chess.SetName("├─");
                        }
                        else if (col == Board.board.GetLength(1) - 1)
                        {
                            //最后一列
                            if (row == 0)
                                chess.SetName(" ┐");
                            else if (row == Board.board.GetLength(0) - 1)
                                chess.SetName(" ┘");
                            else if (row != Board.board.GetLength(0) / 2)
                                chess.SetName("┤ ");
                        }
                        else if (col != 0 || (col != Board.board.GetLength(1) - 1))
                        {
                            //楚河汉界上下边
                            if ((row == Board.board.GetLength(0) / 2 - 1) || (row == Board.board.GetLength(0) - 1))
                                chess.SetName("┴─");
                            else if (row == 0 || (row == Board.board.GetLength(0) / 2 + 1))
                                chess.SetName("┬─");
                        }
                        //九宫格
                        if ((col == 7))
                        {
                            if (row == 3 || row == 17)
                            {
                                chess.SetName("╱ ");
                            }
                            if (row == 1 || row == 15)
                            {
                                chess.SetName("╲ ");
                            }
                        }
                        else if (col == 9)
                        {
                            if (row == 1 || row == 15)
                            {
                                chess.SetName("╱ ");
                            }
                            else if (row == 3 || row == 17)
                            {
                                chess.SetName("╲ ");
                            }
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(chess.GetName());
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        public static void ShowIsWhoseTurnRound()
        {
            //展示目前是谁的回合
            Console.BackgroundColor = ConsoleColor.Yellow;
            if (Controller.TurnRound.Equals("Red"))
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n{Controller.TurnRound} Round.");
            Console.ResetColor();
        }

        public static void ShowTips(string strOouput)
        {
            //弹出提示语
            Console.WriteLine(strOouput);
        }

        public static void GameOver()
        {
            Console.WriteLine("\n\n\t\t\t\tGAME OVAER!!!!!!");
        }
    }
}