using Chameleon.Data;
using Chameleon.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Chameleon.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeComponentsAvailability();
            Login(new User
            {
                UserName = txtUser.Text,
                Password = txtPassword.Text
            });
            ChangeComponentsAvailability();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(null, "Deseja sair ?", "Chameleon", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button1_Click(sender, e);
        }

        private void ChangeComponentsAvailability()
        {
            txtUser.Enabled = !txtUser.Enabled;
            txtPassword.Enabled = !txtPassword.Enabled;
            btnLogin.Enabled = !btnLogin.Enabled;
            btnExit.Enabled = !btnExit.Enabled;
        }

        private string GetMD5Hash(MD5 md5Hash, string text)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            foreach (var item in data)
            {
                sBuilder.Append(item.ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private bool CompareHashes(MD5 md5Hash, string password, string hash)
        {
            string hashOfInput = GetMD5Hash(md5Hash, password);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        private void Login(User userModel)
        {
            bool isAuthenticated = false;
            var user = userModel.UserName;
            var password = userModel.Password;

            if ((string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user)) ||
                (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)))
            {
                MessageBox.Show(null, "Email e/ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MD5 md5hash = MD5.Create())
            {
                try
                {
                    var dbUser = AuthRepository.AuthUser(new User
                    {
                        UserName = user
                    });

                    if (dbUser == null)
                    {
                        MessageBox.Show(null, "Email e/ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (CompareHashes(md5hash, password, dbUser?.Password))
                            isAuthenticated = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(null, $"Ocorreu um erro interno. Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (isAuthenticated)
            {
                Hide();
                new FormVendas().Show();
            }
            else
                MessageBox.Show(null, "Email e/ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
