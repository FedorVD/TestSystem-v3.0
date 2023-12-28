using System.IO;
using System.Text;
using System.Windows;

namespace TestSystem_v3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ApplicationContext db = new ApplicationContext())
            {
                if (db.Users.FirstOrDefault() == null) { MessageBox.Show("Список пользователей пуст, обратитесь к администратору"); }
                /*User u1 = new User { Name = "Иван", Surname = "Иванович", SecondName = "Иванов", Department = "Производственный цех", Position = "Оператор", Login = "IvanovII", Password = "asdfg" };
                db.Users.Add(u1);
                db.SaveChanges();*/
            }
            LoginText.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var firstUser = db.Users.FirstOrDefault();
                if (LoginText.Text == "Admin")
                {
                    char[] chars;
                    using (FileStream fs = new FileStream("Admin.dat", FileMode.Open, FileAccess.Read))
                    {
                        byte[] bytes = new byte[(int)fs.Length];
                        fs.Read(bytes, 0, bytes.Length);
                        chars = Encoding.Default.GetChars(bytes);
                        for (int i = 0; i < chars.Length; i++) chars[i] = (char)((int)chars[i] + 32);
                    }
                    string password = new string(chars);
                    if (password != PasswordText.Password) { MessageBox.Show("Пароль не верный!"); }
                    else
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Close();
                    }
                }
                else if (firstUser != null)// здесь обработка таблицы пользователей на поиск введенного логина 
                {
                    User? user = new User();
                    try { user = db.Users.Where(n => n.Login == LoginText.Text).Single(); }
                    catch { user = null; }
                    finally { }
                    if (user == null)
                    { MessageBox.Show("Пользователь с такой учетной записью не обнаружен"); }
                    else
                    {
                        if (user.Password != PasswordText.Password) { MessageBox.Show("Пароль не правильный"); }
                        else
                        {
                            UserForm userForm = new UserForm(user.Id);
                            userForm.Show();
                            this.Close();
                        }
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}