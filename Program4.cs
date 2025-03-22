// // Առաջադրանք:
// // Ստեղծել աբստրակտ Translator կլասը, որից ժառանգվում են Russian, Spanish, French կլասները:
// // Translator-ն ունի translate աբստրակտ մեթոդը, որն իբրև պարամետր ստանում է string տիպի բառ և վերադարձնում դրա թարգմանությունը համապատասխան լեզվով:
// // Ընդունենք, որ անհրաժեշտ է թարգմանել հետևյալ անգլերեն բառերը.
// // Apple, Banana, Orange, Mango, Pineapple, Grape, Strawberry, Cherry, Watermelon, Peach
// // Թարգմանությունները կարող եք ներկայացնել struct-ով, որն ունի original անգլերեն բառը և դրան համապատասխանող թարգմանությունը:
// // Նշված բառերի թարգմանություններն անհրաժեշտ է պահել համապատասխան կլասնսերում, սակայն հիշողության օպտիմալ օգտագործմամբ:


// using System.Security.Cryptography.X509Certificates;

// abstract class Translator {

//     public abstract string Translate(string s);

// }

// struct Word {
//     public string Originalword { get; set; } 
//     public string transleted { get; set; }

//     public Word(string word, string traned) {
//         Originalword = word;
//         transleted = traned;
//     }

   
// }

// class Russian : Translator{
//     private Word[] TranslatedWords = new Word[] {new Word("Apple","Яблоко"), new Word("Banana","Банан"), new Word("Orange","Апельсин"), new Word("Mango","Манго"),
//     new Word("Pineapple","Ананас"), new Word("Grape", "Виноград"), new Word("Strawberry", "Клубника"),new Word("Cherry","Вишня"), new Word("Watermelon", "Арбуз"), new Word("Peach","Персик")};
    
    
//     public override string Translate(string s) {
//         for (int i = 0; i < TranslatedWords.Length; i++)
//         {

//             if (string.Compare(TranslatedWords[i].Originalword,s,true) == 0) {
//                 return TranslatedWords[i].transleted;
//             }

//         }

//         return "Not tranlate";
//     }
    
// }

// class French : Translator{
//     //Pomme, banane, orange, mangue, ananas, raisin, fraise, cerise, pastèque, pêche
//     private Word[] TranslatedWords = new Word[] {new Word("Apple","Pomme"), new Word("Banana","banane"), new Word("Orange","orange"), new Word("Mango","mangue"),
//     new Word("Pineapple","ananas"), new Word("Grape", "raisin"), new Word("Strawberry", "fraise"),new Word("Cherry","cerise"), new Word("Watermelon", "cerise"), new Word("Peach","pêche")};
    
    
//     public override string Translate(string s) {
//         for (int i = 0; i < TranslatedWords.Length; i++)
//         {

//             if (string.Compare(TranslatedWords[i].Originalword,s,true) == 0) {
//                 return TranslatedWords[i].transleted;
//             }

//         }

//         return "Not tranlate";
//     }
    
// }

// class Spain : Translator{

//     //Manzana, plátano, naranja, mango, piña, uva, fresa, cereza, sandía, melocotón
//     private Word[] TranslatedWords = new Word[] {new Word("Apple","Manzana"), new Word("Banana","plátano"), new Word("Orange","naranja"), new Word("Mango","mango"),
//     new Word("Pineapple","piña"), new Word("Grape", "uva"), new Word("Strawberry", "fresa"),new Word("Cherry","cereza"), new Word("Watermelon", "sandía"), new Word("Peach","melocotón")};
    
    
//     public override string Translate(string s) {
//         for (int i = 0; i < TranslatedWords.Length; i++)
//         {

//             if (string.Compare(TranslatedWords[i].Originalword,s,true) == 0) {
//                 return TranslatedWords[i].transleted;
//             }

//         }

//         return "Not tranlate";
//     }
    
// }


// class Program {
//     static void Main(string[] args) {
//         string[] strings = new string[] {"Apple", "Banana", "Orange", "Mango", "Pineapple", "Grape", "Strawberry", "Cherry", "Watermelon", "Peach"};

//         Console.WriteLine("Which fruit translate do you want in Russian, Spain, French?");
//         for (int i = 0; i < strings.Length; i++)
//         {
//             Console.WriteLine(strings[i]);
//         }

//         Console.Write("Please enter word ");
//         string? fruitChoice = Console.ReadLine();

//         Translator[] translator = new Translator[] {new Spain(), new Russian(), new French()};

//         Console.WriteLine($"Your word is {fruitChoice}: Translated {translator[0].Translate(fruitChoice)}");
//         Console.WriteLine($"Your word is {fruitChoice}: Translated {translator[1].Translate(fruitChoice)}");
//         Console.WriteLine($"Your word is {fruitChoice}: Translated {translator[2].Translate(fruitChoice)}");

//     }
// }