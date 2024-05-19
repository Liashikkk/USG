using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Net.Mime.MediaTypeNames;

namespace USG
{
    class All_Images : Program
    {
        Random Random_Number = new Random();

        public string Main_Menu = "главное меню. 1+Еnter - начать игру, 3+Еnter - выйти из игры (2+Еnter - статистика, которой пока что нет).                                                                                                                                                                        ";
        public string Game_Modes_Choose = "тут выбор режима игры и предыстория. 1+Еnter - режим с дробовиком, 2+Еnter - режим с двустволкой, 3+Еnter - вернуться в главное меню.                                                                                                                                                                 ";

        public string This_Button_Isnt_Exists = "вы сделали что-то неправильно - помните про инструкции =). Еnter для перехода на следующее меню                                                                                                                                                                                          ";

        public string All_Players_Has_Given_Two_Items = "некоторые свободные слоты ваших инвентарей заполучили предметы. Еnter для перехода на следующее меню                                                                                                                                                                                                   ";

        public string Player_Dont_Have_Items = "у тебя нет предметов =/. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        
        public string Opponent_Already_HandCuffed = "его руки уже связаны =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";

        public string Choose_Max_Count_Of_Items = "выберите кол-во предметов, которые вы будете получать после зарядки магазина, максимум 4.                                                                                                                                                                         ";

        public string Wrong_Num_For_Count_Of_Items = "вы выбрали неверное кол-во предметов. Еnter для перехода на следующее меню                                                                                                                                                                                                                                              ";
        
        public string Shotgun_Rules = "правила игры для дробовика...Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                               ";

        public string DoubleBarreledShotgun_Rules = "правила игры для двустволки. напоминание для меня: если остается один патрон, то он автоматически заряжается в оружие...Еnter для перехода на следующее меню                                                                                                                                                                                            ";

        public string Last_Shell_Was_Inserted = "последний патрон был автоматически заряжен. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                     ";

        public string You_Dont_Bleeding_Out = "ты не истекаешь кровью =). Еnter для перехода на следующее меню                                                                                                                                                                                                              ";

        public string Which_Shell_Will_Be_Inserted = "какой патрон вставишь - 1+Еnter - боевой, 2+Еnter - холостой.                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ";

        public string Which_Side_Need_Insert = "в какую часть двустволки вставить патрон - 1+Еnter - левую, 2+Еnter - правую.                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ";

