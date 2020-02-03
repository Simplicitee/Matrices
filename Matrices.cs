using System;
using System.Collections.Generic;
using VectorSpace;
using MatrixSpace;

public class Matrices {

    static Dictionary<string, Matrix> map;
    static void Main() {
        map = new Dictionary<string, Matrix>();
        string input = "";

        while(input != "exit") {
            Console.Write("cmd> ");
            input = Console.ReadLine().ToLower();
            Console.WriteLine();
            string[] args = input.Split(' ');
            if (args.Length < 1) {
                continue;
            }

            if (args[0].Equals("help")) {
                Console.WriteLine("- Commands -");
                Console.WriteLine("help - this page");
                Console.WriteLine("info <matrix> - info about a matrix");
                Console.WriteLine("list - list defined matrices");
                Console.WriteLine("define <matrix> [<matrix>*<matrix>] - define a new matrix [optionally, define the matrix as a product of two other matrices]");
                Console.WriteLine("exit - leave program");
            } else if (args[0].Equals("define")) {
                if (args.Length == 2) {
                    defineMatrix(args[1]);
                } else if (args.Length == 3) {
                    if (!args[2].Contains("*")) {
                        Console.WriteLine("Unknown arg given!");
                        continue;
                    }

                    string[] operands = args[2].Split('*');
                    if (operands.Length != 2) {
                        Console.WriteLine("Only multiply 2 matrices!");
                        continue;
                    }

                    Matrix a, b;
                    if (!map.TryGetValue(operands[0], out a)) {
                        Console.WriteLine("Unknown matrix: " + operands[0]);
                        continue;
                    } else if (!map.TryGetValue(operands[1], out b)) {
                        Console.WriteLine("Unknown matrix: " + operands[1]);
                        continue;
                    }

                    Matrix c = a.multiply(b);
                    map.Add(args[1], c);
                    Console.WriteLine("Matrix " + args[1] + " defined as " + args[2] + "!");
                }
            } else if (args[0].Equals("list") && args.Length == 1) {
                Console.WriteLine("Defined Matrices:");
                Matrix a;
                foreach(string mat in map.Keys) {
                    map.TryGetValue(mat, out a);
                    Console.WriteLine(mat + " - " + a.getOrder());
                }
            } else if (args[0].Equals("info") && args.Length == 2) {
                Matrix a;
                if (!map.TryGetValue(args[1], out a)) {
                    Console.WriteLine("Unknown matrix: " + args[1]);
                    continue;
                }

                string digis = getMaxDigits(a);

                Console.WriteLine(a.getOrder());
                for (int i = 0; i < a.getRows(); i++) {
                    Console.Write("[ ");
                    for (int j = 0; j < a.getColumns(); j++) {
                        string s = a.get(i, j).ToString();
                        if (s.Length > digis.Length) {
                            s = s.Substring(0, digis.Length);
                        }
                        Console.Write(Fill(digis, s) + " ");
                    }
                    Console.WriteLine("]");
                }
            }

            Console.WriteLine();
        }
    }

    static string Fill(string s, string fill) {
        char[] ss = s.ToCharArray();
        for (int i = 0; i < fill.Length; i++) {
            ss[ss.Length - (i + 1)] = fill[fill.Length - (i + 1)];
        }

        return new string(ss);
    }

    static string getMaxDigits(Matrix m) {
        string digi = "";
        int highest = 0;
        int max = 6;
        for (int i = 0; i < m.getRows(); i++) {
            for (int j = 0; j < m.getColumns(); j++) {
                string s = m.get(i, j).ToString();
                int l = s.Length;
                if (l >= max) {
                    highest = max;
                    break;
                } else if (l > highest) {
                    highest = l;
                }
            }

            if (highest == max) {
                break;
            }
        }

        for (int i = 0; i < highest; i++) {
            digi += " ";
        }
        
        return digi;
    }

    static void defineMatrix(string mat) {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        Matrix m = new Matrix(rows, cols);
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                Console.Write("Enter value for m" + i + j + ": ");
                double val = double.Parse(Console.ReadLine());
                m.set(i, j, val);
            }
        }

        Console.WriteLine("Matrix " + mat + " defined!");
        map.Add(mat, m);
    }
}