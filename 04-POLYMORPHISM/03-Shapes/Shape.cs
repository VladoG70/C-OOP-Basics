using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Shape
    {

    public virtual string Draw()
        {
        return "Drawing ";
        }

    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();
    }

