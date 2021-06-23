using System.Collections;
using System.Collections.Generic;
using System.Text;

abstract class IntDynamicArray
{
    const int ExpandMultipleFactor = 2;
    public int[] items;
    public string[] itemsName;
    protected int count;
    protected IntDynamicArray()
    {
        items = new int[5];
        itemsName = new string[5];
        count = 0;
    }
    public abstract void Add(string itemName, int item);
    
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for(int i = 0; i < count; i++)
        {
            builder.Append(items[i]);
            if(i<count -1) {builder.Append(",");}
        }
        return builder.ToString();
    }

    public int Count{get {return count;}}
    //public void Clear() {count = 0;}
}
