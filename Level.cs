using System;
public class Level {

    private int width;
    private int height;

    private Cell[,] map;
    public Level() {
        Random r = new Random();
        this.width = r.Next(1,4) * 3;
        this.height = r.Next(1,4) * 3;
        this.map = new Cell[width,height];
    }

    public void generate() {
        for (int x = 0; x < width; x+= 3) {
            for (int y = 0; y < height; y += 3) {
                Template randomTemplate = Templates.getRandom();
                randomTemplate.randomRotation();
                placeTemplate(randomTemplate, x, y);
            }
        }
    }

    private void placeTemplate(Template template, int x, int y) {
        for(int i = -1; i < 4; i++) {
            for(int j = -1; j < 4; j++) {
                if (x+i >= 0 && y+j >= 0 && x+i < width && y+j < height) {
                    Cell cell = template.GetCell(i+1,j+1);
                    if (cell != Cell.Null) {
                        map[x+i,y+j] = cell;
                    } 
                } 
            }
        }
    }

    public void print() {
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                switch(map[x,y]) {
                    case Cell.Floor:
                        Console.Write(" ");
                        break;
                    case Cell.Wall:
                        Console.Write("#");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}