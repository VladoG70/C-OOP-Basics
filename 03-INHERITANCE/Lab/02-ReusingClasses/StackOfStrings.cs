using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StackOfStrings
    {
    private List<string> data;

    public StackOfStrings()
        {
        this.data = new List<string>();
        }

    public void Push(string item)
        {
        this.data.Add(item);
        }

    public string Pop()
        {
        var element = this.data.Last();
        this.data.Remove(element);
        return element;
        }

    public string Peek()
        {
        var element = this.data.Last();
        return element;
        }

    public bool IsEmpty()
        {
        if (this.data.Count == null)
            {
            return true;
            }

        return false;
        }
    }

