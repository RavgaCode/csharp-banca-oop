// See https://aka.ms/new-console-template for more information
public class Banca
{
    public string Nome { get; set; }
    public List<Cliente> ListaClienti { get; set; }
    public List<Prestito> ListaPrestiti { get; set; }

    public Banca (string nome)
    {
        Nome = nome;
        ListaClienti = new List<Cliente> ();
        ListaPrestiti = new List<Prestito> ();
    }

    public bool NuovoCliente(string nome, string cognome, string codiceFiscale, int stipendio)
    {

        if (
            nome == null || nome == "" ||
            cognome == null || cognome == "" ||
            codiceFiscale == null || codiceFiscale == "" ||
            stipendio < 0
            )
        {
            return false;
        }

       

        Cliente nuovoCliente = new Cliente(nome, cognome, codiceFiscale, stipendio);
        ListaClienti.Add(nuovoCliente);

        return true;
    }
    public Cliente RicercaCliente(string codiceFiscale)
    {
        foreach (Cliente cliente in ListaClienti)
        {
            if (cliente.CodiceFiscale == codiceFiscale)
                return cliente;
        }

        return null;
    }
}