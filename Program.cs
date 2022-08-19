using System;

namespace BinaryConverter
{
    class Program
    {
        static int GetOption(ConsoleColor defaultBack, ConsoleColor defaultFore)
        {
            int selectedOpt = 0;
            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                if(selectedOpt == 0)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Convert Decimal To Binary");
                    Console.BackgroundColor = defaultBack;
                    Console.ForegroundColor = defaultFore;
                    Console.WriteLine("Convert Binary To Decimal");
                }
                else
                {
                    Console.BackgroundColor = defaultBack;
                    Console.ForegroundColor = defaultFore;
                    Console.WriteLine("Convert Decimal To Binary");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Convert Binary To Decimal");
                }
                Console.BackgroundColor = defaultBack;
                Console.ForegroundColor = defaultFore;
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.Key == ConsoleKey.DownArrow && selectedOpt == 0)
                {
                    selectedOpt++;
                }else if(key.Key == ConsoleKey.UpArrow && selectedOpt == 1)
                {
                    selectedOpt--;
                }else if(key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0,0);
                    Console.Write("Input: ");
                    break;
                }
            }
            return selectedOpt;
        }
        static void Main()
        {
            int opt = GetOption(Console.BackgroundColor, Console.ForegroundColor);
            if(opt == 0)
            {
                string input = Console.ReadLine();
                if(ContainsNotInt(input))
                {
                    Console.WriteLine("Input Contains Symbols Other Than Numbers");
                    return;
                }
                int inp = int.Parse(input);
                Console.WriteLine("Binary Format: " + ToBinary(inp));
            }
            else
            {
                string input = Console.ReadLine();
                if(ContainsNotB(input))
                {
                    Console.WriteLine("Input Contains Symbols Other Than 0 Or 1");
                    return;
                }
                Console.WriteLine("Decimal Format: " + ToDecimal(input)); 
            }
        }
        static bool ContainsNotInt(string input)
        {
            bool result = false;
            int j;
            foreach(char num in input)
            {
                if(!int.TryParse(num.ToString(), out j))
                {
                    result = true;
                }
            }
            return result;
        }
        static bool ContainsNotB(string binaryString)
        {
            bool result = false;
            foreach(char bit in binaryString)
            {
                if(!(bit == '0' || bit == '1'))
                {
                    result = false;
                }
            }
            return result;
        }
        static int ToDecimal(string binary)
        {
            char[] binaryArr = binary.ToCharArray();
            Array.Reverse(binaryArr);
            int output = 0;
            for(int i = 0; i < binaryArr.Length; i++)
            {
                if(binaryArr[i] == '1')
                {
                    output += (int)Math.Pow(2,i);
                }
            }
            return output;
        }
        static string ToBinary(int decim)
        {
            string output = "";
            int bitLength = GetBitLength(decim);
            int keepTrack = 0;
            for(int i = bitLength; i > 0; i--)
            {
                
                if(keepTrack + Math.Pow(2,i-1) <= decim)
                {
                    keepTrack += (int)Math.Pow(2,i-1);
                    output += '1';
                }else
                {
                    output += '0';
                }
            }
            return output;
        }
        static int GetBitLength(int decim)
        {
            int bitLength = 0;
            int i = 0;
            do
            {
                
                i = (int)Math.Pow(2,bitLength);
                bitLength++;

            }
            while(i < decim);
            bitLength--;

            //Console.WriteLine(bitLength);

            return bitLength;
        }
    }

}
