Console.WriteLine("Введите размер игрового поля:");
int n = int.Parse(Console.ReadLine());
Random random = new Random();
char[,] grid = new char[n, n];
int lenght = 5;
int health = 5;
char appel = '0';
int[,]appelGeo = new int[1, 2];
char[] snake = new char[lenght];
Array.Fill(snake, 'x');
int[,]geoSnake = new int[lenght,3];
for (int i = 0; i < geoSnake.GetLength(1); i++) geoSnake[0, i]
        = snake.Length - i - 1;
appelGeo[0,0] = random.Next(n);
appelGeo[0, 1] = random.Next(n);
ConsoleKey geo = ConsoleKey.RightArrow;
do
{
    Console.Clear();
    Console.WriteLine("Health:"+health);
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            grid[i, j] = ',';
        }
    }
        switch (geo)
        {
           case ConsoleKey.RightArrow:
        case ConsoleKey.D:
            {
                for (int i = snake.Length - 1; i > 0; i--)
                {
                    geoSnake[i, 0] = geoSnake[i - 1, 0];
                    geoSnake[i, 1] = geoSnake[i - 1, 1];
                }
                int temp = ++geoSnake[0, 1];
                geoSnake[0, 1] = temp;
                try
                {
                    for (int i = 0; i < snake.Length; i++)
                    {
                        int x = geoSnake[i, 0];
                        int y = geoSnake[i, 1];
                        grid[x, y] = 'X';
                    }

                }
                catch (Exception ex)
                {
                    health--;
              
                    for (int i = 0; i < geoSnake.GetLength(1); i++) geoSnake[0, i]
                            = snake.Length - i - 1;
                    geo = ConsoleKey.RightArrow;

                }
               }     break;
            case ConsoleKey.DownArrow:case ConsoleKey.S:
            {
                for (int i = snake.Length - 1; i > 0; i--)
                {
                    geoSnake[i, 0] = geoSnake[i - 1, 0];
                    geoSnake[i, 1] = geoSnake[i - 1, 1];
                }
                int temp = ++geoSnake[0, 0];
                geoSnake[0, 0] = temp;
                try
                {
                    for (int i = 0; i < snake.Length; i++)
                    {
                        int x = geoSnake[i, 0];
                        int y = geoSnake[i, 1];
                        grid[x, y] = 'X';
                    }
                }
                catch
                {
                    health--;

                    for (int i = 0; i < geoSnake.GetLength(1); i++) geoSnake[0, i]
                            = snake.Length - i - 1;
                    geo = ConsoleKey.RightArrow;

                }

            }
            
            break;
            case ConsoleKey.LeftArrow:case ConsoleKey.A:
            {
                for (int i = snake.Length - 1; i > 0; i--)
                {
                    geoSnake[i, 0] = geoSnake[i - 1, 0];
                    geoSnake[i, 1] = geoSnake[i - 1, 1];
                }
                
                
                int temp = --geoSnake[0, 1];
                geoSnake[0, 1] = temp;
                try
                {
                    for (int i = 0; i < snake.Length; i++)
                    {
                        int x = geoSnake[i, 0];
                        int y = geoSnake[i, 1];
                        grid[x, y] = 'X';
                    }
                }
                catch
                {
                    health--;

                    for (int i = 0; i < geoSnake.GetLength(1); i++) geoSnake[0, i]
                            = snake.Length - i - 1;
                    geo = ConsoleKey.RightArrow;

                }
            }
            break;
            case ConsoleKey.UpArrow:case ConsoleKey.W:
            {
                for (int i = snake.Length - 1; i > 0; i--)
                {
                    geoSnake[i, 0] = geoSnake[i - 1, 0];
                    geoSnake[i, 1] = geoSnake[i - 1, 1];
                }


                int temp = --geoSnake[0, 0];
                geoSnake[0, 0] = temp;
                try
                {
                    for (int i = 0; i < snake.Length; i++)
                    {
                        int x = geoSnake[i, 0];
                        int y = geoSnake[i, 1];
                        grid[x, y] = 'X';
                    }
                }
                catch
                {
                    health--;

                    for (int i = 0; i < geoSnake.GetLength(1); i++) geoSnake[0, i]
                            = snake.Length - i - 1;

                }


            }
            break;
        }
    grid[appelGeo[0, 0], appelGeo[0,1]] = appel;
    if (geoSnake[0, 1] == appelGeo[0, 1] && geoSnake[0, 0] == appelGeo[0, 0])
    {
        lenght++;
        int[,]temp = new int[lenght,2];
        Array.Copy(geoSnake,temp,geoSnake.Length);
        snake = new char[lenght];
        Array.Fill(snake, 'X');
        geoSnake=new int[lenght,2];
        Array.Copy(temp, geoSnake, temp.Length);
        appelGeo[0, 0] = random.Next(n);
        appelGeo[0, 1] = random.Next(n);
    }
        for(int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            Console.Write(grid[i,j]+" ");
        }
        Console.WriteLine();
    }
    if (Console.KeyAvailable)
    {
        geo = Console.ReadKey().Key;
    }
        Thread.Sleep(500);
    if (health == 0) break;
    
}
while (true);
Console.WriteLine("Game finish");