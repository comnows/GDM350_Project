using System.Collections.Generic;
using System.Text;
using System;

class OrderedInt : IntDynamicArray
{
    public OrderedInt() : base() {}

    public override void Add(string itemName,int item)
    {
        //if(count == items.Length) {Expand();}
        int addLocation = 0;
        while((addLocation < count) && items[addLocation]>item) //ถ้าค่าใน array มากกว่า ค่าที่จะเพิ่ม ตำแหน่งที่จะเพิ่ม +
        {
            addLocation++;
        }
      
        ShiftUp(addLocation);
        items[addLocation] = item;
        itemsName[addLocation] = itemName;

        if(count < 5) {count++;}
    }

    void ShiftUp(int index) //เปลี่ยนตำแหน่งจาก 0 เป็น 1
    {
        for (int i = count; i>index; i--)
        {
            if(i < 5)
            {
                items[i] = items[i-1];
            }
        }
    }
}
