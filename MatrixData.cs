using System;

public partial class MyMatrix
{
    private double[,] elements;

    // Конструктор з двомірного масиву
    public MyMatrix(double[,] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("Invalid array");
        }

        int height = array.GetLength(0);
        int width = array.GetLength(1);
        elements = new double[height, width];

        Array.Copy(array, elements, array.Length);
    }

    // Конструктор з "зубчастого" масиву
    public MyMatrix(double[][] jaggedArray)
    {
        if (jaggedArray == null || jaggedArray.Length == 0)
        {
            throw new ArgumentException("Invalid jagged array");
        }

        int width = jaggedArray[0].Length;

        foreach (var row in jaggedArray)
        {
            if (row.Length != width)
            {
                throw new ArgumentException("Jagged array is not rectangular");
            }
        }

        elements = new double[jaggedArray.Length, width];

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            Array.Copy(jaggedArray[i], elements, width);
        }
    }

    // Конструктор з масиву рядків
    public MyMatrix(string[] rows)
    {
        if (rows == null || rows.Length == 0)
        {
            throw new ArgumentException("Invalid rows array");
        }

        int width = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
        for (int i = 1; i < rows.Length; i++)
        {
            if (rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != width)
            {
                throw new ArgumentException("Rows array is not rectangular");
            }
        }

        elements = new double[rows.Length, width];

        for (int i = 0; i < rows.Length; i++)
        {
            var values = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < width; j++)
            {
                elements[i, j] = double.Parse(values[j]);
            }
        }
    }

    // Конструктор з рядка
    public MyMatrix(string matrixString)
    {
        if (string.IsNullOrWhiteSpace(matrixString))
        {
            throw new ArgumentException("Invalid matrix string");
        }

        var rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        int width = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

        foreach (var row in rows)
        {
            if (row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length != width)
            {
                throw new ArgumentException("Matrix string is not rectangular");
            }
        }

        elements = new double[rows.Length, width];

        for (int i = 0; i < rows.Length; i++)
        {
            var values = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < width; j++)
            {
                elements[i, j] = double.Parse(values[j]);
            }
        }
    }

    // Властивості Height та Width
    public int Height => elements.GetLength(0);
    public int Width => elements.GetLength(1);

    // Getter для кількості рядків
    public int GetHeight() => Height;

    // Getter для кількості стовпців
    public int GetWidth() => Width;

    // Індексатор
    public double this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
                throw new IndexOutOfRangeException("Index out of range");
            return elements[row, col];
        }
        set
        {
            if (row < 0 || row >= Height || col < 0 || col >= Width)
                throw new IndexOutOfRangeException("Index out of range");
            elements[row, col] = value;
        }
    }

    // Getter та Setter для окремого елемента
    public double GetElement(int row, int col) => this[row, col];
    public void SetElement(int row, int col, double value) => this[row, col] = value;

    // Перевизначення ToString()
    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                result += elements[i, j] + "\t";
            }
            result += Environment.NewLine;
        }
        return result.Trim();
    }
}