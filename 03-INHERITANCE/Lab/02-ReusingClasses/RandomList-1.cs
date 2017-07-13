using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RandomList_1
    {
    public RandomList_1()
        {
        this.rnd = new Random();
        this.data = new List<string>();
        }

    private Random rnd;
    private List<string> data;

    public object RandomString()
        {
        int element = rnd.Next(0, this.data.Count - 1);
        string str = data[element];
        data.Remove(str);
        return str;
        }
    }

