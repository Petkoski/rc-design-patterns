<Query Kind="Program" />

//Interpreter pattern - having some kind of input language and we want 
//to map it to some functionality (or object) once parsed.
//Not hard to understand/recognize, might be hard to implement (depends
//on sophistication of input language).

void Main()
{
	//Language:
	var domainLanguage = "order x10 '2L water bottles' from Tesco";
	Order.Parse(domainLanguage).Dump();
}

//Grammar representation (how to represent all possible sentences we can expect):
const string optionalSpace = " ?";
// \\d+ - multiple numbers 
const string qty = "x(?<qty>\\d+)" + optionalSpace;
const string product = "'(?<product>[\\w ]+)'" + optionalSpace;
const string source = "from (?<source>\\w+)";
const string orderCommand = "order" + optionalSpace + qty + product + source;

public class Order
{
	static Regex _regex = new Regex(orderCommand);

	Order(int qty, string product, string source)
	{
		Qty = qty;
		Product = product;
		Source = source;
	}
	
	public int Qty { get; }
	public string Product { get; }
	public string Source { get; }

	//Interpreter lives in this function (returns dedicated object):
	public static Order Parse(string command)
	{
		var match = _regex.Match(command);
		if (!match.Success)
		{
			return null;
		}
		
		//Extract values:
		var qty = int.Parse(match.Groups["qty"].Value);
		var product = match.Groups["product"].Value;
		var source = match.Groups["source"].Value;
		
		//Return dedicated object:
		return new Order(qty, product, source);
	}
	
	//The input language can not only be mapped to a data representation 
	//object (like above), it can also be mapped to functionality (same
	//way C# code is mapped to machine language and gets executed).
}

//Other real world examples of interpreter: regex, compilers.
//Other tools: ANTLR.