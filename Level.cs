using System;
public class Level {
    private int floorCell;
    private int width;
    private int height;
    private Cell[,] map;
    private int cratesCount;
    private Random rand;

    public Level(int crates = 2) {
        rand = new Random();
        cratesCount = crates;
        width = rand.Next(2,4) * 3 + 2;
        height = width;
    }

    public void generate() {
        map = new Cell[width,height];
        floorCell = 0;

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
                    randomTemplate = Templates.getRandom();
                    randomTemplate.randomRotation();
                    if (attempt > 100) {
                        Console.WriteLine("Max attemp reach, please generate again");
                        return;
                    }
                    attempt++;
                }
                
                placeTemplate(randomTemplate, x, y);
            }
        }
    }

    private bool spawnCrates(int n) {

        int x, y, surroundWall, attempt = 0;
        for (int i = 0; i < n; i++) {

            do {
                x = rand.Next(2, width-2);
                y = rand.Next(2, height-2);

                surroundWall = 0;
                surroundWall += (map[x-1,y] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x+1,y] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x,y-1] == Cell.Wall) ? 1 : 0;
                surroundWall += (map[x,y+1] == Cell.Wall) ? 1 : 0;

                if (attempt >= floorCell) {
                    Console.WriteLine("Can't generate crates ! Max attempt reach");
                    return false;
                }
                attempt++;

            } while(map[x,y] != Cell.Floor || surroundWall >= 2);

            map[x,y] = Cell.Crate;
        }
        return true;
    }

    private bool spawnPlayer() {
        int x, y, attempt = 0;
        do {
            x = rand.Next(1, width-1);
            y = rand.Next(1, height-1);

            if (attempt >= floorCell) {
                Console.WriteLine("Can't generate player ! Max attempt reach");
                return false;
            }
            attempt++;

        } while(map[x,y] != Cell.Floor);

        map[x,y] = Cell.Player;
        return true;
    }

    private bool spawnGoals(int n) {
        int x, y, attempt = 0;
        for (int i = 0; i < n; i++) {
            bool isValidGoal = false;
            do {
                x = rand.Next(1, width-1);
                y = rand.Next(1, height-1);

                if (map[x, y+1] == Cell.Floor && map[x, y+2] == Cell.Floor)
                {
                    isValidGoal = true;
                }
                else if (map[x, y-1] == Cell.Floor && map[x, y-2] == Cell.Floor)
                {
                    isValidGoal = true;
                }
                else if (map[x+1, y] == Cell.Floor && map[x+2, y] == Cell.Floor)
                {
                    isValidGoal = true;
                }
                else if (map[x-1, y] == Cell.Floor && map[x-2, y] == Cell.Floor)
                {
                    isValidGoal = true;
                }

                if (attempt >= floorCell) {
                    Console.WriteLine("Can't generate goals ! Max attemp reach");
                    return false;
                }
                attempt++;

            } while(map[x,y] != Cell.Floor || isValidGoal == false);

            map[x,y] = Cell.Goal;
        }
        return true;
    }

    public bool postProcess() {
        bool complete = false;
        cleanDeadCell();
        complete |= cleanUselessRoom();
        cleanAloneWall();
        cleanDeadCell();
        //To optimize, before spawning crates mark all deadCell
        //Spawn Crate only on non deacCell
        //Need to improve deadCell algorithm too
        complete &= spawnCrates(cratesCount);
        complete &= spawnGoals(cratesCount);
        complete &= spawnPlayer();
        return complete;
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
                        if (rand.Next(0,100) < 30) {
                            map[x,y] = Cell.Floor;
                        }
                    }
                }
            }
        }
    }

    private bool cleanUselessRoom() {

        int filledFloor = 0;
        int attempt = 0;
        int x = rand.Next(1,width-1);
        int y = rand.Next(1,height-1);

        do
        {
            CellToWall(Cell.FloorFilled);
            while (map[x,y] != Cell.Floor) {
                x = rand.Next(1,width-1);
                y = rand.Next(1,height-1);
                if (attempt > width*height) {
                    return false;
                }
                attempt++;
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
        return true;
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