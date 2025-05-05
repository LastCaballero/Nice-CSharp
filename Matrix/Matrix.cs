using System;

using System.Threading;



class Matrix
{
    Random Generator;
    int Count;
    public Matrix()
    {
        Generator = new Random();
        Count = Console.WindowWidth / 3;
        StartMatrix();
    }

    void StartMatrix()
    {
        while (true)
        {
            Console.WriteLine(GenerateHexLine(Generator, Count));
            Thread.Sleep(200);
        }
    }

    string GenerateHexLine(Random random, int count)
    {
        string hexLine = "";
        for (int i = 0; i < count; i++)
        {
            hexLine += random.Next(0, 256).ToString("X2") + " ";
        }
        return hexLine;
    }
}

class Start
{
    static void Main(string[] args)
    {
        new Matrix();
    }
}
