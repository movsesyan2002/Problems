// Ստեղծել, Course, Group, Module կլասները
// Course - ինֆորմացիա է պարունակում դասընթացի մասին
// (անուն,  ամսավճար, մոդուլներ)
// Module - ինֆորմացիա է պարունակում դասընթացի առանձին կտորի մասին
// (վերնագիր, տևողություն)
// Group - Ներկայացնում է խմբի տվյլաները
// (անուն, ուսանողների քանակ, կուրս)
// Course կլասից ժառանգվում են Web, Game, AI  կլասները
// ընդ որում Web-ը ունի նաև type դաշտ, որը կարող է լինել frontend, backend, fullstack
// Game-ը ունի engine դաշտ, որը կարող է լինել unity, unreal:
// Course,Module և Group, Course կապը has a է, իսկ Course=>Web,Game,Ai -ը is a:


class Module {
    public string Title { get; private set; }
    public int Duration { get; set; }


    public Module(string title, int duration) {
        Title = title;
        Duration = duration;
    }
}

class Course {
    public string Name { get; private set; }
    public int MonthlyPayment { get; set; }
    public Module[] MoDule { get; private set; }

    public Course(string name, int monthlyPayment, Module[] module) {
        Name = name;
        MonthlyPayment = monthlyPayment;
        MoDule = module;
    }

}


class Group {
    public string GroupName { get; private set; }
    public int StudentCount { get; set; }

    public Course CourseName { get; set; }

    public Group(string groupsName, int studentCount, Course courseName) {
        GroupName = groupsName;
        StudentCount = studentCount;
        CourseName = courseName;
    }

}

class Web : Course {
    public string Type { get; set;}
    public Web(string coursename, int monthlypayment, string type, Module[] module) : base(coursename, monthlypayment, module)
    {
        Type = type; 
    }

}

class Game : Course {
   
    public string Engine { get; set; }

    public Game (string coursename, int monthlypayment, string engine, Module[] module) : base (coursename, monthlypayment, module) 
    {
        Engine = engine;
    }

}

class AI : Course {

    public AI(string coursename, int monthlypayment, Module[] module) : base(coursename, monthlypayment, module) {

    }

}

class Program {
    static void Main(string[] args) {
        Course[] courses = new Course[]
        {
            new Web("Frontend Development", 500000, "frontend", new Module[] { new Module("HTML & CSS", 2), new Module("JavaScript", 3) }),
            new Web("Fullstack Development", 60000, "fullstack", new Module[] { new Module("Node.js", 4), new Module("React", 5)  }),
            new AI("Machine Learning", 80000, new Module[] { new Module("Python for AI", 6), new Module("Deep Learning", 8) }),
            new Game("Game Development", 72000, "Unity", new Module[] { new Module("C# for Unity", 5), new Module("Physics in Games", 4) }),
            new Game("Game Dev Advanced", 42000, "Unreal", new Module[] { new Module("Blueprints", 6), new Module("C++ for Unreal", 7) })
        };
    
        Group[] groups = new Group[]
        {
            new Group("Frontend Group 1", 15, courses[0]),   // Frontend Development
            new Group("Fullstack Group 1", 12, courses[1]),  // Fullstack Development
            new Group("AI Group 1", 10, courses[2]),         // Machine Learning
            new Group("Game Dev Group 1", 20, courses[3]),   // Unity Game Development
            new Group("Game Dev Group 2", 18, courses[4])    // Unreal Game Development
        };
    

        Console.WriteLine($"Count of Web student is {CountWeb(groups)}");
        Console.WriteLine($"All amount of Unreal student is {Amount(groups)}");
        PopularCourse(groups);
    }
    static int CountWeb(Group[] groups) {
        
        int count = 0;
        
        foreach (Group group in groups) {
            if (group.CourseName is Web) {
                count += group.StudentCount;
            }
        }

        return count;
    }

    static int Amount(Group[] groups) {
        int amount = 0;

        foreach (Group group in groups)
        {
            
            if (group.CourseName is Game) {
                Game x = (Game)group.CourseName;
                
                if (string.Compare(x.Engine,"Unreal",true) == 0) {
                    amount += group.StudentCount * x.MonthlyPayment;
                }
            }
        }   

        return amount;
    }

    static void PopularCourse(Group[] groups) {
        int max = 0;
        foreach (Group group in groups)
        {
            if (max < group.StudentCount) {
                max = group.StudentCount;
            }
        }

        foreach (Group group in groups)
        {
            if (max == group.StudentCount) {
                Console.WriteLine($"{group.GroupName} and count students is {group.StudentCount}");
                break;
            }
        }
    }
}
