using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 2;
			Console.WriteLine(a);

			int? b = 3;
			Console.WriteLine(b.GetType());

			//a = b;
		}
	}
}
