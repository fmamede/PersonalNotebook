using System;
using System.Collections.Generic;

static class NotebookInterface
{
    public static List<Evento> eventos = new List<Evento>();

    public static void AdicionarEvento(Evento e)
    {
        eventos.Add(e);
    }

    public static void SortByDate()
    {
        eventos.Sort((x, y) => y.Data.CompareTo(x.Data));
        eventos.Reverse();
    }
}
