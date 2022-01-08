public static void Main()
	{
		var array = new List<int>(){3,4,3,1,6,5};
		var maxDiff = 2;
		var teamSize = 3;
		
		var answer = 0;
		var i = 0;
		
		array.Sort();
		while(i <= array.Count - teamSize) {
			if(array[i + teamSize-1] -	array[i] <= maxDiff)
			{
				answer +=1;
				i += teamSize;
			}
			else 
			{
				i+=1;
			}
		}
		
		Console.WriteLine(answer);
	}

public static int GetPasswordStrength(string input)
	{
		Dictionary<char, int> map = new Dictionary<char, int>();		
		
		for(var c = 'a';c<='z';c++)
		{
			map[c] = -1;	
		}
		
		int ret = 0;
		int left = 0;
		int right = 0;
		for (var i =0;i<input.Length;i++)
		{
			left = i - map[input[i]];
			right = input.Length - i;
			ret += left * right;
			map[input[i]] = i;
		}
		
		return ret;
	}
