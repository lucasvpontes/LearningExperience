using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace LearningExperience.Utils
{
    public static class Helpers
    {
        public static readonly TimeZoneInfo hwZone = TimeZoneInfo.CreateCustomTimeZone("BR_No_DST", new TimeSpan(-3, 0, 0), "BR No DST", "BR no DST");


        public static string GetCollectionName(string collectionName)
        {
            collectionName = collectionName.Replace("ys", "ies");
            if (collectionName.EndsWith("chs"))
            {
                collectionName = collectionName.Substring(0, collectionName.Length - 3) + "ches";
            }
            return collectionName;
        }

public static DateTime BrazilTime(DateTime? dateTime = null)
        {
            if (dateTime == null)
                dateTime = DateTime.Now;
            return TimeZoneInfo.ConvertTime(dateTime.Value, hwZone);
        }


        public static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }

        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        public static bool RegexMatchValidate(string regex, string textValidate)
        {
            if (string.IsNullOrEmpty(textValidate) || string.IsNullOrEmpty(regex))
                return false;

            if (Regex.Match(textValidate, regex, RegexOptions.IgnoreCase).Success)
                return true;

            return false;
        }

        public static double GetAge(DateTime dateOfBirth, DateTime today)
        {
            int years = today.Year - dateOfBirth.Year;
            DateTime last = dateOfBirth.AddYears(years);
            if (last > today)
            {
                last = last.AddYears(-1);
                years--;
            }
            // get the next birthday
            DateTime next = last.AddYears(1);
            // calculate the number of days between them
            double yearDays = (next - last).Days;
            // calcluate the number of days since last birthday
            double days = (today - last).Days;
            // calculate exaxt age
            return years + (days / yearDays);
        }


        public static int MonthsBetween(DateTime startDate, DateTime endDate)
        {
            var year1 = startDate.Year;
            var year2 = endDate.Year;
            var month1 = startDate.Month;
            var month2 = endDate.Month;
            return (year2 - year1) * 12 + (month2 - month1) + 1;
        }



        public static string ToJsonString(Object obj)
        {
            if (obj == null)
                return "";
            using (var sWriter = new StringWriter())
            using (var jWriter = new JsonTextWriter(sWriter))
            {
                JsonSerializer.Create().Serialize(jWriter, obj);

                var result = sWriter.ToString();

                return result;
            }
        }
        public static string ToCamelCaseJsonString(Object obj)
        {
            using (var sWriter = new StringWriter())
            using (var jWriter = new JsonTextWriter(sWriter))
            {
                JsonSerializer.Create(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }).Serialize(jWriter, obj);

                var result = sWriter.ToString();

                return result;
            }
        }

        public static String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;

                int test;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }

        public static string RemoveSpecialCharacter(string valor)
        {
            return Regex.Replace(valor, @"[^0-9a-zA-Z]+", string.Empty);
        }

        public static string ConvertFileToBase64String(string filePath)
        {
            var extension = NormalizeString(Path.GetExtension(filePath).ToUpper());
            byte[] byteArray;
            string ext = Path.GetExtension(filePath).ToLower();
            byteArray = File.ReadAllBytes(filePath);
            return Convert.ToBase64String(byteArray);
        }

        public static string NormalizeString(string Text)
        {
            if (Text == null)
                Text = "";

            Text = Text.Replace("ç", "c");
            Text = Text.Replace("Ç", "C");
            Text = Text.Replace("ó", "o");
            Text = Text.Replace("Ó", "O");
            Text = Text.Replace("õ", "o");
            Text = Text.Replace("Õ", "O");
            Text = Text.Replace("ô", "o");
            Text = Text.Replace("Ô", "O");
            Text = Text.Replace("-", "");
            Text = Text.Replace(".", "");
            Text = Text.Replace("\r", "");
            Text = Text.Replace("\n", "");
            Text = Text.Trim();

            return RemoveDiacritics(Text);
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string GetAlphaValue(Object value, int maxSize)
        {
            if (value == null)
                return "";

            var str = value.ToString();
            str = OnlyAlphaNumerics(NormalizeString(str));

            if (str.Length > maxSize)
                str = str.Substring(0, maxSize);

            return str.Trim();
        }

        public static string OnlyAlphaNumerics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            Regex rgx = new Regex("[^a-zA-Z0-9 ]");

            return rgx.Replace(text, "");
        }

        public static string NumberToMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Janeiro";
                case 2:
                    return "Fevereiro";
                case 3:
                    return "Março";
                case 4:
                    return "Abril";
                case 5:
                    return "Maio";
                case 6:
                    return "Junho";
                case 7:
                    return "Julho";
                case 8:
                    return "Agosto";
                case 9:
                    return "Setembro";
                case 10:
                    return "Outubro";
                case 11:
                    return "Novembro";
                case 12:
                    return "Dezembro";
                default:
                    return "Não Encontrado";

            }
        }
    }
}