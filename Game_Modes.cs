using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

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
                int Number_Of_Item = Random_Number.Next(1, 5);
                if (Max_Of_PlayerOne_Inventory < PlayerOne_Inventory.Length)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 2:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 3:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 4:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                    }
                }

            }
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 5);
                if (Max_Of_PlayerTwo_Inventory < PlayerTwo_Inventory.Length)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 2:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 3:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 4:
                            PlayerTwo_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                    }
                }
            }
            if (Max_Of_PlayerOne_Inventory > 0 && Max_Of_PlayerTwo_Inventory > 0 && Max_Of_PlayerOne_Inventory != 0 && Max_Of_PlayerTwo_Inventory != 0)
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
                        int Number_Of_Item = Random_Number.Next(1, 5);
                        if (Max_Of_PlayerOne_Inventory < PlayerOne_Inventory.Length)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 2:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 3:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 4:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                            }
                        }

                    }
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 5);
                        if (Max_Of_PlayerTwo_Inventory < PlayerTwo_Inventory.Length)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 2:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 3:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 4:
                                    PlayerTwo_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                            }
                        }
                    }
                    if (Max_Of_PlayerOne_Inventory > 0 && Max_Of_PlayerTwo_Inventory > 0 && Max_Of_PlayerOne_Inventory != 0 && Max_Of_PlayerTwo_Inventory != 0)
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
                            int Who_To_Shoot_At = Random_Number.Next(1, 3);
                            if (Who_To_Shoot_At == 1)
                            {
                                Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                                {
                                    PlayerOne_Lives--;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                        Count_Not_Fired_Shells--;
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                }
                                else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot());
                                    Count_Not_Fired_Shells--;
                                }
                            }
                            else if (Who_To_Shoot_At == 2)
                            {
                                Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                                {
                                    PlayerTwo_Lives--;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                        Count_Not_Fired_Shells--;
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                }
                                else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot(true));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                    PlayerOne_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot());
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                    PlayerTwo_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot(true));
                                Count_Not_Fired_Shells--;
                                if (PlayerTwo_HandCuffed == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            break;
                        case ConsoleKey.D4:
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
                                        Console.Write(Image.All_Player_Items());
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
                                                    List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                    Remove_List.Add("");
                                                    PlayerOne_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
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
                                                        List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                        Remove_List.Add("");
                                                        PlayerOne_Inventory = Remove_List.ToArray();
                                                        Max_Of_PlayerOne_Inventory--;
                                                        Items_Menu = false;
                                                    }

                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D3:
                                                if (PlayerOne_Inventory.Contains("патрончекер") == true)
                                                {
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells], 0));
                                                    List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerOne_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D4:
                                                if (PlayerOne_Inventory.Contains("рандомный патрончекер") == true)
                                                {
                                                    int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells++);
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Index_Of_Shell], Index_Of_Shell, true));
                                                    List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("рандомный патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerOne_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D5:
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
                            int Who_To_Shoot_At = Random_Number.Next(1, 3);
                            if (Who_To_Shoot_At == 1)
                            {
                                Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                                {
                                    PlayerTwo_Lives--;
                                    if (PlayerTwo_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                        Count_Not_Fired_Shells--;
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                }
                                else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot());
                                    Count_Not_Fired_Shells--;
                                }
                            }
                            else if (Who_To_Shoot_At == 2)
                            {
                                Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                                {
                                    PlayerOne_Lives--;
                                    if (PlayerOne_Lives == 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                        Count_Not_Fired_Shells--;
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                }
                                else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot(true));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            break;
                        case ConsoleKey.D2:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerTwo_Lives--;
                                if (PlayerTwo_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                    PlayerTwo_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot());
                                Count_Not_Fired_Shells--;
                            }
                            break;
                        case ConsoleKey.D3:
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                PlayerOne_Lives--;
                                if (PlayerOne_Lives == 0)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                    PlayerOne_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                    Count_Not_Fired_Shells--;
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot(true));
                                Count_Not_Fired_Shells--;
                                if (PlayerOne_HandCuffed == 0)
                                {
                                    Turn_To_Play = 1;
                                }
                            }
                            break;
                        case ConsoleKey.D4:
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
                                        Console.Write(Image.All_Player_Items());
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
                                                    List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                    Remove_List.Add("");
                                                    PlayerTwo_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
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
                                                        List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                        Remove_List.Add("");
                                                        PlayerTwo_Inventory = Remove_List.ToArray();
                                                        Max_Of_PlayerTwo_Inventory--;
                                                        Items_Menu = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D3:
                                                if (PlayerTwo_Inventory.Contains("патрончекер") == true)
                                                {
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells], 0));
                                                    List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerTwo_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D4:
                                                if (PlayerTwo_Inventory.Contains("рандомный патрончекер") == true)
                                                {
                                                    int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells++);
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Index_Of_Shell], Index_Of_Shell, true));
                                                    List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("рандомный патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerTwo_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D5:
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
            int Turn_To_Play = Random_Number.Next(1, 2);

            bool Player_Want_Use_Items = true;

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
                int Number_Of_Item = Random_Number.Next(1, 5);
                if (Max_Of_PlayerOne_Inventory < PlayerOne_Inventory.Length)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 2:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 3:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                        case 4:
                            PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                            Max_Of_PlayerOne_Inventory++;
                            break;
                    }
                }

            }
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 5);
                if (Max_Of_PlayerTwo_Inventory < PlayerTwo_Inventory.Length)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 2:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 3:
                            PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                        case 4:
                            PlayerTwo_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                            Max_Of_PlayerTwo_Inventory++;
                            break;
                    }
                }
            }
            if (Max_Of_PlayerOne_Inventory > 0 && Max_Of_PlayerTwo_Inventory > 0 && Max_Of_PlayerOne_Inventory != 0 && Max_Of_PlayerTwo_Inventory != 0)
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
                        int Number_Of_Item = Random_Number.Next(1, 5);
                        if (Max_Of_PlayerOne_Inventory < PlayerOne_Inventory.Length)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "+хп";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 2:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "наручники";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 3:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                                case 4:
                                    PlayerOne_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                                    Max_Of_PlayerOne_Inventory++;
                                    break;
                            }
                        }

                    }
                    for (int i = 0; i < Count_Of_Items; i++)
                    {
                        int Number_Of_Item = Random_Number.Next(1, 5);
                        if (Max_Of_PlayerTwo_Inventory < PlayerTwo_Inventory.Length)
                        {
                            switch (Number_Of_Item)
                            {
                                case 1:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "+хп";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 2:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "наручники";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 3:
                                    PlayerTwo_Inventory[Max_Of_PlayerTwo_Inventory] = "патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                                case 4:
                                    PlayerTwo_Inventory[Max_Of_PlayerOne_Inventory] = "рандомный патрончекер";
                                    Max_Of_PlayerTwo_Inventory++;
                                    break;
                            }
                        }
                    }
                    if (Max_Of_PlayerOne_Inventory > 0 && Max_Of_PlayerTwo_Inventory > 0 && Max_Of_PlayerOne_Inventory != 0 && Max_Of_PlayerTwo_Inventory != 0)
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
                        if (PlayerOne_Inventory.Contains("Холостой патрон") || PlayerOne_Inventory.Contains("Боевой патрон") || PlayerOne_Inventory.Contains("рандомный патрончекер") || PlayerOne_Inventory.Contains("патрончекер") && Player_Want_Use_Items)
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Will_You_Use_Items(PlayerOne_Name));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    bool Items_Menu = true;
                                    while (Items_Menu && PlayerOne_Inventory.Contains("Холостой патрон") || PlayerOne_Inventory.Contains("Боевой патрон") || PlayerOne_Inventory.Contains("рандомный патрончекер") || PlayerOne_Inventory.Contains("патрончекер"))
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write(Image.All_Player_Items(true, false));
                                        for (int i = 0; i < Max_Of_PlayerOne_Inventory; i++)
                                        {
                                            if (PlayerOne_Inventory[i].Contains("рандомный патрончекер") || PlayerOne_Inventory[i].Contains("патрончекер"))
                                            {
                                                Console.Write(PlayerOne_Inventory[i] + ", ");
                                            }
                                        }
                                        Console.Write("и все.                                                                                                                              ");
                                        Key = Console.ReadKey(true);
                                        switch (Key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                if (PlayerOne_Inventory.Contains("патрончекер") == true)
                                                {
                                                    bool Number_Has_Choosen = false;
                                                    while (!Number_Has_Choosen)
                                                    {
                                                        Console.Write(Image.Choose_Shell_That_You_Check(Count_Not_Fired_Shells));
                                                        Key = Console.ReadKey(true);
                                                        switch (Key.Key) 
                                                        {
                                                            case ConsoleKey.D1:
                                                                if (Count_Not_Fired_Shells >= 0)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[0], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D2:
                                                                if (Count_Not_Fired_Shells >= 1)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[1], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D3:
                                                                if (Count_Not_Fired_Shells >= 2)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[2], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D4:
                                                                if (Count_Not_Fired_Shells >= 3)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[3], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D5:
                                                                if (Count_Not_Fired_Shells >= 4)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[4], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D6:
                                                                if (Count_Not_Fired_Shells >= 5)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[5], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D7:
                                                                if (Count_Not_Fired_Shells >= 6)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[6], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D8:
                                                                if (Count_Not_Fired_Shells >= 7)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[7], 0, false, true));
                                                                    Number_Has_Choosen = true;
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
                                                    List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerOne_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerOne_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D2:
                                                int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells++);
                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[Index_Of_Shell], Index_Of_Shell, true));
                                                List<string> RemoveList = new List<string>(PlayerOne_Inventory);
                                                RemoveList.RemoveAt(RemoveList.IndexOf("рандомный патрончекер"));
                                                RemoveList.Add("");
                                                PlayerOne_Inventory = RemoveList.ToArray();
                                                Max_Of_PlayerOne_Inventory--;
                                                Items_Menu = false;
                                                break;
                                            case ConsoleKey.D3:
                                                Player_Want_Use_Items = false;
                                                Items_Menu = false;
                                                break;
                                            default:
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                break;
                                        }
                                    } 
                                    break;
                                case ConsoleKey.D2:
                                    Player_Want_Use_Items = false;
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        }
                        else if (Count_Not_Fired_Shells == 0)
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
                            Console.Write(Image.Time_To_Load_Shotgun(PlayerOne_Name, Count_Not_Fired_Shells + 1, DBShotgun));
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
                                int Who_To_Shoot_At = Random_Number.Next(1, 3);
                                if (Who_To_Shoot_At == 1)
                                {
                                    Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                    if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                    {
                                        PlayerOne_Lives -= 2;
                                        if (PlayerOne_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                            PlayerOne_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
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
                                        if (PlayerOne_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                            PlayerOne_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                            if (PlayerTwo_HandCuffed == 0)
                                            {
                                                Turn_To_Play = 2;
                                            }
                                        }
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                    else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                    {
                                        Console_WriteReadClear(Image.Blank_Shoot());
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                }
                                else if (Who_To_Shoot_At == 2)
                                {
                                    Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                                    if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                    {
                                        PlayerTwo_Lives -= 2;
                                        if (PlayerTwo_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                            PlayerTwo_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
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
                                        if (PlayerTwo_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                            PlayerTwo_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                            if (PlayerTwo_HandCuffed == 0)
                                            {
                                                Turn_To_Play = 2;
                                            }
                                        }
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                    else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                    {
                                        Console_WriteReadClear(Image.Blank_Shoot(true));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                }
                                break;
                            case ConsoleKey.D2:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives -= 2;
                                    if (PlayerOne_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
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
                                    if (PlayerOne_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot());
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D3:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives -= 2;
                                    if (PlayerTwo_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
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
                                    if (PlayerTwo_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerOne_Lives, PlayerTwo_Lives, true));
                                        if (PlayerTwo_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 2;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot(true));
                                    if (PlayerTwo_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D4:
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
                                            Console.Write(Image.All_Player_Items(false, true));
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
                                                        List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                        Remove_List.Add("");
                                                        PlayerOne_Inventory = Remove_List.ToArray();
                                                        Max_Of_PlayerOne_Inventory--;
                                                        Items_Menu = false;
                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
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
                                                            List<string> Remove_List = new List<string>(PlayerOne_Inventory);
                                                            Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                            Remove_List.Add("");
                                                            PlayerOne_Inventory = Remove_List.ToArray();
                                                            Max_Of_PlayerOne_Inventory--;
                                                            Items_Menu = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    }
                                                    break;
                                                case ConsoleKey.D3:
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
                Player_Want_Use_Items = true;
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
                        if (&& PlayerTwo_Inventory.Contains("Холостой патрон") || PlayerTwo_Inventory.Contains("Боевой патрон") || PlayerTwo_Inventory.Contains("рандомный патрончекер") || PlayerTwo_Inventory.Contains("патрончекер") && Player_Want_Use_Items)
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write(Image.Will_You_Use_Items(PlayerTwo_Name));
                            Key = Console.ReadKey(true);
                            switch (Key.Key)
                            {
                                case ConsoleKey.D1:
                                    bool Items_Menu = true;
                                    while (Items_Menu && PlayerTwo_Inventory.Contains("Холостой патрон") || PlayerTwo_Inventory.Contains("Боевой патрон") || PlayerTwo_Inventory.Contains("рандомный патрончекер") || PlayerTwo_Inventory.Contains("патрончекер"))
                                    {
                                        Console.SetCursorPosition(0, 0);
                                        Console.Write(Image.All_Player_Items(true, false));
                                        for (int i = 0; i < Max_Of_PlayerTwo_Inventory; i++)
                                        {
                                            if (PlayerTwo_Inventory[i].Contains("рандомный патрончекер") || PlayerTwo_Inventory[i].Contains("патрончекер"))
                                            {
                                                Console.Write(PlayerTwo_Inventory[i] + ", ");
                                            }
                                        }
                                        Console.Write("и все.                                                                                                                              ");
                                        Key = Console.ReadKey(true);
                                        switch (Key.Key)
                                        {
                                            case ConsoleKey.D1:
                                                if (PlayerTwo_Inventory.Contains("патрончекер") == true)
                                                {
                                                    bool Number_Has_Choosen = false;
                                                    while (!Number_Has_Choosen)
                                                    {
                                                        Console.Write(Image.Choose_Shell_That_You_Check(Count_Not_Fired_Shells));
                                                        Key = Console.ReadKey(true);
                                                        switch (Key.Key)
                                                        {
                                                            case ConsoleKey.D1:
                                                                if (Count_Not_Fired_Shells >= 0)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[0], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D2:
                                                                if (Count_Not_Fired_Shells >= 1)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[1], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D3:
                                                                if (Count_Not_Fired_Shells >= 2)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[2], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D4:
                                                                if (Count_Not_Fired_Shells >= 3)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[3], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D5:
                                                                if (Count_Not_Fired_Shells >= 4)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[4], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D6:
                                                                if (Count_Not_Fired_Shells >= 5)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[5], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D7:
                                                                if (Count_Not_Fired_Shells >= 6)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[6], 0, false, true));
                                                                    Number_Has_Choosen = true;
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                                break;
                                                            case ConsoleKey.D8:
                                                                if (Count_Not_Fired_Shells >= 7)
                                                                {
                                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[7], 0, false, true));
                                                                    Number_Has_Choosen = true;
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
                                                    List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                    Remove_List.Add("");
                                                    PlayerTwo_Inventory = Remove_List.ToArray();
                                                    Max_Of_PlayerTwo_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                }
                                                break;
                                            case ConsoleKey.D2:
                                                int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells++);
                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[Index_Of_Shell], Index_Of_Shell, true));
                                                List<string> RemoveList = new List<string>(PlayerTwo_Inventory);
                                                RemoveList.RemoveAt(RemoveList.IndexOf("рандомный патрончекер"));
                                                RemoveList.Add("");
                                                PlayerTwo_Inventory = RemoveList.ToArray();
                                                Max_Of_PlayerTwo_Inventory--;
                                                Items_Menu = false;
                                                break;
                                            case ConsoleKey.D3:
                                                Items_Menu = false;
                                                Player_Want_Use_Items = false;
                                                break;
                                            default:
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                break;
                                        }
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    Player_Want_Use_Items = false;
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        }
                        else if (Count_Not_Fired_Shells == 0)
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
                            Console.Write(Image.Time_To_Load_Shotgun(PlayerTwo_Name, Count_Not_Fired_Shells + 1, DBShotgun));
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
                                int Who_To_Shoot_At = Random_Number.Next(1, 3);
                                if (Who_To_Shoot_At == 1)
                                {
                                    if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                    {
                                        PlayerTwo_Lives -= 2;
                                        if (PlayerTwo_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                            PlayerTwo_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
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
                                        if (PlayerTwo_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                            PlayerTwo_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                            if (PlayerOne_HandCuffed == 0)
                                            {
                                                Turn_To_Play = 1;
                                            }
                                        }
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                    else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                    {
                                        Console_WriteReadClear(Image.Blank_Shoot());
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                }
                                else if (Who_To_Shoot_At == 2)
                                {
                                    if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                    {
                                        PlayerOne_Lives -= 2;
                                        if (PlayerOne_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                            PlayerOne_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
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
                                        PlayerOne_Lives--;
                                        if (PlayerOne_Lives <= 0)
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                            PlayerOne_Lives = -1;
                                            Turn_To_Play = 3;
                                            Menu = false;
                                        }
                                        else
                                        {
                                            Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                            if (PlayerOne_HandCuffed == 0)
                                            {
                                                Turn_To_Play = 1;
                                            }
                                        }
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        Menu = false;
                                    }
                                    else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                    {
                                        Console_WriteReadClear(Image.Blank_Shoot(true));
                                        DBShotgun[0] = "null";
                                        DBShotgun[1] = "null";
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                        Menu = false;
                                    }
                                }
                                break;
                            case ConsoleKey.D2:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerTwo_Lives -= 2;
                                    if (PlayerTwo_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3; 
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
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
                                    if (PlayerTwo_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                        PlayerTwo_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot());
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D3:
                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                {
                                    PlayerOne_Lives -= 2;
                                    if (PlayerOne_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
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
                                    PlayerOne_Lives--;
                                    if (PlayerOne_Lives <= 0)
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                        PlayerOne_Lives = -1;
                                        Turn_To_Play = 3;
                                        Menu = false;
                                    }
                                    else
                                    {
                                        Console_WriteReadClear(Image.Live_Shoot(PlayerTwo_Lives, PlayerOne_Lives, true));
                                        if (PlayerOne_HandCuffed == 0)
                                        {
                                            Turn_To_Play = 1;
                                        }
                                    }
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    Menu = false;
                                }
                                else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                {
                                    Console_WriteReadClear(Image.Blank_Shoot(true));
                                    DBShotgun[0] = "null";
                                    DBShotgun[1] = "null";
                                    if (PlayerOne_HandCuffed == 0)
                                    {
                                        Turn_To_Play = 1;
                                    }
                                    Menu = false;
                                }
                                break;
                            case ConsoleKey.D4:
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
                                            Console.Write(Image.All_Player_Items(false, true));
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
                                                        List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                        Remove_List.Add("");
                                                        PlayerTwo_Inventory = Remove_List.ToArray();
                                                        Max_Of_PlayerTwo_Inventory--;
                                                        Items_Menu = false;
                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
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
                                                            List<string> Remove_List = new List<string>(PlayerTwo_Inventory);
                                                            Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                            Remove_List.Add("");
                                                            PlayerTwo_Inventory = Remove_List.ToArray();
                                                            Max_Of_PlayerTwo_Inventory--;
                                                            Items_Menu = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    }
                                                    break;
                                                case ConsoleKey.D3:
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