void Main()
{
	MineSweeper m = new MineSweeper(10,12);
	m.Show();
	m.Reset(90);
	m.Show();
}

class MineSweeper
{
    bool [,] board;
    bool [,] played;
    int bombCount = 0;
	readonly int rows;
	readonly int columns;
    Random rand;
    internal enum SquareState {
        Invalid = -1,
        None = 0,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Bomb = 100
    }
	
	internal void Show()
	{
		this.board.Dump();
	}

    internal MineSweeper(int rows, int columns)
    {
        board = new bool [rows,columns];
        played = new bool [rows,columns];
        this.rows = rows;
        this.columns = columns;
        this.bombCount = 0;
        this.rand = new Random();
        Reset(0);
    }

    internal void Reset(int bombCount)
    {
        if (bombCount > rows * columns) 
        {        
            throw new ArgumentException("more bombs than board allows");
        }
        this.bombCount = 0;
        for  (int i =0; i < rows; i++)
            for (int j=0; j < columns; j++)
        {
            board[i,j] = false;
            played[i,j] = false;
            // place bomb with probability bombCount/(rows*columns)
            int spotsLeft = rows*columns - (i*columns + j);
            int bombsLeft = bombCount - this.bombCount;
			if (bombsLeft == 0)
			{
				continue;
			}
            double p = ((double)bombsLeft)/spotsLeft;
			double r = ((double)rand.Next())/int.MaxValue;
            if (r < p || (bombsLeft == spotsLeft))
            {
                board[i,j] = true;
				++this.bombCount;
            }
        }
    }
            
    internal SquareState Click(int row, int col)
    {
        if (row < 0 || row >= rows || col < 0 || col >= columns)
        {
            return SquareState.Invalid;
        }
        if (played[row,col])
        {
            return SquareState.Invalid;
        }
        played[row,col] = true;
        if (board[row,col])
        {
            return SquareState.Bomb;
        }
        int i=0, j= 0, neighbors = 0;
        for (i= row > 0 ? row - 1 : row; i <= row+1 && i < rows; i++)
        {
            for (j = col > 0? col -1: col; j <= col+1 && j < columns; j++)
            {
                if (board[i,j])
                {
                    ++neighbors;
                }

            }
        }
        return (SquareState) neighbors;
    }
}