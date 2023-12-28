using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TestSystem_v3._0
{
    /// <summary>
    /// Логика взаимодействия для AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        List<User> UserList;
        List<Theme> ThemeList;
        List<Question> QuestionList;
        List<ScoreTable> ScoreTableList;


        // определение визуализации списков пользователей и тестов
        ListBox userListBox = null;
        ListBox themeListBox = null;
        ListBox questionListBox = null;

        // опредлеение форм управления тестом: изменение/добавление

        Label LabelAsk = new Label { Content = "Вопрос:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0,40,0,0)};
        TextBox AskText = new TextBox 
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 40 ,0,0),
            Width = 500,
            TextWrapping = TextWrapping.Wrap
        };
        Label labelAnswer = new Label { Content = "Варианты ответа: ",
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Top,
        Margin = new Thickness(0, 80,0,0)};
        TextBox ansver1Text = new TextBox 
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0,100,0,0),
            Width = 250
        };
        TextBox ansver2Text = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 120, 0, 0),
            Width = 250
        };
        TextBox ansver3Text = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 140, 0, 0),
            Width = 250
        };
        TextBox ansver4Text = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 160, 0, 0),
            Width = 250
        };
        RadioButton ansver1True = new RadioButton
        {
            GroupName = "true",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness (300, 100,0,0)
        };
        RadioButton ansver2True = new RadioButton
        {
            GroupName = "true",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(300, 120, 0, 0)
        };
        RadioButton ansver3True = new RadioButton
        {
            GroupName = "true",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(300, 140, 0, 0)
        };
        RadioButton ansver4True = new RadioButton
        {
            GroupName = "true",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(300, 160, 0, 0)
        };

        ScrollViewer scrollViewer = new ScrollViewer { HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
            Margin=new Thickness(0, 60, 0, 0),
            Height = 350,
            Width = 500
        };

        //определение форм управления добавлением/редактированием пользователя
        Label LabelUserName = new Label { Content = "Имя:", 
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness (0,80,0,0)};
        Label LabelUserSurname = new Label
        {
            Content = "Фамилия:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 60, 0, 0)
        };
        Label LabelUserSecodname = new Label
        {
            Content = "Отчество:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 100, 0, 0)
        };
        Label LabelUserDepartment = new Label
        {
            Content = "Подразделение:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 120, 0, 0)
        };
        Label LabelUserPosition = new Label
        {
            Content = "Должность:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 140, 0, 0)
        };
        Label LabelUserLogin = new Label
        {
            Content = "Логин:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 160, 0, 0)
        };
        Label LabelUserPassword = new Label
        {
            Content = "Пароль:",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(0, 180, 0, 0)
        };
        TextBox UserName = new TextBox {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 80, 0, 0),
            Width = 200
        };
        TextBox UserSurname = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 60, 0, 0),
            Width = 200
        };
        TextBox UserSecodname = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 100, 0, 0),
            Width = 200
        };
        TextBox UserDepartment = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 120, 0, 0),
            Width = 200
        };
        TextBox UserPosition = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 140, 0, 0),
            Width = 200
        };
        TextBox UserLogin = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 160, 0, 0),
            Width = 200
        };
        TextBox UserPassword = new TextBox
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(100, 180, 0, 0),
            Width = 200
        };


        string? changeLogin;
        int? indexEditQuestion;
        int? indexTheme;
        User tempUser;
        public AdminForm()
        {
            InitializeComponent();
            MenuAdmin();
        }

        private void MenuAdmin()
        {
            Menu AdminMenu = new Menu
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 26,
                Width = 790,
                Margin = new Thickness(0, 1, 0, 0),
            };
            var menuItem1 = new MenuItem { Header = "Пользователи" };
            var menuItem2 = new MenuItem { Header = "Темы тестирования" };
            var menuItem3 = new MenuItem { Header = "Статистика" };
            var menuItem4 = new MenuItem { Header = "Справка" };
            var menuItem5 = new MenuItem { Header = "Выход" };
            menuItem1.Click += MenuItemUser_Click;
            menuItem2.Click += MenuItemThemes_Click;
            menuItem3.Click += MenuItemStatistics_Click;
            menuItem4.Click += MenuItemHelp_Click;
            menuItem5.Click += MenuItemExit_Click;
            AdminMenu.Items.Add(menuItem1);
            AdminMenu.Items.Add(menuItem2);
            AdminMenu.Items.Add(menuItem3);
            AdminMenu.Items.Add(menuItem4);
            AdminMenu.Items.Add(menuItem5);
            AdminMainGrid.Children.Add(AdminMenu);
        }

        private void MenuItemUser_Click(object sender, RoutedEventArgs e)
        {
            AdminMainGrid.Children.Clear();
            MenuAdmin();
            using (ApplicationContext db = new ApplicationContext())
            {
                UserList = db.Users.ToList();
            }
                Label UserListLabel = new Label { Content = "Список всех пользователей:", Margin = new Thickness(0, 40, 0, 0) };
                userListBox = new ListBox { Margin = new Thickness(0, 70, 500, 0) };
                foreach (User u in UserList) 
                {
                    string userView = $"{u.Id}. {u.Surname} {u.Name.Substring(0,1)}. {u.SecondName.Substring(0,1)}. " +
                        $"{u.Position} {u.Department}";
                    userListBox.Items.Add(userView); 
                }
                    
                Button buttonAddUser = new Button
                {
                    Content = "Добавить пользователя",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(300, 100, 0, 0)
                };
                Button buttonDelUser = new Button
                {
                    Content = "Удалить пользователя",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(300, 150, 0, 0)
                };
                Button buttonEditUser = new Button
                {
                    Content = "Редактировать пользователя",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(300, 200, 0, 0)
                };

                buttonAddUser.Click += ButtonAddUserClick;
                buttonDelUser.Click += ButtonDelUserClick;
                buttonEditUser.Click += ButtonEditUserClick;

                AdminMainGrid.Children.Add(UserListLabel);
                AdminMainGrid.Children.Add(userListBox);
                AdminMainGrid.Children.Add(buttonAddUser);
                AdminMainGrid.Children.Add(buttonDelUser);
                AdminMainGrid.Children.Add(buttonEditUser);
            
        }

        private void ButtonAddUserClick(object sender, RoutedEventArgs e)
        {
            AdminMainGrid.Children.Clear();
            MenuAdmin();
            changeLogin = null;
            UserSurname.Text = "";
            UserName.Text = "";
            UserSecodname.Text = "";
            UserDepartment.Text = "";
            UserPosition.Text = "";
            UserLogin.Text = "";
            UserPassword.Text = "";
            getEditUserForm();
        }

        private void getEditUserForm()
        {
            AdminMainGrid.Children.Add(LabelUserSurname);
            AdminMainGrid.Children.Add(LabelUserName);
            AdminMainGrid.Children.Add(LabelUserSecodname);
            AdminMainGrid.Children.Add(LabelUserDepartment);
            AdminMainGrid.Children.Add(LabelUserPosition);
            AdminMainGrid.Children.Add(LabelUserLogin);
            AdminMainGrid.Children.Add(LabelUserPassword);
            AdminMainGrid.Children.Add(UserSurname);
            AdminMainGrid.Children.Add(UserName);
            AdminMainGrid.Children.Add(UserSecodname);
            AdminMainGrid.Children.Add(UserDepartment);
            AdminMainGrid.Children.Add(UserPosition);
            AdminMainGrid.Children.Add(UserLogin);
            AdminMainGrid.Children.Add(UserPassword);

            Button ButtonUserOk = new Button
            {
                Content = "Ok",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(60, 220, 0, 0)
            };
            Button ButtonUserCancel = new Button
            {
                Content = "Отмена",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(140, 220, 0, 0)
            };
            ButtonUserOk.Click += ButtonUserOkClick;
            ButtonUserCancel.Click += MenuItemUser_Click;

            AdminMainGrid.Children.Add(ButtonUserOk);
            AdminMainGrid.Children.Add(ButtonUserCancel);
        }

        private void ButtonUserOkClick(object sender, RoutedEventArgs e) 
        {
            if (UserName.Text == "" || UserSecodname.Text == "" || UserSurname.Text == "" || UserDepartment.Text == "" ||
                UserPosition.Text == "" || UserLogin.Text == "" || UserPassword.Text == "") { MessageBox.Show("Все поля должны быть заполнены."); }
            else if (UserList.Where(l => l.Login == UserLogin.Text).Count() != 0 && UserLogin.Text != changeLogin) 
                MessageBox.Show("Пользователь с таким логином существует. Учетная запись должна быть уникальной");
            else
            {
                if (changeLogin == null)
                {
                    tempUser = new User
                    {
                        Name = UserName.Text,
                        SecondName = UserSecodname.Text,
                        Surname = UserSurname.Text,
                        Department = UserDepartment.Text,
                        Position = UserPosition.Text,
                        Login = UserLogin.Text,
                        Password = UserPassword.Text
                    };
                    UserList.Add(tempUser);
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        db.Users.Add(tempUser);
                        db.SaveChanges();
                    }                   
                }
                else
                {                   
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        tempUser=  db.Users.Where(l => l.Login == changeLogin).Single();
                        tempUser.Name = UserName.Text;
                        tempUser.SecondName = UserSecodname.Text;
                        tempUser.Surname = UserSurname.Text;
                        tempUser.Department = UserDepartment.Text;
                        tempUser.Position = UserPosition.Text;
                        tempUser.Login = UserLogin.Text;
                        tempUser.Password = UserPassword.Text;
                        db.SaveChanges();
                    }                    
                }
            }
            MenuItemUser_Click(sender, e);
        }

        private void ButtonDelUserClick(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedItems.Count == 0) MessageBox.Show("Выберите пользователя для удаления");
            else if (MessageBox.Show("Вы уверены что хотите удалить этого пользователя?", 
                "Удаление пользователя",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int indexDot = userListBox.SelectedItem.ToString().IndexOf('.');
                int idDel = Int32.Parse(userListBox.SelectedItem.ToString().Substring(0, indexDot));
                using (ApplicationContext db = new ApplicationContext()) 
                {
                    User user = db.Users.Where(u => u.Id == idDel).Single();
                    List<ScoreTable> scoresForDelete = db.ScoreTables.Where(s => s.UserId == idDel).ToList();
                    db.ScoreTables.RemoveRange(scoresForDelete);
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                MenuItemUser_Click(sender, e);
            }
        }

        private void ButtonEditUserClick(object sender, RoutedEventArgs e)
        {
            if (userListBox.SelectedItems.Count == 0) MessageBox.Show("Выберите пользователя для удаления");
            else
            {
                
                User user;
                int indexDot = userListBox.SelectedItem.ToString().IndexOf('.');
                int idEdit = Int32.Parse(userListBox.SelectedItem.ToString().Substring(0, indexDot));
                using (ApplicationContext db = new ApplicationContext())
                {
                    user = db.Users.Where(u => u.Id == idEdit).Single();
                }
                changeLogin = user.Login;
                UserName.Text = user.Name;
                UserSurname.Text = user.Surname;
                UserSecodname.Text = user.SecondName;
                UserDepartment.Text = user.Department;
                UserPosition.Text = user.Position;
                UserLogin.Text = user.Login;
                UserPassword.Text = user.Password;
                AdminMainGrid.Children.Clear();
                MenuAdmin();
                getEditUserForm();
            }
        }

        private void MenuItemThemes_Click(object sender, RoutedEventArgs e)
        {
            AdminMainGrid.Children.Clear();
            MenuAdmin();
            using(ApplicationContext db = new ApplicationContext()) { ThemeList = db.Themes.ToList(); }
            themeListBox = new ListBox
            {
                Margin = new Thickness(0, 70, 500, 0),
                Width = 280,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top
            };
            foreach (var theme in ThemeList) 
            {
                string themeView = $"{theme.Id}. - {theme.ThemeName} {(theme.IsHidden? " Удалена" : "Действительна")}";
                themeListBox.Items.Add(themeView);
            }
            Label ThemeListLabel = new Label { Content = "Список всех тем:", Margin = new Thickness(0, 40, 0, 0) };

            Button buttonOpenTheme = new Button { Content = "Открыть тему",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 34,
                Width = 230,
                Margin = new Thickness(300, 100, 0, 0)
            };
            Button buttonAddTheme = new Button
            {
                Content = "Добавить тему",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 34,
                Width = 230,
                Margin = new Thickness(300, 150, 0, 0)
            };
            Button buttonDelRestoreTheme = new Button
            {
                Content = "Пометить на удаление/снять пометку",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 34,
                Width = 230,
                Margin = new Thickness(300, 200, 0, 0)
            };

            buttonOpenTheme.Click += ButtonOpenTheme;
            buttonAddTheme.Click += ButtonAddTheme;
            buttonDelRestoreTheme.Click += ButtonDelRestoreTheme;

            AdminMainGrid.Children.Add(ThemeListLabel);
            AdminMainGrid.Children.Add(themeListBox);
            AdminMainGrid.Children.Add(buttonOpenTheme);
            AdminMainGrid.Children.Add(buttonAddTheme);
            AdminMainGrid.Children.Add(buttonDelRestoreTheme);

        }

        private void ButtonOpenTheme(object sender, RoutedEventArgs e)
        {
            if (themeListBox.SelectedItems.Count == 0) { MessageBox.Show("Не выбрана тема."); }
            else
            {
                AdminMainGrid.Children.Clear();
                MenuAdmin();
                int themeDot = themeListBox.SelectedItem.ToString().IndexOf('.');
                indexTheme = Int32.Parse(themeListBox.SelectedItem.ToString().Substring(0, themeDot));
                using (ApplicationContext db = new ApplicationContext())
                {
                    QuestionList = db.Questions.Where(q => q.themeId == indexTheme).ToList();
                }
                questionListBox = new ListBox { Margin = new Thickness(0, 0, 0, 0), Width = 500, Height = 350};
                string NameTheme = ThemeList.Where(i => i.Id == indexTheme).Single().ThemeName; 
                Label questionListLabel = new Label { Content = $"Список вопросов по теме {NameTheme}:", Margin = new Thickness(0, 40, 0, 0) };
                foreach (Question q in QuestionList) questionListBox.Items.Add($"{q.Id}. {q.Ask}");
                Button buttonAddQuestion = new Button
                {
                    Content = "Добавить вопрос",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(550, 100, 0, 0)
                };
                Button buttonEditQuestion = new Button
                {
                    Content = "Редактировать вопрос",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(550, 150, 0, 0)
                };
                Button buttonDelQuestion = new Button
                {
                    Content = "Удалить вопрос",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 34,
                    Width = 200,
                    Margin = new Thickness(550, 200, 0, 0)
                };
                
                buttonAddQuestion.Click += buttonAddQuestionClick;
                buttonEditQuestion.Click += ButtonEditQuestionClick;
                buttonDelQuestion.Click += ButtonDelQuestionClick;
                scrollViewer.Content = questionListBox;

                AdminMainGrid.Children.Add(questionListLabel);
                AdminMainGrid.Children.Add(scrollViewer);
                AdminMainGrid.Children.Add(buttonAddQuestion);
                AdminMainGrid.Children.Add(buttonEditQuestion);
                AdminMainGrid.Children.Add(buttonDelQuestion);
            }       
        }

        private void buttonAddQuestionClick(object sender, RoutedEventArgs e)
        {
            indexEditQuestion = null;
            AskText.Text = "";
            ansver1Text.Text = "";
            ansver2Text.Text = "";
            ansver3Text.Text = "";
            ansver4Text.Text = "";
            ansver1True.IsChecked = false;
            ansver2True.IsChecked = false;
            ansver3True.IsChecked = false;
            ansver4True.IsChecked = false;
            getEditQuestionForm();
        }

        private void ButtonEditQuestionClick(object sender, RoutedEventArgs e)
        {
            if (questionListBox.SelectedItems.Count == 0) { MessageBox.Show("Выберите вопрос для редактирования."); }
            else
            {
                int indexDot = questionListBox.SelectedItem.ToString().IndexOf('.');
                indexEditQuestion = Int32.Parse(questionListBox.SelectedItem.ToString().Substring(0, indexDot));
                Question quest = QuestionList.Where(q => q.Id == indexEditQuestion).Single();
                AskText.Text = quest.Ask;
                ansver1Text.Text = quest.Answer1;
                ansver2Text.Text = quest.Answer2;
                ansver3Text.Text = quest.Answer3;
                ansver4Text.Text = quest.Answer4;

                getEditQuestionForm();
            }
        }

        private void ButtonDelQuestionClick(object sender, RoutedEventArgs e)
        {
            if (questionListBox.SelectedItems.Count == 0) { MessageBox.Show("Выберите вопрос для редактирования."); }
            else
            {
                int indexDot = questionListBox.SelectedItem.ToString().IndexOf('.');
                int indexQuestion = Int32.Parse(questionListBox.SelectedItem.ToString().Substring(0, indexDot));
                using (ApplicationContext db = new ApplicationContext())
                {
                    Question question = db.Questions.Where(q => q.Id == indexQuestion).Single();
                    db.Questions.Remove(question);
                    db.SaveChanges();
                }
                ButtonOpenTheme(sender, e);
            }
        }

        private void getEditQuestionForm()
        {
            AdminMainGrid.Children.Clear();
            MenuAdmin();
            Button AcceptQuestionChanges = new Button
            {
                Content = "Ok",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(150, 200, 0, 0)
            };
            Button CancelQuestionChanges = new Button
            {
                Content = "Отмена",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(200, 200, 0, 0)
            };
            AcceptQuestionChanges.Click += AcceptQuestionChangesclick;
            CancelQuestionChanges.Click += ButtonOpenTheme;
            AdminMainGrid.Children.Add(LabelAsk);
            AdminMainGrid.Children.Add(AskText);
            AdminMainGrid.Children.Add(labelAnswer);
            AdminMainGrid.Children.Add(ansver1Text);
            AdminMainGrid.Children.Add(ansver1True);
            AdminMainGrid.Children.Add(ansver2Text);
            AdminMainGrid.Children.Add(ansver2True);
            AdminMainGrid.Children.Add(ansver3Text);
            AdminMainGrid.Children.Add(ansver3True);
            AdminMainGrid.Children.Add(ansver4Text);
            AdminMainGrid.Children.Add(ansver4True);
            AdminMainGrid.Children.Add(AcceptQuestionChanges);
            AdminMainGrid.Children.Add(CancelQuestionChanges);
        }

        private void AcceptQuestionChangesclick(object sender, RoutedEventArgs e) 
        {
            // прописать схему добваления вопроса или редактирования
            Question tempQuestion;
            if (AskText.Text =="" || ansver1Text.Text == "" || ansver2Text.Text == "" || ansver3Text.Text == "" || ansver4Text.Text == "") { MessageBox.Show("Все поля должны быть заполнены"); }
            else if (ansver1True.IsChecked == false && ansver2True.IsChecked == false && ansver3True.IsChecked == false && ansver4True.IsChecked == false)
            { MessageBox.Show("Надо указать правильный ответ"); }
            else //if (indexEditQuestion == null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (indexEditQuestion == null) 
                    { tempQuestion = new Question(); }
                    else 
                    { tempQuestion = db.Questions.Where(q => q.Id == indexEditQuestion).Single(); }
                    tempQuestion.Ask = AskText.Text;
                    tempQuestion.Answer1 = ansver1Text.Text;
                    tempQuestion.Answer2 = ansver2Text.Text;
                    tempQuestion.Answer3 = ansver3Text.Text;
                    tempQuestion.Answer4 = ansver4Text.Text;
                    if (ansver1True.IsChecked == true) tempQuestion.rightAnswer = 1;
                    if (ansver2True.IsChecked == true) tempQuestion.rightAnswer = 2;
                    if (ansver3True.IsChecked == true) tempQuestion.rightAnswer = 3;
                    if (ansver4True.IsChecked == true) tempQuestion.rightAnswer = 4;
                    tempQuestion.themeId = (int)indexTheme;
                    if (indexEditQuestion == null) { db.Questions.Add(tempQuestion); }
                    db.SaveChanges();
                }                
            }
            /*else
            {
                using (ApplicationContext db = new ApplicationContext()) 
                {
                    tempQuestion = db.Questions.Where(q => q.Id == indexEditQuestion).Single();
                    tempQuestion.Ask = AskText.Text;
                    tempQuestion.Answer1 = ansver1Text.Text;
                    tempQuestion.Answer2 = ansver2Text.Text;
                    tempQuestion.Answer3 = ansver3Text.Text;
                    tempQuestion.Answer4 = ansver4Text.Text;
                    if (ansver1True.IsChecked == true) tempQuestion.rightAnswer = 1;
                    if (ansver2True.IsChecked == true) tempQuestion.rightAnswer = 2;
                    if (ansver3True.IsChecked == true) tempQuestion.rightAnswer = 3;
                    if (ansver4True.IsChecked == true) tempQuestion.rightAnswer = 4;
                    tempQuestion.themeId = (int)indexTheme;
                    db.SaveChanges();
                }
            }*/
            ButtonOpenTheme(sender, e);
        }

        private void ButtonAddTheme(object sender, RoutedEventArgs e)
        {
            string nameTheme = Interaction.InputBox("Введите тему", "Название темы тестирования");
            Theme tempTheme = new Theme { ThemeName = nameTheme, IsHidden = false };
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Themes.Add(tempTheme);
                db.SaveChanges();
            }
            MenuItemThemes_Click(sender, e);
        }

        private void ButtonDelRestoreTheme(object sender, RoutedEventArgs e) 
        {
            if (themeListBox.SelectedItems.Count == 0) MessageBox.Show("Выберите тему.");
            else
            {
                int themeId = Int32.Parse(themeListBox.SelectedItem.ToString().Substring(0,1));
                using (ApplicationContext db = new ApplicationContext())
                {
                    Theme theme = db.Themes.Where(t => t.Id == themeId).Single();
                    if (theme.IsHidden)

                        theme.IsHidden = false;
                    else
                        theme.IsHidden = true;
                    db.SaveChanges();
                }
                MenuItemThemes_Click(sender, e);
            }        
        }

        private void MenuItemStatistics_Click(object sender, RoutedEventArgs e)
        {
            AdminMainGrid.Children.Clear();
            MenuAdmin();
            using (ApplicationContext db = new ApplicationContext())
            {
                ScoreTableList = db.ScoreTables.ToList();
                QuestionList = db.Questions.ToList();
                ThemeList = db.Themes.ToList();
                UserList = db.Users.ToList();
            }
            if (ScoreTableList.Count == 0) { MessageBox.Show("Таблица статистики пуста."); }
            else
            {
                DataGrid StatTable = new DataGrid
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 20, 0, 0),
                    AutoGenerateColumns = true,
                };
                var table = new DataTable();
                table.Columns.Add(new DataColumn("Сотрудник", typeof(string)));
                foreach (Theme item in ThemeList) { table.Columns.Add(new DataColumn(item.ThemeName, typeof(string))); }
                foreach (var user in UserList)
                {
                    var selection = ScoreTableList.Where(u => u.UserId == user.Id).ToList();
                    if (selection.Count > 0)
                    {
                        var rowInTable = table.NewRow();
                        rowInTable[0] = $"{user.Surname} {user.Name.Substring(0, 1)}.{user.SecondName.Substring(0, 1)}. {user.Position} {user.Department}";
                        for (int i = 0; i < ThemeList.Count; i++)
                        {
                            ScoreTable point = null;
                            try
                            {
                                point = ScoreTableList.Where(t => t.ThemeId == ThemeList[i].Id && t.UserId == user.Id).Single();
                            }
                            catch { }
                            finally { }
                            if (point != null) rowInTable[i + 1] = point.Score.ToString();
                            else rowInTable[i + 1] = "0";
                        }
                        table.Rows.Add(rowInTable);
                    }
                }
                StatTable.ItemsSource = table.DefaultView;
                AdminMainGrid.Children.Add(StatTable);
            }
        }

        private void MenuItemHelp_Click(object sender, EventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                string helpText = db.Helps.Where(h => h.Id == 1).Single().Text;
            MessageBox.Show(helpText);
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
