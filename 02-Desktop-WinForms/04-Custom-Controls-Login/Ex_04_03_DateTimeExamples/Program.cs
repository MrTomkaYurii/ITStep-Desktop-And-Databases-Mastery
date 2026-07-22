//01 -> C# DateTime structure
//02 -> DateTime Constructor, Field, Methods and Properties
//03 -> Operators in DateTime
//04 -> DateTime Formatting
//05 -> Managing Nullable DateTime
//06 -> Parse to DateTime object from String
//07 -> Working with Calendars
//08 -> Working with TimeZone
//09 -> DateTime with different Culture
//10 -> Starting with DateTimeOffSet
//11 -> TimeSpan features


using System.Globalization;

Console.WriteLine("== 02 ============================================");
Console.WriteLine("DateTime Constructor, Field, Methods and Properties");
Console.WriteLine(Environment.NewLine);
Console.WriteLine("-DateTime Constructor------------------------------");
// 2015 is year, 12 is month, 25 is day  
DateTime date1 = new DateTime(2015, 12, 25);
Console.WriteLine(date1.ToString()); // 12/25/2015 12:00:00 AM    
// 2015 - year, 12 - month, 25 – day, 10 – hour, 30 – minute, 50 - second  
DateTime date2 = new DateTime(2012, 12, 25, 10, 30, 50);
Console.WriteLine(date1.ToString());// 12/25/2015 10:30:00 AM  



Console.WriteLine("-DateTime Fields-----------------------------------");
// Define an uninitialized date.  
Console.WriteLine(DateTime.MinValue); // 1/1/0001 12:00:00 AM  
// Define an uninitialized date.  
Console.WriteLine(DateTime.MaxValue); // 12/31/9999 11:59:59 PM  



Console.WriteLine( "-DateTime Methods-----------------------------------");
// Creating TimeSpan object of one month(as 30 days)  
System.TimeSpan duration = new System.TimeSpan(30, 0, 0, 0);
System.DateTime newDate1 = DateTime.Now.Add(duration);
System.Console.WriteLine(newDate1); // 1/19/2016 11:47:52 AM  

// Adding days to a date  
DateTime today = DateTime.Now; // 12/20/2015 11:48:09 AM  
DateTime newDate2 = today.AddDays(30); // Adding one month(as 30 days)  
Console.WriteLine(newDate2); // 1/19/2016 11:48:09 AM  

// Parsing  
string dateString = "Wed Dec 30, 2015";
DateTime dateTime12 = DateTime.Parse(dateString); // 12/30/2015 12:00:00 AM  

// Date Difference  
System.DateTime date3 = new System.DateTime(2015, 3, 10, 2, 15, 10);
System.DateTime date4 = new System.DateTime(2015, 7, 15, 6, 30, 20);
System.DateTime date5 = new System.DateTime(2015, 12, 28, 10, 45, 30);

// diff1 gets 127 days, 04 hours, 15 minutes and 10 seconds.  
System.TimeSpan diff1 = date2.Subtract(date3); // 127.04:15:10  
// date4 gets 8/23/2015 6:30:20 AM  
System.DateTime date6 = date3.Subtract(diff1);
// diff2 gets 166 days 4 hours, 15 minutes and 10 seconds.  
System.TimeSpan diff2 = date3 - date2; //166.04:15:10  
// date5 gets 3/10/2015 2:15:10 AM  
System.DateTime date7 = date2 - diff1;

// Universal Time  
DateTime dateObj = new DateTime(2015, 12, 20, 10, 20, 30);
Console.WriteLine("mans" + dateObj.ToUniversalTime()); // 12/20/2015 4:50:30 AM  



Console.WriteLine("-DateTime Properties-----------------------------------");
DateTime myDate = new DateTime(2015, 12, 25, 10, 30, 45);
int year = myDate.Year; // 2015  
int month = myDate.Month; //12  
int day = myDate.Day; // 25  
int hour = myDate.Hour; // 10  
int minute = myDate.Minute; // 30  
int second = myDate.Second; // 45  
int weekDay = (int)myDate.DayOfWeek; // 5 due to Friday  

DateTime dt = new DateTime(2015, 12, 25);
bool isEqual = dt.DayOfWeek == DayOfWeek.Thursday; // False  
bool isEqual2 = dt.DayOfWeek == DayOfWeek.Friday; // True  

DateTime saveNow = DateTime.Now;
DateTime saveUtcNow = DateTime.UtcNow;

DateTime myDate10 = DateTime.SpecifyKind(saveUtcNow, DateTimeKind.Utc); // 12/20/2015 12:17:18 PM  
DateTime myDate11 = DateTime.SpecifyKind(saveNow, DateTimeKind.Local); // 12/20/2015 5:47:17 PM  

Console.WriteLine("Kind: " + myDate10.Kind); // Utc  
Console.WriteLine("Kind: " + myDate11.Kind); // Local  



Console.WriteLine("== 03 ============================================");
Console.WriteLine("DateTime Operators");
Console.WriteLine(Environment.NewLine);

