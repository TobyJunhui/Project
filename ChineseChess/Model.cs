using System.Collections.Generic;

namespace ChineseChess
{
    public class Board
    {
        private readonly int col = 17;
        private readonly int row = 19;
        public static Chess[,] board;

        public Board()
        {
            board = new Chess[this.row, this.col];
            //初始化棋盘
            for (int row = 0; row < this.row; row++)
            {
                for (int col = 0; col < this.col; col++)
                {
                    if (row == 0 || (row == this.row - 1))
                    {
                        //车马……
                        switch (col)
                        {
                            case 0:
                            case 16:
                                if (row < (this.row / 2))
                                {
                                    board[row, col] = new Car("Black");
                                }
                                else
                                {
                                    board[row, col] = new Car("Red");
                                }

                                break;

                            case 2:
                            case 14:
                                if (row < (this.row / 2))
                                {
                                    board[row, col] = new Horse("Black");
                                }
                                else
                                {
                                    board[row, col] = new Horse("Red");
                                }

                                break;

                            case 4:
                            case 12:
                                if (row < (this.row / 2))
                                {
                                    board[row, col] = new Elephant("Black");
                                }
                                else
                                {
                                    board[row, col] = new Elephant("Red");
                                }

                                break;

                            case 6:
                            case 10:
                                if (row < (this.row / 2))
                                {
                                    board[row, col] = new Samurai("Black");
                                }
                                else
                                {
                                    board[row, col] = new Samurai("Red");
                                }

                                break;

                            case 8:
                                if (row < (this.row / 2))
                                {
                                    board[row, col] = new General("Black");
                                }
                                else
                                {
                                    board[row, col] = new General("Red");
                                }

                                break;

                            default:
                                board[row, col] = new Blank();
                                break;
                        }
                    }
                    else if ((row == 4 || (row == this.row - 5)) && (col == 2 || col == 14))
                    {
                        //炮
                        if (row < (this.row / 2))
                        {
                            board[row, col] = new Cannon("Black");
                        }
                        else
                        {
                            board[row, col] = new Cannon("Red");
                        }
                    }
                    else if ((row == 6 || (row == this.row - 7)) && (col % 4 == 0))
                    {
                        //卒
                        if (row < (this.row / 2))
                        {
                            board[row, col] = new Soldier("Black");
                        }
                        else
                        {
                            board[row, col] = new Soldier("Red");
                        }
                    }
                    else
                    {
                        board[row, col] = new Blank();
                    }
                }
            }
        }

        public int GetRow()
        {
            return this.row;
        }

        public int GetCol()
        {
            return this.col;
        }
    }

    public abstract class Chess
    {
        private string color;
        private readonly string defaultColor;

        /// <summary>
        /// 存储棋子可以移动的点
        /// </summary>
        public List<int[]> possibleMovePointList = new List<int[]> { };

        public Chess(string color)
        {
            this.defaultColor = color;
            this.color = color;
            ;
        }

        /// <summary>
        /// Check the next point of the selected chess can move or not and show it in Blue color.
        /// </summary>
        /// <param name="chess">The next point of the selected point.</param>

        public void SetColor(string color)
        {
            this.color = color;
        }

        public string GetColor()
        {
            return this.color;
        }

        public string GetDefaultColor()
        {
            return this.defaultColor;
        }

        public virtual string GetName()
        {
            return " ";
        }

        /// <summary>
        /// Find all the point that the selected chess can move can show it in blue.
        /// </summary>
        /// <param name="row">the horizontal coordinate of the piece in the board </param>
        /// <param name="col">the vertical coordinate of the piece in the board</param>
        public virtual void PossibleMove(int row, int col)
        {
        }
    }

