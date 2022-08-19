using System;
using System.Globalization;

namespace HandleDate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usando DateTime
            //DateTime é um struct e precisa ser inicializado para não trazer o valor padrão inicializado no struct
            var data = new DateTime();
            Console.Clear();
            Console.WriteLine(data);

            data = DateTime.Now;
            Console.WriteLine($"Data atual: {data}");

            data = new DateTime(2022, 08, 04, 1, 20, 19);
            Console.WriteLine($"Data definida: {data}");
            data = new DateTime(2022, 08, 04, 13, 20, 19);
            Console.WriteLine($"Data definida: {data}");
            Console.WriteLine(data.Year);
            Console.WriteLine(data.Month);
            Console.WriteLine(data.Day);
            Console.WriteLine(data.Hour);
            Console.WriteLine(data.Hour);
            Console.WriteLine(data.Minute);
            Console.WriteLine(data.Second);
            Console.WriteLine(data.DayOfYear);
            Console.WriteLine(data.DayOfWeek);

            //Formatando data
            Console.WriteLine("------------------ Formantando DATA ------------------");

            data = DateTime.Now;
            var formatada = String.Format("{0:yyyy-MM-dd}", data);
            Console.WriteLine($"Data formatada com StringFormat: {formatada}");

            formatada = String.Format("{0:yyyy * MM * dd}", data);
            Console.WriteLine($"Data formatada com StringFormat: {formatada}");

            formatada = String.Format("{0:yyyy/MM/dd hh:mm:ss}", data);
            Console.WriteLine($"Data formatada com StringFormat: {formatada}");

            formatada = String.Format("{0:yyyy/MM/dd hh:mm:ss ff}", data);
            Console.WriteLine($"Data formatada com StringFormat e fração de segundo: {formatada}");

            formatada = String.Format("{0:yyyy/MM/dd hh:mm:ss ff z}", data);
            Console.WriteLine($"Data formatada com StringFormat e fração de segundo e time zone: {formatada}");

            formatada = String.Format("{0:t}", data);
            Console.WriteLine($"Data formatada - COMPACTADA com StringFormat: {formatada}");

            formatada = String.Format("{0:D}", data);
            Console.WriteLine($"Data formatada POR EXTENSO com StringFormat: {formatada}");

            formatada = String.Format("{0:T}", data);
            Console.WriteLine($"Data formatada - COM TIME POR EXTENSO com StringFormat: {formatada}");

            formatada = String.Format("{0:f}", data);
            Console.WriteLine($"Data formatada - COM DATA E TIME POR EXTENSO com StringFormat: {formatada}");

            formatada = String.Format("{0:g}", data);
            Console.WriteLine($"Data formatada - COM DATA E TIME COMPACTADA com StringFormat: {formatada}");

            formatada = String.Format("{0:r}", data);
            Console.WriteLine($"Data formatada - PADRÃO ESPECIFICO com StringFormat: {formatada}");

            formatada = String.Format("{0:s}", data);
            Console.WriteLine($"Data formatada - FORMATO JASON com StringFormat: {formatada}");

            formatada = String.Format("{0:u}", data);
            Console.WriteLine($"Data formatada - FORMATO JASON COM ESPAÇO - com StringFormat: {formatada}");

            Console.WriteLine("------------------ CALCULANDO DATA ------------------");
            data = DateTime.Now;
            Console.WriteLine($"Data atual: {data}");

            Console.WriteLine($"Data atual + 11 dias: {data.AddDays(11)}");
            Console.WriteLine($"Data atual + 2 meses: {data.AddMonths(2)}");
            Console.WriteLine($"Data atual + 3 anos: {data.AddYears(3)}");
            Console.WriteLine($"Data atual + 3 anos: {data.AddHours(4)}");

            Console.WriteLine("------------------ DATA NULA ------------------");

            DateTime? dataNula = null;
            Console.WriteLine($"Data nula: {dataNula}");

            Console.WriteLine("------------------ COMPARANDO DATAS ------------------");

            data = DateTime.Now;
            if (data == DateTime.Now)
            {
                Console.WriteLine("As Datas são iguais"); //Não são iguais porque o datetime.now tem mais datas como fraçoes de segundos
            }
            else
            {
                Console.WriteLine("As Datas NÃO SÃO iguais");
            }

            // Comparando corretamente
            if (data.Date == DateTime.Now.Date)
            {
                Console.WriteLine("As Datas são iguais"); //Não são iguais porque o datetime.now tem mais datas como fraçoes de segundos
            }
            else
            {
                Console.WriteLine("As Datas NÃO SÃO iguais");
            }

            Console.WriteLine("------------------ GLOBALIZAÇÃO/LOCALIZAÇÃO - CULTURE INFO -----------------");
            //Data conforme time zone

            var br = new CultureInfo("pt-BR");
            var pt = new CultureInfo("pt-PT");
            var en = new CultureInfo("pt-US");
            var de = new CultureInfo("pt-DE");

            Console.WriteLine(DateTime.Now.ToString("D", br));

            //Para usar a cultura da máquina (idioma da máquina)
            var atual = System.Globalization.CultureInfo.CurrentCulture;
            Console.WriteLine(DateTime.Now.ToString("D", atual));

            //App atende diferente localidades

            //Para data use System.Globalization.CultureInfo.CurrentCulture
            //Para pegar o horário Universal use:

            var dataHora = DateTime.UtcNow;
            Console.WriteLine($"Horário global: {dataHora}");

            Console.WriteLine($"Horário local: {dataHora.ToLocalTime()}");

            //E se a máquina estiver nos US e o usuário na Aústralia:
            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            Console.WriteLine("timezoneAustralia" + timezoneAustralia);

            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(dataHora, timezoneAustralia);
            Console.WriteLine(horaAustralia);

            //Listando todos os timesZones:

            var timesZones = TimeZoneInfo.GetSystemTimeZones();

            foreach (var timeZone in timesZones)
            {
                Console.WriteLine(timeZone.Id);
                Console.WriteLine(timeZone);
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(dataHora, timeZone));
                Console.WriteLine("-------------------------");

            }


            //TimeSpan - unidade de medida universal em segundo usando para cálculo de hora

            var timeSpan = new TimeSpan();
            Console.WriteLine("timeSpan");

            var timeSpanNanoSegundos = new TimeSpan(1);
            Console.WriteLine(timeSpanNanoSegundos);

            var timeSpanHoraMinutoSegundo = new TimeSpan(5, 12, 8);
            Console.WriteLine(timeSpanHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundo = new TimeSpan(4, 5, 12, 8);
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

            //Onde usar? Controle de horas de funcionários, por exemplo.
            Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundo); //subtraindo uma hora da outra
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days); //pega os dias
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0)));

            // Quantos dias tem um mês:
            Console.WriteLine("Quantos dias tem o mês: " + DateTime.DaysInMonth(2022, 2));

            //Hoje É fim de semana?
            Console.WriteLine(IsWeekend(DateTime.Now.DayOfWeek)); //chama função passando dia da semana

            //Estamos no horário de verão?
            Console.WriteLine(DateTime.Now.IsDaylightSavingTime());
        }

        static bool IsWeekend(DayOfWeek today)
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}