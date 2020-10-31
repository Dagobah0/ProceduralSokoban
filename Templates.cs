using System;
using System.Collections.Generic;
public static class Templates {
    private static Cell[,] template1 = new Cell[,] {
        {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[,] template2 = new Cell[,] {
        {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static List<Cell[,]> templates = new List<Cell[,]> {
        template1,
    };


    public static Template getRandom() {
      Random r = new Random();
      Cell[,] randTemplate = templates[r.Next(templates.Count)];
      return new Template(randTemplate);
    }
}