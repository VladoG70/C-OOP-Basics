﻿using System;
using System.Collections.Generic;

namespace BashSoft
    {
    public static class OutputWriter
        {
        public static void WriteMessage(string message)
            {
            Console.Write(message);
            }

        public static void WriteMessageOnNewLine(string message)
            {
            Console.WriteLine(message);
            }

        public static void WriteEmptyLine()
            {
            Console.WriteLine();
            }

        public static void DisplayException(string message)
            {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
            }

        public static void DisplayStudent(KeyValuePair<string, double> student)
            {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {String.Join(", ", student.Value)}"));
            }
        }
    }