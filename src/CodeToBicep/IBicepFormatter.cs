namespace Memoryleek.CodeToBicep;

public interface IBicepFormatter 
{
	string ToBicepString(int indentCount = 0);
}