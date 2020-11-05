using System;
using System.Collections.Generic;
public static class Templates {
    private static Cell[][] template1 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };
    private static Cell[][] template2 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template3 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template4 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template5 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template6 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template7 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template8 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
    };

    private static Cell[][] template9 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
    };

    private static Cell[][] template10 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Floor, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template11 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template12 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Wall, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };
    private static Cell[][] template13 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template14 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Null, Cell.Null, Cell.Null},
    };

    private static Cell[][] template15 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Floor, Cell.Null, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Floor, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Null, Cell.Floor, Cell.Null},
    };

    private static Cell[][] template16 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
    };

    private static Cell[][] template17 = new Cell[][] {
        new Cell [] {Cell.Null, Cell.Null, Cell.Null, Cell.Null, Cell.Null},
        new Cell [] {Cell.Null, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Null},
        new Cell [] {Cell.Floor, Cell.Floor, Cell.Wall, Cell.Floor, Cell.Floor},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Floor, Cell.Null},
        new Cell [] {Cell.Null, Cell.Floor, Cell.Floor, Cell.Null, Cell.Null},
    };

    private static List<Cell[][]> templates = new List<Cell[][]> {
        template1,
        template2,
        template3,
        template4,
        template5,
        template6,
        template7,
        template8,
        template9,
        template10,
        template11,
        template12,
        template13,
        template14,
        template15,
        template16,
        template17,
    };


    public static Template getRandom() {
      Random r = new Random();
      Cell[][] randTemplate = templates[r.Next(templates.Count)];
      return new Template(randTemplate);
    }
}