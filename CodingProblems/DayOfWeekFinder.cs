using System;
namespace CodingProblems
{
    public class DayOfWeekFinder
    {
        public int dayOfWeek(string birthdayDate)
        {
            int day = int.Parse(birthdayDate.Split('-')[1]);
int month = int.Parse(birthdayDate.Split('-')[0]);
int currentyear = int.Parse(birthdayDate.Split('-')[2]);
 DateTime DT = new DateTime(currentyear, month, day);
    var dayinthiyear = DT.DayOfWeek;
// int dayinthiyear = getday(day, month, currentyear);
// DayOfWeek daynextyear = 0;
int year = currentyear + 1;
bool IsLeapYear;
while(true)
{
    if((year % 400) == 0)
    {
        IsLeapYear = true;
    }
    else if((year % 100) == 0)
    {
        IsLeapYear = false;
    }
    else if((year % 4) == 0)
    {
        IsLeapYear = true;
    }
    else
    {
        IsLeapYear = false;
    }
    if(IsLeapYear == false && day == 29 && month == 02)
    {
        year++;
        continue;
    }
    var daynextyear = new DateTime(year, month, day).DayOfWeek;
    if(daynextyear == dayinthiyear)
    {
        break;
    }
    else
    {
    year ++;
    }
}
return year - currentyear;
        }

        int dayOfWeekV2(string birthdayDate) {
int count= 0;
          DateTime dt=  Convert.ToDateTime(birthdayDate);
          DateTime newDate = dt;
          DayOfWeek dd = dt.DayOfWeek;
           do
           {
               if (dt.Year % 4 == 0 && dt.Day==29)
               {
                   count = count + 4;
               }
               else
               {
                   count++;
               }
               
               newDate = dt.AddYears(count);
             
           } while (newDate.DayOfWeek != dd);
         
           return count;
       
}

    }
}