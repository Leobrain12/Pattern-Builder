using System.Globalization;
using System.Text;
using System.Collections.Generic;   
namespace ConsoleApp19
{
class HUMANFIO
{
    // какого сорта мука
    public HUMANFIO(string name , string surename, string lastname) 
    {
        this.Name= name;
        this.Surename= surename;
        this.Lastname= lastname;
    }
    public string Name { get; set; }
    public string Surename { get; set; }
    public string Lastname { get; set; }
}
// соль
class DOGINFO
{
    public DOGINFO(string name,string type) 
    {
        this.Name = name;
        this.Type = type;
    }
    public string Name { get; set; }
    public string Type { get; set;}
}
// пищевые добавки
class CATINFO
{
    public CATINFO (string name,string type)
    {
        this.Name = name;
        this.Type = type;
    }
    public string Name { get; set; }
    public string Type { get; set;}
}
class STREETINFO
{
    public STREETINFO(string city, string streeet, int house, int flat)
    {
        this.City = city;
        this.Streeet = streeet;
        this.House = house;
        this.Flat = flat;
    }


    public string City { get; set; }
    public string Streeet { get; set; }
    public int House { get; set; }
    public int Flat { get; set; }
}
    class INFO
    {
        // мука
        public HUMANFIO FIO { get; set; }
        // соль
        public DOGINFO dOGINFO { get; set; }
        // пищевые добавки
        public CATINFO cATINFO { get; set; }
        public STREETINFO sTREETINFO { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (FIO != null)
                sb.Append(FIO + "\n");
            if (dOGINFO != null)
                sb.Append(dOGINFO + " \n");
            if (cATINFO != null)
                sb.Append(cATINFO + " \n");
            if (sTREETINFO != null)
                sb.Append(sTREETINFO + "\n");
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            INFO ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            INFO wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            Console.Read();
        }
    }
    // абстрактный класс строителя
    abstract class BreadBuilder
    {
        public INFO GetInfo { get; private set; }
        public void CreateBread()
        {
            GetInfo = new INFO();
        }
        public abstract void SetFIO();
        public abstract void SetDOGINFO();
        public abstract void SetCATINFO();
    }
    // пекарь
    class Baker
    {
        public INFO Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFIO();
            breadBuilder.SetDOGINFO();
            breadBuilder.SetCATINFO();
            return breadBuilder.Bread;
        }
    }
    // строитель для ржаного хлеба
    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFIO()
        {
            this.Bread.FIO = new Flour { Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetDOGINFO()
        {
            this.Bread.dOGINFO = new Salt();
        }

        public override void SetCATINFO()
        {
            // не используется
        }
    }
    // строитель для пшеничного хлеба
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFIO()
        {
            this.Bread.FIO = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetDOGINFO()
        {
            this.Bread.dOGINFO = new Salt();
        }

        public override void SetCATINFO()
        {
            this.Bread.cATINFO = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }
}
