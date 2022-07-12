using System;
using Safor.Services;

namespace Safor.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmlManager reader = new EmlManager(@"C: \Users\d.gussoni\Desktop\Davide\PersonalWorkspace\[Ticket_TK20181223_24877]_informazioni_privacy.eml");
            reader.RenameEmail();
        }
    }
}
