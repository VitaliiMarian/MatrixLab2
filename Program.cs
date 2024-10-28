using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding=Encoding.UTF8;
        try
        {
            // Введення користувачем першої матриці
            Console.WriteLine("Введіть першу матрицю (елементи в рядках через пробіл, рядки розділяти Enter):");
            string[] input1 = ReadMatrixInput();
            MyMatrix matrix1 = new MyMatrix(input1);

            // Виведення першої матриці
            Console.WriteLine("Перша матриця:");
            Console.WriteLine(matrix1.ToString());

            // Введення користувачем другої матриці
            Console.WriteLine("\nВведіть другу матрицю (елементи в рядках через пробіл, рядки розділяти Enter):");
            string[] input2 = ReadMatrixInput();
            MyMatrix matrix2 = new MyMatrix(input2);

            // Виведення другої матриці
            Console.WriteLine("Друга матриця:");
            Console.WriteLine(matrix2.ToString());

            // Додавання матриць
            if (matrix1.GetHeight() == matrix2.GetHeight() && matrix1.GetWidth() == matrix2.GetWidth())
            {
                MyMatrix sumMatrix = matrix1 + matrix2;
                Console.WriteLine("\nРезультат додавання:");
                Console.WriteLine(sumMatrix.ToString());
            }
            else
            {
                Console.WriteLine("\nНеможливо додати матриці різного розміру.");
            }

            // Множення матриць
            if (matrix1.GetWidth() == matrix2.GetHeight())
            {
                MyMatrix productMatrix = matrix1 * matrix2;
                Console.WriteLine("\nРезультат множення:");
                Console.WriteLine(productMatrix.ToString());
            }
            else
            {
                Console.WriteLine("\nНеможливо помножити матриці (кількість стовпців першої матриці має дорівнювати кількості рядків другої матриці).");
            }

            // Транспонування першої матриці
            MyMatrix transposedMatrix1 = matrix1.GetTransponedCopy();
            Console.WriteLine("\nТранспонована перша матриця:");
            Console.WriteLine(transposedMatrix1.ToString());

            // Транспонування другої матриці
            MyMatrix transposedMatrix2 = matrix2.GetTransponedCopy();
            Console.WriteLine("\nТранспонована друга матриця:");
            Console.WriteLine(transposedMatrix2.ToString());

            // Транспонування першої матриці безпосередньо
            matrix1.TransponeMe();
            Console.WriteLine("\nПерша матриця після транспонування (in-place):");
            Console.WriteLine(matrix1.ToString());

        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }

    // Метод для читання матриці з консолі
    static string[] ReadMatrixInput()
    {
        var matrixInput = new System.Collections.Generic.List<string>();
        string inputLine;
        Console.WriteLine("Введіть матрицю (порожній рядок для завершення вводу):");

        while (!string.IsNullOrWhiteSpace(inputLine = Console.ReadLine()))
        {
            matrixInput.Add(inputLine);
        }

        return matrixInput.ToArray();
    }
}