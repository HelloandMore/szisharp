using System;
using System.Threading;

class Program
{
	// Define the game board size
	const int Width = 10;
	const int Height = 20;

	// Define the game board
	static bool[,] board = new bool[Width, Height];

	// Define the current falling block
	static int blockX = Width / 2;
	static int blockY = 0;
	static bool[,] currentBlock;

	// Define possible block shapes
	static bool[,] blockI = { { true, true, true, true } };
	static bool[,] blockJ = { { true, false, false }, { true, true, true } };
	static bool[,] blockL = { { false, false, true }, { true, true, true } };
	static bool[,] blockO = { { true, true }, { true, true } };
	static bool[,] blockS = { { false, true, true }, { true, true, false } };
	static bool[,] blockT = { { false, true, false }, { true, true, true } };
	static bool[,] blockZ = { { true, true, false }, { false, true, true } };

	// Define the current score
	static int score = 0;

	// Random number generator for selecting block shapes
	static Random random = new Random();

	// Check if the current block can move down
	static bool CanMoveDown()
	{
		for (int x = 0; x < currentBlock.GetLength(0); x++)
		{
			for (int y = 0; y < currentBlock.GetLength(1); y++)
			{
				if (currentBlock[x, y])
				{
					int boardX = blockX + x;
					int boardY = blockY + y + 1;

					if (boardY >= Height || (boardY >= 0 && board[boardX, boardY]))
						return false;
				}
			}
		}
		return true;
	}

	// Move the current block down
	static void MoveDown()
	{
		if (CanMoveDown())
		{
			blockY++;
		}
		else
		{
			// Merge the current block with the board
			for (int x = 0; x < currentBlock.GetLength(0); x++)
			{
				for (int y = 0; y < currentBlock.GetLength(1); y++)
				{
					if (currentBlock[x, y])
					{
						board[blockX + x, blockY + y] = true;
					}
				}
			}

			// Check for completed rows
			for (int y = 0; y < Height; y++)
			{
				bool isRowFull = true;
				for (int x = 0; x < Width; x++)
				{
					if (!board[x, y])
					{
						isRowFull = false;
						break;
					}
				}

				// If a row is full, remove it and increment the score
				if (isRowFull)
				{
					for (int yy = y; yy > 0; yy--)
					{
						for (int x = 0; x < Width; x++)
						{
							board[x, yy] = board[x, yy - 1];
						}
					}
					score += 100;
				}
			}

			// Check if game over
			for (int x = 0; x < Width; x++)
			{
				if (board[x, 0])
				{
					Console.Clear();
					Console.WriteLine("Game Over!");
					Console.WriteLine("Score: " + score);
					return;
				}
			}

			// Generate a new random block
			switch (random.Next(7))
			{
				case 0: currentBlock = blockI; break;
				case 1: currentBlock = blockJ; break;
				case 2: currentBlock = blockL; break;
				case 3: currentBlock = blockO; break;
				case 4: currentBlock = blockS; break;
				case 5: currentBlock = blockT; break;
				case 6: currentBlock = blockZ; break;
			}

			blockX = Width / 2;
			blockY = 0;
		}
	}

	// Main game loop
	static void Main(string[] args)
	{
		Console.CursorVisible = false;

		while (true)
		{
			// Clear the console and draw the board
			Console.Clear();
			DrawBoard();
			Thread.Sleep(200); // Adjust game speed

			// Handle user input
			if (Console.KeyAvailable)
			{
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.LeftArrow && blockX > 0)
					blockX--;
				else if (key.Key == ConsoleKey.RightArrow && blockX < Width - currentBlock.GetLength(0))
					blockX++;
				else if (key.Key == ConsoleKey.DownArrow)
					MoveDown();
				else if (key.Key == ConsoleKey.UpArrow)
					RotateBlock();
			}

			// Move the current block down
			MoveDown();
		}
	}

	// Draw the game board
	static void DrawBoard()
	{
		for (int y = 0; y < Height; y++)
		{
			for (int x = 0; x < Width; x++)
			{
				Console.Write(board[x, y] ? "#" : " ");
			}
			Console.WriteLine();
		}
		Console.WriteLine("Score: " + score);
	}

	// Rotate the current block
	static void RotateBlock()
	{
		int sizeX = currentBlock.GetLength(0);
		int sizeY = currentBlock.GetLength(1);
		bool[,] rotatedBlock = new bool[sizeY, sizeX];

		for (int x = 0; x < sizeX; x++)
		{
			for (int y = 0; y < sizeY; y++)
			{
				rotatedBlock[y, sizeX - 1 - x] = currentBlock[x, y];
			}
		}

		if (blockX + rotatedBlock.GetLength(0) <= Width && blockY + rotatedBlock.GetLength(1) <= Height)
		{
			currentBlock = rotatedBlock;
		}
	}
}
