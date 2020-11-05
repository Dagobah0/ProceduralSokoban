using System;
public class Level {

    private const int ALLOWED_TRY = 10;

    private int floorCell;
    private int width;
    private int height;
    private Cell[,] map;
    private int cratesCount;

    public Level(int cratesCount) {
        Random r = new Random();
        //this.width = r.Next(1,10) * 3 + 2;
        //height = width;
        this.width = 3 * 3 + 2;
        this.height = 3 * 3 + 2;
        this.map = new Cell[width,height];
        floorCell = 0;
        this.cratesCount = cratesCount;
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
        
        //Template generation
        int attempt = 0;
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

    private void spawnCrates(int n) {

        Random r = new Random();
        int x, y, surroundWall = 0;
        for (int i = 0; i < n; i++) {

            do {
                x = r.Next(2, width-2);
                y = r.Next(2, height-2);

                surroundWall = 0;
                surroundWall += (map[x-1,y] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x+1,y] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x,y-1] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x,y+1] == Cell.Wall) ? 1 : 0;

            } while(map[x,y] != Cell.Floor || surroundWall >= 2);

            map[x,y] = Cell.Crate;
        }
    }

    private void spawnPlayer() {
        Random r = new Random();
        int x, y = 0;
        do {
            x = r.Next(1, width-1);
            y = r.Next(1, height-1);

        } while(map[x,y] != Cell.Floor);

        map[x,y] = Cell.Player;
    }

    private void spawnGoals(int n) {
        Random r = new Random();
        int x, y, attempt = 0;
        bool isValidGoal = false;
        for (int i = 0; i < n; i++) {

            do {
                x = r.Next(1, width-1);
                y = r.Next(1, height-1);

                if (map[x, y+1] == Cell.Floor)
                {
                    if (map[x, y+2] == Cell.Floor)
                    {
                        isValidGoal = true;
                    }
                    else {
                        isValidGoal = false;
                    }
                }
                else if (map[x, y-1] == Cell.Floor)
                {
                    if (map[x, y-2] == Cell.Floor)
                    {
                        isValidGoal = true;
                    }
                    else {
                        isValidGoal = false;
                    }
                }
                else if (map[x+1, y] == Cell.Floor)
                {
                    if (map[x+2, y] == Cell.Floor)
                    {
                        isValidGoal = true;
                    }
                    else {
                        isValidGoal = false;
                    }
                }
                else if (map[x-1, y] == Cell.Floor)
                {
                    if (map[x-2, y] == Cell.Floor)
                    {
                        isValidGoal = true;
                    }
                    else {
                        isValidGoal = false;
                    }
                }
                else {
                    isValidGoal = false;
                }

                if (attempt > 200) {
                    break;
                }
                attempt++;

            } while(map[x,y] != Cell.Floor || isValidGoal == false);

            map[x,y] = Cell.Goal;
        }
    }

    public void postProcess() {
        cleanDeadCell();
        cleanUselessRoom();
        cleanAloneWall();
        cleanDeadCell();
        spawnCrates(cratesCount);
        spawnGoals(cratesCount);
        spawnPlayer();
    }

    private void cleanAloneWall() {
        for(int x = 1; x < width-1; x++) {
            for (int y = 1; y < height-1; y++) {
                if (map[x,y] == Cell.Wall) {
                    int surroundFloor = 0;
                    surroundFloor += (map[x-1,y] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x+1,y] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x,y-1] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x,y+1] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x-1,y-1] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x+1,y-1] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x+1,y+1] == Cell.Floor) ? 1 : 0;
                    surroundFloor += (map[x+1,y-1] == Cell.Floor) ? 1 : 0;

                    if (surroundFloor > 6) {
                        Random r = new Random();
                        if (r.Next(0,100) < 30) {
                            map[x,y] = Cell.Floor;
                        }
                    }
                }
            }
        }
    }

    private void cleanUselessRoom() {
        Random r = new Random();

        int filledFloor = 0;
        int x = r.Next(1,width-1);
        int y = r.Next(1,height-1);

        do
        {
            CellToWall(Cell.FloorFilled);
            while (map[x,y] != Cell.Floor) {
                x = r.Next(1,width-1);
                y = r.Next(1,height-1);
            }
            filledFloor += floodFill(Cell.Floor, Cell.FloorFilled, x, y);
        } while (filledFloor < (int)floorCell * 0.5f);

        for(int i = 1; i < width; i++) {
            for (int j = 1; j < height; j++) {
                if (map[i,j] == Cell.Floor) {
                    map[i,j] = Cell.Wall;
                }
                else if (map[i,j] == Cell.FloorFilled) {
                    map[i,j] = Cell.Floor;
                }
            }
        }
    }

    private void CellToWall(Cell type) {
        for(int x = 1; x < width; x++) {
            for (int y = 1; y < height; y++) {
                if (map[x,y] == type) {
                    map[x,y] = Cell.Wall;
                }
            }
        }
    }

    private int floodFill(Cell target, Cell replace, int x, int y) {
        int filledFloor = 0;
        if (target == replace) { return 0; }
        else if (map[x,y] != target) { return 0; }
        else { 
            map[x,y] = replace;
            filledFloor++;
        }

        if (x+1 < width-1) {
            filledFloor += floodFill(target, replace, x-1, y);
        }
        if (x-1 > 0) {
            filledFloor += floodFill(target, replace, x+1, y);
        }
        if (y+1 < height-1) {
            filledFloor += floodFill(target, replace, x, y+1);
        }
        if (y-1 > 0) {
            filledFloor += floodFill(target, replace, x, y-1);
        }

        return filledFloor;
    }

    private void cleanDeadCell() {
        for (int x = 1; x < width - 1; x++) {
            for (int y = 1; y < height -1; y++) {
                if (map[x,y] == Cell.Floor) {
                    int surroundWall = 0;
                    surroundWall += (map[x-1,y] == Cell.Wall) ? 1 : 0;
                    surroundWall += (map[x+1,y] == Cell.Wall) ? 1 : 0;
                    surroundWall += (map[x,y-1] == Cell.Wall) ? 1 : 0;
                    surroundWall += (map[x,y+1] == Cell.Wall) ? 1 : 0;
                    if (surroundWall >= 3) {
                        map[x,y] = Cell.Wall;
                    }
                }
            }
        }
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
                    case Cell.Crate:
                        Console.Write("$");
                        break;
                    case Cell.Goal:
                        Console.Write(".");
                        break;
                    case Cell.Player:
                        Console.Write("@");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
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
                    case Cell.Goal:
                        ret += ".";
                        break;
                    case Cell.Wall:
                        ret += "#";
                        break;
                    case Cell.Player:
                        ret += "@";
                        break;
                    case Cell.Crate:
                        ret += "$";
                        break;
                    default:
                        break;
                }
            }
            ret += "\n";
        }
        return ret;
    }
}