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
        public string Main_Menu = "главное меню. 1+Еnter - начать игру, 3+Еnter - выйти из игры (2+Еnter - статистика, которой пока что нет).                                                                                                                                                                        ";
        public string Game_Modes_Choose = "тут выбор режима игры и предыстория. 1+Еnter - режим с дробовиком, 2+Еnter - режим с двустволкой, 3+Еnter - вернуться в главное меню.                                                                                                                                                                 ";

        public string This_Button_Isnt_Exists = "вы ошиблись кнопкой =). Еnter для перехода на следующее меню                                                                                                                                                                                          ";

        public string All_Players_Has_Given_Two_Items = "некоторые свободные слоты ваших инвентарей заполучили предметы. Еnter для перехода на следующее меню                                                                                                                                                                                                   ";

        public string Player_Dont_Have_Items = "у тебя нет предметов =/. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
        
        public string Opponent_Already_HandCuffed = "его руки уже связаны =). Еnter для перехода на следующее меню                                                                                                                                                                                                ";

        public string Choose_Max_Count_Of_Items = "выберите кол-во предметов, которые вы будете получать после зарядки магазина, максимум 4.                                                                                                                                                                         ";

        public string Wrong_Num_For_Count_Of_Items = "вы выбрали неверное кол-во предметов. Еnter для перехода на следующее меню                                                                                                                                                                                                                                              ";
        
        public string Shotgun_Rules = "правила игры для дробовика...Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                               ";

        public string DoubleBarreledShotgun_Rules = "правила игры для двустволки. напоминание для меня: если остается один патрон, то он автоматически заряжается в оружие...Еnter для перехода на следующее меню                                                                                                                                                                                            ";

        public string Last_Shell_Was_Inserted = "последний патрон был автоматически заряжен. Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                     ";

        public string Which_Shell_You_Want_To_Check = "выбери интересующй тебя патрон: 1 или 2                                                                                                                                                                                                                                                                                     ";

        public string Choose_Shell_That_You_Check(int Count_Of_Shells)
        {
            return $"выбери один патрон из {Count_Of_Shells}, нажатием на цифру на клавиатуре, соответсвующую цифре патрона +Еnter                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ";
        }
        public string Will_You_Use_Items(string Player_Name)
        {
            return $"{Player_Name}, время зарядить оружие. Перед этим, не хочешь использовать полезные для такого случая предметы ? 1+Еnter - да, 2+Еnter - нет.                                                                                                                                                                                                                                                                                 ";
        }
        public string All_Player_Items(bool Double_Barrel_Insert = false, bool Double_Barrel_After_Insert = false)
        {
            if (Double_Barrel_Insert)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать патрончекер (покажет тип выбранного тобой патрона из всех имеющихся), 2+Еnter - рандомный патрончекер (укажет тип случано выбранного патрона из всех имеющихся). 3+Еnter - приступить к зарядке двустволки. у тебя есть: ";
            }
            else if (Double_Barrel_After_Insert)
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать +хп, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - инвентор (меняет тип текущего/щих патрона/ов). 4+Еnter - выйти из этого меню. у тебя есть: ";
            }
            else
            {
                return "сводка об предметах (чтобы их использовать, жми на цифру на клавиатуре, соответсвующую цифре предмета): 1+Еnter - использовать +хп, 2+Еnter - использовать наручники (соперник пропустит ход, т.е. вы походите два раза), 3+Еnter - использовать патрончекер (покажет тип патрона), 4+Еnter - рандомный патрончекер (укажет тип случано выбранного патрона), 5+Еnter - инвентор (меняет тип текущего/щих патрона/ов). 6+Еnter - выйти из этого меню. у тебя есть: ";
            }
        }
        public string Blank_Shoot(bool Shoot_At_Opponent = false)
        {
            Random Random_Number = new Random();
            string[] Yourself_Commentaries = {"какое облегчение =)", "как же легко стало теперь =)", "=)", "ты заслужил возможность походить ещё раз"  };
            string[] Opponent_Commentaries = {"какое разочарование =(", "эххх..", "щит опонента не тронут..", "как-то...неприятно, да?",  };
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
        public string Live_Shoot(int Count_Player_Lives, int Count_Opponent_Lives, bool Shoot_At_Opponent = false)
        {
            Random Random_Number = new Random();
            string[] You_Dead_Commentaries = {"как жаль =(", "бывает же такое =/", "кто-то сегодня не вернется домой..", "=(", "ты проиграл =(" };
            string[] Opponent_Dead_Commentaries = {"поздравляю =)", "кто-то сегодня не вернется домой..", "ты победил =)", "ты рад, победитель?", "кому-то сегодня сказачно повезло, да? =)" };
            if (Shoot_At_Opponent && Count_Opponent_Lives > 0)
            {
                return $"прозвучал выстрел... количество его жизней = {Count_Opponent_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                ";
            }
            else if (Shoot_At_Opponent && Count_Opponent_Lives <= 0)
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "прозвучал выстрел... его тело падает замертво." + You_Dead_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                     "; ;
            }
            else if (Count_Player_Lives > 0)
            {
                return $"прозвучал выстрел... количество твоих жизней = {Count_Player_Lives}. Еnter для перехода на следующее меню                                                                                                                                                                                                ";
            }
            else
            {
                int Comm_Number = Random_Number.Next(0, 5);
                return "прозвучал выстрел... ваше тело падает замертво..." + You_Dead_Commentaries[Comm_Number] + ". Еnter для перехода на следующее меню                                                                                                                                                                                                                                                                                                                                                                     "; ;
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
                Console.Clear();
                Console.Write("выбирайте свою позицию: первый и второй. первый игрок, введи своё имя: ");
                Name = Console.ReadLine();
                if (Name.Length > 6)
                {
                    Console_WriteReadClear("имя слишком длинное - укоротите его до 6 букв минимум)    ");
                }
                else
                {
                    Name_Has_Choosen = true;
                }
            }
            return Name; 
        }
        public string PlayerTwo_Name_Input()
        {
            Console.Write("теперь второй игрок, введи своё имя: ");
            bool Name_Has_Choosen = false;
            string Name = "";
            while (!Name_Has_Choosen)
            {
                Console.Clear();
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
        public string Player_Menu(string Player_Name, int Count_Of_Player_Lives, string Opponent_Name, int Count_Of_Items, bool Opponent_HandCuffed = false)
        {
            if (Count_Of_Items == 0)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника.                                                                                                                                                                                                                       ";
            }
            else if (Opponent_HandCuffed)
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}, у него связаны руки. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов.                                                                                                                                                                                               ";
            }
            else
            {
                return $"Ходит {Player_Name}. перед вашим лицом {Opponent_Name}. кол-во ваших жизней {Count_Of_Player_Lives}. 1+Еnter - прокрутить оружие на столе, 2+Еnter - выстрел в себя, 3+Еnter - выстрел в соперника, 4+Еnter - меню предметов.                                                                                                                                                                                                                       ";
            }
        }
    }
}
