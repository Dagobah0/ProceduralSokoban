using System;
public class Level {

    private const int ALLOWED_TRY = 10;

    private int floorCell;
    private int width;
    private int height;
    private Cell[,] map;
    public Level() {
        Random r = new Random();
        /*this.width = r.Next(1,4) * 3 + 2;
        this.height = r.Next(1,4) * 3 + 2;*/
        this.width = 3 * 3 + 2;
        this.height = 3 * 3 + 2;
        this.map = new Cell[width,height];
        floorCell = 0;
    }

    public void generate() {
        //Wall generation around level
        for (int x = 0; x < width; x++) {
            map[0,x] = Cell.Wall;
            map[height-1,x] = Cell.Wall;
        }
        for (int y = 1; y < height-1; y++) {
            map[y,0] = Cell.Wall;
            map[y,width-1] = Cell.Wall;
        }
        
        int attempt = 0;
        //Template generation
        for (int x = 1; x < width-2; x+= 3) {
            for (int y = 1; y < height-2; y += 3) {

                Template randomTemplate = Templates.getRandom();
                randomTemplate.randomRotation();

                while(placementAllowed(randomTemplate,x,y) != true) {
                    if (attempt == ALLOWED_TRY) {
                        //TODO 
                        // Regenerate map
                        attempt = 0;
                    }
                    randomTemplate = Templates.getRandom();
                    randomTemplate.randomRotation();
                    attempt++;
                }
                
                placeTemplate(randomTemplate, x, y);
            }
        }
    }

    public void postProcess() {
        bool valid = true;
        valid = isFloorContiguous();
    }

    private bool isFloorContiguous() {
        return true;
    }

    private bool placementAllowed(Template template, int x, int y) {
        bool allowed = true;

        for (int i = -1; i < 4; i++) {
            if (x+i > -1 && x+i < width) {
                Cell upperCellMap = map[x+i,y-1];
                Cell lowerCellMap = map[x+i,y+3];
                if (upperCellMap != Cell.Null || lowerCellMap != Cell.Null) {
                    Cell upperCell = template.GetCell(i+1,0);
                    Cell lowerCell = template.GetCell(i+1,4);
                    
                    if (upperCell != Cell.Null && lowerCell != Cell.Null) {
                        if (upperCell != upperCellMap || lowerCell != lowerCellMap) {
                            allowed = false;
                            break;
                        }
                    }
                } 
            }
        }

        for (int j = 0; j < 4; j++) {
            if (y+j < height) {
                Cell leftCellMap = map[x-1,y+j];
                Cell rigthCellMap = map[x+3,y+j];
                if (leftCellMap != Cell.Null || rigthCellMap != Cell.Null) {
                    Cell leftCell = template.GetCell(0,j+1);
                    Cell rigthCell = template.GetCell(4,j+1);
                    if (leftCell != Cell.Null && rigthCell != Cell.Null) {
                        if (leftCell != leftCellMap || rigthCell != rigthCellMap) {
                            allowed = false;
                            break;
                        }
                    }
                }
            }
        }
        return allowed;
    }

    private void placeTemplate(Template template, int x, int y) {
        for(int i = -1; i < 4; i++) {
            for(int j = -1; j < 4; j++) {
                if (x+i > 0 && y+j > 0 && x+i < width-1 && y+j < height-1) {
                    Cell cell = template.GetCell(i+1,j+1);
                    if (cell != Cell.Null) {
                        if (cell == Cell.Floor) {
                            floorCell++;
                        }
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
                        Console.Write("N"); //Only for debug, delete in production
                        break;
                }
                if (y%3 == 0) {
                    Console.Write("|");
                }
            }
            Console.WriteLine();
            if (x%3 == 0) {
                    Console.WriteLine("---------------");
            }
        }
    }

    public override string ToString()
    {
        string ret = "";
        for(int x = 0; x < width; x++) {
            for(int y = 0; y < height; y++) {
                switch(map[x,y]) {
                    case Cell.Floor:
                        ret += " ";
                        break;
                    case Cell.Wall:
                        ret += "#";
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