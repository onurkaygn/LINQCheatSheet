using LINQCheatsheet;

var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "Harvey",
        LastName = "Specter"
    },
     new Lawyer()
    {
        FirstName = "Micheal",
        LastName = "Ross"
    },
};

var clients = new[]
{
    new Client()
    {
        FirstName = "Tim",
        LastName = "Funny"
    },
    new Client()
    {
        FirstName = "Jim",
        LastName = "Decker"
    },
    new Client()
    {
        FirstName = "Yana",
        LastName = "Cat"
    },
};

var cases = new[]
{
    new Case()
    {
        Title = "Car accident.",
        AmountInDispute = 1000,
        CaseType = CaseType.Commercial,
        Client= clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Molding flat.",
        AmountInDispute = 65000,
        CaseType = CaseType.ProBono,
        Client= clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Death threat.",
        AmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        Client= clients[1],
        Lawyer = lawyers[1]
    },
    new Case()
    {
        Title = "Robbery.",
        AmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        Client= clients[2],
        Lawyer = lawyers[1]
    },
};

//Where
foreach(Lawyer lawyer in lawyers)
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();


foreach(Client client in clients)
    client.Cases = cases.Where(c => c.Client == client).ToList();

//First
var workingFirstExample = lawyers.First(l => l.FirstName == "Harvey"); //Lawyerstaki ismi ilk Harvey olan avukatı seçer ve workingFirstExample'a atar.

try{var firstExceptionExample = lawyers.First(l => l.FirstName == "Louis");} //Lawyerstaki ismi ilk Louis olan avukatı seçer ve firstExceptionExample'a atar.
catch (InvalidOperationException ex){Console.WriteLine(ex.Message);} //Eğer Louis isimli biri yoksa bu satır çalışır.

//FirstOrDefault 
var firstOrDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Sheila"); //First ile tek farkı Sheilayı bulamadığında default değer döndürür hata fırlatmaz.

//Single
var workingSingleExample = lawyers.Single(l => l.FirstName == "Micheal"); /*Lawyers'ta bulunan adı Robert olan avukatı seçer. Birden fazla Robert varsa veya Robert yoksa hata fırlatır.*/

try
{
    var singleExeceptionExample = lawyers.Single(l => l.LastName.Contains("s"));/*Lawyers'ta bulunan adı LastName'sinde s harfi içeren  avukatı seçer. Birden fazla  varsa veya  yoksa hata fırlatır.*/

}
catch (InvalidOperationException ex)
{

    Console.WriteLine(ex.Message);
}

//SingleOrDefault
var singleOrDefaultExample = lawyers.SingleOrDefault(l => l.FirstName == "Robert"); //Single gibi fakat Robert yoksa veya birden fazla varsa default değer atar.

//Any
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(c => c.CaseType == CaseType.ProBono)); //Probono davaları olan avukatları seçer.

//All
var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial)); //Sadece commercial davalarla ilgilenen avukatları seçer.

//Working with numbers
var sumOfAmountInDispute = cases.Sum(c => c.AmountInDispute);
var averageAmountInDispute = cases.Average(c => c.AmountInDispute);
var maxAmountInDispute = cases.Max(c => c.AmountInDispute);
var minAmountInDispute = cases.Min(c => c.AmountInDispute);

//OrderBy
var lawyersByAmountInDisputeAsc = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmountInDispute)); //Bu iki satır avukatları AmountInDispute özelliğine göre sıralar.
var lawyersByAmountInDisputeDsc = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmountInDispute));

//Select
var caseTitles = cases.Select(c => c.Title); //Davaların sadece titleını alır.

//Fluent
var caseTitlesOfCommercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial)); /*Yalnızca commercial davalarda uğraşan avukatların Title'ını seçer.*/