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
    Console.WriteLine("Inserisci il nome cliente");
    string nomeCliente = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome cliente");
    string cognomeCliente = Console.ReadLine();
    Console.WriteLine("Inserisci il codice fiscale del cliente");
    string codiceFiscaleCliente = Console.ReadLine();
    Console.WriteLine("Inserisci lo stipendio cliente");
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