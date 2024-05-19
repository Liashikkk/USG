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

        Random Random_Number = new Random();
        private void Give_Items(ref string[] Player_Inventory, ref int Count_Of_Items, ref int Max_Of_Player_Inventory, bool Player_Bleeding_Phase)
        {
            for (int i = 0; i < Count_Of_Items; i++)
            {
                int Number_Of_Item = Random_Number.Next(1, 9);
                if (Max_Of_Player_Inventory < Player_Inventory.Length)
                {
                    switch (Number_Of_Item)
                    {
                        case 1:
                            if (Player_Bleeding_Phase)
                            {
                                Player_Inventory[Max_Of_Player_Inventory] = "бинт";
                                Max_Of_Player_Inventory++;
                            }
                            else
                            {
                                Player_Inventory[Max_Of_Player_Inventory] = "+хп";
                                Max_Of_Player_Inventory++;
                            }
                            break;
                        case 2:
                            Player_Inventory[Max_Of_Player_Inventory] = "наручники";
                            Max_Of_Player_Inventory++;
                            break;
                        case 3:
                            Player_Inventory[Max_Of_Player_Inventory] = "патрончекер";
                            Max_Of_Player_Inventory++;
                            break;
                        case 4:
                            Player_Inventory[Max_Of_Player_Inventory] = "рандомный патрончекер";
                            Max_Of_Player_Inventory++;
                            break;
                        case 5:
                            Player_Inventory[Max_Of_Player_Inventory] = "инвертор";
                            Max_Of_Player_Inventory++;
                            break;
                        case 6:
                            Player_Inventory[Max_Of_Player_Inventory] = "холостой патрон";
                            Max_Of_Player_Inventory++;
                            break;
                        case 7:
                            Player_Inventory[Max_Of_Player_Inventory] = "боевой патрон";
                            Max_Of_Player_Inventory++;
                            break;
                        case 8:
                            Player_Inventory[Max_Of_Player_Inventory] = "удвоитель урона";
                            Max_Of_Player_Inventory++;
                            break;
                    }
                }

            }
        }
        private void Shotgun_Shells_Insert(ref int Count_Not_Fired_Shells, ref int Count_Of_Live, ref string[] Magazine)
        {
            //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов
            int Random_Number_for_Magazine;
            string Temp_For_Magazine;
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
        }
        private void DoubleBarrel_Shotgun_Handful_Of_Shells(ref int Count_Not_Fired_Shells, ref int Count_Of_Live, ref string[] Handful_Of_Shells)
        {
            //Распределение патронов, извучка их игрокам, зарядка их в магазин и выдача 2-х предметов
            int Random_Number_for_Handful_Of_Shells;
            string Temp_For_Handful_Of_Shells;
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
        }
        private void Shotgun_Player_Turn(ref bool Player_Double_Damage, ref int Turn_To_Play, ref string Player_Name, ref int Player_Lives, ref bool Player_First_Time_Bleeding, ref bool Opponent_First_Time_Bleeding, ref int Opponent_Lives, ref string Opponent_Name, ref int Count_Of_Items, ref int Opponent_HandCuffed, ref bool Player_Bleeding_Phase, ref int Player_Bleeding_Turns, ref int Count_Of_Player_Bleedings, ref bool Opponent_Bleeding_Phase, ref int Opponent_Bleeding_Turns, ref int Count_Of_Opponent_Bleedings, ref string[] Magazine, ref int Count_Not_Fired_Shells, ref int Max_Of_Player_Inventory, ref string[] Player_Inventory, ref string[] Opponent_Inventory)
        {
            if (Opponent_HandCuffed > 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Player_Menu(Player_Name, Player_Lives, Opponent_Name, Count_Of_Items, true, Player_Bleeding_Phase, Player_Bleeding_Turns));
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Player_Menu(Player_Name, Player_Lives, Opponent_Name, Count_Of_Items, false, Player_Bleeding_Phase, Player_Bleeding_Turns));
            }
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        int Who_To_Shoot_At = Random_Number.Next(1, 3);
                        if (Who_To_Shoot_At == 1)
                        {
                            Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Player_Lives -= 2;
                                }
                                else
                                {
                                    Player_Lives--;
                                }
                                if (Player_Bleeding_Phase == false && Player_Lives == 0)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Player_Bleedings == 0)
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Count_Of_Player_Bleedings = 4;
                                            Player_Lives = 1;
                                        }
                                        else
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Player_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Player_Lives = -1;
                                    }
                                }
                                if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                                {
                                    Player_Lives = -1;
                                }
                                else
                                {
                                    Player_Lives = 1;
                                }
                                if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                                {
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Player_Bleeding_Phase));
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Player_Bleeding_Phase));
                                    Count_Not_Fired_Shells--;
                                    if (Player_First_Time_Bleeding)
                                    {
                                        Player_First_Time_Bleeding = false;
                                        if (Player_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                            for (int i = 0; i < Player_Inventory.Length; i++)
                                            {
                                                if (Player_Inventory[i] == "+хп")
                                                {
                                                    Player_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Player_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                if (Opponent_HandCuffed > 0)
                                {
                                    Opponent_HandCuffed--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                Console_WriteReadClear(Image.Blank_Shoot());
                                if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                                {
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                                }
                                else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                                {
                                    Opponent_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                                }
                                Count_Not_Fired_Shells--;
                                Player_First_Time_Bleeding = false;
                            }
                        }
                        else if (Who_To_Shoot_At == 2)
                        {
                            Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                            if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Opponent_Lives -= 2;
                                }
                                else
                                {
                                    Opponent_Lives--;
                                }
                                if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Count_Of_Opponent_Bleedings = 4;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Opponent_Bleedings == 0)
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Count_Of_Opponent_Bleedings = 2;
                                            Opponent_Lives = 1;
                                        }
                                        else
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Opponent_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Opponent_Lives = -1;
                                    }
                                }
                                if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                                {
                                    Opponent_Lives = -1;
                                }
                                else
                                {
                                    Opponent_Lives = 1;
                                }
                                if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                                {
                                    Opponent_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Opponent_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                    Count_Not_Fired_Shells--;
                                    if (Opponent_First_Time_Bleeding)
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                        if (Opponent_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                            for (int i = 0; i < Opponent_Inventory.Length; i++)
                                            {
                                                if (Opponent_Inventory[i] == "+хп")
                                                {
                                                    Opponent_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                            }
                            else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot(true));
                                Count_Not_Fired_Shells--;
                                Opponent_First_Time_Bleeding = false;
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                                {
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                                }
                                else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                                {
                                    Opponent_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                        }
                        break;
                    case 2:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Player_Lives -= 2;
                            }
                            else
                            {
                                Player_Lives--;
                            }
                            if (Player_Bleeding_Phase == false && Player_Lives == 0)
                            {
                                if (Count_Of_Player_Bleedings == 0)
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Count_Of_Player_Bleedings = 4;
                                    Player_Lives = 1;
                                }
                                else
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Player_Lives = 1;
                                }
                            }
                            else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Player_Lives = -1;
                                }
                            }
                            if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                            {
                                Player_Lives = -1;
                            }
                            else
                            {
                                Player_Lives = 1;
                            }
                            if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                            {
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Player_Bleeding_Phase));
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Player_Bleeding_Phase));
                                Count_Not_Fired_Shells--;
                                if (Player_First_Time_Bleeding)
                                {
                                    Player_First_Time_Bleeding = false;
                                    if (Player_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                        for (int i = 0; i < Player_Inventory.Length; i++)
                                        {
                                            if (Player_Inventory[i] == "+хп")
                                            {
                                                Player_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Player_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                        }
                        else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                        {
                            if (Opponent_HandCuffed > 0)
                            {
                                Opponent_HandCuffed--;
                            }
                            if (Opponent_Bleeding_Turns > 0)
                            {
                                Opponent_Bleeding_Turns--;
                            }
                            Console_WriteReadClear(Image.Blank_Shoot());
                            if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                            {
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                            }
                            else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                            {
                                Opponent_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                            }
                            Count_Not_Fired_Shells--;
                            Player_First_Time_Bleeding = false;
                        }
                        break;
                    case 3:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Opponent_Lives -= 2;
                            }
                            else
                            {
                                Opponent_Lives--;
                            }
                            if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                            {
                                if (Count_Of_Opponent_Bleedings == 0)
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Count_Of_Opponent_Bleedings = 4;
                                    Opponent_Lives = 1;
                                }
                                else
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Opponent_Lives = 1;
                                }
                            }
                            else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Count_Of_Opponent_Bleedings = 2;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Opponent_Lives = -1;
                                }
                            }
                            if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                            {
                                Opponent_Lives = -1;
                            }
                            else
                            {
                                Opponent_Lives = 1;
                            }
                            if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                            {
                                Opponent_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Opponent_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                Count_Not_Fired_Shells--;
                                if (Opponent_First_Time_Bleeding)
                                {
                                    Opponent_First_Time_Bleeding = false;
                                    if (Opponent_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                        for (int i = 0; i < Opponent_Inventory.Length; i++)
                                        {
                                            if (Opponent_Inventory[i] == "+хп")
                                            {
                                                Opponent_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Opponent_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                        }
                        else if (Magazine[Count_Not_Fired_Shells] == "Холостой")
                        {
                            Console_WriteReadClear(Image.Blank_Shoot(true));
                            Count_Not_Fired_Shells--;
                            Opponent_First_Time_Bleeding = false;
                            if (Player_Bleeding_Turns > 0)
                            {
                                Player_Bleeding_Turns--;
                            }
                            if (Opponent_Bleeding_Turns > 0)
                            {
                                Opponent_Bleeding_Turns--;
                            }
                            if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                            {
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                            }
                            else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                            {
                                Opponent_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                            }
                            if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                            {
                                Turn_To_Play = 2;
                            }
                        }
                        break;
                    case 4:
                        if (Count_Of_Items != 0)
                        {
                            if (Max_Of_Player_Inventory == 0)
                            {
                                Console_WriteReadClear(Image.Player_Dont_Have_Items);
                            }
                            else
                            {
                                bool Items_Menu = true;
                                while (Items_Menu)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write(Image.All_Player_Items(Player_Bleeding_Phase));
                                    for (int i = 0; i < Max_Of_Player_Inventory; i++)
                                    {
                                        Console.Write(Player_Inventory[i] + ", ");
                                    }
                                    Console.Write("и все.                                                                                                                              ");
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            if (Player_Bleeding_Phase && Player_Inventory.Contains("бинт") == true)
                                            {
                                                Player_Bleeding_Phase = false;
                                                Count_Of_Player_Bleedings--;
                                                Player_Bleeding_Turns = 0;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("бинт"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else if (Player_Inventory.Contains("+хп") == true)
                                            {
                                                Player_Lives++;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else if (Player_Inventory.Contains("бинт") == true)
                                            {
                                                Console_WriteReadClear(Image.You_Dont_Bleeding_Out);
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 2:
                                            if (Player_Inventory.Contains("наручники") == true)
                                            {
                                                if (Opponent_HandCuffed > 0)
                                                {
                                                    Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                }
                                                else
                                                {
                                                    Opponent_HandCuffed = 2;
                                                    List<string> Remove_List = new List<string>(Player_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                    Remove_List.Add("");
                                                    Player_Inventory = Remove_List.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                }

                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 3:
                                            if (Player_Inventory.Contains("патрончекер") == true)
                                            {
                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells], 0));
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 4:
                                            if (Player_Inventory.Contains("рандомный патрончекер") == true)
                                            {
                                                int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells);
                                                Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Magazine[Count_Not_Fired_Shells - Index_Of_Shell], Index_Of_Shell + 1, true));
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("рандомный патрончекер"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 5:
                                            if (Player_Inventory.Contains("инвертор") == true)
                                            {
                                                if (Magazine[Count_Not_Fired_Shells] == "Боевой")
                                                {
                                                    Magazine[Count_Not_Fired_Shells] = "Холостой";
                                                }
                                                else
                                                {
                                                    Magazine[Count_Not_Fired_Shells] = "Боевой";
                                                }
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("инвертор"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 6:
                                            if (Player_Inventory.Contains("боевой патрон") == true && Player_Inventory.Contains("холостой патрон") == true)
                                            {
                                                if (Count_Not_Fired_Shells < 8)
                                                {
                                                    bool Shell_Choosen = false;
                                                    while (!Shell_Choosen)
                                                    {
                                                        Console.SetCursorPosition(0, 0);
                                                        Console.Write(Image.Which_Shell_Will_Be_Inserted);
                                                        List<string> Add_List = new List<string>(Magazine);
                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                        try
                                                        {
                                                            switch (Convert.ToInt32(Console.ReadLine()))
                                                            {
                                                                case 1:
                                                                    Add_List.Insert(0, "Боевой");
                                                                    Magazine = Add_List.ToArray();
                                                                    Shell_Choosen = true;
                                                                    Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                    Remove_List.Add("");
                                                                    Player_Inventory = Remove_List.ToArray();
                                                                    Max_Of_Player_Inventory--;
                                                                    Count_Not_Fired_Shells++;
                                                                    Items_Menu = false;
                                                                    break;
                                                                case 2:
                                                                    Add_List.Insert(0, "Холостой");
                                                                    Magazine = Add_List.ToArray();
                                                                    Shell_Choosen = true;
                                                                    Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                    Remove_List.Add("");
                                                                    Player_Inventory = Remove_List.ToArray();
                                                                    Max_Of_Player_Inventory--;
                                                                    Count_Not_Fired_Shells++;
                                                                    Items_Menu = false;
                                                                    break;
                                                                default:
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                    break;
                                                            }
                                                        }
                                                        catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }

                                                    }
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.Magazine_Full);
                                                }
                                            }
                                            else if (Player_Inventory.Contains("боевой патрон") == true || Player_Inventory.Contains("холостой патрон") == true)
                                            {
                                                if (Count_Not_Fired_Shells < 8)
                                                {
                                                    List<string> Add_List = new List<string>(Magazine);
                                                    if (Player_Inventory.Contains("боевой патрон") == true)
                                                    {
                                                        Add_List.Insert(0, "Боевой");
                                                        Magazine = Add_List.ToArray(); 
                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                        Remove_List.Add("");
                                                        Player_Inventory = Remove_List.ToArray();
                                                        Max_Of_Player_Inventory--;
                                                        Count_Not_Fired_Shells++;
                                                        Items_Menu = false;
                                                    }
                                                    else
                                                    {
                                                        Add_List.Insert(0, "Холостой");
                                                        Magazine = Add_List.ToArray(); 
                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                        Remove_List.Add("");
                                                        Player_Inventory = Remove_List.ToArray();
                                                        Max_Of_Player_Inventory--;
                                                        Count_Not_Fired_Shells++;
                                                        Items_Menu = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Console_WriteReadClear(Image.Magazine_Full);
                                                }
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 7:
                                            if (Player_Inventory.Contains("удвоитель урона") == true)
                                            {
                                                Player_Double_Damage = true;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("удвоитель урона"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Count_Not_Fired_Shells++;
                                                Items_Menu = false;
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 8:
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
                    case 0:
                        if (Player_Lives == 1)
                        {
                            Console_WriteReadClear(Image.You_Choose_To_Die());
                            Player_Lives = -1;
                            Turn_To_Play = 3;
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
            catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
        }
        private void DoubleBarrel_Shotgun_Insert_Shells(ref string[] DBShotgun, ref string[] Handful_Of_Shells, ref string Player_Name, ref string[] Player_Inventory, ref int Max_Of_Player_Inventory, ref int Count_Not_Fired_Shells)
        {
            //зарядка двустволки игроком
            bool Player_Want_Use_Items = true;
            while (DBShotgun[0].Contains("null") || DBShotgun[1].Contains("null"))
            {
                if (Player_Want_Use_Items)
                {
                    if (Player_Inventory.Contains("холостой патрон") || Player_Inventory.Contains("боевой патрон") || Player_Inventory.Contains("рандомный патрончекер") || Player_Inventory.Contains("патрончекер"))
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write(Image.Will_You_Use_Items(Player_Name));
                        try
                        {
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    bool Items_Menu = true;
                                    if (Player_Inventory.Contains("холостой патрон") || Player_Inventory.Contains("боевой патрон") || Player_Inventory.Contains("рандомный патрончекер") || Player_Inventory.Contains("патрончекер"))
                                    {
                                        while (Items_Menu)
                                        {
                                            Console.SetCursorPosition(0, 0);
                                            Console.Write(Image.All_Player_Items(false, true, false));
                                            for (int i = 0; i < Max_Of_Player_Inventory; i++)
                                            {
                                                if (Player_Inventory[i].Contains("рандомный патрончекер") || Player_Inventory[i].Contains("патрончекер") || Player_Inventory[i].Contains("холостой патрон") || Player_Inventory[i].Contains("боевой патрон"))
                                                {
                                                    Console.Write(Player_Inventory[i] + ", ");
                                                }
                                            }
                                            Console.Write("и все.                                                                                                                              ");
                                            switch (Convert.ToInt32(Console.ReadLine()))
                                            {
                                                case 1:
                                                    if (Player_Inventory.Contains("патрончекер") == true)
                                                    {
                                                        bool Number_Has_Choosen = false;
                                                        while (!Number_Has_Choosen)
                                                        {
                                                            Console.SetCursorPosition(0, 0);
                                                            Console.Write(Image.Choose_Shell_That_You_Check(Count_Not_Fired_Shells + 1));
                                                            switch (Convert.ToInt32(Console.ReadLine()))
                                                            {
                                                                case 1:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[0], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 2:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[1], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 3:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[2], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 4:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[3], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 5:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[4], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 6:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[5], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 7:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[6], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                case 8:
                                                                    try
                                                                    {
                                                                        Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[7], 0, false, true));
                                                                        Number_Has_Choosen = true;
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                    break;
                                                                default:
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                    break;
                                                            }
                                                        }
                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                        Remove_List.RemoveAt(Remove_List.IndexOf("патрончекер"));
                                                        Remove_List.Add("");
                                                        Player_Inventory = Remove_List.ToArray();
                                                        Max_Of_Player_Inventory--;
                                                        Items_Menu = false;
                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    }
                                                    break;
                                                case 2:
                                                    int Index_Of_Shell = Random_Number.Next(0, Count_Not_Fired_Shells);
                                                    Console_WriteReadClear(Image.What_Is_Shell_In_Shotgun(Handful_Of_Shells[Index_Of_Shell], Index_Of_Shell + 1, true));
                                                    List<string> RemoveList = new List<string>(Player_Inventory);
                                                    RemoveList.RemoveAt(RemoveList.IndexOf("рандомный патрончекер"));
                                                    RemoveList.Add("");
                                                    Player_Inventory = RemoveList.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                    break;
                                                case 3:
                                                    if (Player_Inventory.Contains("боевой патрон") == true && Player_Inventory.Contains("холостой патрон") == true)
                                                    {
                                                        bool Shell_Choosen = false;
                                                        while (!Shell_Choosen)
                                                        {
                                                            int Side = -1;
                                                            if (DBShotgun[0].Contains("null") == true && DBShotgun[1].Contains("null") == true)
                                                            {
                                                                Console.SetCursorPosition(0, 0);
                                                                Console.Write(Image.Which_Side_Need_Insert);
                                                                while (Side == -1)
                                                                {
                                                                    try
                                                                    {
                                                                        if (Convert.ToInt32(Console.ReadLine()) == 1)
                                                                        {
                                                                            Side = 0; //левая сторона
                                                                        }
                                                                        else if (Convert.ToInt32(Console.ReadLine()) == 2)
                                                                        {
                                                                            Side = 1; //правая сторона
                                                                        }
                                                                        else
                                                                        {
                                                                            Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                        }
                                                                    }
                                                                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                                }
                                                            }
                                                            Console.SetCursorPosition(0, 0);
                                                            Console.Write(Image.Which_Shell_Will_Be_Inserted);
                                                            try
                                                            {
                                                                if (Convert.ToInt32(Console.ReadLine()) == 1)
                                                                {
                                                                    if (Side > -1)
                                                                    {
                                                                        DBShotgun[Side] = "Боевой";
                                                                        Shell_Choosen = true;
                                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                                        Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                        Remove_List.Add("");
                                                                        Player_Inventory = Remove_List.ToArray();
                                                                        Max_Of_Player_Inventory--;
                                                                        Count_Not_Fired_Shells++;
                                                                        Items_Menu = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (DBShotgun[0].Contains("null"))
                                                                        {
                                                                            DBShotgun[0] = "Боевой";
                                                                            Shell_Choosen = true;
                                                                            List<string> Remove_List = new List<string>(Player_Inventory);
                                                                            Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                            Remove_List.Add("");
                                                                            Player_Inventory = Remove_List.ToArray();
                                                                            Max_Of_Player_Inventory--;
                                                                            Count_Not_Fired_Shells++;
                                                                            Items_Menu = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            DBShotgun[1] = "Боевой";
                                                                            Shell_Choosen = true;
                                                                            List<string> Remove_List = new List<string>(Player_Inventory);
                                                                            Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                            Remove_List.Add("");
                                                                            Player_Inventory = Remove_List.ToArray();
                                                                            Max_Of_Player_Inventory--;
                                                                            Count_Not_Fired_Shells++;
                                                                            Items_Menu = false;
                                                                        }
                                                                    }
                                                                }
                                                                else if (Convert.ToInt32(Console.ReadLine()) == 2)
                                                                {
                                                                    if (Side > -1)
                                                                    {
                                                                        DBShotgun[Side] = "Холостой";
                                                                        Shell_Choosen = true;
                                                                        List<string> Remove_List = new List<string>(Player_Inventory);
                                                                        Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                        Remove_List.Add("");
                                                                        Player_Inventory = Remove_List.ToArray();
                                                                        Max_Of_Player_Inventory--;
                                                                        Count_Not_Fired_Shells++;
                                                                        Items_Menu = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (DBShotgun[0].Contains("null"))
                                                                        {
                                                                            DBShotgun[0] = "Холостой";
                                                                            Shell_Choosen = true;
                                                                            List<string> Remove_List = new List<string>(Player_Inventory);
                                                                            Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                            Remove_List.Add("");
                                                                            Player_Inventory = Remove_List.ToArray();
                                                                            Max_Of_Player_Inventory--;
                                                                            Count_Not_Fired_Shells++;
                                                                            Items_Menu = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            DBShotgun[1] = "Холостой";
                                                                            Shell_Choosen = true;
                                                                            List<string> Remove_List = new List<string>(Player_Inventory);
                                                                            Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                            Remove_List.Add("");
                                                                            Player_Inventory = Remove_List.ToArray();
                                                                            Max_Of_Player_Inventory--;
                                                                            Count_Not_Fired_Shells++;
                                                                            Items_Menu = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                                }
                                                            }
                                                            catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                                                        }
                                                    }
                                                    else if (Player_Inventory.Contains("боевой патрон") == true || Player_Inventory.Contains("холостой патрон") == true)
                                                    {
                                                        if (Player_Inventory.Contains("боевой патрон") == true)
                                                        {
                                                            if (DBShotgun[0].Contains("null"))
                                                            {
                                                                DBShotgun[0] = "Боевой";
                                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                                Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                Remove_List.Add("");
                                                                Player_Inventory = Remove_List.ToArray();
                                                                Max_Of_Player_Inventory--;
                                                                Count_Not_Fired_Shells++;
                                                                Items_Menu = false;
                                                            }
                                                            else
                                                            {
                                                                DBShotgun[1] = "Боевой";
                                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                                Remove_List.RemoveAt(Remove_List.IndexOf("боевой патрон"));
                                                                Remove_List.Add("");
                                                                Player_Inventory = Remove_List.ToArray();
                                                                Max_Of_Player_Inventory--;
                                                                Count_Not_Fired_Shells++;
                                                                Items_Menu = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (DBShotgun[0].Contains("null"))
                                                            {
                                                                DBShotgun[0] = "Холостой";
                                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                                Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                Remove_List.Add("");
                                                                Player_Inventory = Remove_List.ToArray();
                                                                Max_Of_Player_Inventory--;
                                                                Count_Not_Fired_Shells++;
                                                                Items_Menu = false;
                                                            }
                                                            else
                                                            {
                                                                DBShotgun[1] = "Холостой";
                                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                                Remove_List.RemoveAt(Remove_List.IndexOf("холостой патрон"));
                                                                Remove_List.Add("");
                                                                Player_Inventory = Remove_List.ToArray();
                                                                Max_Of_Player_Inventory--;
                                                                Count_Not_Fired_Shells++;
                                                                Items_Menu = false;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    }
                                                    break;
                                                case 4:
                                                    Player_Want_Use_Items = false;
                                                    Items_Menu = false;
                                                    break;
                                                default:
                                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case 2:
                                    Player_Want_Use_Items = false;
                                    break;
                                default:
                                    Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                    break;
                            }
                        }
                        catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                    }
                    else
                    {
                        Player_Want_Use_Items = false;
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
                    Console.Write(Image.Time_To_Load_Shotgun(Player_Name, Count_Not_Fired_Shells + 1, DBShotgun));
                    try
                    {
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
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
                            case 2:
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
                            case 3:
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
                            case 4:
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
                            case 5:
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
                            case 6:
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
                            case 7:
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
                            case 8:
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
                    catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
                }
            }
        }
        private void Double_Barrel(ref bool Player_Double_Damage, ref int Count_Of_Live, ref string[] Handful_Of_Shells, ref int Turn_To_Play, ref string Player_Name, ref int Player_Lives, ref bool Player_First_Time_Bleeding, ref bool Opponent_First_Time_Bleeding, ref int Opponent_Lives, ref string Opponent_Name, ref int Count_Of_Items, ref int Opponent_HandCuffed, ref bool Player_Bleeding_Phase, ref int Player_Bleeding_Turns, ref int Count_Of_Player_Bleedings, ref bool Opponent_Bleeding_Phase, ref int Opponent_Bleeding_Turns, ref int Count_Of_Opponent_Bleedings, ref string[] DBShotgun, ref int Count_Not_Fired_Shells, ref int Max_Of_Player_Inventory, ref string[] Player_Inventory, ref string[] Opponent_Inventory)
        {
            if (Opponent_HandCuffed > 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Player_Menu(Player_Name, Player_Lives, Opponent_Name, Count_Of_Items, true));
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(Image.Player_Menu(Player_Name, Player_Lives, Opponent_Name, Count_Of_Items));
            }
            try
            {
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        int Who_To_Shoot_At = Random_Number.Next(1, 3);
                        if (Who_To_Shoot_At == 1)
                        {
                            Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                            if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Player_Lives -= 4;
                                }
                                else
                                {
                                    Player_Lives -= 2;
                                }
                                if (Player_Bleeding_Phase == false && Player_Lives == 0)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Player_Bleedings == 0)
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Count_Of_Player_Bleedings = 4;
                                            Player_Lives = 1;
                                        }
                                        else
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Player_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Player_Lives = -1;
                                    }
                                }
                                if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                                {
                                    Player_Lives = -1;
                                }
                                else
                                {
                                    Player_Lives = 1;
                                }
                                if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                    if (Player_First_Time_Bleeding)
                                    {
                                        Player_First_Time_Bleeding = false;
                                        if (Player_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                            for (int i = 0; i < Player_Inventory.Length; i++)
                                            {
                                                if (Player_Inventory[i] == "+хп")
                                                {
                                                    Player_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Player_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                            }
                            if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Player_Lives -= 2;
                                }
                                else
                                {
                                    Player_Lives--;
                                }
                                if (Player_Bleeding_Phase == false && Player_Lives == 0)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Player_Bleedings == 0)
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Count_Of_Player_Bleedings = 4;
                                            Player_Lives = 1;
                                        }
                                        else
                                        {
                                            Player_Bleeding_Phase = true;
                                            Player_First_Time_Bleeding = true;
                                            Player_Bleeding_Turns = 9;
                                            Player_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Player_Lives = -1;
                                    }
                                }
                                if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                                {
                                    Player_Lives = -1;
                                }
                                else
                                {
                                    Player_Lives = 1;
                                }
                                if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                    if (Player_First_Time_Bleeding)
                                    {
                                        Player_First_Time_Bleeding = false;
                                        if (Player_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                            for (int i = 0; i < Player_Inventory.Length; i++)
                                            {
                                                if (Player_Inventory[i] == "+хп")
                                                {
                                                    Player_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Player_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                            }
                            else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot());
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                                {
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                                }
                                else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                                {
                                    Opponent_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                                Player_First_Time_Bleeding = false;
                            }
                        }
                        else if (Who_To_Shoot_At == 2)
                        {
                            Console_WriteReadClear(Image.Will_Be_Fired_At(Who_To_Shoot_At));
                            if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Opponent_Lives -= 4;
                                }
                                else
                                {
                                    Opponent_Lives -= 2;
                                }
                                if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Count_Of_Opponent_Bleedings = 4;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Opponent_Bleedings == 0)
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Count_Of_Opponent_Bleedings = 2;
                                            Opponent_Lives = 1;
                                        }
                                        else
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Opponent_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Opponent_Lives = -1;
                                    }
                                }
                                if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                                {
                                    Opponent_Lives = -1;
                                }
                                else
                                {
                                    Opponent_Lives = 1;
                                }
                                if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                                {
                                    Opponent_Lives = -1;
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                    if (Opponent_First_Time_Bleeding)
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                        if (Opponent_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                            for (int i = 0; i < Opponent_Inventory.Length; i++)
                                            {
                                                if (Opponent_Inventory[i] == "+хп")
                                                {
                                                    Opponent_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                            }
                            if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                            {
                                if (Player_Double_Damage)
                                {
                                    Player_Double_Damage = false;
                                    Opponent_Lives -= 2;
                                }
                                else
                                {
                                    Opponent_Lives--;
                                }
                                if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Count_Of_Opponent_Bleedings = 4;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 9;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                                {
                                    int Luck = Random_Number.Next(1, 3);
                                    if (Luck == 1)
                                    {
                                        if (Count_Of_Opponent_Bleedings == 0)
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Count_Of_Opponent_Bleedings = 2;
                                            Opponent_Lives = 1;
                                        }
                                        else
                                        {
                                            Opponent_Bleeding_Phase = true;
                                            Opponent_First_Time_Bleeding = true;
                                            Opponent_Bleeding_Turns = 5;
                                            Opponent_Lives = 1;
                                        }
                                    }
                                    else
                                    {
                                        Opponent_Lives = -1;
                                    }
                                }
                                if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                                {
                                    Opponent_Lives = -1;
                                }
                                else
                                {
                                    Opponent_Lives = 1;
                                }
                                if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                                {
                                    Opponent_Lives = -1;
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                    Turn_To_Play = 3;
                                }
                                else
                                {
                                    Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                    if (Opponent_First_Time_Bleeding)
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                        if (Opponent_Inventory.Contains("+хп"))
                                        {
                                            Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                            for (int i = 0; i < Opponent_Inventory.Length; i++)
                                            {
                                                if (Opponent_Inventory[i] == "+хп")
                                                {
                                                    Opponent_Inventory[i] = "бинт";
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Opponent_First_Time_Bleeding = false;
                                    }
                                    if (Player_Bleeding_Turns > 0)
                                    {
                                        Player_Bleeding_Turns--;
                                    }
                                    if (Opponent_Bleeding_Turns > 0)
                                    {
                                        Opponent_Bleeding_Turns--;
                                    }
                                    if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                    {
                                        Turn_To_Play = 2;
                                    }
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                            }
                            else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                            {
                                Console_WriteReadClear(Image.Blank_Shoot(true));
                                Opponent_First_Time_Bleeding = false;
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                                {
                                    Player_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                                }
                                else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                                {
                                    Opponent_Lives = -1;
                                    Turn_To_Play = 3;
                                    Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                                DBShotgun[0] = "null";
                                DBShotgun[1] = "null";
                            }
                        }
                        break;
                    case 2:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Player_Lives -= 4;
                            }
                            else
                            {
                                Player_Lives -= 2;
                            }
                            if (Player_Bleeding_Phase == false && Player_Lives == 0)
                            {
                                if (Count_Of_Player_Bleedings == 0)
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Count_Of_Player_Bleedings = 4;
                                    Player_Lives = 1;
                                }
                                else
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Player_Lives = 1;
                                }
                            }
                            else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Player_Lives = -1;
                                }
                            }
                            if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                            {
                                Player_Lives = -1;
                            }
                            else
                            {
                                Player_Lives = 1;
                            }
                            if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                if (Player_First_Time_Bleeding)
                                {
                                    Player_First_Time_Bleeding = false;
                                    if (Player_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                        for (int i = 0; i < Player_Inventory.Length; i++)
                                        {
                                            if (Player_Inventory[i] == "+хп")
                                            {
                                                Player_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Player_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                        }
                        if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Player_Lives -= 2;
                            }
                            else
                            {
                                Player_Lives--;
                            }
                            if (Player_Bleeding_Phase == false && Player_Lives == 0)
                            {
                                if (Count_Of_Player_Bleedings == 0)
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Count_Of_Player_Bleedings = 4;
                                    Player_Lives = 1;
                                }
                                else
                                {
                                    Player_Bleeding_Phase = true;
                                    Player_First_Time_Bleeding = true;
                                    Player_Bleeding_Turns = 9;
                                    Player_Lives = 1;
                                }
                            }
                            else if (Player_Bleeding_Phase == false && Player_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Player_Bleedings == 0)
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Count_Of_Player_Bleedings = 4;
                                        Player_Lives = 1;
                                    }
                                    else
                                    {
                                        Player_Bleeding_Phase = true;
                                        Player_First_Time_Bleeding = true;
                                        Player_Bleeding_Turns = 9;
                                        Player_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Player_Lives = -1;
                                }
                            }
                            if (!Player_First_Time_Bleeding && Player_Bleeding_Phase && Count_Of_Player_Bleedings == 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase && Player_Bleeding_Turns <= 0 || !Player_First_Time_Bleeding && Player_Bleeding_Phase)
                            {
                                Player_Lives = -1;
                            }
                            else
                            {
                                Player_Lives = 1;
                            }
                            if (Player_Lives < 1 && !Player_First_Time_Bleeding)
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase));
                                if (Player_First_Time_Bleeding)
                                {
                                    Player_First_Time_Bleeding = false;
                                    if (Player_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Player_Name));
                                        for (int i = 0; i < Player_Inventory.Length; i++)
                                        {
                                            if (Player_Inventory[i] == "+хп")
                                            {
                                                Player_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Player_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                        }
                        else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                        {
                            Console_WriteReadClear(Image.Blank_Shoot());
                            if (Player_Bleeding_Turns > 0)
                            {
                                Player_Bleeding_Turns--;
                            }
                            if (Opponent_Bleeding_Turns > 0)
                            {
                                Opponent_Bleeding_Turns--;
                            }
                            if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                            {
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                            }
                            else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                            {
                                Opponent_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                            Player_First_Time_Bleeding = false;
                        }
                        break;
                    case 3:
                        if (Opponent_HandCuffed > 0)
                        {
                            Opponent_HandCuffed--;
                        }
                        if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Opponent_Lives -= 4;
                            }
                            else
                            {
                                Opponent_Lives -= 2;
                            }
                            if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                            {
                                if (Count_Of_Opponent_Bleedings == 0)
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Count_Of_Opponent_Bleedings = 4;
                                    Opponent_Lives = 1;
                                }
                                else
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Opponent_Lives = 1;
                                }
                            }
                            else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Count_Of_Opponent_Bleedings = 2;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Opponent_Lives = -1;
                                }
                            }
                            if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                            {
                                Opponent_Lives = -1;
                            }
                            else
                            {
                                Opponent_Lives = 1;
                            }
                            if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                            {
                                Opponent_Lives = -1;
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                Turn_To_Play = 3;
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                if (Opponent_First_Time_Bleeding)
                                {
                                    Opponent_First_Time_Bleeding = false;
                                    if (Opponent_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                        for (int i = 0; i < Opponent_Inventory.Length; i++)
                                        {
                                            if (Opponent_Inventory[i] == "+хп")
                                            {
                                                Opponent_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Opponent_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                        }
                        if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Холостой" || DBShotgun[0] == "Холостой" && DBShotgun[1] == "Боевой")
                        {
                            if (Player_Double_Damage)
                            {
                                Player_Double_Damage = false;
                                Opponent_Lives -= 2;
                            }
                            else
                            {
                                Opponent_Lives--;
                            }
                            if (Opponent_Bleeding_Phase == false && Opponent_Lives == 0)
                            {
                                if (Count_Of_Opponent_Bleedings == 0)
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Count_Of_Opponent_Bleedings = 4;
                                    Opponent_Lives = 1;
                                }
                                else
                                {
                                    Opponent_Bleeding_Phase = true;
                                    Opponent_First_Time_Bleeding = true;
                                    Opponent_Bleeding_Turns = 9;
                                    Opponent_Lives = 1;
                                }
                            }
                            else if (Opponent_Bleeding_Phase == false && Opponent_Lives < 0)
                            {
                                int Luck = Random_Number.Next(1, 3);
                                if (Luck == 1)
                                {
                                    if (Count_Of_Opponent_Bleedings == 0)
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Count_Of_Opponent_Bleedings = 2;
                                        Opponent_Lives = 1;
                                    }
                                    else
                                    {
                                        Opponent_Bleeding_Phase = true;
                                        Opponent_First_Time_Bleeding = true;
                                        Opponent_Bleeding_Turns = 5;
                                        Opponent_Lives = 1;
                                    }
                                }
                                else
                                {
                                    Opponent_Lives = -1;
                                }
                            }
                            if (!Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Count_Of_Opponent_Bleedings == 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase && Opponent_Bleeding_Turns <= 0 || !Opponent_First_Time_Bleeding && Opponent_Bleeding_Phase)
                            {
                                Opponent_Lives = -1;
                            }
                            else
                            {
                                Opponent_Lives = 1;
                            }
                            if (Opponent_Lives < 1 && !Opponent_First_Time_Bleeding)
                            {
                                Opponent_Lives = -1;
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                Turn_To_Play = 3;
                            }
                            else
                            {
                                Console_WriteReadClear(Image.Live_Shoot(Player_Lives, Opponent_Lives, Player_Bleeding_Phase, Opponent_Bleeding_Phase, true));
                                if (Opponent_First_Time_Bleeding)
                                {
                                    Opponent_First_Time_Bleeding = false;
                                    if (Opponent_Inventory.Contains("+хп"))
                                    {
                                        Console_WriteReadClear(Image.Heals_Was_Changed_To_Bandage(Opponent_Name));
                                        for (int i = 0; i < Opponent_Inventory.Length; i++)
                                        {
                                            if (Opponent_Inventory[i] == "+хп")
                                            {
                                                Opponent_Inventory[i] = "бинт";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Opponent_First_Time_Bleeding = false;
                                }
                                if (Player_Bleeding_Turns > 0)
                                {
                                    Player_Bleeding_Turns--;
                                }
                                if (Opponent_Bleeding_Turns > 0)
                                {
                                    Opponent_Bleeding_Turns--;
                                }
                                if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                                {
                                    Turn_To_Play = 2;
                                }
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                        }
                        else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                        {
                            Console_WriteReadClear(Image.Blank_Shoot(true));
                            Opponent_First_Time_Bleeding = false;
                            if (Player_Bleeding_Turns > 0)
                            {
                                Player_Bleeding_Turns--;
                            }
                            if (Opponent_Bleeding_Turns > 0)
                            {
                                Opponent_Bleeding_Turns--;
                            }
                            if (Player_Bleeding_Phase && Player_Lives <= 1 && Count_Of_Player_Bleedings == 0 || Player_Bleeding_Phase && Player_Lives <= 1 && Player_Bleeding_Turns <= 0)
                            {
                                Player_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out());
                            }
                            else if (Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Count_Of_Opponent_Bleedings == 0 || Opponent_Bleeding_Phase && Opponent_Lives <= 1 && Opponent_Bleeding_Turns <= 0)
                            {
                                Opponent_Lives = -1;
                                Turn_To_Play = 3;
                                Console_WriteReadClear(Image.Dead_Of_Bleeding_Out(true));
                            }
                            if (Opponent_HandCuffed == 0 && Player_Bleeding_Turns % 2 == 0)
                            {
                                Turn_To_Play = 2;
                            }
                            DBShotgun[0] = "null";
                            DBShotgun[1] = "null";
                        }
                        break;
                    case 4:
                        if (Count_Of_Items != 0)
                        {
                            if (Max_Of_Player_Inventory == 0)
                            {
                                Console_WriteReadClear(Image.Player_Dont_Have_Items);
                            }
                            else
                            {
                                bool Items_Menu = true;
                                while (Items_Menu)
                                {
                                    Console.SetCursorPosition(0, 0);
                                    Console.Write(Image.All_Player_Items(Player_Bleeding_Phase, false, true));
                                    for (int i = 0; i < Max_Of_Player_Inventory; i++)
                                    {
                                        Console.Write(Player_Inventory[i] + ", ");
                                    }
                                    Console.Write("и все.                                                                                                                              ");
                                    switch (Convert.ToInt32(Console.ReadLine()))
                                    {
                                        case 1:
                                            if (Player_Bleeding_Phase && Player_Inventory.Contains("бинт") == true)
                                            {
                                                Player_Bleeding_Phase = false;
                                                Count_Of_Player_Bleedings--;
                                                Player_Bleeding_Turns = 0;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("бинт"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else if (Player_Inventory.Contains("+хп") == true)
                                            {
                                                Player_Lives++;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("+хп"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Items_Menu = false;
                                            }
                                            else if (Player_Inventory.Contains("бинт") == true)
                                            {
                                                Console_WriteReadClear(Image.You_Dont_Bleeding_Out);
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 2:
                                            if (Player_Inventory.Contains("наручники") == true)
                                            {
                                                if (Opponent_HandCuffed > 0)
                                                {
                                                    Console_WriteReadClear(Image.Opponent_Already_HandCuffed);
                                                }
                                                else
                                                {
                                                    Opponent_HandCuffed = 2;
                                                    List<string> Remove_List = new List<string>(Player_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("наручники"));
                                                    Remove_List.Add("");
                                                    Player_Inventory = Remove_List.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                }

                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 3:
                                            if (Player_Inventory.Contains("инвертор") == true)
                                            {
                                                if (DBShotgun[0] == "Боевой" && DBShotgun[1] == "Боевой")
                                                {
                                                    DBShotgun[0] = "Холостой";
                                                    DBShotgun[1] = "Холостой";
                                                    List<string> Remove_List = new List<string>(Player_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("инвертор"));
                                                    Remove_List.Add("");
                                                    Player_Inventory = Remove_List.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else if (DBShotgun[0] == "Холостой" || DBShotgun[1] == "Боевой" && DBShotgun[0] == "Боевой" || DBShotgun[1] == "Холостой")
                                                {
                                                    if (DBShotgun[0] == "Холостой")
                                                    {
                                                        DBShotgun[1] = "Боевой";
                                                    }
                                                    else
                                                    {
                                                        DBShotgun[1] = "Холостой";
                                                    }
                                                    if (DBShotgun[1] == "Холостой")
                                                    {
                                                        DBShotgun[1] = "Боевой";
                                                    }
                                                    else
                                                    {
                                                        DBShotgun[1] = "Холостой";
                                                    }
                                                    List<string> Remove_List = new List<string>(Player_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("инвертор"));
                                                    Remove_List.Add("");
                                                    Player_Inventory = Remove_List.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                }
                                                else if (DBShotgun[0] == "Холостой" && DBShotgun[1] == "Холостой")
                                                {
                                                    DBShotgun[0] = "Боевой";
                                                    DBShotgun[1] = "Боевой";
                                                    List<string> Remove_List = new List<string>(Player_Inventory);
                                                    Remove_List.RemoveAt(Remove_List.IndexOf("инвертор"));
                                                    Remove_List.Add("");
                                                    Player_Inventory = Remove_List.ToArray();
                                                    Max_Of_Player_Inventory--;
                                                    Items_Menu = false;
                                                }
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 4:
                                            if (Player_Inventory.Contains("удвоитель урона") == true)
                                            {
                                                Player_Double_Damage = true;
                                                List<string> Remove_List = new List<string>(Player_Inventory);
                                                Remove_List.RemoveAt(Remove_List.IndexOf("удвоитель урона"));
                                                Remove_List.Add("");
                                                Player_Inventory = Remove_List.ToArray();
                                                Max_Of_Player_Inventory--;
                                                Count_Not_Fired_Shells++;
                                                Items_Menu = false;
                                            }
                                            else
                                            {
                                                Console_WriteReadClear(Image.This_Button_Isnt_Exists);
                                            }
                                            break;
                                        case 5:
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
            catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
        }
        public void Shotgun_Mode()
        {
            //Инициализация всех нужных переменных

            int PlayerOne_Lives = 1;
            int PlayerTwo_Lives = 1;

            bool PlayerOne_Double_Damage = false;
            bool PlayerTwo_Double_Damage = false;

            int PlayerOne_HandCuffed = 0;
            int PlayerTwo_HandCuffed = 0;

            bool PlayerOne_Bleeding_Phase = false;
            bool PlayerTwo_Bleeding_Phase = false;
            bool PlayerOne_First_Time_Bleeding = false;
            bool PlayerTwo_First_Time_Bleeding = false;
            int Count_Of_PlayerOne_Bleedings = 0;
            int Count_Of_PlayerTwo_Bleedings = 0;
            int PlayerOne_Bleeding_Turns = 0;
            int PlayerTwo_Bleeding_Turns = 0;

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
                try
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
                catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
            }

            //Игроки делятся на первого и второго игрока и вводят свои имена
            string PlayerOne_Name = Image.PlayerOne_Name_Input();
            string PlayerTwo_Name = Image.PlayerTwo_Name_Input();

            int Count_Not_Fired_Shells = Random_Number.Next(2, 8);
            string[] Magazine = new string[Count_Not_Fired_Shells];
            int Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);
            Shotgun_Shells_Insert(ref Count_Not_Fired_Shells, ref Count_Of_Live, ref Magazine);

            //Bыдача 2-x предметов

            Give_Items(ref PlayerOne_Inventory, ref Count_Of_Items, ref Max_Of_PlayerOne_Inventory, PlayerOne_Bleeding_Phase);

            Give_Items(ref PlayerTwo_Inventory, ref Count_Of_Items, ref Max_Of_PlayerTwo_Inventory, PlayerTwo_Bleeding_Phase);

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
                    //Зарядка магазина (8 патронов в максимум)

                    Shotgun_Shells_Insert(ref Count_Not_Fired_Shells, ref Count_Of_Live, ref Magazine);

                    //Bыдача 2-x предметов

                    Give_Items(ref PlayerOne_Inventory, ref Count_Of_Items, ref Max_Of_PlayerOne_Inventory, PlayerOne_Bleeding_Phase);

                    Give_Items(ref PlayerTwo_Inventory, ref Count_Of_Items, ref Max_Of_PlayerTwo_Inventory, PlayerTwo_Bleeding_Phase);

                    if (Max_Of_PlayerOne_Inventory > 0 && Max_Of_PlayerTwo_Inventory > 0 && Max_Of_PlayerOne_Inventory != 0 && Max_Of_PlayerTwo_Inventory != 0)
                    {
                        Console_WriteReadClear(Image.All_Players_Has_Given_Two_Items);
                    }
                    Count_Not_Fired_Shells--;
                }
                while (Turn_To_Play == 1 && Count_Not_Fired_Shells >= 0 && PlayerOne_HandCuffed == 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    Shotgun_Player_Turn(ref PlayerOne_Double_Damage, ref Turn_To_Play, ref PlayerOne_Name, ref PlayerOne_Lives, ref PlayerOne_First_Time_Bleeding, ref PlayerTwo_First_Time_Bleeding, ref PlayerTwo_Lives, ref PlayerTwo_Name, ref Count_Of_Items, ref PlayerTwo_HandCuffed, ref PlayerOne_Bleeding_Phase, ref PlayerOne_Bleeding_Turns, ref Count_Of_PlayerOne_Bleedings, ref PlayerTwo_Bleeding_Phase, ref PlayerTwo_Bleeding_Turns, ref Count_Of_PlayerTwo_Bleedings, ref Magazine, ref Count_Not_Fired_Shells, ref Max_Of_PlayerOne_Inventory, ref PlayerOne_Inventory, ref PlayerTwo_Inventory);
                    //ход первого игрока
                }
                while (Turn_To_Play == 2 && Count_Not_Fired_Shells >= 0 && PlayerTwo_HandCuffed == 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    Shotgun_Player_Turn(ref PlayerTwo_Double_Damage, ref Turn_To_Play, ref PlayerTwo_Name, ref PlayerTwo_Lives, ref PlayerTwo_First_Time_Bleeding, ref PlayerOne_First_Time_Bleeding, ref PlayerOne_Lives, ref PlayerOne_Name, ref Count_Of_Items, ref PlayerOne_HandCuffed, ref PlayerTwo_Bleeding_Phase, ref PlayerTwo_Bleeding_Turns, ref Count_Of_PlayerTwo_Bleedings, ref PlayerOne_Bleeding_Phase, ref PlayerOne_Bleeding_Turns, ref Count_Of_PlayerOne_Bleedings, ref Magazine, ref Count_Not_Fired_Shells, ref Max_Of_PlayerTwo_Inventory, ref PlayerTwo_Inventory, ref PlayerOne_Inventory);
                    //ход второго игрока
                }
            }
        }
        public void DoubleBarreledShotgun_Mode()
        {
            //Инициализация всех нужных переменных

            int PlayerOne_Lives = 8;
            int PlayerTwo_Lives = 8;

            int PlayerOne_HandCuffed = 0;
            int PlayerTwo_HandCuffed = 0;

            bool PlayerOne_Double_Damage = false;
            bool PlayerTwo_Double_Damage = false;

            string[] PlayerOne_Inventory = new string[6];
            string[] PlayerTwo_Inventory = new string[6];
            int Max_Of_PlayerOne_Inventory = 0;
            int Max_Of_PlayerTwo_Inventory = 0;
            int Turn_To_Play = Random_Number.Next(1, 2);

            bool PlayerOne_Bleeding_Phase = false;
            bool PlayerTwo_Bleeding_Phase = false;
            bool PlayerOne_First_Time_Bleeding = false;
            bool PlayerTwo_First_Time_Bleeding = false;
            int Count_Of_PlayerOne_Bleedings = 0;
            int Count_Of_PlayerTwo_Bleedings = 0;
            int PlayerOne_Bleeding_Turns = 0;
            int PlayerTwo_Bleeding_Turns = 0;

            bool Player_Want_Use_Items = true;

            Console_WriteReadClear(Image.DoubleBarreledShotgun_Rules);

            //Игроки выбирают кол-во выдаваемых предметов за раз
            int Count_Of_Items = 0;
            bool Count_Of_Items_Not_Choosen = true;
            while (Count_Of_Items_Not_Choosen)
            {
                try
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
                catch (Exception e) { Console_WriteReadClear(Image.This_Button_Isnt_Exists); }
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
            string[] DBShotgun = { "null", "null" };
            int Count_Of_Live = Random_Number.Next(1, Count_Not_Fired_Shells);

            DoubleBarrel_Shotgun_Handful_Of_Shells(ref Count_Not_Fired_Shells, ref Count_Of_Live, ref Handful_Of_Shells);

            //Bыдача 2-x предметов

            Give_Items(ref PlayerOne_Inventory, ref Count_Of_Items, ref Max_Of_PlayerOne_Inventory, PlayerOne_Bleeding_Phase);

            Give_Items(ref PlayerTwo_Inventory, ref Count_Of_Items, ref Max_Of_PlayerTwo_Inventory, PlayerTwo_Bleeding_Phase);

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
                    DoubleBarrel_Shotgun_Handful_Of_Shells(ref Count_Not_Fired_Shells, ref Count_Of_Live, ref Handful_Of_Shells);
                    //Bыдача 2-x предметов
                    Give_Items(ref PlayerOne_Inventory, ref Count_Of_Items, ref Max_Of_PlayerOne_Inventory, PlayerOne_Bleeding_Phase);
                    Give_Items(ref PlayerTwo_Inventory, ref Count_Of_Items, ref Max_Of_PlayerTwo_Inventory, PlayerTwo_Bleeding_Phase);
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
                while (Turn_To_Play == 1 && Count_Not_Fired_Shells > 0 && PlayerOne_HandCuffed == 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    //ход первого игрока
                    DoubleBarrel_Shotgun_Insert_Shells(ref DBShotgun, ref Handful_Of_Shells, ref PlayerOne_Name, ref PlayerOne_Inventory, ref Max_Of_PlayerOne_Inventory, ref Count_Not_Fired_Shells);
                    Double_Barrel(ref PlayerOne_Double_Damage, ref Count_Of_Live, ref Handful_Of_Shells, ref Turn_To_Play, ref PlayerOne_Name, ref PlayerOne_Lives, ref PlayerOne_First_Time_Bleeding, ref PlayerTwo_First_Time_Bleeding, ref PlayerTwo_Lives, ref PlayerTwo_Name, ref Count_Of_Items, ref PlayerTwo_HandCuffed, ref PlayerOne_Bleeding_Phase, ref PlayerOne_Bleeding_Turns, ref Count_Of_PlayerOne_Bleedings, ref PlayerTwo_Bleeding_Phase, ref PlayerTwo_Bleeding_Turns, ref Count_Of_PlayerTwo_Bleedings, ref Handful_Of_Shells, ref Count_Not_Fired_Shells, ref Max_Of_PlayerOne_Inventory, ref PlayerOne_Inventory, ref PlayerTwo_Inventory);
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
                while (Turn_To_Play == 2 && Count_Not_Fired_Shells > 0 && PlayerTwo_HandCuffed == 0 && PlayerOne_Lives > 0 && PlayerTwo_Lives > 0)
                {
                    //ход второго игрока
                    DoubleBarrel_Shotgun_Insert_Shells(ref DBShotgun, ref Handful_Of_Shells, ref PlayerTwo_Name, ref PlayerTwo_Inventory, ref Max_Of_PlayerTwo_Inventory, ref Count_Not_Fired_Shells);
                    Double_Barrel(ref PlayerTwo_Double_Damage, ref Count_Of_Live, ref Handful_Of_Shells, ref Turn_To_Play, ref PlayerTwo_Name, ref PlayerTwo_Lives, ref PlayerTwo_First_Time_Bleeding, ref PlayerOne_First_Time_Bleeding, ref PlayerOne_Lives, ref PlayerOne_Name, ref Count_Of_Items, ref PlayerOne_HandCuffed, ref PlayerTwo_Bleeding_Phase, ref PlayerTwo_Bleeding_Turns, ref Count_Of_PlayerTwo_Bleedings, ref PlayerOne_Bleeding_Phase, ref PlayerOne_Bleeding_Turns, ref Count_Of_PlayerOne_Bleedings, ref Handful_Of_Shells, ref Count_Not_Fired_Shells, ref Max_Of_PlayerTwo_Inventory, ref PlayerTwo_Inventory, ref PlayerOne_Inventory);
                }
            }
        }
    }
}