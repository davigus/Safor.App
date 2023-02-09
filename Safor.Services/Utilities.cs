using System;
using System.IO;
using MsgReader;
using Safor.Services.Models;
using System.Linq;
using System.Collections.Generic;

namespace Safor.Services
{
    public static class Utilities
    {
      public static string SetAndValidateDate(string date, out DateTime dateTime)
      {
        dateTime = DateTime.Today;
        if(date.Length != 8)
        {
            return "Inserisci una data corretta, il formato è aaaammgg";
        }
        int year, month, day;
        bool isValidYear = int.TryParse(date.Substring(0,4), out year);
        bool isValidMonth  = int.TryParse(date.Substring(4,2), out month);
        bool isValidDay = int.TryParse(date.Substring(4,2), out day);
        if(!isValidDay | !isValidMonth | !isValidYear)
        {
            return "Inserisci una data corretta, il formato è aaaammgg";
        }
        if(month < 0 | month > 12)
        {
            return "Inserisci una data corretta, il mese non è corretto. Il formato è aaaammgg";
        }
        
        dateTime = new DateTime(year, month, day);
        return string.Empty;
      } 
    }
}
