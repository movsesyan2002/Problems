// Առաջադրանք 1:
// Ստեղծել Parent և Child կլասները, որոնցից առաջինը ծնողի մասին է տեղեկություններ պարունակում, երկրորդը՝ երեխայի:
// Օրինակ՝
// Child c1 = new Child("Tigran", 13, new Parent("Anna", 32, 270000), new Parent("Arman", 44, 500000));
// Նշանակում է
// c1-ը օբյեկտ է, ընդ որում
// -----
// name:"Tigran"
// age: 13
// mother: [ name:"Anna", age:32, salary:270000]
// father: [name:"Arman", age:44, salary:500000]
// ----
// Ստեղծել Child-երի ստատիկ զանգված կազմված 10 տարրերից
// Տպել այն երեխաների ցուցակը, որոնց հոր և մոր տարիքը միասին չի գերազանցում 70-ը
// Գտնել տարիքով ամենամեծ երեխայի հոր աշխատավարձը
// Գտնել ամենամեծ ընտանեկան եկամուտ ունեցող երեխայի տվյալները
// Զանգվածում տեղերով փոխել ամենաերիտասարդ և ամենամեծ երեխաների դիրքերը` տպելով ընդհանուր զանգվածը:


using System.Security.Cryptography;

class Parent {

    private string _name;
    private int _age;
    private int _salary;

    public Parent(string name, int age, int salary) {
        this._name = name;
        this._age = age;
        this._salary = salary;
    }

    public string Name {
        get { return _name; }
    }

    public int Age {
        get { return _age; }
    }   

    public int Salary {
        get { return _salary; }
    }



}

class Child {
    private string _name;
    private int _age;
    
    private Parent father;
    private Parent mother;

    public Child(string name, int age, Parent father, Parent mother) {
        this._name = name;
        this._age = age;
        this.father = father;
        this.mother = mother;
    }

    public Parent Father{
        get { return father; }
    }

    public Parent Mother{
        get { return mother; }
    }

    public string Name {
        get { return _name; }
    }

    public int Age {
        get { return _age; }
    }  

    public bool Age70(Parent father, Parent mother) {
        return father.Age + mother.Age < 70;
    }


}

class Program {

    static void PrintChild(Child[] childs) {
        
        foreach (Child item in childs) {
            if (item.Age70(item.Father,item.Mother)) {

                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Child name is {item.Name}\nChild age is {item.Age}");
                Console.WriteLine("---------------------------------------");

            }
        }
    }

    static void PrintBigChild(Child[] childs) {
        
        int maxage = 0;
        foreach (Child item in childs) {
            if (maxage < item.Age) {   
                maxage = item.Age;
            }
        }

        foreach (Child item in childs) {
            if (maxage == item.Age) {   
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Father name is {item.Father.Name} and salary is {item.Father.Salary}");
                Console.WriteLine("---------------------------------------");            }
        }
    }

    static void BigIncome(Child[] children) {
        int maxincome = 0;
        foreach (Child item in children) {
            if (maxincome < item.Father.Salary + item.Mother.Salary) {   
                maxincome = item.Father.Salary + item.Mother.Salary;
            }
        }

        foreach (Child item in children) {
            if (maxincome == item.Father.Salary + item.Mother.Salary) {   
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Child name is {item.Name}\nChild age is {item.Age}");
                Console.WriteLine("---------------------------------------");          
            }
        }

    }

    static void BigChildSmallChild(Child[] children) {
        int small = 0;
        int big = 0;

        int max = children[0].Age;
        int min = children[0].Age;

        for (int i = 0; i < children.Length; i++)
        {
            if (max < children[i].Age) {
                max = children[i].Age;
                big = i;
            }

            if (min > children[i].Age) {
                min = children[i].Age;
                small = i;
            }
        }

        Child tmp = children[small];
        children[small] = children[big];
        children[big] = tmp;

        foreach (Child item in children)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Child name is {item.Name}\nChild age is {item.Age}");
            Console.WriteLine("---------------------------------------"); 
        }
    }

    static void Main(string[] args) {
        Child[] childs = new Child[10];
        childs[0] = new Child(name:"Tigran",age: 13,new Parent("Arman", 44, 500000),new Parent ("Anna",39,250000));
        childs[1] = new Child("Vahan", 8, new Parent("Seda", 35, 300000), new Parent("Vagharsh", 40, 350000));
        childs[2] = new Child("Narine", 12, new Parent("Mariam", 38, 400000), new Parent("Gevorg", 45, 450000));
        childs[3] = new Child("Lusine", 5, new Parent("Siranush", 30, 250000), new Parent("Artur", 42, 320000));
        childs[4] = new Child("Hovhannes", 5, new Parent("Ani", 28, 290000), new Parent("Ashot", 30, 480000));
        childs[5] = new Child("Aram", 10, new Parent("Elena", 33, 330000), new Parent("Sergey", 39, 470000));
        childs[6] = new Child("Maya", 7, new Parent("Narine", 31, 350000), new Parent("Garegin", 36, 530000));
        childs[7] = new Child("Tatevik", 9, new Parent("Zaruhi", 34, 310000), new Parent("Mher", 43, 460000));
        childs[8] = new Child("Viktor", 14, new Parent("Anush", 36, 360000), new Parent("Levon", 48, 540000));
        childs[9] = new Child("Shushan", 6, new Parent("Lilit", 28, 280000), new Parent("Sargis", 41, 490000));

        // PrintChild(childs);
        // PrintBigChild(childs);
        // BigIncome(childs);
        BigChildSmallChild(childs);
    }
}