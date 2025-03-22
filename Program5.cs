// Ստեղծել Shape աբստրակտ կլասը, որի աբստրակտ մեթոդներն են՝  surface և  draw, առաջինը՝ մակերեը հաշվելու համար, երկրորդը նկարելու
// Կլասն ունի նաև ոչ աբստրակտ print մեթոդը, որը կանչելիս ելքագրվում է տվյալ Shape-ի անունը, մակերեսը, ինչպես նաև պատկերը.
// Կլասից ժառանգվում են՝
// Square, Rectangle, կլասները.
// Օրինակ՝
// Shape[] shapes = new Shape[2];
// shapes[0] = new Square(4);
// shapes[1] = new Rectnangle(4,6);
// foreach(Shape s in shapes){
//    s.Print();
// }
// --- արդյունքը՝
// Square, S = 16
// +  +  +  +
// +  +  +  +
// +  +  +  +
// +  +  +  +
// ------------------------
// Rectangle, S = 24
// +  +  +  + +  + 
// +  +  +  + +  + 
// +  +  +  + +  + 
// +  +  +  + +  + 
// ------------------------

abstract class Shape {
    
    public abstract int Surface();
    public abstract void Draw();

    public void Print() {
        Console.WriteLine($"{this.GetType()}, S = {Surface()}");
        Draw();
    }
}

class Square : Shape {

    public int Slength { get; set; }
    public int Width { get; set; }

    public Square (int Length) {
        this.Slength = Length;
        this.Width = Length;
    }

    public override int Surface() {
        return Slength * Width;
    }
    public override void Draw() {

        for (int i = 0; i < Slength; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Console.Write("*" );
            }
            Console.WriteLine();
        }

    }

}

class Rectangle : Shape {

    public int Slength { get; set; }
    public int Width { get; set; }

    public Rectangle (int Length, int Width) {
        this.Slength = Length;
        this.Width = Width;
    }

    public override int Surface() {
        return Slength * Width;
    }
    public override void Draw() {

        for (int i = 0; i < Slength; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Console.Write("*" );
            }
            Console.WriteLine();
        }
        
    }

}


class Program {

    static void Main (string[] args) {
        Shape[] shapes = new Shape[] {new Rectangle(3,5), new Square(4)};

        foreach (Shape item in shapes)
        {
            item.Print();
        }
    }

}