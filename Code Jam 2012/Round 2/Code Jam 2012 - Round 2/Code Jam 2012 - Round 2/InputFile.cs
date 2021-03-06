﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace SwingingWild
{
    class InputFile
    {
        public InputFile(string filePath)
        {
            using (var file = File.OpenText(filePath))
            {
                var testCaseCount = int.Parse(file.ReadLine());

                testCases = new List<TestCase>(testCaseCount);

                for (var i = 0; i < testCaseCount; i++)
                {
                    var N = ReadInts(file)[0];
                    var vines = new Vine[N];
                    for (var j = 0; j < N; j++)
                    {
                        var dl = ReadInts(file);
                        vines[j] = new Vine(dl[0], dl[1]);
                    }

                    var D = ReadInts(file)[0];

                    testCases.Add(new TestCase(D, vines));
                }
            }
        }

        private readonly List<TestCase> testCases;

        public IEnumerable<TestCase> TestCases
        {
            get { return testCases; }
        }

        private static string[] ReadStrings(TextReader file)
        {
            return file.ReadLine().Split(' ');
        }

        private static int[] ReadInts(TextReader file)
        {
            return ReadStrings(file).Select(int.Parse).ToArray();
        }

        private static double[] ReadDoubles(TextReader file)
        {
            var line = file.ReadLine();
            return ReadStrings(file).Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        private int[,] ReadIntGrid(TextReader file, int rowCount, int colCount)
        {
            int[,] grid = new int[rowCount, colCount];

            for (var i = 0; i < rowCount; i++)
            {
                var row = ReadInts(file);
                Debug.Assert(row.Length == colCount);
                for (var j = 0; j < colCount; j++)
                {
                    grid[i, j] = row[j];
                }
            }

            return grid;
        }
    }
}
