using System;

namespace SzyfrCezaraApp
{
    public class CaesarCipher
    {
        private const int AlphabetLength = 26;
        private const char FirstLetter = 'a'; // ASCII 97

        /// <summary>
        /// Szyfruje podany tekst jawny szyfrem Cezara dla zadanego klucza.
        /// </summary>
        /// <param name="plainText">Tekst jawny (małe litery a-z oraz spacje).</param>
        /// <param name="key">Klucz szyfrowania (liczba całkowita, również ujemna lub > 26).</param>
        /// <returns>Zaszyfrowany tekst.</returns>
        public static string Encrypt(string plainText, int key)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return string.Empty;
            }

            int normalizedShift = ((key % AlphabetLength) + AlphabetLength) % AlphabetLength;

            char[] result = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                char currentChar = plainText[i];

                if (currentChar == ' ')
                {
                    result[i] = ' ';
                }
                else if (currentChar >= 'a' && currentChar <= 'z')
                {
                    int positionInAlphabet = currentChar - FirstLetter;
                    int shiftedPosition = (positionInAlphabet + normalizedShift) % AlphabetLength;
                    result[i] = (char)(FirstLetter + shiftedPosition);
                }
                else
                {              
                    result[i] = currentChar;
                }
            }

            return new string(result);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Podaj tekst jawny (małe litery i spacje): ");
            string plainText = Console.ReadLine() ?? string.Empty;

            Console.Write("Podaj klucz szyfrowania (liczba całkowita): ");
            string? keyInput = Console.ReadLine();

            if (!int.TryParse(keyInput, out int key))
            {
                Console.WriteLine("Błąd: podany klucz nie jest poprawną liczbą całkowitą.");
                return;
            }

            string encryptedText = CaesarCipher.Encrypt(plainText, key);

            Console.WriteLine($"Tekst zaszyfrowany: {encryptedText}");
        }
    }
}