        public string Magazine_Full = "магазин полон - патроны не 3арядить =). Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ";
        public string Dead_Of_Bleeding_Out(bool Opponent = false)
        {
            if (Opponent) 
            {
                string[] Comentary = { "кто-то сегодня не вернется домой..", "поздравляю =)", "ты победил =)", "ты рад, победитель?", "кому-то сегодня сказачно повезло =)" };
                int Comm_Number = Random_Number.Next(0, 5);
                return "тело соперника падает замертво - в нем недостаточно крови..." + Comentary[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                ";
            }
            else
            {
                string[] Comentary = { "кто-то сегодня не вернется домой..", "ты не смог воспользоваться вторым шансом", "ты потрял последнюю возможность..", "жаль, в человеке крови меньше, чем хотелось бы..", "ты не успел дать отпор" };
                int Comm_Number = Random_Number.Next(0, 5);
                return "твое тело падает замертво - в нем недостаточно крови..." + Comentary[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            }
        }
        public string Heals_Was_Changed_To_Bandage(string Player_Name)
        {
            return $"{Player_Name}, тебе дается последний шанс - твои батарейки были заменены на медицинские бинты.                                                                                                                                                                                                                                                                                                                                                                                                                        ";
        }
        public string You_Choose_To_Die()
        {
            string[] Comentary = {"это была твоя последняя капля..", "ты сдался", "кто-то сегодня не вернется домой..", "ты выбрал легкий путь", "ты поддался сопернику, эхх =("};
            int Comm_Number = Random_Number.Next(0, 5);
            return "ты разряжаешь оружие, заряжая боевой патрон... твое тело падает замертво - " + Comentary[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
        }
        public string Choose_Shell_That_You_Check(int Count_Of_Shells)
        {
            return $"выбери один патрон из {Count_Of_Shells}, нажатием на цифру на клавиатуре, соответсвующую цифре патрона + Еnter                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ";
        }
        public string Will_You_Use_Items(string Player_Name)
        {
            return $"{Player_Name}, время зарядить оружие. Перед этим, не хочешь использовать полезные для такого случая предметы ? 1+Еnter - да, 2+Еnter - нет.                                                                                                                                                                                                                                                                                 ";
        }
        public string All_Player_Items(bool Bleeding_Phase, bool Double_Barrel_Insert = false, bool Double_Barrel_After_Insert = false)
        {
            if (Double_Barrel_Insert)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать патрончекер (покажет тип выбранного тобой патрона из всех имеющихся), 2+Еnter - рандомный патрончекер (укажет тип случано выбранного с конца патрона из всех имеющихся), 3+Еnter - боевой/холостой патроны (вы заряжаете ещё один патрон). 4+Еnter - приступить к зарядке двустволки. у тебя есть: ";
            }
            else if (Double_Barrel_After_Insert)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать +хп, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - инвентор (меняет тип текущего/щих патрона/ов), 4+Еnter - удвоитель урона. 5+Еnter - выйти из этого меню. у тебя есть: ";
            }
            else if (Double_Barrel_After_Insert && Bleeding_Phase)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать бинт, который остановит кровотечение, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - инвентор (меняет тип текущего/щих патрона/ов), 4+Еnter - удвоитель урона. 5+Еnter - выйти из этого меню. у тебя есть: ";
            }
            else if (Bleeding_Phase)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать бинт, который остановит кровотечение, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - использовать патрончекер (покажет тип патрона), 4+Еnter - рандомный патрончекер (покажет тип выбранного тобой патрона из всех имеющихся), 2+Еnter - рандомный патрончекер (укажет тип случано выбранного с конца патрона из всех имеющихся), 5+Еnter - инвентор (меняет тип текущего/щих патрона/ов), 6+Еnter - боевой/холостой патроны (вы заряжаете ещё один патрон), 7+Еnter - удвоитель урона. 8+Еnter - выйти из этого меню. у тебя есть: ";
            }
            else
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать +хп, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - использовать патрончекер (покажет тип патрона), 4+Еnter - рандомный патрончекер (покажет тип выбранного тобой патрона из всех имеющихся), 5+Еnter - инвентор (меняет тип текущего/щих патрона/ов), 6+Еnter - боевой/холостой патроны (вы заряжаете ещё один патрон), 7+Еnter - удвоитель урона. 8+Еnter - выйти из этого меню. у тебя есть: ";
            }
        }
        public string Blank_Shoot(bool Shoot_At_Opponent = false)
        {
            string[] Yourself_Commentaries = {"какое облегчение =)", "как же легко стало теперь =)", "=)", "ты заслужил возможность походить ещё раз", "приятный звук, правда?"  };
            string[] Opponent_Commentaries = {"какое разочарование =(", "эххх..", "щит опонента не тронут..", "как-то...неприятно, да?", "повезло твоему сопернику" };
            if (Shoot_At_Opponent)
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "щелчок... " + Opponent_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
            }
            else
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "щелчок... " + Yourself_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                     ";
            }
        }
        public string Live_Shoot(int Count_Player_Lives, int Count_Opponent_Lives, bool Player_Bleeding_Phase, bool Opponent_Bleeding_Phase, bool Shoot_At_Opponent = false)
        {
            string[] You_Dead_Commentaries = {"как жаль =(", "бывает же такое =/", "кто-то сегодня не вернется домой..", "=(", "ты проиграл =(" };
            string[] Opponent_Dead_Commentaries = {"поздравляю =)", "кто-то сегодня не вернется домой..", "ты победил =)", "ты рад, победитель?", "кому-то сегодня сказачно повезло, да? =)" };
            if (Shoot_At_Opponent && Opponent_Bleeding_Phase && Count_Opponent_Lives == 1)
            {
                return $"прозвучал выстрел... его тело падает на пол, но ему хватает сил встать. из него течет кровь...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ";
            }
            else if (Shoot_At_Opponent && Count_Opponent_Lives > 1)
            {
                return $"прозвучал выстрел... количество зарядов его щита = {Count_Opponent_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                ";
            }
            else if (Shoot_At_Opponent && Opponent_Bleeding_Phase && Count_Opponent_Lives <= 0)
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "прозвучал выстрел... его тело падает замертво. " + Opponent_Dead_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                     "; ;
            }
            else if (Player_Bleeding_Phase && Count_Player_Lives == 1)
            {
                return $"прозвучал выстрел... твое тело падает на пол, но тебе хватает сил встать. у тебя кровотечение...                                                                                                                                                                                                                                                                                                                                                              ";
            }
            else if (Count_Player_Lives > 1)
            {
                return $"прозвучал выстрел... количество зарядов твоего щита = {Count_Player_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
            }
            else
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "прозвучал выстрел... твое тело падает замертво... " + You_Dead_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                     "; ;
            }
        }
        public string Will_Be_Fired_At(int Who_To_Shoot_At)
        {
            if (Who_To_Shoot_At == 1)
            {
                return "ствол оружия был направлен в вашу сторону. вы стреляете в себя. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                ";
            }
            else
            {
                return "ствол оружия был направлен в сторону соперника. вы стреляете в него. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                   ";
            }
        }
        public string Time_To_Load_Shotgun(string Player_Name, int Count_Of_Shells, string[] Shotgun)
        {
            if (Shotgun[0].Contains("Холостой") || Shotgun[0].Contains("Боевой"))
            {
                return $"{Player_Name}, выбери второй патрон из {Count_Of_Shells} нажатием на цифру, соответсвующей номеру выбранного патрона.                                                                                                                                                                                                        ";
            }
            else
            {
                return $"{Player_Name}, выбери первый патрона из {Count_Of_Shells} нажатием на цифру, соответсвующей номеру выбранного патрона.                                                                                                                                                                                                                                                                                        ";
            }
        }
        public string PlayerOne_Name_Input()
        {
            bool Name_Has_Choosen = false;
            string Name = "";
            while (!Name_Has_Choosen)
            {
                try
                {
                    Console.Clear();
                    Console.Write("выбирайте свою позицию: первый и второй. первый игрок, введи своё имя: ");
                    Name = Console.ReadLine();
                    if (Name.Length > 6)
                    {
                        Console_WriteReadClear("имя слишком длинное - укоротите его до 6 букв минимум)                                                                                                                                                                                                                      ");
                    }
                    else
                    {
                        Name_Has_Choosen = true;
                    }
                }
                catch (Exception e) { Console_WriteReadClear(This_Button_Isnt_Exists); }
            }
            return Name; 
        }
        public string PlayerTwo_Name_Input()
        {
            bool Name_Has_Choosen = false;
            string Name = "";
            while (!Name_Has_Choosen)
            {
                try
                {
                    Console.Write("теперь второй игрок, введи своё имя: ");
                    Name = Console.ReadLine();
                    if (Name.Length > 6)
                    {
                        Console_WriteReadClear("имя слишком длинное - укоротите его до 6 букв минимум)");
                    }
                    else
                    {
                        Name_Has_Choosen = true;
                    }
                }
                catch (Exception e) { Console_WriteReadClear(This_Button_Isnt_Exists); }
            }
            return Name;
        }

        public string How_Live_Shells_Will_Be(int Count_Of_Live_Shells, int Count_All_Posible_Shells)
        {
            return $"Боевых патронов {Count_Of_Live_Shells} из {Count_All_Posible_Shells}. удачи =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        }

        public string What_Is_Shell_In_Shotgun(string Shell_Type, int Shell_Number, bool Random_Shell = false, bool Double_Barrel = false)
        {
            if (Random_Shell)
            {
                return $"Патрон под номером {Shell_Number} - это {Shell_Type} патрон. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            }
            else if (Double_Barrel)
            {
                return $"Выбранный тобой патрон - это {Shell_Type} патрон. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ";
            }
            else
            {
                return $"Выстрелить сейчас должен {Shell_Type} патрон. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ";
            }
        }
        public string Player_Menu(string Player_Name, int Count_Of_Player_Lives, string Opponent_Name, int Count_Of_Items, bool Opponent_HandCuffed = false, bool Player_Bleeding_Out = false, int Count_Of_Turns = 0)
        {
            if (Count_Of_Items == 0 && Player_Bleeding_Out)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. у вас кровотечение. через {Count_Of_Turns} ходов крови в вас будет недостаточно, чтобы вы могли жить. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            }
            else if (Count_Of_Items == 0 && Count_Of_Player_Lives == 1)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            }
            else if (Count_Of_Items == 0)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ";
            }


            if (Player_Bleeding_Out && Opponent_HandCuffed)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}, у него связаны руки. у вас кровотечение. через {Count_Of_Turns} ходов крови в вас будет недостаточно, чтобы вы могли жить. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ";
            }
            else if (Player_Bleeding_Out)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. у вас кровотечение. через {Count_Of_Turns} ходов крови в вас будет недостаточно, чтобы вы могли жить. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ";
            }


            if (Count_Of_Player_Lives == 1 && Opponent_HandCuffed)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}, у него связаны руки. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
            }
            else if (Count_Of_Player_Lives == 1)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов. 0+Еnter - сдаться, если тебе нечего терять...                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ";
            }


            if (Opponent_HandCuffed)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}, у него связаны руки. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             ";
            }
            else
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ";
            }
        }
    }
}
