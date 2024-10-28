using System;

public partial class MyMatrix
{
    // Оператор + для додавання двох матриць
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.Height != b.Height || a.Width != b.Width)
        {
            throw new ArgumentException("Matrices must have the same dimensions");
        }

        var result = new double[a.Height, a.Width];

        for (int i = 0; i < a.Height; i++)
        {
            for (int j = 0; j < a.Width; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }

        return new MyMatrix(result);
    }

    // Оператор * для множення двох матриць
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.Width != b.Height)
        {
            throw new ArgumentException("Invalid matrix dimensions for multiplication");
        }

        var result = new double[a.Height, b.Width];

        for (int i = 0; i < a.Height; i++)
        {
            for (int j = 0; j < b.Width; j++)
            {
                for (int k = 0; k < a.Width; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        return new MyMatrix(result);
    }

    // Метод для отримання транспонованого масиву
    private double[,] GetTransponedArray()
    {
        var transposed = new double[Width, Height];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                transposed[j, i] = elements[i, j];
            }
        }

        return transposed;
    }

    // Метод для отримання транспонованої копії
    public MyMatrix GetTransponedCopy()
    {
        return new MyMatrix(GetTransponedArray());
    }

    // Метод для транспонування матриці
    public void TransponeMe()
    {
        elements = GetTransponedArray();
    }
}