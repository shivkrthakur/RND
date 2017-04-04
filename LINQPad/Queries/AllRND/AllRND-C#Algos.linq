<Query Kind="Statements" />

public static void Main(string[] args)
{

  
}

		
public class TypeSafeArray<X>
{
    int arraySize = 0;
    int currentSize = 0;
    X[] typeSafeArray;

    public TypeSafeArray(int arraySize = 4)
    {
        this.arraySize = arraySize;
        typeSafeArray = new X[this.arraySize];
    }

    public int Length { get { return arraySize; } }

    public X this[int index]
    {
        get
        {
            if (index < 0 && arraySize == currentSize)
            {
                throw new IndexOutOfRangeException();
            }
            return typeSafeArray[index];
        }
    }

    public void Add(X element)
    {
        if (currentSize == arraySize)
        {
            arraySize = arraySize == 0 ? 4 : arraySize * 2;
            X[] tempTypeSafeArray = new X[arraySize * 2];
            typeSafeArray.CopyTo(tempTypeSafeArray, 0);
            typeSafeArray = tempTypeSafeArray;
        }
        typeSafeArray[currentSize] = element;
        currentSize++;
    }

    public override string ToString()
    {
        string allElements = string.Empty;

        for(int i = 0; i < currentSize; i++)
        {
            allElements += typeSafeArray[i] + ", ";
        }

        return allElements.TrimEnd(',');
    }
}