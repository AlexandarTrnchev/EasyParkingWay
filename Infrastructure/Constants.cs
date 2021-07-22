using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class Constants
    {
        #region Roles

        public static string AdministratorRole = "Administrator";
        public static string EmployeeRole = "Employee";
        public static string ProjectManagerRole = "Project Manager";
        public static string HRRole = "Human Resources";

        #endregion

        #region DevOps

        public static string DevOpsPAT = "n==";

        #endregion


        #region regex

        public static string[] PhonePatterns = new string[] {
           @"^[0-9]{10}$",                     // xxxxxxxxxx       
           //@"^\+[0-9]{2}\s+[0-9]{2}[0-9]{8}$", //+xx xx xxxxxxxx   
           //@"^\+[0-9]{3}\s+[0-9]{3}\s+[0-9]{6}$", //+xxx xxx xxxxxx   
           //@"^[0-9]{3}-[0-9]{4}-[0-9]{4}$",    // xxx-xxxx-xxxx
           @"^\+[0-9]{12}$", // +xxxxxxxxxxxx
         };
        #endregion

        #region Strings

        public static string UserMicrosoftIdClaim = "oid";
        public static string UserIdClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        #endregion
    }
}
