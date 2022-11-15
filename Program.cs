// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Banca banca = new Banca("bancaIntesa");

bool programma = true;
while (programma)
{
    Console.WriteLine("Scegliere un'operazione:");
    Console.WriteLine("1 - Registra un nuovo cliente");
    Console.WriteLine("2 - Ricerca/Modifica un cliente");
    Console.WriteLine("3 - Effettua prestito");
    Console.WriteLine("4 - Ricerca prestiti");
    Console.WriteLine("9 - Esci");

    int rispostaUtente = Convert.ToInt32(Console.ReadLine());

    switch (rispostaUtente)
    {
        case 1:
            RegistraNuovoCliente();
            break;
        case 2:
            RicercaCliente();
            break;
        case 3:
            EffettuaPrestito();
            break;
        case 4:
           
            break;
        case 9:
            programma = false;
            break;
        default:
            Console.WriteLine("Digitare un'operazione valida");
            break;
    }
}

void RegistraNuovoCliente()
{
    Console.Write("Inserisci il nome cliente: ");
    string nomeCliente = Console.ReadLine();
    Console.Write("Inserisci il cognome cliente: ");
    string cognomeCliente = Console.ReadLine();
    Console.Write("Inserisci il codice fiscale del cliente: ");
    string codiceFiscaleCliente = Console.ReadLine();
    Console.Write("Inserisci lo stipendio cliente: ");
    int stipendioCliente = Convert.ToInt32(Console.ReadLine());

    if (banca.NuovoCliente(nomeCliente, cognomeCliente, codiceFiscaleCliente, stipendioCliente))
    {
        Console.WriteLine();
        Console.WriteLine("Nuovo cliente registrato correttamente!");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Errore durante la compilazione dati!");
        Console.WriteLine();
    }
}
void RicercaCliente()
{
    Console.Write("Digitare il codice fiscale del cliente da ricercare: ");
    string codiceFiscaleCliente = Console.ReadLine();
    Cliente clienteDaRicercare = banca.RicercaCliente(codiceFiscaleCliente);
    
    if(clienteDaRicercare == null)
    {
        Console.WriteLine();
        Console.WriteLine("Cliente non registrato!");
        Console.WriteLine();
        return;
    }
   
    Console.WriteLine();
    Console.WriteLine("Cliente trovato, si vuole procedere con la modifica dei dati (sì/no) ?: ");
    string rispostaModificaCliente = Console.ReadLine();
    if(rispostaModificaCliente == "no")
    {
        return;
    }
    else
    {
        ModificaCliente(codiceFiscaleCliente);
    }

}
void ModificaCliente( string codiceFiscaleCliente)
{
    Cliente clienteDaModificare = banca.RicercaCliente(codiceFiscaleCliente);
    if (clienteDaModificare == null)
    {
        Console.WriteLine("Cliente non registrato!");
        return;
    }

    Console.Write("Digitare il nuovo nome: ");
    string Nome = Console.ReadLine();
    if (Nome != "")
    {
        clienteDaModificare.Nome = Nome;
    }

    Console.Write("Digitare il nuovo cognome: ");
    string Cognome = Console.ReadLine();
    if (Cognome != "")
    {
        clienteDaModificare.Cognome = Cognome;
    }

    Console.Write("Digitare il nuovo codice fiscale: ");
    string CodiceFiscale = Console.ReadLine();
    if (CodiceFiscale != "")
    {
        clienteDaModificare.CodiceFiscale = CodiceFiscale;
    }

    Console.WriteLine("Digitare il nuovo stipendio: ");
    int Stipendio = Convert.ToInt32(Console.ReadLine());
    if (Stipendio > 0)
    {
        clienteDaModificare.Stipendio = Stipendio;
    }
}
void EffettuaPrestito()
{
    Console.Write("Inserire codice fiscale cliente: ");
    string codiceFiscaleCliente = Console.ReadLine();

    Cliente clientePrestito = banca.RicercaCliente(codiceFiscaleCliente);
    if (clientePrestito == null)
    {
        Console.WriteLine("Cliente non registrato!");
        return;
    }
    Console.WriteLine("Cliente trovato");
    Console.WriteLine();
    Console.Write("Digitare ID prestito: ");
    int idPrestito = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digitare l'ammontare totale del prestito: ");
    int ammontarePrestito = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digitare la rata del prestito: ");
    float rataPrestito = Convert.ToInt32(Console.ReadLine());
    Console.Write("Digitare la data di fine prestito (dd/mm/yyyy)");
    DateTime dataFinePrestito = DateTime.Parse(Console.ReadLine());

    Prestito nuovoPrestito = new Prestito(idPrestito, clientePrestito.Nome, ammontarePrestito, rataPrestito, dataFinePrestito);

    if (banca.AggiungiPrestito(nuovoPrestito))
    {
        Console.WriteLine();
        Console.WriteLine("Nuovo prestito registrato correttamente!");
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Errore di compilazione!");
        Console.WriteLine();
    }
}