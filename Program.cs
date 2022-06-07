using System;
using System.Collections.Generic;

namespace RegExABC
{
    internal class Program
    {
        public static string comeco { get; set; }
        public static string resultado { get; set; }
        public static List<char> entrada = new List<char> { 'a', 'b', 'c' };
        static void RecebeEntrada()
//meu maior arrependimento recente foi ter escrito isso em pt
        {
            Console.WriteLine("Digite caracteres permitidos 'a, b ou c'");
            string input = Console.ReadLine();

            if (input is not null )
               comeco = input.Trim().ToLower();
                  else
                    throw new Exception("não pode ser nulo");
        }
        static void ValidarChar()
        {
            for (int i = 0; i < comeco.Length; i++)
            {
                if (!entrada.Contains(comeco[i]))
                   throw new Exception("char invalido");
            }
        }
        static bool reduzivel(string stringreduzivel)
        {
            if (stringreduzivel.Length <= 1)
                return false;
            for (int i = 1; i < stringreduzivel.Length; i++)
                if (stringreduzivel[i] != stringreduzivel[0])
                    return true;
            return false;
        }
        static bool charreduziveis(char firstCharacter, char secondCharacter)
        {
            return firstCharacter != secondCharacter;
        }
        static char CharDesejado(char firstCharacter, char secondCharacter)
        {
            return entrada.Find(c => c != firstCharacter && c != secondCharacter);
        }
        static string Reduzir(string stringreduzivel2)
        {
            if (reduzivel(stringreduzivel2) == false)
            {
                return stringreduzivel2;
            }
            else
            {
                for (int i = 0; i < stringreduzivel2.Length; i++)
                {
                    int nextPosition = i + 1;

                    if (nextPosition >= stringreduzivel2.Length || charreduziveis(stringreduzivel2[i], stringreduzivel2[nextPosition]) == false)
                    {
                        continue;
                    }
                        char desiredCharacter = CharDesejado(stringreduzivel2[i], stringreduzivel2[nextPosition]);

                        stringreduzivel2 = stringreduzivel2.Remove(i, 2);
                        stringreduzivel2 = stringreduzivel2.Insert(i, desiredCharacter.ToString());
                        return Reduzir(stringreduzivel2);
                    
                }
            }
            
           return stringreduzivel2;
        }
        static void MostrarNoConsole()
        {
            Console.WriteLine($"Começo: {comeco}");
            Console.WriteLine($"Fim: {resultado}");
            Console.WriteLine($"Quantidade de caracteres: {resultado.Length}");
        }
        static void Main(string[] args)
        {
            RecebeEntrada();
            ValidarChar();
            resultado = Reduzir(comeco);
            MostrarNoConsole();
        }
    }
}