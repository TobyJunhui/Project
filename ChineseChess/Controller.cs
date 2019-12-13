using System;
using System.Collections.Generic;

namespace ChineseChess
{
    public partial class Controller
    {
        public static int TurnRoundNums = 0;
        public static string TurnRound;
        public static bool IndexIsWrong = false;

        public static void SetChessForegroundColor(string color)
        {
            //设置单元格字体颜色
            if (color.Equals("Red"))
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color.Equals("Black"))
                Console.ForegroundColor = ConsoleColor.Black;
            else if (color.Equals("Blue"))
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ResetBoardToDefaultColor()
        {
            //将整体棋盘恢复默认配色
            foreach (Chess c in Board.board)
            {
                if (c.GetColor().Equals("Blue"))
                {
                    c.SetColor(c.GetDefaultColor());
                }
            }
        }

        public static void UpdateTheTurnRound()
        {
            //计算回合以确定轮到什么颜色棋子移动
            TurnRoundNums++;
            if (TurnRoundNums % 2 == 1)
                TurnRound = "Red";
            else TurnRound = "Black";
        }

        /// <summary>
        /// 将可移动的点颜色改成蓝色
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public static void SetThePosiibleMovePointToBlue(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            chess.PossibleMove(row, col);
            void SetBlue()
            {
                List<int[]> list = chess.possibleMovePointList;
                foreach (int[] index in list)
                {
                    Board.board[index[0], index[1]].SetColor("Blue");
                }
            }
            switch (chess.GetName())
            {
                case "车":
                    SetBlue();
                    break;

                case "马":
                    SetBlue();
                    break;

                case "象":
                    SetBlue();
                    break;

                case "士":
                    SetBlue();
                    break;

                case "将":
                case "帅":
                    SetBlue();
                    break;

                case "炮":
                    SetBlue();
                    break;

                case "卒":
                case "兵":
                    SetBlue();
                    break;
            }
        }

        public static int[] ConvertIndex(string strInput)
        {
            int[] coordinate = new int[2];
            coordinate[0] = Convert.ToInt32((strInput.Split(' '))[0]) * 2;
            coordinate[1] = Convert.ToInt32((strInput.Split(' '))[1]) * 2;
            return coordinate;
        }
    }
}