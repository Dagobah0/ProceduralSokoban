using System;
public class Template {
    private Cell[,] template;

    public Template(Cell[,] content) {
        this.template = content;
    }

    public Cell[,] GetTemp() { return template; }

    public Cell GetCell(int x, int y) {
        return template[x,y];
    }

    public void randomRotation() {
        Random r = new Random();
        /*for(int i = 0; i < r.Next(5); i++) {
            rotate();
        }*/
        this.rotate();
    }

    private void rotate() {
        // Array transposition
        for(int x = 1; x < template.GetLength(0); x++) {
            Cell tmpCell = template[x,0];
            template[x,0] = template[0,x];
            template[0,x] = tmpCell;
        }
        for(int y = 1; y < template.GetLength(1); y++) {
            Cell tmpCell = template[template.GetLength(0)-1,y];
            template[template.GetLength(0)-1,y] = template[y,template.GetLength(1)-1];
            template[y,template.GetLength(1)-1] = tmpCell;
        }

        // Reverse each row
        for(int y = 0; y < template.GetLength(1); y++) {
            for(int x = 0; x < template.GetLength(0) / 2; x++) {
                Cell tmpCell = template[x,y];
                template[x,y] = template[template.GetLength(0)-1-x,y];
                template[template.GetLength(0)-1-x,y] = tmpCell;
            }
        }
    }

    public override string ToString()
    {
        string ret = "";
        for (int y = 0; y < template.GetLength(1); y++) {
            for (int x = 0; x < template.GetLength(0); x++) {
                switch(template[x,y]) {
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