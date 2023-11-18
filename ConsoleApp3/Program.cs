//Задача 2 - Журнал
//1.Ввод информации о журнале
//2. Вывод информации о журнале
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

Journal TheLancet = new Journal("The Lancet", "ElSeiver publishing", 1823, 120);
Console.WriteLine(TheLancet);

//3. Сериализация журнала
//4.Сохранение сериализованного журнала в файл
using (FileStream file = new FileStream("journal.json", FileMode.OpenOrCreate))
{
    DataContractJsonSerializer journalSaver = new DataContractJsonSerializer(typeof(Journal));
    journalSaver.WriteObject(file, TheLancet);
}

//5.Загрузка сериализованного журнала из файла. После загрузки нужно произвести десериализацию журнала.
Journal ? LoadedJournal;
using (FileStream file = new FileStream("journal.json", FileMode.Open))
{
    DataContractJsonSerializer journalSaver = new DataContractJsonSerializer(typeof(Journal));
    LoadedJournal = (Journal?)  journalSaver.ReadObject(file);
    Console.WriteLine("\nDeserialized journal");
    Console.WriteLine(LoadedJournal);
}


[Serializable]
[DataContract]
public class Journal
{
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string Publisher { get; set; }

    [DataMember]
    public uint Date { get; set; }
    [DataMember]
    public uint Pages { get; set; }

    public Journal(string name, string publisher, uint date, uint pages)
    {
        Name = name;
        Publisher = publisher;
        Date = date;
        Pages = pages;
    }
    public override string ToString()
    {
        return $"\"{Name ?? "NoData"}\".{Publisher ?? "NoData"} - {Date} - {Pages}p";
    }
}