// It is 10th December 2015  
System.DateTime dtObject = new System.DateTime(2015, 12, 10); // 12/10/2015 12:00:00 AM  
// TimeSpan object with 15 days, 10 hours, 5 minutes and 1 second.  
System.TimeSpan timeSpan = new System.TimeSpan(15, 10, 5, 1);
System.DateTime addResult = dtObject + timeSpan; // 12/25/2015 10:05:01 AM  
System.DateTime substarctResult = dtObject - timeSpan; // 11/24/2015 1:54:59 PM  

DateTime dec25 = new DateTime(2015, 12, 25);
DateTime dec15 = new DateTime(2015, 12, 15);

// areEqual gets false.  
bool areEqual = dec25 == dec15;
DateTime newDate = new DateTime(2015, 12, 25);
// areEqual gets true.  
areEqual = dec25 == newDate;




Console.WriteLine("== 04 ============================================");
Console.WriteLine("DateTime Formatting");
Console.WriteLine(Environment.NewLine);

DateTime tempDate = new DateTime(2015, 12, 08); // creating date object with 8th December 2015  
Console.WriteLine(tempDate.ToString("MMMM dd, yyyy")); //December 08, 2105. 



Console.WriteLine("== 05 ============================================");
Console.WriteLine("Handling Nullable DateTime");
Console.WriteLine(Environment.NewLine);

Nullable<DateTime> nullDateTime;
DateTime? nullDateTime01 = null;



Console.WriteLine("== 06 ============================================");
Console.WriteLine("Parse string to DateTime object");
Console.WriteLine(Environment.NewLine);

CultureInfo culture = new CultureInfo("en-US");

DateTime dateTimeObj00 = Convert.ToDateTime("10/22/2015 12:10:15 PM", culture);
//DateTime dateTimeObj01 = DateTime.Parse("10/22/2015 12:10:15 PM");
DateTime dateTimeObj02 = DateTime.ParseExact("10-22-2015", "MM-dd-yyyy", culture); // 10/22/2015 12:00:00 AM  

DateTime dateTimeObj04; // 10-22-2015 12:00:00 AM  
bool isSuccess = DateTime.TryParse("10-22-2015", out dateTimeObj04); // True  

DateTime dateTimeObj; // 10/22/2015 12:00:00 AM  
CultureInfo provider = CultureInfo.InvariantCulture;
bool isSuccess01 = DateTime.TryParseExact("10-22-2015", "MM-dd-yyyy", provider, DateTimeStyles.None, out dateTimeObj); // True  




Console.WriteLine("== 07 ============================================");
Console.WriteLine("Working with Calendars");
Console.WriteLine(Environment.NewLine);

CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
Calendar cl = currentCulture.Calendar; // System.Globalization.GregorianCalendar  
string temip = cl.ToString().Replace("System.Globalization.", "");

// 4th Jan 2016 - current date  
Calendar calendar = new HijriCalendar();
DateTime dt10 = new DateTime(2016, 01, 04, calendar);// Uses month 13!  
Console.WriteLine("HijriCalendar year: " + dt10.Year); // 2141  
Console.WriteLine("HijriCalendar month: " + dt10.Month); // 9  
Console.WriteLine("HijriCalendar total date: " + dt10.ToString("d")); // 9  

// Converting one Calendar value to another - Option1  
var calendar1 = new HijriCalendar();
var hijriYear = calendar1.GetYear(DateTime.Now); // 1437  
var hijriMonth = calendar1.GetMonth(DateTime.Now); // 3  
var hijriDay = calendar1.GetDayOfMonth(DateTime.Now); // 24  

//- Option2  
DateTime utc = DateTime.Now;
var ci = CultureInfo.CreateSpecificCulture("ar-SA");
string s = utc.ToString(ci); // 24/03/37 08:15:03 ?
                             // A calendar divides into multiple eras. In .Net framework it supports only one era except JapaneseCalendar (supports multiple).  

Calendar cal = new JapaneseCalendar();
foreach (int era in cal.Eras)
{
    DateTime date22 = cal.ToDateTime(year, month, day, 0, 0, 0, 0, era);

    Console.WriteLine("{0}/{1}/{2} era {3} in Japanese Calendar -> {4:d} in Gregorian", cal.GetMonth(date22), cal.GetDayOfMonth(date22), cal.GetYear(date22), cal.GetEra(date22), date22);
}



Console.WriteLine("== 08 ============================================");
Console.WriteLine("DateTime with Different Culture");
Console.WriteLine(Environment.NewLine);

// Current culture name  
string currentCulture10 = Thread.CurrentThread.CurrentCulture.DisplayName;

DateTime currentTime = DateTime.Now; //"1/9/2016 10:22:45 AM"  
//// Getting DateTime based on culture.  
string dateInUSA = currentTime.ToString("D", new CultureInfo("en-US")); // USA - Saturday, January 09, 2016  
string dateInHindi = currentTime.ToString("D", new CultureInfo("hi-IN")); // Hindi - 09 ????? 2016  
string dateInJapan = currentTime.ToString("D", new CultureInfo("ja-JP")); // Japan - 2016?1?9?  
string dateInFrench = currentTime.ToString("D", new CultureInfo("fr-FR")); // French - samedi 9 janvier 2016  

