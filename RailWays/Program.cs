using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWays
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ContextForTrain())
            {
                var directionList = context.Directions.ToList();
                var TrainsList = context.Trains.ToList();
                var PlaceList = context.Places.ToList();

                #region AddDirection
                //Console.WriteLine("Сколько направлений добавить?");
                //int countDirection = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countDirection; i++)
                //{
                //    Console.WriteLine("Введите направление откуда?");
                //    string beginCity = Console.ReadLine();
                //    Console.WriteLine("Введите направление куда?");
                //    string endCity = Console.ReadLine();
                //    var direction = new Direction
                //    {
                //        BeginCity = beginCity,
                //        EndCity = endCity
                //    };
                //    context.Directions.Add(direction);
                //}
                //context.SaveChanges();
                #endregion

                #region AddTrain
                //Console.WriteLine("Сколько поездов добавить?");
                //int countTrains = int.Parse(Console.ReadLine());
                //for (int i = 0; i < countTrains; i++)
                //{
                //    Console.WriteLine("Введите наименование поезда?");
                //    string nameTrain = Console.ReadLine();
                //    Console.WriteLine("Введите кол-во вагона?");
                //    int countWagon = int.Parse(Console.ReadLine());
                //    Console.WriteLine("Введите напрвление?(с 0)");
                //    for (int j = 0; j < context.Directions.Count(); j++)
                //    {
                //        Console.WriteLine($"{j}" + $" {directionList[j].BeginCity} - " +
                //            $"{directionList[j].EndCity}");
                //    }
                //    int choiceDirectionTrains = int.Parse(Console.ReadLine());
                //    var train = new Train
                //    {
                //        NameTrain = nameTrain,
                //        CountWagon = countWagon,
                //        DirectionId = directionList[choiceDirectionTrains].Id
                //    };
                //    context.Trains.Add(train);
                //}
                //context.SaveChanges();
                #endregion

                #region AddPlace
                //var countWagons = from train in context.Trains
                //                  select train;
                //int k = 0;
                //foreach (Train train in countWagons)//Кол-во поездов
                //{
                //    for (int m = 0; m < train.CountWagon; m++)//Для каждого поезда свое кол-во вагона
                //    {
                //        Console.WriteLine("Сколько мест добавить?");
                //        int countPlace = int.Parse(Console.ReadLine());
                //        for (int i = 0; i < countPlace; i++)//Для каждого вагона свое кол-во мест
                //        {
                //            Console.WriteLine("Введите номер места:");
                //            int numberWagon = int.Parse(Console.ReadLine());
                //            Console.WriteLine("Свободен?(0-нет/1-да)");
                //            int choiceEmpty = int.Parse(Console.ReadLine());
                //            Console.WriteLine("Статус?\n1-VIP \n2Premium");
                //            int choiceStatus = int.Parse(Console.ReadLine());
                //            string status = "";
                //            if (choiceStatus == 1) { status = "VIP"; }
                //            else if (choiceStatus == 2) { status = "Premium"; }
                //            Console.WriteLine("Сумма за проезд по статусу?");
                //            int moneyPay = int.Parse(Console.ReadLine());

                //            var place = new Place
                //            {
                //                NumberPlace = numberWagon,
                //                IsEmty = choiceEmpty,
                //                Status = status,
                //                Payment = moneyPay,
                //                TrainId = TrainsList[k].Id
                //            };
                //            context.Places.Add(place);
                //        }
                //    }
                //    k++;
                //}
                //context.SaveChanges();
                #endregion

                //Выбор места и бронирование
                #region ChoicePlace
                Console.WriteLine("Сколько пассажиров?");
                int countPassangers = int.Parse(Console.ReadLine());
                for (int i = 0; i < countPassangers; i++)
                {
                    Console.WriteLine("Введите направление: (c 0)");
                        for (int j = 0; j < context.Directions.Count(); j++)
                        {
                            //Показывает список направлении откуда - куда
                            Console.WriteLine($"{j}" +
                            $" {directionList[j].BeginCity} - " +
                            $"{directionList[j].EndCity}");
                        }
                        int choiceDirectionForPassangers = int.Parse(Console.ReadLine());

                        //записваю выбранный (откуда - куда) в переменные и далее беру Id который совпадает с нашим выбранным
                        string begin = directionList[choiceDirectionForPassangers].BeginCity;
                        string end = directionList[choiceDirectionForPassangers].EndCity;
                        Console.WriteLine("Введите имя пассажира?");
                        string namePassanger = Console.ReadLine();
                        var getDirectionId =  (from direct in context.Directions
                                          where (direct.BeginCity == begin
                                          && direct.EndCity == end)
                                          select direct.Id).SingleOrDefault();

                        if (getDirectionId != null)
                        {
                            var countTrain = (from train in context.Trains
                                              where train.DirectionId == getDirectionId
                                              select context.Trains.Count()).FirstOrDefault();
                            var getNameTrain = from train in context.Trains
                                               where train.DirectionId == getDirectionId
                                               select train;

                            Console.WriteLine("Выберите поезд");
                            int l = 0;
                            foreach (Train trains in getNameTrain)
                            {
                                Console.WriteLine($"{l} ::- " + $"{TrainsList[l].NameTrain}");
                                l++;
                            }
                            //for (int l = 0; l < countTrain; l++)
                            //{
                            //    Console.WriteLine($"{l} ::- " + $"{TrainsList[l].NameTrain}");
                            //}
                            int choiceTrain = int.Parse(Console.ReadLine());

                            string trainName = TrainsList[choiceTrain].NameTrain;

                            var getTrainId = (from train in context.Trains
                                              where train.NameTrain == trainName
                                              select train.Id).FirstOrDefault();

                            var countPlaces = (from place in context.Places
                                               where getTrainId == place.TrainId & place.IsEmty == 1
                                               select context.Places.Count()).FirstOrDefault();

                            var places = from place in context.Places
                                         where getTrainId == place.TrainId & place.IsEmty == 1
                                         select place;

                            int n = 1;
                            Console.WriteLine("Выберите место");
                            Console.WriteLine($"№     " + $"  Номер  " + $"Свободен" + $"  Статус");
                            foreach (Place placing in places)
                            {
                                Console.WriteLine($"{n} ::- " + $"\t{placing.NumberPlace}\t" +
                                $"{placing.IsEmty}\t" +
                                $"{placing.Status}");
                                n++;
                            }

                            int choicePlace = int.Parse(Console.ReadLine());

                            int placeInWagon = PlaceList[choicePlace].NumberPlace;

                            var getPlaceId = (from place in context.Places
                                              where place.NumberPlace == placeInWagon
                                              select place.Id).FirstOrDefault();
                            var status = (from place in context.Places
                                          where place.Id == getPlaceId
                                          select place.Status).FirstOrDefault();
                            var payment = (from place in context.Places
                                           where place.Id == getPlaceId
                                           select place.Payment).FirstOrDefault();

                            var user = new Users
                            {
                                Name = namePassanger,
                                DirectionId = getDirectionId,
                                PlaceId = getPlaceId,
                                TrainsId = getTrainId,
                                Status = status,
                                Payment = payment,
                                CountPassangers = countPassangers
                            };
                            context.User.Add(user);
                        }
                }
                context.SaveChanges();
                #endregion
            }
        }
    }
}
