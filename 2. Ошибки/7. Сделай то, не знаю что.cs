public static string Decode (string a)
	{
	var b = int.Parse(a.Replace(".",""))%1024;
		return b.ToString();
	}