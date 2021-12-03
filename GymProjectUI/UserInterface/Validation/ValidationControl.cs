using GYMDatabaseProject.Models;
using GYMDatabaseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using GYMDatabaseProject.DataAccess;
using System.Windows;
using GYMProjectUI;
using GymProjectUI.WPF_APPS;
using System.Windows.Media;
using System.Windows.Controls;

namespace GymProjectUI.Validation
{
    public static class EmailControl
    {
        static private MainWindow main = new MainWindow();
        static private Register register = new Register();

        public static async Task<bool> EmailExists(string email)
        {
            using(var dbContext = new DatabaseGYM())
            {
                return await Task.Run(() =>
                {
                    if (dbContext.Users.Where(user => user.Email == email).Any())
                    {
                        return true;
                    }
                    else return false;
                });
            }
        }
    }


    public static class Password_Control
    {
        static private MainWindow main = new MainWindow();
        static private Register register = new Register();

        // Validation of password length, charachters(Uppercase , numeric, and symbol)
        public static async Task<bool> Validate_Password_RegisterAsync(string pass)
        {
            //checking password length
            return await Task.Run(async () =>
            {
                string[] warnings = new string[4];

                // If all set - final return is true //
                bool lengthCheck = await LengthCheckAsync(pass);
                bool upperCheck = await UpperCheckAsync(pass);
                bool lowerCheck = await LowerCheckAsync(pass);
                bool digitCheck = await DigitCheckAsync(pass);
                bool separatorCheck = await SeparatorCheckAsync(pass);

                if (lengthCheck && upperCheck && lowerCheck && digitCheck && !separatorCheck) return true;
                else return false;

            });
        }

        private static async Task<bool> UpperCheckAsync(string pass)
        {
            return await Task.Run(() => { return pass.Any(char.IsUpper); });
        }

        private static async Task<bool> LowerCheckAsync(string pass)
        {
            return await  Task.Run(() => { return pass.Any(char.IsLower); });
        }

        private static async Task<bool> DigitCheckAsync(string pass)
        {
            return await  Task.Run(() => { return pass.Any(char.IsDigit); });
        }

        private static async Task<bool> SeparatorCheckAsync(string pass)
        {
            return await Task.Run(() => { return pass.Any(char.IsSeparator); });
        }
        private static async Task<bool> LengthCheckAsync(string pass)
        {
            return await Task.Run(() => { return pass.Length > 6 && pass.Length < 20; });
        }

        public static bool Validate_Password_On_DB(int id, string password)
        {
            using (var dbContext = new DatabaseGYM())
            {
                if (dbContext.Users.Where(user => user.User_ID == id).Any())
                {
                    if (dbContext.Users.Where(user => user._Password == password).Any()) return true;
                    else main.incorrectDataLabel.Content = "Password incorrect";
                }
                else main.incorrectDataLabel.Content = "ID incorrect";

                return false;
            }
        }
    }
}
