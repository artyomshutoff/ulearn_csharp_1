public static double Calculate(string userInput)
        {
            string[] values = userInput.Split(' ');
            
            var sum = double.Parse(values[0]);
            var rank = double.Parse(values[1]);
            var deposit = double.Parse(values[2]);

            return (sum * (Math.Pow(1 + rank / 1200, deposit)));
        }	