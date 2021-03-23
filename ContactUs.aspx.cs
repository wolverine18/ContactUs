using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ContactUs1
{
    public partial class ContactUs : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.ServerClick += BtnSubmit_ServerClick;
        }

        private void BtnSubmit_ServerClick(object sender, EventArgs e)
        {
            string fName = inputFirstName.Value;
            string lName = inputLastName.Value;
            string email = inputEmail.Value;
            string msg = taMessage.Value;

            if (!IsValidEmail(email))
            {
                lblInvalidEmail.Visible = true;
                return;
            }
            string fileTxt = GetFileText(fName, lName, email, msg);
            string fileName = GetFileName(fName, lName);

            //Gets the destination path in the root folder
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            //Create and write to file if it doesn't exist else overwrite existing file
            File.WriteAllText(destPath, fileTxt);

            ClearFields();
            this.ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", string.Format("<script type='text/javascript'>alert('{0}')</script>", "Contact form succesfully submitted."));
        }

        private static string GetFileName(string fName, string lName)
        {
            //default file name is "info.txt", else first name plus last name .txt
            string fileName = "info.txt";
            if (!string.IsNullOrEmpty(fName) || !string.IsNullOrEmpty(lName))
            {
                fileName = fName + lName + ".txt";
            }

            return fileName;
        }

        private static string GetFileText(string fName, string lName, string email, string msg)
        {
            return $"First Name: {fName}{Environment.NewLine}Last Name: {lName}{Environment.NewLine}Email: {email}{Environment.NewLine}Message: {msg}";
        }

        private void ClearFields()
        {
            lblInvalidEmail.Visible = false;
            inputFirstName.Value = "";
            inputLastName.Value = "";
            inputEmail.Value = "";
            taMessage.Value = "";
        }

        private bool IsValidEmail(string email)
        {
            //regex taken from this post https://code.4noobz.net/c-email-validation/
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}