using System;

class Program
{
    static bool IsRowValid(int[,] board, int row, int value)
    {
        for (int col = 0; col < 9; col++)
        {
            if (board[row, col] == value)
            {
                return false;
            }
        }
        return true;
    }

    static bool IsColumnValid(int[,] board, int col, int value)
    {
        for (int row = 0; row < 9; row++)
        {
            if (board[row, col] == value)
            {
                return false;
            }
        }
        return true;
    }

    static void PrintBoard(int[,] board)
    {
        Console.Clear(); // Очистить консоль перед каждым выводом доски

        Console.WriteLine("┌────────┬──────────┬──────────┐");
        for (int row = 0; row < 9; row++)
        {
            if (row % 3 == 0 && row != 0)
            {
                Console.WriteLine("├────────┼──────────┼──────────┤");
            }
            for (int col = 0; col < 9; col++)
            {
                if (col % 3 == 0 && col != 0)
                {
                    Console.Write("│ ");
                }
                Console.Write(board[row, col] == 0 ? "   " : $" {board[row, col]} ");
            }
            Console.WriteLine("│");
        }
        Console.WriteLine("└────────┴──────────┴──────────┘");
    }

    static void Main()
    {
        int[,] board = new int[9, 9]; // Создаем пустую доску 9x9

        // Заполняем доску каким-то начальным состоянием (0 обозначает пустую ячейку)
        int[,] initialBoard = {
            {5, 3, 0, 0, 7, 0, 0, 0, 0},
            {6, 0, 0, 1, 9, 5, 0, 0, 0},
            {0, 9, 8, 0, 0, 0, 0, 6, 0},
            {8, 0, 0, 0, 6, 0, 0, 0, 3},
            {4, 0, 0, 8, 0, 3, 0, 0, 1},
            {7, 0, 0, 0, 2, 0, 0, 0, 6},
            {0, 6, 0, 0, 0, 0, 2, 8, 0},
            {0, 0, 0, 4, 1, 9, 0, 0, 5},
            {0, 0, 0, 0, 8, 0, 0, 7, 9}
        };

        // Копируем начальное состояние на доску
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                board[i, j] = initialBoard[i, j];
            }
        }

        while (true)
        {
            PrintBoard(board); // Выводим текущее состояние доски

            // Здесь можно добавить код для ввода значений игроком и проверки их правильности

            Console.WriteLine("Введите координаты и значение (например, 3 4 7), или 'exit' для завершения:");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            string[] parts = input.Split(' ');
            if (parts.Length == 3)
            {
                int row = int.Parse(parts[0]) - 1;
                int col = int.Parse(parts[1]) - 1;
                int value = int.Parse(parts[2]);

                // Проверяем, можно ли поставить значение в данную ячейку
                if (IsRowValid(board, row, value) && IsColumnValid(board, col, value))
                {
                    if (board[row, col] != 0)
                    {
                        Console.WriteLine("Ошибка: Число уже присутствует в данной ячейке.");
                    }
                    else
                    {
                        board[row, col] = value;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Число уже присутствует в строке или столбце.");
                }
            }
        }

        Console.WriteLine("Игра завершена.");
    }
}