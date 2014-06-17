using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericList<T>
{
    public T[] Elements { get; private set; }
    private int initialCap = 10;
    private int Count { get; set; }

    public GenericList()
    {
        this.Count = 0;
        this.Elements = new T[this.initialCap];
    }

    public GenericList(int size) : this()
    {
        this.Elements = new T[size];
    }

    public void Add(T element)
    {
        if (Count == this.Elements.Length) DoubleTheSize();

        this.Count++;
        this.Elements[Count - 1] = element;
    }

    public T Access(int index)
    {
        if(index >= this.Count || index < 0)
        {
            throw new IndexOutOfRangeException("no such index");
        }

        return this.Elements[index];
    }

    public void Remove(int index)
    {
        if(index >= this.Count || index < 0)
        {
            throw new IndexOutOfRangeException("no such index");
        }
        
        for (int i = index; i < this.Count-1; i++)
        {
            this.Elements[i] = this.Elements[i + 1];
        }

        this.Count--;
    }

    public void Insert(T element, int pos)
    {
        if(pos > this.Count || pos < 0)
        {
            throw new IndexOutOfRangeException("can not insert this element to this pos , the pos has to be between 0 to Count");
        }

        if (Count == this.Elements.Length) DoubleTheSize();

        for (int i = Count; i > pos; i--)
        {
            this.Elements[i] = this.Elements[i - 1];
        }

        this.Elements[pos] = element;
        this.Count++;
    }

    public T Max()
    {
        T maxEl = this.Elements[0];

        foreach (var el in this.Elements)
        {
            if ((dynamic)el > maxEl) maxEl = el;
        }

        return maxEl;
    }

    public T Min()
    {
        T minEl = this.Elements[0];

        foreach (var el in this.Elements)
        {
            if ((dynamic)el < minEl) minEl = el;
        }

        return minEl;
    }

    public void Clear()
    {
        this.Elements = new T[this.initialCap];
        Count = 0;
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < this.Count; i++)
        {
            output.Append("(" + this.Elements[i].ToString() + ") ");
        }
            
        return output.ToString();
    }

    private void DoubleTheSize()
    {
        T[] doubledArray = new T[this.Elements.Length * 2];

        for (int i = 0; i < this.Elements.Length; i++)
        {
            doubledArray[i] = this.Elements[i];
        }

        this.Elements = doubledArray;
    }

}

