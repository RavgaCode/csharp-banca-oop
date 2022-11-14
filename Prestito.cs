// See https://aka.ms/new-console-template for more information
public class Prestito
{
    public int ID { get; set; }
    public string Intestatario { get; set; }
    public int Ammontare { get; set; }
    public float Rata { get; set; }
    public DateTime DataInizio { get; set; }
    public DateTime DataFine  { get; set; }

    public Prestito (int iD, string intestatario, int ammontare, float rata, DateTime dataInizio, DateTime dataFine)
    {
        ID = iD;
        Intestatario = intestatario;
        Ammontare = ammontare;
        Rata = rata;
        DataInizio = dataInizio;
        DataFine = dataFine;
    }
}