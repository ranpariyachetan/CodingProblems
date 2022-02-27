using System.Collections.Generic;

namespace CodingProblems.Sudoku
{
    public class Sudoku
    {
        private static int count = 0;
        public static bool IsValidSudoku(char[][] board)
        {
            var set = new HashSet<char>();
            for (var i = 0; i < 9; i++)
            {
                count++;
                var b = CheckDuplicateInRow(board[i]);

                if (!b)
                    return false;

                b = CheckDuplicateInColumn(board, i);

                if (!b)
                    return false;
            }

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    count++;
                    var b = CheckDuplicateInBox(board, i - i % 3, j - j % 3);

                    if (!b)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CheckDuplicateInRow(char[] arr)
        {
            var set = new HashSet<char>();

            for (var i = 0; i < arr.Length; i++)
            {
                count++;
                if (arr[i] == '.')
                    continue;
                if (set.Contains(arr[i]))
                {
                    return false;

                }
                else
                {
                    set.Add(arr[i]);
                }
            }

            return true;
        }

        private static bool CheckDuplicateInColumn(char[][] arr, int colIndex)
        {
            var set = new HashSet<char>();

            for (var i = 0; i < arr.Length; i++)
            {
                count++;
                if (arr[i][colIndex] == '.')
                    continue;
                if (set.Contains(arr[i][colIndex]))
                {
                    return false;
                }
                else
                {
                    set.Add(arr[i][colIndex]);
                }
            }

            return true;
        }

        private static bool CheckDuplicateInBox(char[][] board, int rowStart, int colStart)
        {
            var set = new HashSet<char>();

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    count++;
                    var c = board[i + rowStart][j + colStart];

                    if (set.Contains(c))
                    {
                        return false;
                    }
                    if (c != '.')
                    {
                        set.Add(c);
                    }
                }
            }

            return true;
        }


        public static bool IsValidSudokuV2(char[][] board)
        {
            var set = new HashSet<string>();

            for(var i = 0;i<board.Length;i++)
            {
                for(var j = 0;j<board[i].Length;j++)
                {
                    var ch = board[i][j];
                    var r = "r" + ch.ToString() + i.ToString();
                    var c = "c" + ch.ToString() + j.ToString();
                    var b = "c" + ch.ToString() + (i / 3) * 3 + (j/3);
                    if(ch != '.')
                    {
                        
                            if(set.Contains(r) || set.Contains(c) || set.Contains(b))
                            {
                                return false;
                            }
                        
                        else
                        {
                            set.Add(r);
                            set.Add(c);
                            set.Add(b);
                        }
                    }
                }
            }

            return true;
        }
        public static void TestValidateSudoku()
        {
            var board = new char[][] {


new char[] {'8','3','.','.','7','.','.','.','.'},
new char[] {'6','.','.','1','9','5','.','.','.'},
new char[] {'.','9','8','.','.','.','.','6','.'},
new char[] {'8','.','.','.','6','.','.','.','3'},
new char[] {'4','.','.','8','.','3','.','.','1'},
new char[] {'7','.','.','.','2','.','.','.','6'},
new char[] {'.','6','.','.','.','.','2','8','.'},
new char[] {'.','.','.','4','1','9','.','.','5'},
new char[] {'.','.','.','.','8','.','.','7','9'}
            };

            var res = IsValidSudokuV2(board);

            Console.WriteLine(res);
            Console.WriteLine(count);
        }
    }
}