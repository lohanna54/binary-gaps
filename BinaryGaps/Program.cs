using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryGaps
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Random random = new Random();

            int randomNumber = random.Next(1, 100);

            BinaryGaps(randomNumber);

        }

        public static void BinaryGaps(int randomNumber)
        {
            const int BINARY_BASE_DIGIT = 2;

            string convertedNumber = Convert.ToString(randomNumber, BINARY_BASE_DIGIT);

            char[] numberDigits = convertedNumber.ToCharArray();

            var result = GetBinaryRepresentation(numberDigits);

            var joinOfGapsLength = "";

            if (result.HasBinaryGaps)
            {

                if (result.BinaryGaps.Count > 1)
                {
                    result.BinaryGaps.ForEach(gap =>
                    {
                        joinOfGapsLength += gap.NumberOfZeros + ", ";
                    });
                }
                else
                {
                    joinOfGapsLength = result.BinaryGaps.First(x => x.NumberOfZeros != default).NumberOfZeros.ToString();
                }

            }

            var message = result.HasBinaryGaps ? result.NumberOfBinaryGaps > 1 ?
                String.Format("contém {0} espaços binários com os comprimentos de {1}repectivamente", result.NumberOfBinaryGaps, joinOfGapsLength)
                : String.Format("contém {0} espaço binário com o comprimento de {1}", result.NumberOfBinaryGaps, joinOfGapsLength)
                : "não possui espaços binários";

            Console.WriteLine("O número {0} tem representação binária {1} e {2}.", randomNumber, convertedNumber, message);
        }

        public static BinaryRepresentation GetBinaryRepresentation(char[] digits)
        {
            var numberOfZeros = 0;

            List<BinaryGap> gaps = new();

            for (int i = 0; i < digits.Length; i++)
            {
                if (i != 0)
                {

                    if (digits[i] == '0' && digits[i - 1] == '1')
                    {
                        numberOfZeros = 1;
                    }
                    else if (digits[i] == '0' && digits[i - 1] == '0')
                    {
                        numberOfZeros++;
                    }
                    else if (digits[i] == '1' && digits[i - 1] == '0')
                    {
                        gaps.Add(new BinaryGap
                        {
                            NumberOfZeros = numberOfZeros
                        });

                        numberOfZeros = 0;
                    }

                }

            }

            if (gaps.Count < 1)
            {
                return new BinaryRepresentation
                {
                    HasBinaryGaps = false,
                    NumberOfBinaryGaps = 0,
                };
            }

            return new BinaryRepresentation
            {
                HasBinaryGaps = true,
                NumberOfBinaryGaps = gaps.Count,
                BinaryGaps = gaps
            };
        }
    }
}