    public class Car : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Car(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            return "车";
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;

            for (int i = row; i < Board.board.GetLength(0); i += 2)
            {
                chess = Board.board[i, col];

                if (i != row)
                {
                    if (!(this.GetColor().Equals(chess.GetColor())))
                    {
                        possibleMovePointList.Add(new int[] { i, col });
                        if (!(chess.GetDefaultColor().Equals("White")))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
            for (int i = row; i >= 0; i -= 2)
            {
                chess = Board.board[i, col];
                if (i != row)
                {
                    if (!(this.GetColor().Equals(chess.GetColor())))
                    {
                        possibleMovePointList.Add(new int[] { i, col });
                        if (!(chess.GetDefaultColor().Equals("White")))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            for (int i = col; i >= 0; i -= 2)
            {
                chess = Board.board[row, i];
                if (i != col)
                {
                    if (!(this.GetColor().Equals(chess.GetColor())))
                    {
                        possibleMovePointList.Add(new int[] { row, i });
                        if (!(chess.GetDefaultColor().Equals("White")))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            for (int i = col; i < Board.board.GetLength(1); i += 2)
            {
                chess = Board.board[row, i];
                if (i != col)
                {
                    if (!(this.GetColor().Equals(chess.GetColor())))
                    {
                        possibleMovePointList.Add(new int[] { row, i });
                        if (!(chess.GetDefaultColor().Equals("White")))
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public class Horse : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Horse(string color)
        : base(color)
        {
        }

        private void IsTheNextPointCanGo(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            //判断是否是友方棋子
            if (!(this.GetColor().Equals(chess.GetColor())))
            {
                //判断是‘空白’还是敌方棋子 并将其设为蓝色
                if (!(chess.GetColor().Equals("White")))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                }
                possibleMovePointList.Add(new int[] { row, col });
            }
        }

        public override string GetName()
        {
            return "马";
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;
            //先根据移动方式得到可能的落点 然后判断该点是否在棋盘内 接着再判断路径中间是否有其他棋子堵住路
            if ((row + 4 < Board.board.GetLength(0)) && (col + 2 < Board.board.GetLength(1)) && (Board.board[row + 2, col].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row + 4, col + 2];
                this.IsTheNextPointCanGo(row + 4, col + 2);
            }
            if ((row + 4 < Board.board.GetLength(0)) && (col - 2 >= 0) && (Board.board[row + 2, col].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row + 4, col - 2];
                this.IsTheNextPointCanGo(row + 4, col - 2);
            }

            if ((row - 4 >= 0) && (col + 2 < Board.board.GetLength(1)) && (Board.board[row - 2, col].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row - 4, col + 2];
                this.IsTheNextPointCanGo(row - 4, col + 2);
            }
            if ((row - 4 >= 0) && (col - 2 >= 0) && (Board.board[row - 2, col].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row - 4, col - 2];
                this.IsTheNextPointCanGo(row - 4, col - 2);
            }
            if ((row + 2 < Board.board.GetLength(0)) && (col - 4 >= 0) && (Board.board[row, col - 2].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row + 2, col - 4];
                this.IsTheNextPointCanGo(row + 2, col - 4);
            }
            if ((row - 2 >= 0) && (col - 4 >= 0) && (Board.board[row, col - 2].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row - 2, col - 4];
                this.IsTheNextPointCanGo(row - 2, col - 4);
            }

            if ((row + 2 < Board.board.GetLength(0)) && (col + 4 < Board.board.GetLength(1)) && (Board.board[row, col + 2].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row + 2, col + 4];
                this.IsTheNextPointCanGo(row + 2, col + 4);
            }
            if ((row - 2 >= 0) && (col + 4 < Board.board.GetLength(1)) && (Board.board[row, col + 2].GetDefaultColor().Equals("White")))
            {
                chess = Board.board[row - 2, col + 4];
                this.IsTheNextPointCanGo(row - 2, col + 4);
            }
        }
    }

    public class Elephant : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Elephant(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            return "象";
        }

        private void IsTheNextPointCanGo(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            //判断是否是友方棋子
            if (!(this.GetColor().Equals(chess.GetColor())))
            {
                //判断是‘空白’还是敌方棋子 并将其设为蓝色
                if (!(chess.GetColor().Equals("White")))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                }
                possibleMovePointList.Add(new int[] { row, col });
            }
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;
            //先判断是红/黑方 再根据移动方式得到可能的落点 然后判断该点是否自己地盘且没有超出棋盘 接着再判断路径中间是否有其他棋子堵住路
            if (this.GetColor().Equals("Black"))
            {
                if ((row + 4 < Board.board.GetLength(0) / 2) && (col + 4 <= (Board.board.GetLength(1))) && (Board.board[row + 2, col + 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row + 4, col + 4];
                    this.IsTheNextPointCanGo(row + 4, col + 4);
                }
                if ((row + 4 < Board.board.GetLength(0) / 2) && (col - 4 >= 0) && (Board.board[row + 2, col - 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row + 4, col - 4];
                    this.IsTheNextPointCanGo(row + 4, col - 4);
                }
                if ((row - 4 >= 0) && (col + 4 <= ((Board.board.GetLength(1)))) && (Board.board[row - 2, col + 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row - 4, col + 4];
                    this.IsTheNextPointCanGo(row - 4, col + 4);
                }
                if ((row - 4 >= 0) && (col - 4 >= 0) && (Board.board[row - 2, col - 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row - 4, col - 4];
                    this.IsTheNextPointCanGo(row - 4, col - 4);
                }
            }
            else if (this.GetColor().Equals("Red"))
            {
                if ((row + 4 < Board.board.GetLength(0)) && (col + 4 < (Board.board.GetLength(1))) && (Board.board[row + 2, col + 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row + 4, col + 4];
                    this.IsTheNextPointCanGo(row + 4, col + 4);
                }
                if ((row + 4 < Board.board.GetLength(0)) && (col - 4 >= 0) && (Board.board[row + 2, col - 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row + 4, col - 4];
                    this.IsTheNextPointCanGo(row + 4, col - 4);
                }
                if ((row - 4 >= Board.board.GetLength(0) / 2) && (col + 4 < (Board.board.GetLength(1))) && (Board.board[row - 2, col + 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row - 4, col + 4];
                    this.IsTheNextPointCanGo(row - 4, col + 4);
                }
                if ((row - 4 >= Board.board.GetLength(0) / 2) && (col - 4 >= 0) && (Board.board[row - 2, col - 2].GetDefaultColor().Equals("White")))
                {
                    chess = Board.board[row - 4, col - 4];
                    this.IsTheNextPointCanGo(row - 4, col - 4);
                }
            }
        }
    }

    public class Samurai : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Samurai(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            return "士";
        }

        private void IsTheNextPointCanGo(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            //判断是否是友方棋子
            if (!(this.GetColor().Equals(chess.GetColor())))
            {
                //判断是‘空白’还是敌方棋子 并将其设为蓝色
                if (!(chess.GetColor().Equals("White")))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                }
                possibleMovePointList.Add(new int[] { row, col });
            }
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;
            //先判断颜色方 然后判断根据移动方式给出的点是否可行
            if (this.GetColor().Equals("Black"))
            {
                if ((row + 2 <= 4) && (col + 2 <= 10))
                {
                    chess = Board.board[row + 2, col + 2];
                    this.IsTheNextPointCanGo(row + 2, col + 2);
                }
                if ((row + 2 <= 4) && (col - 2 >= 6))
                {
                    chess = Board.board[row + 2, col - 2];
                    this.IsTheNextPointCanGo(row + 2, col - 2);
                }
                if ((row - 2 >= 0) && (col + 1 <= 10))
                {
                    chess = Board.board[row - 2, col + 2];
                    this.IsTheNextPointCanGo(row - 2, col + 2);
                }
                if ((row - 2 >= 0) && (col - 2 >= 6))
                {
                    chess = Board.board[row - 2, col - 2];
                    this.IsTheNextPointCanGo(row - 2, col - 2);
                }
            }

            if (this.GetColor().Equals("Red"))
            {
                if ((row + 2 < Board.board.GetLength(0)) && (col + 2 < 10))
                {
                    chess = Board.board[row + 2, col + 2];
                    this.IsTheNextPointCanGo(row + 2, col + 2);
                }
                if ((row + 2 < Board.board.GetLength(0)) && (col - 2 >= 6))
                {
                    chess = Board.board[row + 2, col - 2];
                    this.IsTheNextPointCanGo(row + 2, col - 2);
                }
                if ((row - 2 >= (Board.board.GetLength(0) - 6)) && (col + 2 <= 10))
                {
                    chess = Board.board[row - 2, col + 2];
                    this.IsTheNextPointCanGo(row - 2, col + 2);
                }
                if ((row - 2 >= (Board.board.GetLength(0) - 6)) && (col - 2 >= 6))
                {
                    chess = Board.board[row - 2, col - 2];
                    this.IsTheNextPointCanGo(row - 2, col - 2);
                }
            }
        }
    }

    public class General : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public General(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            if (this.GetColor().Equals("Red"))
            {
                return "帅";
            }
            else
            {
                return "将";
            }
        }

        private void IsTheNextPointCanGo(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            //判断是否是友方棋子
            if (!(this.GetColor().Equals(chess.GetColor())))
            {
                //判断是‘空白’还是敌方棋子 并将其设为蓝色
                if (!(chess.GetColor().Equals("White")))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                }
                possibleMovePointList.Add(new int[] { row, col });
            }
        }

        //先判断颜色方 然后判断根据移动方式给出的点是否可行
        public override void PossibleMove(int row, int col)
        {
            dynamic chess;

            if (this.GetColor().Equals("Black"))
            {
                if (row + 2 <= 4)
                {
                    chess = Board.board[row + 2, col];
                    this.IsTheNextPointCanGo(row + 2, col);
                }
                if (col - 2 >= 6)
                {
                    chess = Board.board[row, col - 2];
                    this.IsTheNextPointCanGo(row, col - 2);
                }
                if (row - 2 >= 0)
                {
                    chess = Board.board[row - 2, col];
                    this.IsTheNextPointCanGo(row - 2, col);
                }
                if (col + 2 <= 10)
                {
                    chess = Board.board[row, col + 2];
                    this.IsTheNextPointCanGo(row, col + 2);
                }
            }
            if (this.GetColor().Equals("Red"))
            {
                if (row + 2 < Board.board.GetLength(0))
                {
                    chess = Board.board[row + 2, col];
                    this.IsTheNextPointCanGo(row + 2, col);
                }
                if (col - 2 >= 6)
                {
                    chess = Board.board[row, col - 2];
                    this.IsTheNextPointCanGo(row, col - 2);
                }
                if (row - 2 >= (Board.board.GetLength(0) - 6))
                {
                    chess = Board.board[row - 2, col];
                    this.IsTheNextPointCanGo(row - 2, col);
                }
                if (col + 2 <= 10)
                {
                    chess = Board.board[row, col + 2];
                    this.IsTheNextPointCanGo(row, col + 2);
                }
            }
        }
    }

    public class Cannon : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Cannon(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            return "炮";
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;
            string color = this.GetColor();
            bool haveMiddleChess = false;

            bool Moving(int row, int col)
            {
                //判断是否是能吃的敌方棋子 是的话将其设为蓝色
                if (!(chess.GetColor().Equals(color)) && (haveMiddleChess == true) && (!(chess.GetColor().Equals("White"))))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                    return true;
                }
                //判断是否为空格，否则将'有中间棋子'设为true
                if (chess.GetColor().Equals("White") && (haveMiddleChess != true))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                    return false;
                }
                else
                {
                    haveMiddleChess = true;
                    return false;
                }
            }

            for (int i = row; i < Board.board.GetLength(0); i += 2)
            {
                chess = Board.board[i, col];
                if (i != row)
                {
                    if (Moving(i, col))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            haveMiddleChess = false;
            for (int i = row; i >= 0; i -= 2)
            {
                chess = Board.board[i, col];
                if (i != row)
                {
                    if (Moving(i, col))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }

            haveMiddleChess = false;
            for (int i = col; i >= 0; i -= 2)
            {
                chess = Board.board[row, i];
                if (i != col)
                {
                    if (Moving(row, i))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            haveMiddleChess = false;
            for (int i = col; i < Board.board.GetLength(1); i += 2)
            {
                chess = Board.board[row, i];
                if (i != col)
                {
                    if (Moving(row, i))
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public class Soldier : Chess
    {
        public new List<int[]> possibleMovePointList = new List<int[]> { };

        public Soldier(string color)
        : base(color)
        {
        }

        public override string GetName()
        {
            if (this.GetColor().Equals("Red"))
            {
                return "兵";
            }
            else
            {
                return "卒";
            }
        }

        private void IsTheNextPointCanGo(int row, int col)
        {
            dynamic chess = Board.board[row, col];
            //判断是否是友方棋子
            if (!(this.GetColor().Equals(chess.GetColor())))
            {
                //判断是‘空白’还是敌方棋子 并将其设为蓝色
                if (!(chess.GetColor().Equals("White")))
                {
                    possibleMovePointList.Add(new int[] { row, col });
                }
                possibleMovePointList.Add(new int[] { row, col });
            }
        }

        public override void PossibleMove(int row, int col)
        {
            dynamic chess;

            //先判断颜色方 然后判断根据移动方式给出的点是否可行
            if (this.GetColor().Equals("Red"))
            {
                if (row >= (Board.board.GetLength(0) / 2))
                {
                    chess = Board.board[row - 2, col];

                    this.IsTheNextPointCanGo(row - 2, col);
                }
                else
                {
                    if (row - 2 >= 0)
                    {
                        chess = Board.board[row - 2, col];

                        this.IsTheNextPointCanGo(row - 2, col);
                    }
                    if (col - 2 >= 0)
                    {
                        chess = Board.board[row, col - 2];

                        this.IsTheNextPointCanGo(row, col - 2);
                    }
                    if (col + 2 < Board.board.GetLength(1))
                    {
                        chess = Board.board[row, col + 2];

                        this.IsTheNextPointCanGo(row, col + 2);
                    }
                }
            }
            if (this.GetColor().Equals("Black"))
            {
                if (row < (Board.board.GetLength(0) / 2))
                {
                    chess = Board.board[row + 2, col];

                    this.IsTheNextPointCanGo(row + 2, col);
                }
                else
                {
                    if (row + 2 < Board.board.GetLength(0))
                    {
                        chess = Board.board[row + 2, col];

                        this.IsTheNextPointCanGo(row + 2, col);
                    }
                    if (col - 2 >= 0)
                    {
                        chess = Board.board[row, col - 2];

                        this.IsTheNextPointCanGo(row, col - 2);
                    }
                    if (col + 2 < Board.board.GetLength(1))
                    {
                        chess = Board.board[row, col + 2];

                        this.IsTheNextPointCanGo(row, col + 2);
                    }
                }
            }
        }
    }

    public class Blank : Chess
    {
        private string name = "┼─";

        public Blank(string color = "White")
        : base(color)
        {
        }

        public override string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}