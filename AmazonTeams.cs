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
