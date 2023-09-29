using System.Data;

namespace Program {
    class Program {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            string result = ConvertorForReversePolishNotation(input, stack);
            Console.WriteLine(result);
             double finalResult = CalculateReversePolishNotation(input);
            Console.WriteLine(finalResult);
        }

        private static double CalculateReversePolishNotation(string result)
        {

            string expression = result;
 
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (Char.IsLetter(c))
                {
                    Console.Write("Enter a value for variable " + c + ": ");
                    char value = char.Parse(Console.ReadLine());
                    expression = expression.Replace(c, value);
                }
            }
            Console.WriteLine("Обратният полски израз е :");
            Console.WriteLine(expression);

            DataTable dt = new DataTable();
       
            object A = dt.Compute(expression, "");           
            return Convert.ToDouble(A);
        }
       

        public static string ConvertorForReversePolishNotation(string input, Stack<char> stack)
        {
            string result = "";
            char[] operators = new char[] { '+', '-', '*', '/' };


            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        stack.Push(symbol);
                        break;
                    case '*':
                    case '/':
                        stack.Push(symbol);
                        break;
                    case '+':
                    case '-':
                        while (stack.Count > 0
                        && operators.Contains(stack.Peek()))
                        {
                           result += stack.Pop();
                        }
                        if (symbol != '(' || symbol != ')')
                        {
                            stack.Push(symbol);
                        }
                        break;
                    case ')':
                        while (stack.Peek() != '(' && stack.Count > 0)
                        {
                            if (stack.Peek() != '(')
                            {
                                result += stack.Pop();
                            }
                        }

                        if (stack.Peek() == '(' && stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    default:
                        result += symbol;
                        break;
                }
            }
            while (stack.Count>0) { 
             result+=stack.Pop();
            }
            return result;
        }        
    }
}
