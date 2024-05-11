using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USG
{
    class Game_Modes : Program
    {
        All_Images Image = new All_Images();

        ConsoleKeyInfo Key = new ConsoleKeyInfo();
        public void Shotgun_Mode()
        {
            //Инициализация всех нужных переменных

            Random Random_Number = new Random();

            int PlayerOne_Lives = 6;
            int PlayerTwo_Lives = 6;

            int PlayerOne_HandCuffed = 0;
            int PlayerTwo_HandCuffed = 0;

            string[] PlayerOne_Inventory = new string[6];
            string[] PlayerTwo_Inventory = new string[6];
            int Max_Of_PlayerOne_Inventory = 0;
            int Max_Of_PlayerTwo_Inventory = 0;
            int Num_To_PlayerOne_Items = 0;

            int Num_To_PlayerTwo_Items = 0;
            int Turn_To_Play = Random_Number.Next(1, 2);

            Console_WriteReadClear(Image.Shotgun_Rules);

            //Игроки выбирают кол-во выдаваемых предметов за раз
            int Count_Of_Items = 0;
            bool Count_Of_Items_Not_Choosen = true;
            while (Count_Of_Items_Not_Choosen)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Choose_Max_Count_Of_Items);
                Count_Of_Items = Convert.ToInt32(Console.ReadLine());
                if (Count_Of_Items > 4 || Count_Of_Items < 0)
                {
                    Console_WriteReadClear(Image.Wrong_Num_For_Count_Of_Items);
                }
                else
                {
                    Count_Of_Items_Not_Choosen = false;
                }
            }

            //Игроки делятся на первого и второго игрока и вводят свои имена
            string PlayerOne_Name = Image.PlayerOne_Name_Input();
            string PlayerTwo_Name = Image.PlayerTwo_Name_Input();

            //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов (в первый раз)
            int Count_Not_Fired_Shells = Random_Number.Next(2, 8);
            string[] Magazine = new string[Count_Not_Fired_Shells];
            int Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);
            int Random_Number_for_Magazine;
            string Temp_For_Magazine;
            Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live, Count_Not_Fired_Shells));
            //Зарядка магазина (8 патронов в максимум)
            for (int i = 0; i < Count_Not_Fired_Shells; i++)
            {
                if (Count_Of_Live > 0)
                {
                    Magazine[i] = "Боевой";
                    Count_Of_Live--;
                }
                else
                {
                    Magazine[i] = "Холостой";
                }
            }
            for (int i = Magazine.Length - 1; i > 0; i--)
            {
                Random_Number_for_Magazine = Random_Number.Next(i + 1);
                Temp_For_Magazine = Magazine[Random_Number_for_Magazine];
                Magazine[Random_Number_for_Magazine] = Magazine[i];
                Magazine[i] = Temp_For_Magazine;
            }
            //Bыдача 2-x предметов
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerOne_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 2:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 3:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                    }
                }

            }
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerTwo_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 2:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 3:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                    }
                }
            }
            if (Count_Of_Items > 0)
            {
                Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items);
            }
            Count_Not_Fired_Shells--;
            //Начало игры
            while (PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
            {
                if (Count_Not_Fired_Shells == -1)
                {
                    //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов (происходит, когда патронов нет)
                    Count_Not_Fired_Shells = Random_Number.Next(2, 8);
                    Magazine = new string[Count_Not_Fired_Shells];
                    Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);
                    Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live, Count_Not_Fired_Shells));
                    //Зарядка магазина (8 патронов в максимум)
                    for (int i = 0; i < Count_Not_Fired_Shells; i++)
                    {
                        if (Count_Of_Live > 0)
                        {
                            Magazine[i] = "Боевой";
                            Count_Of_Live--;
                        }
                        else
                        {
                            Magazine[i] = "Холостой";
                        }
                    }
                    for (int i = Magazine.Length - 1; i > 0; i--)
                    {
                        Random_Number_for_Magazine = Random_Number.Next(i + 1);
                        Temp_For_Magazine = Magazine[Random_Number_for_Magazine];
                        Magazine[Random_Number_for_Magazine] = Magazine[i];
                        Magazine[i] = Temp_For_Magazine;
                    }
                    //Bыдача 2-x предметов
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerOne_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 2:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 3:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                            }
                        }

                    }
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerTwo_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 2:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 3:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                            }
                        }
                    }
                    if (Count_Of_Items > 0)
                    {
                        Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items);
                    }
                    Count_Not_Fired_Shells--;
                }
                while (Turn_To_Play == 1 && Count_Not_Fired_Shells >= 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    if (PlayerTwo_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 1;
                    }
                    //ход первого игрока
                    if (PlayerTwo_HandCuffed > 0)
                    {
                        PlayerTwo_HandCuffed--;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Player_Menu(PlayerOne_Name, PlayerOne_Lives, PlayerTwo_Name, Count_Of_Items));
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Player_Menu(PlayerOne_Name, PlayerOne_Lives, PlayerTwo_Name, Count_Of_Items));
                    }
                    Key = Console.ReadKey(true);
                    switch (Key.Key)
                    {
                        case ConsoleKey.D1:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                    PlayerOne_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerOne_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                    PlayerTwo_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerTwo_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                Count_Not_Fired_Shells--;
                                if (PlayerTwo_HandCuffed == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Count_Of_Items != 0)
                            {
                                if (Max_Of_PlayerOne_Inventory == 0)
                                {
                                    Console_WriteReadClear(Image.Player_Dont_Have_Items);
                                }
                                else
                                {
                                    bool Items_Menu = true;
                                    while (Items_Menu)
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write(Image.All_Player_Items);
                                        for (int i = 0; i < Max_Of_PlayerOne_Inventory; i++)
                                        {
                                            Console.Write(PlayerOne_Inventory[i] + ", ");
                                        }
                                        Console.Write("и все.                                                                                                                              ");
                                        Key = Console.ReadKey(true);
                                        switch (Key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                if (PlayerOne_Inventory.Contains("+хп") == true)
                                                {
                                                    PlayerOne_Lives++;
                                                    Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerOne_Lives));
                                                    int numIndex = Array.IndexOf(PlayerOne_Inventory, "+хп");
                                                    PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Num_To_PlayerOne_Items--;
                                                    Items_Menu = false;
                                                }
                                                break;
                                            case ConsoleKey.D2:
                                                if (PlayerOne_Inventory.Contains("наручники") == true)
                                                {
                                                    if (PlayerTwo_HandCuffed > 0)
                                                    {
                                                        Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                    }
                                                    else
                                                    {
                                                        PlayerTwo_HandCuffed = 2;
                                                        int numIndex = Array.IndexOf(PlayerOne_Inventory, "наручники");
                                                        PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerOne_Inventory--;
                                                        Num_To_PlayerOne_Items--;
                                                        Items_Menu = false;
                                                    }

                                                }
                                                break;
                                            case ConsoleKey.D3:
                                                if (PlayerOne_Inventory.Contains("патрончекер") == true)
                                                {
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells]));
                                                    int numIndex = Array.IndexOf(PlayerOne_Inventory, "патрончекер");
                                                    PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Num_To_PlayerOne_Items--;
                                                    Items_Menu = false;
                                                }
                                                break;
                                            case ConsoleKey.D4:
                                                Items_Menu = false;
                                                break;
                                            default:
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                            }
                            break;
                    }
                }
                while (Turn_To_Play == 2 && Count_Not_Fired_Shells >= 0 && PlayerTwo_HandCuffed == 0)
                {
                    //ход второго игрока
                    if (PlayerOne_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 2;
                    }
                    if (PlayerOne_HandCuffed > 0)
                    {
                        PlayerOne_HandCuffed--;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Player_Menu(PlayerTwo_Name, PlayerTwo_Lives, PlayerOne_Name, Count_Of_Items));
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Player_Menu(PlayerTwo_Name, PlayerTwo_Lives, PlayerOne_Name, Count_Of_Items));
                    }
                    Key = Console.ReadKey(true);
                    switch (Key.Key)
                    {
                        case ConsoleKey.D1:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                    PlayerTwo_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerTwo_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                    PlayerOne_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerOne_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                Count_Not_Fired_Shells--;
                                if (PlayerOne_HandCuffed == 0)
                                {
                                    Turn_To_Play = 1;
                                }
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Count_Of_Items != 0)
                            {
                                if (Max_Of_PlayerTwo_Inventory == 0)
                                {
                                    Console_WriteReadClear(Image.Player_Dont_Have_Items);
                                }
                                else if (Max_Of_PlayerTwo_Inventory > 0)
                                {
                                    bool Items_Menu = true;
                                    while (Items_Menu)
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write(Image.All_Player_Items);
                                        for (int i = 0; i < Max_Of_PlayerTwo_Inventory; i++)
                                        {
                                            Console.Write(PlayerTwo_Inventory[i] + ", ");
                                        }
                                        Console.Write("и все.                                                                                                                              ");
                                        Key = Console.ReadKey(true);
                                        switch (Key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                if (PlayerTwo_Inventory.Contains("+хп") == true)
                                                {
                                                    PlayerTwo_Lives++;
                                                    Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerTwo_Lives));
                                                    int numIndex = Array.IndexOf(PlayerTwo_Inventory, "+хп");
                                                    PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Num_To_PlayerTwo_Items--;
                                                    Items_Menu = false;
                                                }
                                                break;
                                            case ConsoleKey.D2:
                                                if (PlayerTwo_Inventory.Contains("наручники") == true)
                                                {
                                                    if (PlayerOne_HandCuffed > 0)
                                                    {
                                                        Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                    }
                                                    else
                                                    {
                                                        PlayerOne_HandCuffed = 2;
                                                        int numIndex = Array.IndexOf(PlayerTwo_Inventory, "наручники");
                                                        PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerTwo_Inventory--;
                                                        Num_To_PlayerTwo_Items--;
                                                        Items_Menu = false;
                                                    }
                                                }
                                                break;
                                            case ConsoleKey.D3:
                                                if (PlayerTwo_Inventory.Contains("патрончекер") == true)
                                                {
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells]));
                                                    int numIndex = Array.IndexOf(PlayerTwo_Inventory, "патрончекер");
                                                    PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Num_To_PlayerTwo_Items--;
                                                    Items_Menu = false;
                                                }
                                                break;
                                            case ConsoleKey.D4:
                                                Items_Menu = false;
                                                break;
                                            default:
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                            }
                            break;
                        default:
                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                            break;
                    }
                }
            }
        }
        public void DoubleBarreledShotgun_Mode()
        {
            //Инициализация всех нужных переменных

            Random Random_Number = new Random();

            int PlayerOne_Lives = 8;
            int PlayerTwo_Lives = 8;

            int PlayerOne_HandCuffed = 0;
            int PlayerTwo_HandCuffed = 0;

            string[] PlayerOne_Inventory = new string[6];
            string[] PlayerTwo_Inventory = new string[6];
            int Max_Of_PlayerOne_Inventory = 0;
            int Max_Of_PlayerTwo_Inventory = 0;
            int Num_To_PlayerOne_Items = 0;

            int Num_To_PlayerTwo_Items = 0;
            int Turn_To_Play = Random_Number.Next(1, 2);

            Console_WriteReadClear(Image.DoubleBarreledShotgun_Rules);

            //Игроки выбирают кол-во выдаваемых предметов за раз
            int Count_Of_Items = 0;
            bool Count_Of_Items_Not_Choosen = true;
            while (Count_Of_Items_Not_Choosen)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Choose_Max_Count_Of_Items);
                Count_Of_Items = Convert.ToInt32(Console.ReadLine());
                if (Count_Of_Items > 4 || Count_Of_Items < 0)
                {
                    Console_WriteReadClear(Image.Wrong_Num_For_Count_Of_Items);
                }
                else
                {
                    Count_Of_Items_Not_Choosen = false;
                }
            }

            //Игроки делятся на первого и второго игрока и вводят свои имена
            string PlayerOne_Name = Image.PlayerOne_Name_Input();
            string PlayerTwo_Name = Image.PlayerTwo_Name_Input();

            //Распределение патронов, извучка их игрокам и выдача 2-х предметов (в первый раз)
            int Count_Not_Fired_Shells = Random_Number.Next(2, 8);
            while (Count_Not_Fired_Shells % 2 != 0)
            {
                Count_Not_Fired_Shells = Random_Number.Next(2, 8);
            }
            string[] Handful_Of_Shells = new string[Count_Not_Fired_Shells];
            string[] DBShotgun = {"null", "null"};
            int Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);
            int Random_Number_for_Handful_Of_Shells;
            string Temp_For_Handful_Of_Shells;
            Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live, Count_Not_Fired_Shells));
            for (int i = 0; i < Count_Not_Fired_Shells; i++)
            {
                if (Count_Of_Live > 0)
                {
                    Handful_Of_Shells[i] = "Боевой";
                    Count_Of_Live--;
                }
                else
                {
                    Handful_Of_Shells[i] = "Холостой";
                }
            }
            for (int i = Handful_Of_Shells.Length - 1; i > 0; i--)
            {
                Random_Number_for_Handful_Of_Shells = Random_Number.Next(i + 1);
                Temp_For_Handful_Of_Shells = Handful_Of_Shells[Random_Number_for_Handful_Of_Shells];
                Handful_Of_Shells[Random_Number_for_Handful_Of_Shells] = Handful_Of_Shells[i];
                Handful_Of_Shells[i] = Temp_For_Handful_Of_Shells;
            }
            //Bыдача 2-x предметов
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerOne_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 2:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                        case 3:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            Num_To_PlayerOne_Items++;
                            break;
                    }
                }

            }
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 4);
                if (Max_Of_PlayerTwo_Inventory < 6)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 2:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                        case 3:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            Num_To_PlayerTwo_Items++;
                            break;
                    }
                }
            }
            if (Count_Of_Items > 0)
            {
                Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items);
            }
            Count_Not_Fired_Shells--;
            //Начало игры
            while (PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
            {
                if (Count_Not_Fired_Shells == -1)
                {
                    //Распределение патронов, извучка их игрокам и выдача 2-х предметов (происходит, когда патронов нет)
                    Count_Not_Fired_Shells = Random_Number.Next(2, 8);
                    while (Count_Not_Fired_Shells % 2 != 0)
                    {
                        Count_Not_Fired_Shells = Random_Number.Next(2, 8);
                    }
                    Handful_Of_Shells = new string[Count_Not_Fired_Shells];
                    Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);
                    Console_WriteReadClear(Image.How_Live_Shells_Will_Be(Count_Of_Live, Count_Not_Fired_Shells));
                    for (int i = 0; i < Count_Not_Fired_Shells; i++)
                    {
                        if (Count_Of_Live > 0)
                        {
                            Handful_Of_Shells[i] = "Боевой";
                            Count_Of_Live--;
                        }
                        else
                        {
                            Handful_Of_Shells[i] = "Холостой";
                        }
                    }
                    for (int i = Handful_Of_Shells.Length - 1; i > 0; i--)
                    {
                        Random_Number_for_Handful_Of_Shells = Random_Number.Next(i + 1);
                        Temp_For_Handful_Of_Shells = Handful_Of_Shells[Random_Number_for_Handful_Of_Shells];
                        Handful_Of_Shells[Random_Number_for_Handful_Of_Shells] = Handful_Of_Shells[i];
                        Handful_Of_Shells[i] = Temp_For_Handful_Of_Shells;
                    }
                    //Bыдача 2-x предметов
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerOne_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 2:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                                case 3:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    Num_To_PlayerOne_Items++;
                                    break;
                            }
                        }

                    }
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 4);
                        if (Max_Of_PlayerTwo_Inventory < 6)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 2:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                                case 3:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    Num_To_PlayerTwo_Items++;
                                    break;
                            }
                        }
                    }
                    if (Count_Of_Items > 0)
                    {
                        Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items);
                    }
                    Count_Not_Fired_Shells--;
                }
                if (Count_Not_Fired_Shells == 0)
                {
                    Console_WriteReadClear(Image.Last_Shell_Was_Inserted);
                    if (DBShotgun[0].Contains("null"))
                    {
                        DBShotgun[0] = Handful_Of_Shells[0];
                    }
                    else
                    {
                        DBShotgun[1] = Handful_Of_Shells[0];
                    }
                    Count_Not_Fired_Shells--;
                }
                while (Turn_To_Play == 1 && Count_Not_Fired_Shells > 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    //ход первого игрока
                    if (PlayerTwo_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 1;
                    }
                    //зарядка двустволки игроком
                    while (DBShotgun[0].Contains("null") || DBShotgun[1].Contains("null"))
                    {
                        /* это часть кода для будущих предметов - пока его не брать во внимание
                        if(PlayerOne_Inventory.Contains("Холостой патрон") == false || PlayerOne_Inventory.Contains("Боевой патрон") == false)
                        {
                            Console_WriteReadClear(Image.Time_To_Load_Shotgun(Count_Not_Fired_Shells, true));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        } */
                        if (Count_Not_Fired_Shells == 0)
                        {
                            Console_WriteReadClear(Image.Last_Shell_Was_Inserted);
                            if (DBShotgun[0].Contains("null"))
                            {
                                DBShotgun[0] = Handful_Of_Shells[0];
                            }
                            else
                            {
                                DBShotgun[1] = Handful_Of_Shells[0];
                            }
                            Count_Not_Fired_Shells--;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Time_To_Load_Shotgun(Count_Not_Fired_Shells + 1, DBShotgun));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    try
                                    {
                                        if (Handful_Of_Shells[0].Contains("Холостой") || Handful_Of_Shells[0].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[0];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 0).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[0];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 0).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D2:
                                    try
                                    {
                                        if (Handful_Of_Shells[1].Contains("Холостой") || Handful_Of_Shells[1].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[1];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 1).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[1];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 1).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D3:
                                    try
                                    {
                                        if (Handful_Of_Shells[2].Contains("Холостой") || Handful_Of_Shells[2].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[2];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 2).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[2];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 2).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D4:
                                    try
                                    {
                                        if (Handful_Of_Shells[3].Contains("Холостой") || Handful_Of_Shells[3].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[3];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 3).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[3];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 3).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D5:
                                    try
                                    {
                                        if (Handful_Of_Shells[4].Contains("Холостой") || Handful_Of_Shells[4].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[4];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 4).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[4];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 4).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D6:
                                    try
                                    {
                                        if (Handful_Of_Shells[5].Contains("Холостой") || Handful_Of_Shells[5].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[5];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 5).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[5];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 5).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D7:
                                    try
                                    {
                                        if (Handful_Of_Shells[6].Contains("Холостой") || Handful_Of_Shells[6].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[6];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 6).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[6];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 6).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D8:
                                    try
                                    {
                                        if (Handful_Of_Shells[7].Contains("Холостой") || Handful_Of_Shells[7].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[7];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 7).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[7];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 7).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }

                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        }
                    }
                    bool Menu = true;
                    while (Menu)
                    {
                        if (PlayerTwo_HandCuffed > 0)
                        {
                            PlayerTwo_HandCuffed--;
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Player_Menu(PlayerOne_Name, PlayerOne_Lives, PlayerTwo_Name, Count_Of_Items));
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Player_Menu(PlayerOne_Name, PlayerOne_Lives, PlayerTwo_Name, Count_Of_Items));
                        }
                        Key = Console.ReadKey(true);
                        switch (Key.Key)
                        {
                            case ConsoleKey.D1:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives = -2;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerOne_Lives));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives--;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerOne_Lives));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D2:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives = -2;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerTwo_Lives));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives--;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerTwo_Lives));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D3:
                                if (Count_Of_Items != 0)
                                {
                                    if (Max_Of_PlayerOne_Inventory == 0)
                                    {
                                        Console_WriteReadClear(Image.Player_Dont_Have_Items);
                                    }
                                    else
                                    {
                                        bool Items_Menu = true;
                                        while (Items_Menu)
                                        {
                                            Console.SetCursorPosition(0, 0);
                                            Console.Write(Image.All_Player_Items);
                                            for (int i = 0; i < Max_Of_PlayerOne_Inventory; i++)
                                            {
                                                Console.Write(PlayerOne_Inventory[i] + ", ");
                                            }
                                            Console.Write("и все.                                                                                                                              ");
                                            Key = Console.ReadKey(true);
                                            switch (Key.Key)
                                            {
                                                case ConsoleKey.D1:
                                                    if (PlayerOne_Inventory.Contains("+хп") == true)
                                                    {
                                                        PlayerOne_Lives++;
                                                        Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerOne_Lives));
                                                        int numIndex = Array.IndexOf(PlayerOne_Inventory, "+хп");
                                                        PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerOne_Inventory--;
                                                        Num_To_PlayerOne_Items--;
                                                        Items_Menu = false;
                                                    }
                                                    break;
                                                case ConsoleKey.D2:
                                                    if (PlayerOne_Inventory.Contains("наручники") == true)
                                                    {
                                                        if (PlayerTwo_HandCuffed > 0)
                                                        {
                                                            Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                        }
                                                        else
                                                        {
                                                            PlayerTwo_HandCuffed = 2;
                                                            int numIndex = Array.IndexOf(PlayerOne_Inventory, "наручники");
                                                            PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                            Max_Of_PlayerOne_Inventory--;
                                                            Num_To_PlayerOne_Items--;
                                                            Items_Menu = false;
                                                        }

                                                    }
                                                    break;
                                                case ConsoleKey.D3:
                                                    if (PlayerOne_Inventory.Contains("патрончекер") == true)
                                                    {
                                                        Console.Write(Image.Which_Shell_You_Want_To_Check);
                                                        Key = Console.ReadKey(true);
                                                        switch (Key.Key)
                                                        {
                                                            case ConsoleKey.D1:
                                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(DBShotgun[0]));
                                                                break;
                                                            case ConsoleKey.D2:
                                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(DBShotgun[1]));
                                                                break;
                                                            default:
                                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                break;
                                                        }
                                                        int numIndex = Array.IndexOf(PlayerOne_Inventory, "патрончекер");
                                                        PlayerOne_Inventory = PlayerOne_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerOne_Inventory--;
                                                        Num_To_PlayerOne_Items--;
                                                        Items_Menu = false;
                                                    }
                                                    break;
                                                case ConsoleKey.D4:
                                                    Items_Menu = false;
                                                    break;
                                                default:
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                }
                                break;
                        }
                    }
                }
                if (Count_Not_Fired_Shells == 0)
                {
                    Console_WriteReadClear(Image.Last_Shell_Was_Inserted);
                    if (DBShotgun[0].Contains("null"))
                    {
                        DBShotgun[0] = Handful_Of_Shells[0];
                    }
                    else
                    {
                        DBShotgun[1] = Handful_Of_Shells[0];
                    }
                    Count_Not_Fired_Shells--;
                }
                while (Turn_To_Play == 2 && Count_Not_Fired_Shells > 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    //ход второго игрока
                    if (PlayerOne_HandCuffed - 1 == 0)
                    {
                        Turn_To_Play = 1;
                    }
                    //зарядка двустволки игроком
                    while (DBShotgun[0].Contains("null") || DBShotgun[1].Contains("null"))
                    {
                        /* это часть кода для будущих предметов - пока его не брать во внимание
                        if(PlayerOne_Inventory.Contains("Холостой патрон") == false || PlayerOne_Inventory.Contains("Боевой патрон") == false)
                        {
                            Console_WriteReadClear(Image.Time_To_Load_Shotgun(Count_Not_Fired_Shells, true));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        } */
                        if (Count_Not_Fired_Shells == 0)
                        {
                            Console_WriteReadClear(Image.Last_Shell_Was_Inserted);
                            if (DBShotgun[0].Contains("null"))
                            {
                                DBShotgun[0] = Handful_Of_Shells[0];
                            }
                            else
                            {
                                DBShotgun[1] = Handful_Of_Shells[0];
                            }
                            Count_Not_Fired_Shells--;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Time_To_Load_Shotgun(Count_Not_Fired_Shells + 1, DBShotgun));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    try
                                    {
                                        if (Handful_Of_Shells[0].Contains("Холостой") || Handful_Of_Shells[0].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[0];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 0).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[0];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 0).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D2:
                                    try
                                    {
                                        if (Handful_Of_Shells[1].Contains("Холостой") || Handful_Of_Shells[1].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[1];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 1).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[1];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 1).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D3:
                                    try
                                    {
                                        if (Handful_Of_Shells[2].Contains("Холостой") || Handful_Of_Shells[2].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[2];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 2).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[2];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 2).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D4:
                                    try
                                    {
                                        if (Handful_Of_Shells[3].Contains("Холостой") || Handful_Of_Shells[3].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[3];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 3).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[3];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 3).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D5:
                                    try
                                    {
                                        if (Handful_Of_Shells[4].Contains("Холостой") || Handful_Of_Shells[4].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[4];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 4).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[4];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 4).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D6:
                                    try
                                    {
                                        if (Handful_Of_Shells[5].Contains("Холостой") || Handful_Of_Shells[5].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[5];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 5).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[5];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 5).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D7:
                                    try
                                    {
                                        if (Handful_Of_Shells[6].Contains("Холостой") || Handful_Of_Shells[6].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[6];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 6).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[6];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 6).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                case ConsoleKey.D8:
                                    try
                                    {
                                        if (Handful_Of_Shells[7].Contains("Холостой") || Handful_Of_Shells[7].Contains("Боевой"))
                                        {
                                            if (DBShotgun[0].Contains("null"))
                                            {
                                                DBShotgun[0] = Handful_Of_Shells[7];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 7).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }
                                            else if (DBShotgun[1].Contains("null"))
                                            {
                                                DBShotgun[1] = Handful_Of_Shells[7];
                                                Handful_Of_Shells = Handful_Of_Shells.Where((val, idx) => idx != 7).ToArray();
                                                Count_Not_Fired_Shells--;
                                            }

                                        }
                                    }
                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        }
                    }
                    bool Menu = true;
                    while (Menu)
                    {
                        if (PlayerOne_HandCuffed > 0)
                        {
                            PlayerOne_HandCuffed--;
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Player_Menu(PlayerTwo_Name, PlayerTwo_Lives, PlayerOne_Name, Count_Of_Items));
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Player_Menu(PlayerTwo_Name, PlayerTwo_Lives, PlayerOne_Name, Count_Of_Items));
                        }
                        Key = Console.ReadKey(true);
                        switch (Key.Key)
                        {
                            case ConsoleKey.D1:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives = -2;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3; 
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerTwo_Lives));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives--;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yourself_Dead);
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Yoursef_Alive(PlayerTwo_Lives));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Blank_Shot_Yourself);
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D2:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives = -2;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerOne_Lives));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives--;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Dead);
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shot_Opponent_Alive(PlayerOne_Lives));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Blank_Shot_Opponent);
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D3:
                                if (Count_Of_Items != 0)
                                {
                                    if (Max_Of_PlayerTwo_Inventory == 0)
                                    {
                                        Console_WriteReadClear(Image.Player_Dont_Have_Items);
                                    }
                                    else
                                    {
                                        bool Items_Menu = true;
                                        while (Items_Menu)
                                        {
                                            Console.SetCursorPosition(0, 0);
                                            Console.Write(Image.All_Player_Items);
                                            for (int i = 0; i < Max_Of_PlayerTwo_Inventory; i++)
                                            {
                                                Console.Write(PlayerTwo_Inventory[i] + ", ");
                                            }
                                            Console.Write("и все.                                                                                                                              ");
                                            Key = Console.ReadKey(true);
                                            switch (Key.Key)
                                            {
                                                case ConsoleKey.D1:
                                                    if (PlayerTwo_Inventory.Contains("+хп") == true)
                                                    {
                                                        PlayerTwo_Lives++;
                                                        Console_WriteReadClear(Image.Count_Player_Lives_After_Heal(PlayerTwo_Lives));
                                                        int numIndex = Array.IndexOf(PlayerTwo_Inventory, "+хп");
                                                        PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerTwo_Inventory--;
                                                        Num_To_PlayerTwo_Items--;
                                                        Items_Menu = false;
                                                    }
                                                    break;
                                                case ConsoleKey.D2:
                                                    if (PlayerTwo_Inventory.Contains("наручники") == true)
                                                    {
                                                        if (PlayerOne_HandCuffed > 0)
                                                        {
                                                            Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                        }
                                                        else
                                                        {
                                                            PlayerOne_HandCuffed = 2;
                                                            int numIndex = Array.IndexOf(PlayerTwo_Inventory, "наручники");
                                                            PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                            Max_Of_PlayerTwo_Inventory--;
                                                            Num_To_PlayerTwo_Items--;
                                                            Items_Menu = false;
                                                        }

                                                    }
                                                    break;
                                                case ConsoleKey.D3:
                                                    if (PlayerTwo_Inventory.Contains("патрончекер") == true)
                                                    {
                                                        Console.Write(Image.Which_Shell_You_Want_To_Check);
                                                        Key = Console.ReadKey(true);
                                                        switch (Key.Key)
                                                        {
                                                            case ConsoleKey.D1:
                                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(DBShotgun[0]));
                                                                break;
                                                            case ConsoleKey.D2:
                                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(DBShotgun[1]));
                                                                break;
                                                            default:
                                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                break;
                                                        }
                                                        int numIndex = Array.IndexOf(PlayerTwo_Inventory, "патрончекер");
                                                        PlayerTwo_Inventory = PlayerTwo_Inventory.Where((val, idx) => idx != numIndex).ToArray();
                                                        Max_Of_PlayerTwo_Inventory--;
                                                        Num_To_PlayerTwo_Items--;
                                                        Items_Menu = false;
                                                    }
                                                    break;
                                                case ConsoleKey.D4:
                                                    Items_Menu = false;
                                                    break;
                                                default:
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    break;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}