string dateInOriya = currentTime.ToString("D", new CultureInfo("or")); // Oriya - 09 ???????? 2016  
// Convert Hindi Date to French Date  
DateTime originalResult = new DateTime(2016, 01, 09);
// Converting Hindi Date to DateTime object  
bool success = DateTime.TryParse(dateInHindi, new System.Globalization.CultureInfo("hi-IN"),
System.Globalization.DateTimeStyles.None, out originalResult);

// Next convert current date to French date  
string frenchTDate = originalResult.ToString("D", new CultureInfo("fr-FR")); // French - samedi 9 janvier 2016  

// To get DatePattern from Culture  
CultureInfo fr = new CultureInfo("fr-FR");
string shortUsDateFormatString = fr.DateTimeFormat.LongDatePattern;
string shortUsTimeFormatString = fr.DateTimeFormat.ShortTimePattern;

// To get all installed culture in .Net version  
foreach (CultureInfo c_i in CultureInfo.GetCultures(CultureTypes.AllCultures))
{
    Console.WriteLine(c_i.Name + ", " + c_i.EnglishName);
}




Console.WriteLine("== 09 ============================================");
Console.WriteLine("What is DateTimeOffset?");
Console.WriteLine(Environment.NewLine);
// Original time: 1/9/2016 2:27:00 PM  
DateTimeOffset date = DateTimeOffset.Now; // 1/9/2016 2:27:00 PM +05:30  

// You can get Offset value using Offset property  
DateTimeOffset dateTimeObjP = DateTime.Now;
int x = dateTimeObjP.Offset.Hours; // 5
int y = dateTimeObjP.Offset.Minutes; //30  
int z = dateTimeObjP.Offset.Seconds; // 0  

// Get only DateTime from DateTimeOffset  
var q = dateTimeObjP.DateTime; // 1/9/2016 2:27:00 PM  

// Get Utc time from DateTime Offset  
dateTimeObjP.UtcDateTime.ToString(); // 1/9/2016 7:57:00 PM  

// Get Utc from local time  
DateTime utcTimeObjR = DateTimeOffset.Parse(DateTime.Now.ToString()).UtcDateTime;

// Another way to get Utc from local time  
DateTime utcTimeObjT = DateTime.Now.ToUniversalTime();

// Get local time from Utc time  
DateTime localVersion = DateTime.UtcNow.ToLocalTime();

// Another way to get local(India) time from Utc time  
localVersion = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));





Console.WriteLine("== 10============================================");
Console.WriteLine("Working with TimeSpan");
Console.WriteLine(Environment.NewLine);
TimeSpan ts = new TimeSpan(10, 40, 20); // 10 - hour, 40 - minute, 20 - second  
TimeSpan ts1 = new TimeSpan(1, 2, 5, 10); // 1 - day, 2 - hour, 5 - minute, 10 – seconds  

// You can add TimeSpan with DateTime object as well as TimeSpan object.  
TimeSpan ts3 = new TimeSpan(10, 40, 20); // 10 - hour, 40 - minute, 20 - second  
TimeSpan ts4 = new TimeSpan(1, 2, 5, 10); // 1 - day, 2 - hour, 5 - minute, 10 – seconds  

DateTime tt = DateTime.Now + ts; // Addition with DateTime  
ts.Add(ts1); // Addition with TimeSpan Object  

TimeSpan ts5 = new TimeSpan(10000000);
double secondFromTs = ts5.TotalSeconds; // 1 second  
Console.WriteLine(secondFromTs);

// Define two dates.  
DateTime date11 = new DateTime(2016, 1, 10, 11, 20, 30);
DateTime date21 = new DateTime(2016, 2, 20, 12, 25, 35);

// Calculate the interval between the two dates.  
TimeSpan interval = date21 - date11;

// Display individual properties of the resulting TimeSpan object.  
Console.WriteLine("No of Days:", interval.Days); // 41  
Console.WriteLine("Total No of Days:", interval.TotalDays); // 41.0451  
Console.WriteLine("No of Hours:", interval.Hours); //1  
Console.WriteLine("Total No of Hours:", interval.TotalHours); // 985.084  
Console.WriteLine("No of Minutes:", interval.Minutes); // 5  
Console.WriteLine("Total No of Minutes:", interval.TotalMinutes); // 59105.833  
Console.WriteLine("No of Seconds:", interval.Seconds); // 5  
Console.WriteLine("Total No of Seconds:", interval.TotalSeconds); // 3546305.0  
Console.WriteLine("No of Milliseconds:", interval.Milliseconds); // 0  
Console.WriteLine("Total No of Milliseconds:", interval.TotalMilliseconds); // 3546305000  
Console.WriteLine("Ticks:", interval.Ticks); // 354630500000000  