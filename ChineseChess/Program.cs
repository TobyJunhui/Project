using System;

namespace ChineseChess
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool gameOver = false;
            Board board = new Board();
            int FirstInput_row;
            int FirstInput_col;
            int SecondInput_row;
            int SecondInput_col;

            while (!gameOver)
            {
                try
                {
                    //第一次选择
                    do
                    {
                        //递增回合数
                        Controller.UpdateTheTurnRound();
                        //展示棋盘
                        View.DisplayBoard(board);
                        //如果之前输入坐标有误 则弹出提示语
                        if (Controller.IndexIsWrong)
                        {
                            View.ShowTips($"\n  You should choose a {Controller.TurnRound} chess!!!!!");
                            Controller.IndexIsWrong = false;
                        }
                        //要求用户输入选择棋子的坐标
                        View.ShowTips($"\nInput which one {Controller.TurnRound} chess you choose.(row col):");

                        int[] index = Controller.ConvertIndex(Console.ReadLine());
                        FirstInput_row = index[0];
                        FirstInput_col = index[1];

                        if (!(Board.board[FirstInput_row, FirstInput_col].GetColor().Equals("White")) && (Board.board[FirstInput_row, FirstInput_col].GetColor().Equals(Controller.TurnRound)))
                        {
                            //显示棋子能走的方位
                            Controller.SetThePosiibleMovePointToBlue(FirstInput_row, FirstInput_col);
                            Console.Clear();
                            View.DisplayBoard(board);
                            //View.ShowBluePoints(board, FirstInput_row, FirstInput_col);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Controller.TurnRoundNums--;
                            Controller.IndexIsWrong = true;
                            continue;
                        }
                    } while (true);
                }
                catch (Exception)
                {
                    //防止输入格式有误直接导致程序停止 则提示用户重新输入
                    Console.Clear();
                    Controller.IndexIsWrong = true;
                    Controller.TurnRoundNums--;
                    continue;
                }

                //第二次选择
                try
                {
                    do
                    {
                        //要求用户输入坐标
                        View.ShowTips("\nWhich blue point you want to move?(row col)" +
                                    $" or you can choose another {Controller.TurnRound} chess.");

                        int[] index = Controller.ConvertIndex(Console.ReadLine());
                        SecondInput_row = index[0];
                        SecondInput_col = index[1];

                        //检测输入的坐标是否为可选方位
                        if (Board.board[SecondInput_row, SecondInput_col].GetColor().Equals("Blue"))
                        {
                            //检测将要被吃的棋子是否为’将/帅‘
                            if (Board.board[SecondInput_row, SecondInput_col].GetName().Equals("将") || Board.board[SecondInput_row, SecondInput_col].GetName().Equals("帅"))
                                gameOver = true;

                            //实现移动效果 将原来位置设置为空 如果要实现悔棋功能 可从此处入手
                            Board.board[SecondInput_row, SecondInput_col] = Board.board[FirstInput_row, FirstInput_col];
                            Board.board[FirstInput_row, FirstInput_col] = new Blank();
                            //还原棋盘 消除蓝色
                            Controller.ResetBoardToDefaultColor();
                            break;
                        }
                        //如果输入的不是蓝色点位 而是其它同色棋子 表明用户重新选择
                        else if (Board.board[SecondInput_row, SecondInput_col].GetColor().Equals(Controller.TurnRound))
                        {
                            //先消除蓝色点 再更根据用户输入展示新的蓝色点
                            Controller.ResetBoardToDefaultColor();
                            Controller.SetThePosiibleMovePointToBlue(SecondInput_row, SecondInput_col);
                            Console.Clear();
                            View.DisplayBoard(board);
                            //View.ShowBluePoints(board, SecondInput_row, SecondInput_col);
                            FirstInput_row = SecondInput_row;
                            FirstInput_col = SecondInput_col;
                            continue;
                        }
                        else
                        {
                            Console.Clear();
                            View.DisplayBoard(board);
                            View.ShowTips($"\n  You should choose a blue point!!!!!");
                            continue;
                        }
                    } while (true);
                    Console.Clear();
                }
                catch (Exception)
                { }
            }
            View.GameOver();
        }
    }
}