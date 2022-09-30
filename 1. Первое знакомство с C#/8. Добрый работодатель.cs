private static string GetGreetingMessage(string name, double salary) {
    string namee = (string) name;
    int salaryy = (int) Math.Ceiling(salary);
    string s1 = "Hello, ";
    string s2 = namee;
    string s3 = ", your salary is ";
    string s4 = salaryy.ToString();
    string total = s1 + s2 + s3 + s4;
    return total;
}