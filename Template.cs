using System;
public class Template {
    private Cell[][] template;

    public Template(Cell[][] content) {
        template = new Cell[content.Length][];

        for (var x = 0; x < content.Length; x++)
        {
            var newer = new Cell[content[x].Length];
            Array.Copy(content[x], newer, content[x].Length);
            template[x] = newer;
        }
    }

    public Cell GetCell(int x, int y) {
        return template[x][y];
    }

    public void randomRotation() {
        Random r = new Random();
        for(int i = 0; i < r.Next(5); i++) {
            rotate();
        }
    }

    private void rotate() {
        int width = template.Length;
        int heigth = template[0].Length;
        // Array transposition
        for(int y = 0; y < heigth; y++) {
            for(int x = y; x < width; x++) {
                Cell tmpCell = template[y][x];
                template[y][x] = template[x][y];
                template[x][y] = tmpCell;
            }
        }

        // Reverse each row
        for(int y = 0; y < heigth; y++) {
            for(int x = 0; x < width/ 2; x++) {
                Cell tmpCell = template[y][x];
                template[y][x] = template[y][width-1-x];
                template[y][width-1-x] = tmpCell;
            }
        }

    }

    public override string ToString()
    {
        string ret = "";
        for (int x = 0; x < template.Length; x++) {
            for (int y = 0; y < template[x].Length; y++) {
                switch(template[x][y]) {
                    case Cell.Wall:
                        ret += "#";
                        break;
                    case Cell.Floor:
                        ret += " ";
                        break;
                    default:
                        ret += "N";
                        break;
                }
            }
            ret += "\n";
        }
        return ret;
    }
}